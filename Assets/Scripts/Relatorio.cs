using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Relatorio : MonoBehaviour
{
    public Caderno cadernoOriginal;
    public GameObject Roubo;
    public GameObject CadernoLimpo;
    public GameObject Evidencias;
    public GameObject Desavença;
    public GameObject Raiva;
    public GameObject Suicidio;
    public GameObject Prazer;
    public GameObject Justica;
    public GameObject preencher;
    public GameObject trocarCenaSim;
    public GameObject SemEvidencia;
    public GameObject Finalizar;
    public GameObject no;
    private Queue<string> sentence;
    public Text texto;
    public bool isInRange;
    public Animator PixelArt;
    public Animator Transition;
    public Animator caderno;
    public movimento movimento;
    private string fraseAtual;
    public static bool entrouPreencher = false;
    public static bool escrevendo = false;
    public string respostaTexto;
    public int numeroDaPergunta;
    public static int Pontuacao;
    public static int AcertouArma;
    public static int AcertouMotivo;
    public static int AcertouEntrada;
    public static int AcertouSaida;
    public static int AcertouLocal;
    public static bool jogoFinalizado;
    public static bool perguntando = false;
    // Start is called before the first frame update
    void Start()
    {
        jogoFinalizado = false;
        numeroDaPergunta = 1;
        Pontuacao = 0;
        entrouPreencher = false;
        escrevendo = false;
        sentence = new Queue<string>();
        Finalizar.SetActive(false);
        AcertouArma = 0;
        AcertouMotivo = 0;
        AcertouEntrada = 0;
        AcertouSaida = 0;
        AcertouLocal = 0;
    }

    public void FinalizaGame()
    {
        PixelArt.SetBool("On", false);
        sentence.Enqueue("Respostas corretas:" + Pontuacao.ToString());
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
        MainMenu.NewGame = true;
        SaveSystem.SavePlayer(movimento);
        jogoFinalizado = true;
        PauseMenu.NumeroDeCasosJogadoPeloPlayer++;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (jogoFinalizado == true)
        {
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                if (ScenesManager.ActualScene == 3)
                {
                    SceneManager.LoadScene(2);
                }
                else if (ScenesManager.ActualScene == 2)
                {
                    SceneManager.LoadScene(3);
                }
            }*/
        }
        if (isInRange && jogoFinalizado == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == false)
            {
                if (PlayerData.Idioma == "ingles")
                {
                    sentence.Enqueue("I need to understand what happened in this case.");
                    sentence.Enqueue("First I need to reformulate the crime scene.");
                    sentence.Enqueue("How did the murderer enter the place?");
                    sentence.Enqueue("It makes sense for them to enter like this.");
                    sentence.Enqueue("But after entering, something happened inside there.");
                    sentence.Enqueue("Where did the murder take place?");
                    sentence.Enqueue("Knowing the victim died there.");
                    sentence.Enqueue("I still need to find out more.");
                    sentence.Enqueue("What weapon did they use?");
                    sentence.Enqueue("After commiting the murder.");
                    sentence.Enqueue("They must have had a escape plan.");
                    sentence.Enqueue("How did the murderer leave the place?");
                    sentence.Enqueue("It's all coming together.");
                    sentence.Enqueue("Having figured out how they entered.");
                    sentence.Enqueue("Where the murder happened, the weapon used and how they left.");
                    sentence.Enqueue("It's time to figure out the motive.");
                    sentence.Enqueue("What is the reason of the murder?");
                    sentence.Enqueue("Should I turn in the Report like this?");
                    texto.text = "Write the Report?";
                }
                else
                {
                    sentence.Enqueue("Preciso entender o que aconteceu nesse caso.");
                    sentence.Enqueue("Primeiro preciso reformular a cena do crime.");
                    sentence.Enqueue("De que forma o assassino entrou no local?");
                    sentence.Enqueue("Faz sentido ele entrar dessa forma.");
                    sentence.Enqueue("Mas após ele entrar, algo aconteceu lá dentro.");
                    sentence.Enqueue("Em que local será que ocorreu o assassinato?");
                    sentence.Enqueue("Sabendo que ele morreu ali.");
                    sentence.Enqueue("Ainda é necessário saber outra coisa.");
                    sentence.Enqueue("Qual arma ele utilizou no crime?");
                    sentence.Enqueue("Após ter cometido o assassinato.");
                    sentence.Enqueue("Ele deve ter tido algum plano para fugir.");
                    sentence.Enqueue("De que forma o assassino saiu do local?");
                    sentence.Enqueue("Tudo está começando a se encaixar.");
                    sentence.Enqueue("Tendo agora pensado em como ele entrou.");
                    sentence.Enqueue("Onde ele assassinou, a arma utilizada e como ele saiu.");
                    sentence.Enqueue("É preciso saber o motivo por trás.");
                    sentence.Enqueue("Qual a razão do assassinato?");
                    sentence.Enqueue("Devo entregar o relatório assim?");
                    texto.text = "Escrever o relatório?";
                }
                preencher.SetActive(true);
                trocarCenaSim.SetActive(false);
                no.SetActive(true);
                Transition.SetBool("Abrir", true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == true && escrevendo == true && perguntando == false)
            {
                StopAllCoroutines();
                texto.text = fraseAtual;
                escrevendo = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == true && escrevendo == false && perguntando == false)
            {
                fraseAtual = sentence.Dequeue();
                StartCoroutine(typeSentence(fraseAtual));
                if (fraseAtual == "De que forma o assassino entrou no local?" ||
                fraseAtual == "De que forma o assassino saiu do local?" ||
                fraseAtual == "Em que local será que ocorreu o assassinato?" ||
                fraseAtual == "Qual arma ele utilizou no crime?" ||

                fraseAtual == "How did the murderer enter the place?" ||
                fraseAtual == "Where did the murder take place?" ||
                fraseAtual == "What weapon did they use?" ||
                fraseAtual == "How did the murderer leave the place?")
                {
                    CadernoLimpo.SetActive(false);
                    Evidencias.SetActive(true);
                    cadernoOriginal.EscreverEvidencias();
                    caderno.SetBool("Rela", true);
                    SemEvidencia.SetActive(true);
                    perguntando = true;
                }
                else if (fraseAtual == "Qual a razão do assassinato?" ||
                fraseAtual == "What is the reason of the murder?")
                {
                    CadernoLimpo.SetActive(true);
                    Evidencias.SetActive(false);
                    caderno.SetBool("Rela", false);
                    perguntando = true;
                    Ativa6Botoes();
                }
            }
        }
        else
        {
            trocarCenaSim.SetActive(true);
            preencher.SetActive(false);
            no.SetActive(true);
        }
    }
    public void Ativa6Botoes()
    {
        Raiva.SetActive(true);
        Suicidio.SetActive(true);
        Prazer.SetActive(true);
        Desavença.SetActive(true);
        Justica.SetActive(true);
        Roubo.SetActive(true);
    }
    public void Desativa6Botoes()
    {
        Raiva.SetActive(false);
        Suicidio.SetActive(false);
        Prazer.SetActive(false);
        Desavença.SetActive(false);
        Justica.SetActive(false);
        Roubo.SetActive(false);
    }
    public void RaivaResposta()
    {
        respostaTexto = "Raiva";
        Confirma();
    }
    public void SuicidioResposta()
    {
        respostaTexto = "Suicidio";
        Confirma();
    }
    public void PrazerResposta()
    {
        respostaTexto = "Prazer";
        Confirma();
    }
    public void DesavençaResposta()
    {
        respostaTexto = "Desavenca";
        Confirma();
    }
    public void JusticaResposta()
    {
        respostaTexto = "Justica";
        Confirma();
    }
    public void RouboResposta()
    {
        respostaTexto = "Roubo";
        Confirma();
    }
    public void Resposta(Text resposta)
    {
        if (isInRange)
        {
            respostaTexto = resposta.text;
            trocarCenaSim.SetActive(true);
            SemEvidencia.SetActive(true);
            if (PlayerData.Idioma == "ingles")
            {
                texto.text = "Could this be it?";
            }
            else
            {
                texto.text = "Sera que é isso?";
            }
        }
    }
    public void NoEvidencias()
    {
        if (numeroDaPergunta == 5)
        {
            CadernoLimpo.SetActive(true);
            Evidencias.SetActive(false);
            caderno.SetBool("Rela", false);
            Desativa6Botoes();
            no.SetActive(true);
            Finalizar.SetActive(true);
        }
        numeroDaPergunta++;
        trocarCenaSim.SetActive(false);
        SemEvidencia.SetActive(false);
        CadernoLimpo.SetActive(true);
        Evidencias.SetActive(false);
        caderno.SetBool("Rela", false);
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void Confirma()
    {
        if (isInRange)
        {
            switch (numeroDaPergunta)
            {
                case 1:
                    if (respostaTexto == SpawnObjects.PrimeiraResposta)
                    {
                        Pontuacao++;
                        AcertouEntrada = 1;
                    }
                    else if (respostaTexto == SpawnObjects.PrimeiraRespostaIngles)
                    {
                        Pontuacao++;
                        AcertouEntrada = 1;
                    }
                    break;
                case 2:
                    if (respostaTexto == SpawnObjects.SegundaResposta)
                    {
                        Pontuacao++;
                        AcertouLocal = 1;
                    }
                    else if (respostaTexto == SpawnObjects.SegundaRespostaIngles)
                    {
                        Pontuacao++;
                        AcertouLocal = 1;
                    }
                    break;
                case 3:
                    if (respostaTexto == SpawnObjects.TerceiraResposta)
                    {
                        Pontuacao++;
                        AcertouArma = 1;
                    }
                    else if (respostaTexto == SpawnObjects.TerceiraRespostaIngles)
                    {
                        Pontuacao++;
                        AcertouArma = 1;
                    }
                    break;
                case 4:
                    if (respostaTexto == SpawnObjects.QuartaResposta)
                    {
                        Pontuacao++;
                        AcertouSaida = 1;
                    }
                    else if (respostaTexto == SpawnObjects.QuartaRespostaIngles)
                    {
                        Pontuacao++;
                        AcertouSaida = 1;
                    }
                    break;
                case 5:
                    if (respostaTexto == SpawnObjects.QuintaResposta)
                    {
                        Pontuacao++;
                        AcertouMotivo = 1;
                    }
                    CadernoLimpo.SetActive(true);
                    Evidencias.SetActive(false);
                    caderno.SetBool("Rela", false);
                    Desativa6Botoes();
                    no.SetActive(true);
                    Finalizar.SetActive(true);
                    break;
            }
            CadernoLimpo.SetActive(true);
            Evidencias.SetActive(false);
            caderno.SetBool("Rela", false);
            trocarCenaSim.SetActive(false);
            SemEvidencia.SetActive(false);
            numeroDaPergunta++;
            perguntando = false;
            fraseAtual = sentence.Dequeue();
            StartCoroutine(typeSentence(fraseAtual));
        }
    }
    public void PreencherORelatorio()
    {
        movimento.ParaPersonagem = true;
        Caderno.PermissaoAbrirCaderno = false;
        entrouPreencher = true;
        PixelArt.SetBool("On", true);
        preencher.SetActive(false);
        no.SetActive(false);
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void No()
    {
        isInRange = false;
        Transition.SetBool("Abrir", false);
        CadernoLimpo.SetActive(true);
        Evidencias.SetActive(false);
        caderno.SetBool("Rela", false);
        entrouPreencher = false;
        sentence.Clear();
        PixelArt.SetBool("On", false);
        movimento.ParaPersonagem = false;
        Caderno.PermissaoAbrirCaderno = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerData.Idioma == "ingles")
            {
                texto.text = "Do you wish to return to the crime scene?";
            }
            else
            {
                texto.text = "Deseja voltar a cena do crime?";
            }
            Transition.SetBool("Abrir", false);
            CadernoLimpo.SetActive(true);
            Evidencias.SetActive(false);
            caderno.SetBool("Rela", false);
            SemEvidencia.SetActive(false);
            Finalizar.SetActive(false);
            trocarCenaSim.SetActive(true);
            no.SetActive(true);
            Desativa6Botoes();
            isInRange = false;
            Pontuacao = 0;
            perguntando = false;
            numeroDaPergunta = 1;
            entrouPreencher = false;
            sentence.Clear();
        }
    }

    IEnumerator typeSentence(string sentence)
    {
        texto.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            escrevendo = true;
            texto.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        escrevendo = false;
    }
}
