using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    public Text nameText;
    public Image spriteDetetivePaisagem;
    public Image spriteSecundarioPaisagem;
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

    public void FechaJanela()
    {
        if (!SemImagem)
        {
            spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
            spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
        }
        animator.SetBool("isOpen", false);
        sentences.Clear();
        nameText.text = " ";
        primeiraVez = true;
        Caderno.PermissaoAbrirCaderno = true;
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Caderno.PermissaoAbrirCaderno = false;
        if (!escrevendoDialogo)
        {
            if (primeiraVez && primeirodialogo)
            {
                sentences.Clear();
                personAtual = 1;
                animator.SetBool("isOpen", true);
                if (!SemImagem)
                {
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPaisagem;
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    nameText.text = dialogue.nameperson1;
                }
                foreach (string sentence in dialogue.sentences)
                {
                    sentences.Enqueue(sentence);
                }
                primeiraVez = false;
                DisplayNextSentence(dialogue);
            }
            else if (!primeiraVez && primeirodialogo)
            {
                DisplayNextSentence(dialogue);
            }
            else if (primeiraVez && !primeirodialogo)
            {
                sentences.Clear();
                personAtual = 1;
                animator.SetBool("isOpen", true);
                if (!SemImagem)
                {
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPaisagem;
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    nameText.text = dialogue.nameperson1;
                }
                foreach (string sentence in dialogue.senteceloop)
                {
                    sentences.Enqueue(sentence);
                }
                primeiraVez = false;
                DisplayNextSentence(dialogue);
            }
            else if (!primeiraVez && !primeirodialogo)
            {
                DisplayNextSentence(dialogue);
            }
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = sentence;
            escrevendoDialogo = false;
        }

    }

    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (ScenesManager.entrouTutorial == false)
        {
            if (sentences.Count == 0)
            {
                primeirodialogo = false;
                primeiraVez = true;
                Analise.EntrouAnalisando = !Analise.EntrouAnalisando;
                Analise.terminouConversa = true;
                Final.FinalDialiogoBool = true;
                ScenesManager.fechar();
                if (!Testemunha.isInRange)
                {
                    EndDialogue();
                }
                else
                {
                    Testemunha.terminouConversa = true;
                }
                return;
            }
            sentence = sentences.Dequeue();
            StopAllCoroutines();
            if (sentence == "troca paisagem")
            {
                if (personAtual == 1)
                {
                    nameText.text = dialogue.nameperson2;
                    spriteDetetivePaisagem.sprite = dialogue.spriteDetetivePaisagem;
                    if (!SemImagem)
                    {
                        spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 2;
                }
                else
                {
                    nameText.text = dialogue.nameperson1;
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPaisagem;
                    if (!SemImagem)
                    {
                        spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 1;
                }
                sentence = sentences.Dequeue();
            }
            if (sentence == "troca pensando")
            {
                if (personAtual == 1)
                {
                    nameText.text = dialogue.nameperson2;
                    spriteDetetivePaisagem.sprite = dialogue.spriteDetetivePensando;
                    if (!SemImagem)
                    {
                        spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 2;
                }
                else
                {
                    nameText.text = dialogue.nameperson1;
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioPensando;
                    if (!SemImagem)
                    {
                        spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 1;
                }
                sentence = sentences.Dequeue();
            }
            if (sentence == "troca embara")
            {
                if (personAtual == 1)
                {
                    nameText.text = dialogue.nameperson2;
                    spriteDetetivePaisagem.sprite = dialogue.spriteDetetiveEmbaraçado;
                    if (!SemImagem)
                    {
                        spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 2;
                }
                else
                {
                    nameText.text = dialogue.nameperson1;
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioEmbaraçado;
                    if (!SemImagem)
                    {
                        spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 1;
                }
                sentence = sentences.Dequeue();
            }
            if (sentence == "troca desgosto")
            {
                if (personAtual == 1)
                {
                    nameText.text = dialogue.nameperson2;
                    spriteDetetivePaisagem.sprite = dialogue.spriteDetetiveDesgosto;
                    if (!SemImagem)
                    {
                        spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 2;
                }
                else
                {
                    nameText.text = dialogue.nameperson1;
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioDesgosto;
                    if (!SemImagem)
                    {
                        spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 1;
                }
                sentence = sentences.Dequeue();
            }
            if (sentence == "troca caderno")
            {
                if (personAtual == 1)
                {
                    nameText.text = dialogue.nameperson2;
                    spriteDetetivePaisagem.sprite = dialogue.spriteDetetiveCaderno;
                    if (!SemImagem)
                    {
                        spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 2;
                }
                else
                {
                    nameText.text = dialogue.nameperson1;
                    spriteSecundarioPaisagem.sprite = dialogue.spriteSecundarioCaderno;
                    if (!SemImagem)
                    {
                        spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                    }
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                    personAtual = 1;
                }
                sentence = sentences.Dequeue();
            }
            if (sentence == "pensando detetive")
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetivePaisagem.sprite = dialogue.spriteDetetivePensando;
                if (!SemImagem)
                {
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;
                sentence = sentences.Dequeue();
            }
            if (sentence == "paisagem detetive")
            {
                nameText.text = dialogue.nameperson2;
                spriteDetetivePaisagem.sprite = dialogue.spriteDetetivePaisagem;
                if (!SemImagem)
                {
                    spriteDetetivePaisagem.color = new Color(255f, 255f, 255f, 1.0f);
                }
                spriteSecundarioPaisagem.color = new Color(255f, 255f, 255f, 0.0f);
                personAtual = 2;

                sentence = sentences.Dequeue();
            }
            if (sentence == "finalizar")
            {
                primeirodialogo = false;
                primeiraVez = true;
                Analise.EntrouAnalisando = !Analise.EntrouAnalisando;
                Analise.terminouConversa = true;
                ScenesManager.fechar();
                if (!Testemunha.isInRange)
                {
                    EndDialogue();
                }
                else
                {
                    Testemunha.terminouConversa = true;
                }
                return;
            }
            if (sentence == "evidencia")
            {
                spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                spriteDetetivePaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                sentence = sentences.Dequeue();
            }
            StartCoroutine(typeSentence(sentence));
        }
    }

    IEnumerator typeSentence(string sentence)
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
        sentences.Clear();
        if (!SemImagem)
        {
            spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteDetetivePaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            spriteSecundarioPaisagem.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        nameText.text = " ";
        animator.SetBool("isOpen", false);
        Caderno.PermissaoAbrirCaderno = true;
    }
}
