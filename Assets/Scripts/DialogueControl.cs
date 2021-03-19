using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    public Text nameText;
    public Image spriteDetetivePaisagem;
    public Image spriteDetetivePensando;
    public Image spriteDetetiveEmbaraçado;
    public Image spriteDetetiveDesgosto;
    public Image spriteDetetiveCaderno;
    public Image spriteSecundarioPaisagem;
    public Image spriteSecundarioPensando;
    public Image spriteSecundarioEmbaraçado;
    public Image spriteSecundarioDesgosto;
    public Image spriteSecundarioCaderno;   
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
        spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
        spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
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
                spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPaisagem;
                if(!SemImagem){
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
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
                spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPaisagem;
                if(!SemImagem){
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
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
        if (sentence == "trocaPaisagem")
        {
            if (personAtual == 1)
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetivePaisagem.sprite = dialogue.spriteDetetivePaisagem;
                if(!SemImagem){
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
            }
            else
            {
                nameText.text = dialogue.nameperson1;
                spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPaisagem;
                if(!SemImagem){
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 1;
            }
            sentence = sentences.Dequeue();
        }
        if (sentence == "trocaPensando")
        {
            if (personAtual == 1)
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetivePensando.sprite = dialogue.spriteDetetivePensando;
                if(!SemImagem){
                    spriteDetetivePensando.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetivePensando.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
            }
            else
            {
                nameText.text = dialogue.nameperson1;
                spriteSecundarioPensando.sprite = dialogue.spriteSecundarioPensando;
                if(!SemImagem){
                    spriteSecundarioPensando.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioPensando.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 1;
            }
            sentence = sentences.Dequeue();
        }
        if (sentence == "trocaEmbaracado")
        {
            if (personAtual == 1)
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetiveEmbaraçado.sprite = dialogue.spriteDetetiveEmbaraçado;
                if(!SemImagem){
                    spriteDetetiveEmbaraçado.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetiveEmbaraçado.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
            }
            else
            {
                nameText.text = dialogue.nameperson1;
                spriteSecundarioEmbaraçado.sprite = dialogue.spriteSecundarioEmbaraçado;
                if(!SemImagem){
                    spriteSecundarioEmbaraçado.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioEmbaraçado.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 1;
            }
            sentence = sentences.Dequeue();
        }
        if (sentence == "trocaDesgosto")
        {
            if (personAtual == 1)
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetiveDesgosto.sprite = dialogue.spriteDetetiveDesgosto;
                if(!SemImagem){
                    spriteDetetiveDesgosto.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetiveDesgosto.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
            }
            else
            {
                nameText.text = dialogue.nameperson1;
                spriteSecundarioDesgosto.sprite = dialogue.spriteSecundarioDesgosto;
                if(!SemImagem){
                    spriteSecundarioDesgosto.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioDesgosto.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 1;
            }
            sentence = sentences.Dequeue();
        }
        if (sentence == "trocaCaderno")
        {
            if (personAtual == 1)
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetiveCaderno.sprite = dialogue.spriteDetetiveCaderno;
                if(!SemImagem){
                    spriteDetetiveCaderno.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteDetetiveCaderno.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
            }
            else
            {
                nameText.text = dialogue.nameperson1;
                spriteSecundarioCaderno.sprite = dialogue.spriteSecundarioCaderno;
                if(!SemImagem){
                    spriteSecundarioCaderno.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioCaderno.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 1;
            }
            sentence = sentences.Dequeue();
        }
        if (sentence == "evidencia"){
            spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetivePaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetivePaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetivePensando.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetiveEmbaraçado.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetiveDesgosto.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetiveCaderno.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteSecundarioPensando.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteSecundarioEmbaraçado.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteSecundarioDesgosto.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteSecundarioCaderno.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
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
        spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteDetetivePaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteDetetivePaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteDetetivePensando.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteDetetiveEmbaraçado.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteDetetiveDesgosto.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteDetetiveCaderno.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteSecundarioPensando.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteSecundarioEmbaraçado.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteSecundarioDesgosto.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        spriteSecundarioCaderno.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        animator.SetBool("isOpen", false);
        Caderno.PermissaoAbrirCaderno = true;
    }
}
