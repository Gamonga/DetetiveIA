using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Testemunha : MonoBehaviour
{
    public GameObject CadernoLimpo;
    public GameObject Evidencias;
    public GameObject ConcordaB;
    public GameObject DiscordaB;
    public GameObject DuvidaB;
    public GameObject VistoB;
    public GameObject OuviuB;
    public GameObject SimEcolheu;
    public Caderno cadernoObjeto;
    public string NomeDaTestemunha;
    private static string evidenciaUsada;
    private string NomeEvidenciaDiscordaOuviu;
    private string NomeEvidenciaDiscordaViu;
    private string NomeEvidenciaDiscordaRelacao;
    public GameObject RelaçãoComVitimaB;
    private Queue<string> sentence;
    public Text texto;
    public Text Nome;
    private bool isInRange;
    public static bool relacaoPergunta;
    public static bool ouviuPergunta;
    public static bool vistoPergunta;
    private string VistoVerdade;
    private string OuviuVerdade;
    private string RelaçãoVerdade;
    private static string PerguntaFeita;
    public Animator dialogo;
    public Animator caderno;
    public movimento movimento;
    private string fraseAtual;
    private static bool entrouPreencher;
    private static bool escrevendo;
    private string respostaTexto;
    private static bool perguntando;
    private static bool FinalizouTestemunha;
    private static bool TerminouPerguntas;
    private int i;
    private int NumeroInfoTestemunha;
    private string OuviuTestemunha;
    private string VistoTestemunha;
    private string RelacaoTestemunha;
    public static bool depoimentoTestemunhaVisto;
    public static bool depoimentoTestemunhaOuviu;
    // Start is called before the first frame update
    void Start()
    {
        OuviuTestemunha = "";
        VistoTestemunha = "";
        RelacaoTestemunha = "";
        NumeroInfoTestemunha = 0;
        TerminouPerguntas = false;
        FinalizouTestemunha = false;
        entrouPreencher = false;
        escrevendo = false;
        sentence = new Queue<string>();
        relacaoPergunta = true;
        ouviuPergunta = true;
        perguntando = false;
        vistoPergunta = true;
        if (MainMenu.NewGame == false)
        {
            PlayerData data = SaveSystem.LoadPlayer();
            relacaoPergunta = data.relacaoPergunta;
            ouviuPergunta = data.ouviuPergunta;
            vistoPergunta = data.vistoPergunta;
            depoimentoTestemunhaVisto = data.depoimentoTestemunhaVisto;
            depoimentoTestemunhaOuviu = data.depoimentoTestemunhaOuviu;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == false && FinalizouTestemunha == false)
            {
                texto.text = "";
                if (!vistoPergunta && !ouviuPergunta && !relacaoPergunta)
                {
                    Nome.text = NomeDaTestemunha;
                    dialogo.SetBool("isOpen", true);
                    if (PlayerData.Idioma == "ingles")
                    {
                        fraseAtual = "I hope that I have helped you, detective.";
                    }
                    else
                    {
                        fraseAtual = "Espero que eu tenha ajudado, detetive.";
                    }
                    StartCoroutine(typeSentence(fraseAtual));
                    FinalizouTestemunha = true;
                    TerminouPerguntas = true;
                }
                else
                {
                    Caderno.PermissaoAbrirCaderno = false;
                    DecideVerdades();
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("Pleased to meet you, I'm " + NomeDaTestemunha);
                        sentence.Enqueue("What do you want to know, detective?");
                    }
                    else
                    {
                        sentence.Enqueue("Prazer, me chamo " + NomeDaTestemunha);
                        sentence.Enqueue("O que deseja saber, detetive?");
                    }
                    dialogo.SetBool("isOpen", true);
                    entrouPreencher = true;
                    fraseAtual = sentence.Dequeue();
                    StartCoroutine(typeSentence(fraseAtual));
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == true && escrevendo == false && perguntando == false && FinalizouTestemunha == false)
            {
                fraseAtual = sentence.Dequeue();
                if (fraseAtual != "Pergunta" && fraseAtual != "Terminou")
                {
                    StartCoroutine(typeSentence(fraseAtual));
                }
                else if (fraseAtual == "Pergunta")
                {
                    ConcordaB.SetActive(true);
                    DiscordaB.SetActive(true);
                    DuvidaB.SetActive(true);
                    perguntando = true;
                }
                else if (fraseAtual == "Terminou")
                {
                    if (!vistoPergunta && !ouviuPergunta && !relacaoPergunta)
                    {
                        if (PlayerData.Idioma == "ingles")
                        {
                            fraseAtual = "I hope that I have helped you, detective.";
                        }
                        else
                        {
                            fraseAtual = "Espero que eu tenha ajudado, detetive";
                        }
                        FinalizouTestemunha = true;
                        TerminouPerguntas = true;
                    }
                    else
                    {
                        if (PlayerData.Idioma == "ingles")
                        {
                            fraseAtual = "What do you want to know, detective?";
                        }
                        else
                        {
                            fraseAtual = "O que deseja saber, detetive?";
                        }
                        perguntando = true;
                    }
                    StartCoroutine(typeSentence(fraseAtual));
                    if (vistoPergunta)
                    {
                        VistoB.SetActive(true);
                    }
                    if (ouviuPergunta)
                    {
                        OuviuB.SetActive(true);
                    }
                    if (relacaoPergunta)
                    {
                        RelaçãoComVitimaB.SetActive(true);
                    }
                }
                if (fraseAtual == "O que deseja saber, detetive?" || fraseAtual == "What do you want to know, detective?")
                {
                    if (vistoPergunta)
                    {
                        VistoB.SetActive(true);
                    }
                    if (ouviuPergunta)
                    {
                        OuviuB.SetActive(true);
                    }
                    if (relacaoPergunta)
                    {
                        RelaçãoComVitimaB.SetActive(true);
                    }
                    perguntando = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == true && escrevendo == true && perguntando == false && FinalizouTestemunha == false)
            {
                StopAllCoroutines();
                texto.text = fraseAtual;
                escrevendo = false;
            }
            else if (Input.GetKeyDown(KeyCode.E) && FinalizouTestemunha == true)
            {
                if (TerminouPerguntas == true)
                {
                    SimEcolheu.SetActive(false);
                    sentence.Clear();
                    Nome.text = "";
                    dialogo.SetBool("isOpen", false);
                    Caderno.PermissaoAbrirCaderno = true;
                    caderno.SetBool("Rela", false);
                    ConcordaB.SetActive(false);
                    DiscordaB.SetActive(false);
                    DuvidaB.SetActive(false);
                    VistoB.SetActive(false);
                    OuviuB.SetActive(false);
                    RelaçãoComVitimaB.SetActive(false);
                    isInRange = false;
                    perguntando = false;
                    entrouPreencher = false;
                    FinalizouTestemunha = false;
                }
            }
        }
        else
        {
        }
    }
    public void DecideVerdades()
    {
        Nome.text = NomeDaTestemunha;
        VistoVerdade = SpawnObjects.VistoVerdade;
        OuviuVerdade = SpawnObjects.OuviuVerdade;
        depoimentoTestemunhaVisto = SpawnObjects.depoimentoTestemunhaVisto;
        depoimentoTestemunhaOuviu = SpawnObjects.depoimentoTestemunhaOuviu;
        RelaçãoVerdade = "true";
    }
    public void Concorda()
    {
        sentence.Clear();
        switch (PerguntaFeita)
        {
            case "visto":
                if (VistoVerdade == "true")
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        if (depoimentoTestemunhaVisto)
                        {
                            sentence.Enqueue("I remember it very well, he came right there.");
                            VistoTestemunha = "I saw a man going inside through the door in the dark. I remember it very well, he came right there.";
                        }
                        else
                        {
                            sentence.Enqueue("I remember it very well, he left right there.");
                            VistoTestemunha = "I saw a man leaving through the door in the dark. I remember it very well, he left right there.";
                        }
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                    }
                    else
                    {
                        if (depoimentoTestemunhaVisto)
                        {
                            sentence.Enqueue("Eu me lembro bem, ele entrou por lá mesmo.");
                            VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro. Eu me lembro bem, ele entrou por lá mesmo.";
                        }
                        else
                        {
                            sentence.Enqueue("Eu me lembro bem, ele saiu por lá mesmo.");
                            VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro. Eu me lembro bem, ele saiu por lá mesmo.";
                        }
                        Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                    }

                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("That's all I know, detective.");
                    }
                    else
                    {
                        sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                    }
                }
                sentence.Enqueue("Terminou");
                vistoPergunta = false;
                break;
            case "ouviu":
                if (OuviuVerdade == "true")
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("I heard a gunshot actually");
                        OuviuTestemunha = "I heard a gunshot actually";
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                    }
                    else
                    {
                        sentence.Enqueue("Ouvi um disparo de arma para falar a verdade.");
                        OuviuTestemunha = "Ouvi um disparo de arma para falar a verdade.";
                        Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("That's all I know, detective.");
                    }
                    else
                    {
                        sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                    }
                }
                sentence.Enqueue("Terminou");
                ouviuPergunta = false;
                break;
            case "relacao":
                if (RelaçãoVerdade == "true")
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("I only know that he used to like to be alone.");
                        RelacaoTestemunha = "I only know that he used to like to be alone.";
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                    }
                    else
                    {
                        sentence.Enqueue("Só sei que ele gostava de ficar sozinho.");
                        RelacaoTestemunha = "Só sei que ele gostava de ficar sozinho.";
                        Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("That's all I know, detective.");
                    }
                    else
                    {
                        sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                    }
                }
                sentence.Enqueue("Terminou");
                relacaoPergunta = false;
                break;
        }
        ConcordaB.SetActive(false);
        DiscordaB.SetActive(false);
        DuvidaB.SetActive(false);
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void escolheuEvidenciaSim()
    {
        sentence.Clear();
        if (isInRange)
        {
            switch (PerguntaFeita)
            {
                case "visto":
                    if (VistoVerdade == "false")
                    {
                        if (evidenciaUsada == NomeEvidenciaDiscordaViu)
                        {
                            if (PlayerData.Idioma == "ingles")
                            {
                                if (depoimentoTestemunhaVisto)
                                {
                                    sentence.Enqueue("I remember it very well, he came right there.");
                                    VistoTestemunha = "I saw a man going inside through the door in the dark. I remember it very well, he came right there.";
                                }
                                else
                                {
                                    sentence.Enqueue("I remember it very well, he left right there.");
                                    VistoTestemunha = "I saw a man leaving through the door in the dark. I remember it very well, he left right there.";
                                }
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                                "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                                "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                            }
                            else
                            {
                                if (depoimentoTestemunhaVisto)
                                {
                                    sentence.Enqueue("Eu me lembro bem, ele entrou por lá mesmo.");
                                    VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro. Eu me lembro bem, ele entrou por lá mesmo.";
                                }
                                else
                                {
                                    sentence.Enqueue("Eu me lembro bem, ele saiu por lá mesmo.");
                                    VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro. Eu me lembro bem, ele saiu por lá mesmo.";
                                }
                                Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                                "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                                "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                            }
                        }
                        else
                        {
                            if (PlayerData.Idioma == "ingles")
                            {
                                sentence.Enqueue("Making false accusations is something serious, detective.");
                            }
                            else
                            {
                                sentence.Enqueue("Fazer acusações falsas é algo grave, detetive.");
                            }
                        }
                    }
                    else
                    {
                        if (PlayerData.Idioma == "ingles")
                        {
                            sentence.Enqueue("That's all I know, detective.");
                        }
                        else
                        {
                            sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                        }
                    }
                    sentence.Enqueue("Terminou");
                    vistoPergunta = false;
                    break;
                case "ouviu":
                    if (OuviuVerdade == "false")
                    {
                        if (evidenciaUsada == NomeEvidenciaDiscordaOuviu)
                        {
                            if (PlayerData.Idioma == "ingles")
                            {
                                sentence.Enqueue("I heard a gunshot actually");
                                OuviuTestemunha = "I heard a gunshot actually";
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                                "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                                "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                            }
                            else
                            {
                                sentence.Enqueue("Ouvi um disparo de arma para falar a verdade.");
                                OuviuTestemunha = "Ouvi um disparo de arma para falar a verdade.";
                                Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                                "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                                "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                            }
                        }
                        else
                        {
                            if (PlayerData.Idioma == "ingles")
                            {
                                sentence.Enqueue("Making false accusations is something serious, detective.");
                            }
                            else
                            {
                                sentence.Enqueue("Fazer acusações falsas é algo grave, detetive.");
                            }
                        }
                    }
                    else
                    {
                        if (PlayerData.Idioma == "ingles")
                        {
                            sentence.Enqueue("That's all I know, detective.");
                        }
                        else
                        {
                            sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                        }
                    }
                    sentence.Enqueue("Terminou");
                    ouviuPergunta = false;
                    break;
                case "relacao":
                    if (RelaçãoVerdade == "false")
                    {
                        if (evidenciaUsada == NomeEvidenciaDiscordaRelacao)
                        {
                            if (PlayerData.Idioma == "ingles")
                            {
                                sentence.Enqueue("I only know that he used to like to be alone.");
                                RelacaoTestemunha = "I only know that he used to like to be alone.";
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                                "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                                "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                            }
                            else
                            {
                                sentence.Enqueue("Só sei que ele gostava de ficar sozinho.");
                                RelacaoTestemunha = "Só sei que ele gostava de ficar sozinho.";
                                Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                                "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                                "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                                Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                            }
                        }
                        else
                        {
                            if (PlayerData.Idioma == "ingles")
                            {
                                sentence.Enqueue("Making false accusations is something serious, detective.");
                            }
                            else
                            {
                                sentence.Enqueue("Fazer acusações falsas é algo grave, detetive.");
                            }
                        }
                    }
                    else
                    {
                        if (PlayerData.Idioma == "ingles")
                        {
                            sentence.Enqueue("That's all I know, detective.");
                        }
                        else
                        {
                            sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                        }
                    }
                    sentence.Enqueue("Terminou");
                    relacaoPergunta = false;
                    break;
            }
            SimEcolheu.SetActive(false);
            caderno.SetBool("Rela", false);
            dialogo.SetBool("isOpen", true);
            perguntando = false;
            fraseAtual = sentence.Dequeue();
            StartCoroutine(typeSentence(fraseAtual));
        }
    }
    public void escolheuEvidencia(Text evidencia)
    {
        sentence.Clear();
        if (isInRange)
        {
            if (PlayerData.Idioma == "ingles")
            {
                texto.text = "Does this evidence contradict what has been said?";
            }
            else
            {
                texto.text = "Essa evidência contraria o que foi dito?";
            }
            evidenciaUsada = evidencia.text;
            SimEcolheu.SetActive(true);
        }
    }
    public void Discorda()
    {
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Enqueue("Do you have any proof that goes against what I said?");
        }
        else
        {
            sentence.Enqueue("Você teria alguma prova para discordar do que eu disse?");
        }
        CadernoLimpo.SetActive(false);
        Evidencias.SetActive(true);
        caderno.SetBool("Rela", true);
        ConcordaB.SetActive(false);
        DiscordaB.SetActive(false);
        DuvidaB.SetActive(false);
        cadernoObjeto.EscreverEvidencias();
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void Duvida()
    {
        sentence.Clear();
        switch (PerguntaFeita)
        {
            case "visto":
                if (VistoVerdade == "duvida")
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        if (depoimentoTestemunhaVisto)
                        {
                            sentence.Enqueue("I remember it very well, he came right there.");
                            VistoTestemunha = "I saw a man going inside through the door in the dark. I remember it very well, he came right there.";
                        }
                        else
                        {
                            sentence.Enqueue("I remember it very well, he left right there.");
                            VistoTestemunha = "I saw a man leaving through the door in the dark. I remember it very well, he left right there.";
                        }
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                    }
                    else
                    {
                        if (depoimentoTestemunhaVisto)
                        {
                            sentence.Enqueue("Eu me lembro bem, ele entrou por lá mesmo.");
                            VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro. Eu me lembro bem, ele entrou por lá mesmo.";
                        }
                        else
                        {
                            sentence.Enqueue("Eu me lembro bem, ele saiu por lá mesmo.");
                            VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro. Eu me lembro bem, ele saiu por lá mesmo.";
                        }
                        Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("That's all I know, detective.");
                    }
                    else
                    {
                        sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                    }
                }
                sentence.Enqueue("Terminou");
                vistoPergunta = false;
                break;
            case "ouviu":
                if (OuviuVerdade == "duvida")
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("I heard a gunshot actually");
                        OuviuTestemunha = "I heard a gunshot actually";
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                    }
                    else
                    {
                        sentence.Enqueue("Ouvi um disparo de arma para falar a verdade.");
                        OuviuTestemunha = "Ouvi um disparo de arma para falar a verdade.";
                        Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("That's all I know, detective.");
                    }
                    else
                    {
                        sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                    }
                }
                sentence.Enqueue("Terminou");
                ouviuPergunta = false;
                break;
            case "relacao":
                if (RelaçãoVerdade == "duvida")
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("I only know that he used to like to be alone.");
                        RelacaoTestemunha = "I only know that he used to like to be alone.";
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
                    }
                    else
                    {
                        sentence.Enqueue("Só sei que ele gostava de ficar sozinho.");
                        RelacaoTestemunha = "Só sei que ele gostava de ficar sozinho.";
                        Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
                        "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
                        "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
                        Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        sentence.Enqueue("That's all I know, detective.");
                    }
                    else
                    {
                        sentence.Enqueue("Isso é tudo que eu sei, detetive.");
                    }
                }
                sentence.Enqueue("Terminou");
                relacaoPergunta = false;
                break;
        }
        ConcordaB.SetActive(false);
        DiscordaB.SetActive(false);
        DuvidaB.SetActive(false);
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void Visto()
    {
        for (i = 0; i < 20; i++)
        {
            if (Caderno.evidencias[i].nome == "Informações da testemunha")
            {
                NumeroInfoTestemunha = i;
                break;
            }
        }
        PerguntaFeita = "visto";
        sentence.Clear();
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Enqueue("It was really late. I was scared. I could only see through the door crack.");
            if (depoimentoTestemunhaVisto)
            {
                sentence.Enqueue("I saw a man going inside through the door in the dark.");
                VistoTestemunha = "I saw a man going inside through the door in the dark.";
            }
            else
            {
                sentence.Enqueue("I saw a man leaving through the door in the dark.");
                VistoTestemunha = "I saw a man leaving through the door in the dark.";
            }
            Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
            "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
            "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
            Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
        }
        else
        {
            sentence.Enqueue("Estava bem tarde e eu, assustado, só consegui ver pela fresta da porta.");
            if (depoimentoTestemunhaVisto)
            {
                sentence.Enqueue("Eu vi um homem entrando pela porta no meio do escuro.");
                VistoTestemunha = "Eu vi um homem entrando pela porta no meio do escuro.";
            }
            else
            {
                sentence.Enqueue("Eu vi um homem saindo pela porta no meio do escuro.");
                VistoTestemunha = "Eu vi um homem saindo pela porta no meio do escuro.";
            }
            Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
            "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
            "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
            Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
        }
        sentence.Enqueue("Pergunta");
        VistoB.SetActive(false);
        OuviuB.SetActive(false);
        RelaçãoComVitimaB.SetActive(false);
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void Ouviu()
    {
        for (i = 0; i < 20; i++)
        {
            if (Caderno.evidencias[i].nome == "Informações da testemunha")
            {
                NumeroInfoTestemunha = i;
                break;
            }
        }
        PerguntaFeita = "ouviu";
        sentence.Clear();
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Enqueue("I couldn't hear much.");
            sentence.Enqueue("I don't think I have much to tell you about this.");
            OuviuTestemunha = "I couldn't hear much.";
            Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
            "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
            "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
            Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
        }
        else
        {
            sentence.Enqueue("Eu não consegui ouvir muita coisa.");
            sentence.Enqueue("Acredito que nesse quesito não tenha muito para te falar.");
            OuviuTestemunha = "Eu não consegui ouvir muita coisa.";
            Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
            "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
            "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
            Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
        }
        sentence.Enqueue("Pergunta");
        VistoB.SetActive(false);
        OuviuB.SetActive(false);
        RelaçãoComVitimaB.SetActive(false);
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void RelaçãoComVitima()
    {
        for (i = 0; i < 20; i++)
        {
            if (Caderno.evidencias[i].nome == "Informações da testemunha")
            {
                NumeroInfoTestemunha = i;
                break;
            }
        }
        PerguntaFeita = "relacao";
        sentence.Clear();
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Enqueue("I hardly knew him.");
            sentence.Enqueue("I have always found him a peaceful man.");
            RelacaoTestemunha = "I hardly knew him. I have always found him a peaceful man.";
            Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles = "<b>What was seen?</b>" + "\n" + VistoTestemunha + "\n" +
            "<b>What was heard?</b>" + "\n" + OuviuTestemunha + "\n" +
            "<b>Relationship with the victim?</b>" + "\n" + RelacaoTestemunha;
            Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdateIngles = Caderno.evidencias[NumeroInfoTestemunha].descriptionIngles;
        }
        else
        {
            sentence.Enqueue("Eu o conhecia só de vista.");
            sentence.Enqueue("Sempre achei ele um homem tranquilo com todos.");
            RelacaoTestemunha = "Eu o conhecia só de vista. Sempre achei ele um homem tranquilo com todos.";
            Caderno.evidencias[NumeroInfoTestemunha].description = "<b>O que foi visto?</b>" + "\n" + VistoTestemunha + "\n" +
            "<b>O que foi ouvido?</b>" + "\n" + OuviuTestemunha + "\n" +
            "<b>Relação com a vítima?</b>" + "\n" + RelacaoTestemunha;
            Caderno.evidencias[NumeroInfoTestemunha].descriptionUpdate = Caderno.evidencias[NumeroInfoTestemunha].description;
        }
        sentence.Enqueue("Pergunta");
        VistoB.SetActive(false);
        OuviuB.SetActive(false);
        RelaçãoComVitimaB.SetActive(false);
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinalizouTestemunha = false;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SimEcolheu.SetActive(false);
            sentence.Clear();
            Nome.text = "";
            dialogo.SetBool("isOpen", false);
            Caderno.PermissaoAbrirCaderno = true;
            caderno.SetBool("Rela", false);
            ConcordaB.SetActive(false);
            DiscordaB.SetActive(false);
            DuvidaB.SetActive(false);
            VistoB.SetActive(false);
            OuviuB.SetActive(false);
            RelaçãoComVitimaB.SetActive(false);
            isInRange = false;
            perguntando = false;
            entrouPreencher = false;
            FinalizouTestemunha = false;
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
