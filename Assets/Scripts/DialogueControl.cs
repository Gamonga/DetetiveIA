using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    public Text nameText;
    public Image sprite1;
    public Image sprite2;    
    public Text dialogueText;
    private bool primeiraVez = true;
    private bool primeirodialogo = true;
    public Animator animator;
    private Queue<string> sentences;
    private int personAtual = 1;
    private string sentence;
    private bool escrevendoDialogo = false;
    public bool SemImagem;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        sentences.Clear();
        primeiraVez = true;
    }
    
    public void FechaJanela(){
        sprite1.color = new Color(255f, 255f, 255f, 0.0f);
        sprite2.color = new Color(255f, 255f, 255f, 0.0f);
        animator.SetBool("isOpen",false);
        sentences.Clear();
        nameText.text = " ";
        primeiraVez = true;
        Caderno.PermissaoAbrirCaderno = true;
    }
    public void StartDialogue( Dialogue dialogue)
    {      
        Caderno.PermissaoAbrirCaderno = false;
        if(!escrevendoDialogo){
            if(primeiraVez && primeirodialogo)
            {                
                personAtual = 1;
                animator.SetBool("isOpen",true);
                sprite1.sprite = dialogue.sprite1;
                if(!SemImagem){
                    sprite1.color = new Color(255f, 255f, 255f, 1.0f);
                }
                sprite2.color = new Color(255f, 255f, 255f, 0.0f);
                nameText.text = dialogue.nameperson1;
                foreach (string sentence in dialogue.sentences)
                {                
                    sentences.Enqueue(sentence);                
                }
                primeiraVez = false;
                DisplayNextSentence(dialogue);
            }
            else if(!primeiraVez && primeirodialogo)
            {
                DisplayNextSentence(dialogue);
            }  
            else if(primeiraVez && !primeirodialogo)
            {
                personAtual = 1;
                animator.SetBool("isOpen",true);
                sprite1.sprite = dialogue.sprite1;
                if(!SemImagem){
                    sprite1.color = new Color(255f, 255f, 255f, 1.0f);
                }
                sprite2.color = new Color(255f, 255f, 255f, 0.0f);
                nameText.text = dialogue.nameperson1;
                foreach (string sentence in dialogue.senteceloop)
                {                
                    sentences.Enqueue(sentence);                
                }
                primeiraVez = false;
                DisplayNextSentence(dialogue);
            }       
            else if(!primeiraVez && !primeirodialogo)
            {
                DisplayNextSentence(dialogue);
            }
        }
        else{
            StopAllCoroutines();
            dialogueText.text = sentence;
            escrevendoDialogo = false;
        }

    }    

    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count == 0)
        {                        
            primeirodialogo = false;
            primeiraVez = true;
            Analise.EntrouAnalisando = !Analise.EntrouAnalisando;
            Analise.terminouConversa = true;
            EndDialogue();
            return;
        }
        sentence = sentences.Dequeue();
        StopAllCoroutines();
        if (sentence == "troca")
        {
            if (personAtual == 1)
            {
                nameText.text = dialogue.nameperson2;
                sprite2.sprite = dialogue.sprite2;
                if(!SemImagem){
                    sprite2.color = new Color(255f, 255f, 255f, 1.0f);
                }
                sprite1.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
            }
            else
            {
                nameText.text = dialogue.nameperson1;
                sprite1.sprite = dialogue.sprite1;
                if(!SemImagem){
                    sprite1.color = new Color(255f, 255f, 255f, 1.0f);
                }
                sprite2.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 1;
            }
            sentence = sentences.Dequeue();
        }
        if (sentence == "evidencia"){
            sprite1.color = new Color(255f, 255f, 255f, 0.0f);
            sprite2.color = new Color(255f, 255f, 255f, 0.0f);
            sentence = sentences.Dequeue();
        }
        StartCoroutine(typeSentence(sentence));
    }

    IEnumerator typeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            escrevendoDialogo = true;
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        escrevendoDialogo = false;
    }

    void EndDialogue()
    {
        nameText.text = " ";
        sprite1.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        sprite2.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        animator.SetBool("isOpen", false);
        Caderno.PermissaoAbrirCaderno = true;
    }
}
