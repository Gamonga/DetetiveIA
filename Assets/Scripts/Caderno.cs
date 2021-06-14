using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Caderno : MonoBehaviour
{
    static public Evidence[] evidencias = new Evidence[20];
    static public bool[] update = new bool[20];
    static public Pessoa[] pessoas = new Pessoa[20];
    public static int posiçãoPessoa;
    public Animator caderno;
    public Animator Transition;
    public Text textoPensamentos;
    private int repetidor;
    private bool open;
    public static bool PrecisaFecharTransition;
    public static bool kyle;
    public static bool Steve;
    public static bool Jessie;
    public static bool Jhony;
    public static bool Sanefuji;
    public static bool Devi;
    private Pessoa TesteSanefuji;
    private Pessoa TesteJessie;
    private Pessoa TesteJohny;
    private Pessoa TesteDevi;
    private Pessoa TesteKyle;
    private Pessoa TesteSteve;
    public GameObject SelecionarOutraPista;
    public GameObject JuntarPistas;
    public GameObject CadernoLimpo;
    public GameObject evidenciasTextos;
    public GameObject pessoasTextos;
    public GameObject Pensamentos;
    public Text description;
    public Text evidencia1;
    public Text evidencia2;
    public Text evidencia3;
    public Text evidencia4;
    public Text evidencia5;
    public Text evidencia6;
    public Text evidencia7;
    public Text evidencia8;
    public Text evidencia9;
    public Text evidencia10;
    public Text evidencia11;
    public Text evidencia12;
    public Text evidencia13;
    public Text evidencia14;
    public Text evidencia15;
    public Text evidencia16;
    public Text pessoa1;
    public Text pessoa2;
    public Text pessoa3;
    public Text pessoa4;
    public Text pessoa5;
    public Text pessoa6;
    public Text pessoa7;
    public Text pessoa8;
    public Text pessoa9;
    public Text pessoa10;
    public Text pessoa11;
    public Text pessoa12;
    public Text pessoa13;
    public Text pessoa14;
    public Text pessoa15;

    public Image ImagemObjeto;
    static public int posiçãoEvidencias = 0;
    private int i = 0;
    private int j = 0;
    private AudioSource barulhoAnotando;
    private AudioSource abrindoCaderno;
    static private bool entrou = false;
    static private bool entrouPessoa = false;
    static public bool PermissaoAbrirCaderno;
    static public string Pensamento1;
    static public string Pensamento2;
    private static int numeroPensamento;
    public static int contadorPensamentos;
    public GameObject Nao;
    public GameObject Sim;

    // Start is called before the first frame update
    void Start()
    {
        numeroPensamento = 1;
        contadorPensamentos = 3;
        PrecisaFecharTransition = false;
        PermissaoAbrirCaderno = true;
        entrouPessoa = false;
        entrou = false;
        Sanefuji = false;
        Jessie = false;
        kyle = false;
        Steve = false;
        Jhony = false;
        Devi = false;
        open = false;
        posiçãoEvidencias = 0;
        posiçãoPessoa = 0;
        repetidor = 0;
        if (MainMenu.NewGame == true)
        {
            for (i = 0; i < 20; i++)
            {
                update[i] = false;
            }
        }
    }

    private void Awake()
    {
        entrouPessoa = false;
        entrou = false;
        posiçãoEvidencias = 0;
        posiçãoPessoa = 0;
    }
    void abrirCaderno()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ScenesManager.entrouTutorial == false)
        {
            caderno.SetBool("abrir", false);
            open = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && PermissaoAbrirCaderno && ScenesManager.entrouTutorial == false)
        {

            if (!open)
            {
                caderno.SetBool("abrir", true);
                abrindoCaderno = GameObject.Find("abrindoCaderno").GetComponent<AudioSource>();
                abrindoCaderno.Play();
                evidenciasTextos.SetActive(false);
                pessoasTextos.SetActive(false);
                SelecionarOutraPista.SetActive(false);
                JuntarPistas.SetActive(false);
                Pensamentos.SetActive(false);
                CadernoLimpo.SetActive(true);
                Transition.SetBool("Abrir", false);
                textoPensamentos.text = "Deseja ir a cena do crime?";
                open = true;
            }
            else
            {
                evidenciasTextos.SetActive(false);
                pessoasTextos.SetActive(false);
                SelecionarOutraPista.SetActive(false);
                JuntarPistas.SetActive(false);
                Pensamentos.SetActive(false);
                Transition.SetBool("Abrir", false);
                caderno.SetBool("Rela", false);
                caderno.SetBool("abrir", false);
                open = false;
            }
        }
        if (PrecisaFecharTransition)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                fechaTransition();
            }
        }
    }
    public void atualizaDescricao(int tag)
    {
        evidenciasTextos.SetActive(true);
        description = GameObject.Find("Description").GetComponent<Text>();
        ImagemObjeto = GameObject.Find("Image").GetComponent<Image>();
        if (tag == 0)
        {
            evidencias[0].description = evidencias[0].descriptionUpdate;
            evidencias[0].descriptionIngles = evidencias[0].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[0].descriptionIngles;
            }
            else
            {
                description.text = evidencias[0].description;
            }
            update[0] = true;
        }
        if (tag == 1)
        {
            evidencias[1].description = evidencias[1].descriptionUpdate;
            evidencias[1].descriptionIngles = evidencias[1].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[1].descriptionIngles;
            }
            else
            {
                description.text = evidencias[1].description;
            }
            update[1] = true;
        }
        if (tag == 2)
        {
            evidencias[2].description = evidencias[2].descriptionUpdate;
            evidencias[2].descriptionIngles = evidencias[2].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[2].descriptionIngles;
            }
            else
            {
                description.text = evidencias[2].description;
            }
            update[2] = true;
        }
        if (tag == 3)
        {
            evidencias[3].description = evidencias[3].descriptionUpdate;
            evidencias[3].descriptionIngles = evidencias[3].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[3].descriptionIngles;
            }
            else
            {
                description.text = evidencias[3].description;
            }
            update[3] = true;
        }
        if (tag == 4)
        {
            evidencias[4].description = evidencias[4].descriptionUpdate;
            evidencias[4].descriptionIngles = evidencias[4].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[4].descriptionIngles;
            }
            else
            {
                description.text = evidencias[4].description;
            }
            update[4] = true;
        }
        if (tag == 5)
        {
            evidencias[5].description = evidencias[5].descriptionUpdate;
            evidencias[5].descriptionIngles = evidencias[5].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[5].descriptionIngles;
            }
            else
            {
                description.text = evidencias[5].description;
            }
            update[5] = true;
        }
        if (tag == 6)
        {
            evidencias[6].description = evidencias[6].descriptionUpdate;
            evidencias[6].descriptionIngles = evidencias[6].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[6].descriptionIngles;
            }
            else
            {
                description.text = evidencias[6].description;
            }
            update[6] = true;
        }
        if (tag == 7)
        {
            evidencias[7].description = evidencias[7].descriptionUpdate;
            evidencias[7].descriptionIngles = evidencias[7].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[7].descriptionIngles;
            }
            else
            {
                description.text = evidencias[7].description;
            }
            update[7] = true;
        }
        if (tag == 8)
        {
            evidencias[8].description = evidencias[8].descriptionUpdate;
            evidencias[8].descriptionIngles = evidencias[8].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[8].descriptionIngles;
            }
            else
            {
                description.text = evidencias[8].description;
            }
            update[8] = true;
        }
        if (tag == 9)
        {
            evidencias[9].description = evidencias[9].descriptionUpdate;
            evidencias[9].descriptionIngles = evidencias[9].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[9].descriptionIngles;
            }
            else
            {
                description.text = evidencias[9].description;
            }
            update[9] = true;
        }
        if (tag == 10)
        {
            evidencias[10].description = evidencias[10].descriptionUpdate;
            evidencias[10].descriptionIngles = evidencias[10].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[10].descriptionIngles;
            }
            else
            {
                description.text = evidencias[10].description;
            }
            update[10] = true;
        }
        if (tag == 11)
        {
            evidencias[11].description = evidencias[11].descriptionUpdate;
            evidencias[11].descriptionIngles = evidencias[11].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[11].descriptionIngles;
            }
            else
            {
                description.text = evidencias[11].description;
            }
            update[11] = true;
        }
        if (tag == 12)
        {
            evidencias[12].description = evidencias[12].descriptionUpdate;
            evidencias[12].descriptionIngles = evidencias[12].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[12].descriptionIngles;
            }
            else
            {
                description.text = evidencias[12].description;
            }
            update[12] = true;
        }
        if (tag == 13)
        {
            evidencias[13].description = evidencias[13].descriptionUpdate;
            evidencias[13].descriptionIngles = evidencias[13].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[13].descriptionIngles;
            }
            else
            {
                description.text = evidencias[13].description;
            }
            update[13] = true;
        }
        if (tag == 14)
        {
            evidencias[14].description = evidencias[14].descriptionUpdate;
            evidencias[14].descriptionIngles = evidencias[14].descriptionUpdateIngles;
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[14].descriptionIngles;
            }
            else
            {
                description.text = evidencias[14].description;
            }
            update[14] = true;
        }
        evidenciasTextos.SetActive(false);
    }
    public void ViraPagina()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        switch (Final.paginaAtual)
        {
            case 1:
                for (j = 0; j < evidencias.Length; j++)
                {
                    evidencias[j] = null;
                }
                contadorPensamentos = data.contadorPensamento;
                posiçãoEvidencias = 0;
                for (j = 0; j < data.NumeroDeEvidencias; j++)
                {
                    adicionar(GameObject.Find(data.nomeObjetoEvidenciasCaso1[j]).GetComponent<Evidence>());
                    update[j] = data.update[j];
                    if (update[j] == true)
                    {
                        atualizaDescricao(j);
                    }
                }
                break;
            case 2:
                for (j = 0; j < evidencias.Length; j++)
                {
                    evidencias[j] = null;
                }
                contadorPensamentos = data.contadorPensamento;
                posiçãoEvidencias = 0;
                for (j = 0; j < data.NumeroDeEvidencias; j++)
                {
                    adicionar(GameObject.Find(data.nomeObjetoEvidenciasCaso2[j]).GetComponent<Evidence>());
                    update[j] = data.update[j];
                    if (update[j] == true)
                    {
                        atualizaDescricao(j);
                    }
                }
                break;
            case 3:
                for (j = 0; j < evidencias.Length; j++)
                {
                    evidencias[j] = null;
                }
                contadorPensamentos = data.contadorPensamento;
                posiçãoEvidencias = 0;
                for (j = 0; j < data.NumeroDeEvidencias; j++)
                {
                    adicionar(GameObject.Find(data.nomeObjetoEvidenciasCaso3[j]).GetComponent<Evidence>());
                    update[j] = data.update[j];
                    if (update[j] == true)
                    {
                        atualizaDescricao(j);
                    }
                }
                break;
            case 4:
                for (j = 0; j < evidencias.Length; j++)
                {
                    evidencias[j] = null;
                }
                contadorPensamentos = data.contadorPensamento;
                posiçãoEvidencias = 0;
                for (j = 0; j < data.NumeroDeEvidencias; j++)
                {
                    adicionar(GameObject.Find(data.nomeObjetoEvidenciasCaso4[j]).GetComponent<Evidence>());
                    update[j] = data.update[j];
                    if (update[j] == true)
                    {
                        atualizaDescricao(j);
                    }
                }
                break;
            case 5:
                for (j = 0; j < evidencias.Length; j++)
                {
                    evidencias[j] = null;
                }
                contadorPensamentos = data.contadorPensamento;
                posiçãoEvidencias = 0;
                for (j = 0; j < data.NumeroDeEvidencias; j++)
                {
                    adicionar(GameObject.Find(data.nomeObjetoEvidenciasCaso5[j]).GetComponent<Evidence>());
                    update[j] = data.update[j];
                    if (update[j] == true)
                    {
                        atualizaDescricao(j);
                    }
                }
                break;
            case 6:
                for (j = 0; j < evidencias.Length; j++)
                {
                    evidencias[j] = null;
                }
                contadorPensamentos = data.contadorPensamento;
                posiçãoEvidencias = 0;
                for (j = 0; j < data.NumeroDeEvidencias; j++)
                {
                    adicionar(GameObject.Find(data.nomeObjetoEvidenciasCaso6[j]).GetComponent<Evidence>());
                    update[j] = data.update[j];
                    if (update[j] == true)
                    {
                        atualizaDescricao(j);
                    }
                }
                break;
        }
    }
    public void trocarDescricao(Text Text)
    {
        description = GameObject.Find("Description").GetComponent<Text>();
        ImagemObjeto = GameObject.Find("Image").GetComponent<Image>();
        if (Text.tag == "0")
        {
            description = GameObject.Find("Description").GetComponent<Text>();
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[0].descriptionIngles;
            }
            else
            {
                description.text = evidencias[0].description;
            }
            ImagemObjeto.sprite = evidencias[0].ImagemObjeto;
        }
        if (Text.tag == "1")
        {
            description = GameObject.Find("Description").GetComponent<Text>();
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[1].descriptionIngles;
            }
            else
            {
                description.text = evidencias[1].description;
            }
            ImagemObjeto.sprite = evidencias[1].ImagemObjeto;
        }
        if (Text.tag == "2")
        {
            description = GameObject.Find("Description").GetComponent<Text>();
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[2].descriptionIngles;
            }
            else
            {
                description.text = evidencias[2].description;
            }
            ImagemObjeto.sprite = evidencias[2].ImagemObjeto;
        }
        if (Text.tag == "3")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[3].descriptionIngles;
            }
            else
            {
                description.text = evidencias[3].description;
            }
            ImagemObjeto.sprite = evidencias[3].ImagemObjeto;
        }
        if (Text.tag == "4")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[4].descriptionIngles;
            }
            else
            {
                description.text = evidencias[4].description;
            }
            ImagemObjeto.sprite = evidencias[4].ImagemObjeto;
        }
        if (Text.tag == "5")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[5].descriptionIngles;
            }
            else
            {
                description.text = evidencias[5].description;
            }
            ImagemObjeto.sprite = evidencias[5].ImagemObjeto;
        }
        if (Text.tag == "6")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[6].descriptionIngles;
            }
            else
            {
                description.text = evidencias[6].description;
            }
            ImagemObjeto.sprite = evidencias[6].ImagemObjeto;
        }
        if (Text.tag == "7")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[7].descriptionIngles;
            }
            else
            {
                description.text = evidencias[7].description;
            }
            ImagemObjeto.sprite = evidencias[7].ImagemObjeto;
        }
        if (Text.tag == "8")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[8].descriptionIngles;
            }
            else
            {
                description.text = evidencias[8].description;
            }
            ImagemObjeto.sprite = evidencias[8].ImagemObjeto;
        }
        if (Text.tag == "9")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[9].descriptionIngles;
            }
            else
            {
                description.text = evidencias[9].description;
            }
            ImagemObjeto.sprite = evidencias[9].ImagemObjeto;
        }
        if (Text.tag == "10")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[10].descriptionIngles;
            }
            else
            {
                description.text = evidencias[10].description;
            }
            ImagemObjeto.sprite = evidencias[10].ImagemObjeto;
        }
        if (Text.tag == "11")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[11].descriptionIngles;
            }
            else
            {
                description.text = evidencias[11].description;
            }
            ImagemObjeto.sprite = evidencias[11].ImagemObjeto;
        }
        if (Text.tag == "12")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[12].descriptionIngles;
            }
            else
            {
                description.text = evidencias[12].description;
            }
            ImagemObjeto.sprite = evidencias[12].ImagemObjeto;
        }
        if (Text.tag == "13")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[13].descriptionIngles;
            }
            else
            {
                description.text = evidencias[13].description;
            }
            ImagemObjeto.sprite = evidencias[13].ImagemObjeto;
        }
        if (Text.tag == "14")
        {
            if (PlayerData.Idioma == "ingles")
            {
                description.text = evidencias[14].descriptionIngles;
            }
            else
            {
                description.text = evidencias[14].description;
            }
            ImagemObjeto.sprite = evidencias[14].ImagemObjeto;
        }
    }
    public void JuntarPensamentos()
    {
        switch (Pensamento1)
        {
            case "Wreckage":
                Pensamento1 = "Destroços";
                break;
            case "Victim":
                Pensamento1 = "Vítima";
                break;
            case "Plate":
                Pensamento1 = "Prato";
                break;
            case "Policeman's notes":
                Pensamento1 = "Informações do policial";
                break;
            case "Report":
                Pensamento1 = "Laudo";
                break;
        }
        switch (Pensamento2)
        {
            case "Wreckage":
                Pensamento2 = "Destroços";
                break;
            case "Victim":
                Pensamento2 = "Vítima";
                break;
            case "Plate":
                Pensamento2 = "Prato";
                break;
            case "Policeman's notes":
                Pensamento2 = "Informações do policial";
                break;
            case "Report":
                Pensamento2 = "Laudo";
                break;
        }
        if (Pensamento1 == "Destroços" && Pensamento2 == "Vítima")
        {
            adicionar(GameObject.Find("Punhos(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento2 == "Destroços" && Pensamento1 == "Vítima")
        {
            adicionar(GameObject.Find("Punhos(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento1 == "Prato" && Pensamento2 == "Vítima")
        {
            adicionar(GameObject.Find("Convite(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento2 == "Prato" && Pensamento1 == "Vítima")
        {
            adicionar(GameObject.Find("Convite(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento1 == "Prato" && Pensamento2 == "Informações do policial")
        {
            adicionar(GameObject.Find("Convite(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento2 == "Prato" && Pensamento1 == "Informações do policial")
        {
            adicionar(GameObject.Find("Convite(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento2 == "Laudo" && Pensamento1 == "Vítima")
        {
            adicionar(GameObject.Find("Convite(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento1 == "Laudo" && Pensamento2 == "Vítima")
        {
            adicionar(GameObject.Find("Convite(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento2 == "Vítima" && Pensamento1 == "Laudo")
        {
            adicionar(GameObject.Find("Sufocamento(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else if (Pensamento1 == "Vítima" && Pensamento2 == "Laudo")
        {
            adicionar(GameObject.Find("Sufocamento(Clone)").GetComponent<Evidence>());
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Thought added to the notebook.";
            }
            else
            {
                textoPensamentos.text = "Pensamento adicionado ao caderno.";
            }
        }
        else
        {
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "I don't see correlation between these 2 pieces of evidence.";
            }
            else
            {
                textoPensamentos.text = "Não vejo correlação entre essas 2 evidências.";
            }
        }
        contadorPensamentos--;
        Transition.SetBool("Abrir", true);
        caderno.SetBool("Rela", false);
        caderno.SetBool("abrir", false);
        SelecionarOutraPista.SetActive(false);
        JuntarPistas.SetActive(false);
        PrecisaFecharTransition = true;
        open = false;
        numeroPensamento = 1;
        Pensamento2 = "";
        Pensamento1 = "";
    }
    public void SelecionarOutraPistaBotao()
    {
        numeroPensamento = 1;
        SelecionarOutraPista.SetActive(false);
        JuntarPistas.SetActive(false);
        Pensamento2 = "";
    }
    public void SelecionaPensamentos(Text Text)
    {
        Transition.SetBool("Abrir", true);
        if (numeroPensamento == 1)
        {
            Pensamento1 = Text.text;
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "Should I join " + Pensamento1 + " with which other clue? (Remaining attempts: " + contadorPensamentos + ").";
            }
            else
            {
                textoPensamentos.text = "Devo juntar " + Pensamento1 + " com qual outra pista? (Tentativas Restantes: " + contadorPensamentos + ").";
            }
            numeroPensamento++;
            SelecionarOutraPista.SetActive(true);
        }
        if (numeroPensamento == 2)
        {
            if (Pensamento1 == Text.text || Pensamento2 == Text.text)
            {

            }
            else
            {
                JuntarPistas.SetActive(true);
                Pensamento2 = Text.text;
                if (PlayerData.Idioma == "ingles")
                {
                    textoPensamentos.text = "Does it make sense for me to join " + Pensamento1 + " and " + Pensamento2 + "? (Remaining attempts: " + contadorPensamentos + ").";
                }
                else
                {
                    textoPensamentos.text = "Faz sentido eu juntar " + Pensamento1 + " e " + Pensamento2 + "? (Tentativas Restantes: " + contadorPensamentos + ").";
                }
            }
        }
    }
    public void EscreverPensamentos()
    {
        Sim.SetActive(false);
        Nao.SetActive(false);
        if (contadorPensamentos > 0)
        {
            numeroPensamento = 1;
            Pensamento2 = "";
            Pensamento1 = "";
            CadernoLimpo.SetActive(false);
            Pensamentos.SetActive(true);
            caderno.SetBool("Rela", true);
            description = GameObject.Find("Description").GetComponent<Text>();
            ImagemObjeto = GameObject.Find("Image").GetComponent<Image>();
            for (i = 0; i < posiçãoEvidencias; i++)
            {
                switch (i)
                {
                    case 0:
                        evidencia1 = GameObject.Find("Text0").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia1.text = evidencias[0].nomeIngles;
                        }
                        else
                        {
                            evidencia1.text = evidencias[0].nome;
                        }
                        break;
                    case 1:
                        evidencia2 = GameObject.Find("Text1").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia2.text = evidencias[1].nomeIngles;
                        }
                        else
                        {
                            evidencia2.text = evidencias[1].nome;
                        }
                        break;
                    case 2:
                        evidencia3 = GameObject.Find("Text2").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia3.text = evidencias[2].nomeIngles;
                        }
                        else
                        {
                            evidencia3.text = evidencias[2].nome;
                        }
                        break;
                    case 3:
                        evidencia4 = GameObject.Find("Text3").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia4.text = evidencias[3].nomeIngles;
                        }
                        else
                        {
                            evidencia4.text = evidencias[3].nome;
                        }
                        break;
                    case 4:
                        evidencia5 = GameObject.Find("Text4").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia5.text = evidencias[4].nomeIngles;
                        }
                        else
                        {
                            evidencia5.text = evidencias[4].nome;
                        }
                        break;
                    case 5:
                        evidencia6 = GameObject.Find("Text5").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia6.text = evidencias[5].nomeIngles;
                        }
                        else
                        {
                            evidencia6.text = evidencias[5].nome;
                        }
                        break;
                    case 6:
                        evidencia7 = GameObject.Find("Text6").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia7.text = evidencias[6].nomeIngles;
                        }
                        else
                        {
                            evidencia7.text = evidencias[6].nome;
                        }
                        break;
                    case 7:
                        evidencia8 = GameObject.Find("Text7").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia8.text = evidencias[7].nomeIngles;
                        }
                        else
                        {
                            evidencia8.text = evidencias[7].nome;
                        }
                        break;
                    case 8:
                        evidencia9 = GameObject.Find("Text8").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia9.text = evidencias[8].nomeIngles;
                        }
                        else
                        {
                            evidencia9.text = evidencias[8].nome;
                        }
                        break;
                    case 9:
                        evidencia10 = GameObject.Find("Text9").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia10.text = evidencias[9].nomeIngles;
                        }
                        else
                        {
                            evidencia10.text = evidencias[9].nome;
                        }
                        break;
                    case 10:
                        evidencia11 = GameObject.Find("Text10").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia11.text = evidencias[10].nomeIngles;
                        }
                        else
                        {
                            evidencia11.text = evidencias[10].nome;
                        }
                        break;
                    case 11:
                        evidencia12 = GameObject.Find("Text11").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia12.text = evidencias[11].nomeIngles;
                        }
                        else
                        {
                            evidencia12.text = evidencias[11].nome;
                        }
                        break;
                    case 12:
                        evidencia13 = GameObject.Find("Text12").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia13.text = evidencias[12].nomeIngles;
                        }
                        else
                        {
                            evidencia13.text = evidencias[12].nome;
                        }
                        break;
                    case 13:
                        evidencia14 = GameObject.Find("Text13").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia14.text = evidencias[13].nomeIngles;
                        }
                        else
                        {
                            evidencia14.text = evidencias[13].nome;
                        }
                        break;
                    case 14:
                        evidencia15 = GameObject.Find("Text14").GetComponent<Text>();
                        if (PlayerData.Idioma == "ingles")
                        {
                            evidencia15.text = evidencias[14].nomeIngles;
                        }
                        else
                        {
                            evidencia15.text = evidencias[14].nome;
                        }
                        break;
                }
            }
        }
        else
        {
            Transition.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                textoPensamentos.text = "I'm too tired to be able to think now.";
            }
            else
            {
                textoPensamentos.text = "Estou cansado demais para conseguir pensar agora.";
            }
            caderno.SetBool("Rela", false);
            caderno.SetBool("abrir", false);
            PrecisaFecharTransition = true;
            open = false;
        }
    }
    public void fechaTransition()
    {
        Transition.SetBool("Abrir", false);
        if (PlayerData.Idioma == "ingles")
        {
            textoPensamentos.text = "Do you want to go to the crime scene?";
        }
        else
        {
            textoPensamentos.text = "Deseja ir a cena do crime?";
        }
        PrecisaFecharTransition = false;
        SelecionarOutraPista.SetActive(false);
        JuntarPistas.SetActive(false);
        Pensamentos.SetActive(false);
    }
    public void EscreverEvidencias()
    {
        CadernoLimpo.SetActive(false);
        evidenciasTextos.SetActive(true);
        description = GameObject.Find("Description").GetComponent<Text>();
        ImagemObjeto = GameObject.Find("Image").GetComponent<Image>();
        for (i = 0; i < posiçãoEvidencias; i++)
        {
            switch (i)
            {
                case 0:
                    evidencia1 = GameObject.Find("Text0").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia1.text = evidencias[0].nomeIngles;
                    }
                    else
                    {
                        evidencia1.text = evidencias[0].nome;
                    }
                    break;
                case 1:
                    evidencia2 = GameObject.Find("Text1").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia2.text = evidencias[1].nomeIngles;
                    }
                    else
                    {
                        evidencia2.text = evidencias[1].nome;
                    }
                    break;
                case 2:
                    evidencia3 = GameObject.Find("Text2").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia3.text = evidencias[2].nomeIngles;
                    }
                    else
                    {
                        evidencia3.text = evidencias[2].nome;
                    }
                    break;
                case 3:
                    evidencia4 = GameObject.Find("Text3").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia4.text = evidencias[3].nomeIngles;
                    }
                    else
                    {
                        evidencia4.text = evidencias[3].nome;
                    }
                    break;
                case 4:
                    evidencia5 = GameObject.Find("Text4").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia5.text = evidencias[4].nomeIngles;
                    }
                    else
                    {
                        evidencia5.text = evidencias[4].nome;
                    }
                    break;
                case 5:
                    evidencia6 = GameObject.Find("Text5").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia6.text = evidencias[5].nomeIngles;
                    }
                    else
                    {
                        evidencia6.text = evidencias[5].nome;
                    }
                    break;
                case 6:
                    evidencia7 = GameObject.Find("Text6").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia7.text = evidencias[6].nomeIngles;
                    }
                    else
                    {
                        evidencia7.text = evidencias[6].nome;
                    }
                    break;
                case 7:
                    evidencia8 = GameObject.Find("Text7").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia8.text = evidencias[7].nomeIngles;
                    }
                    else
                    {
                        evidencia8.text = evidencias[7].nome;
                    }
                    break;
                case 8:
                    evidencia9 = GameObject.Find("Text8").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia9.text = evidencias[8].nomeIngles;
                    }
                    else
                    {
                        evidencia9.text = evidencias[8].nome;
                    }
                    break;
                case 9:
                    evidencia10 = GameObject.Find("Text9").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia10.text = evidencias[9].nomeIngles;
                    }
                    else
                    {
                        evidencia10.text = evidencias[9].nome;
                    }
                    break;
                case 10:
                    evidencia11 = GameObject.Find("Text10").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia11.text = evidencias[10].nomeIngles;
                    }
                    else
                    {
                        evidencia11.text = evidencias[10].nome;
                    }
                    break;
                case 11:
                    evidencia12 = GameObject.Find("Text11").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia12.text = evidencias[11].nomeIngles;
                    }
                    else
                    {
                        evidencia12.text = evidencias[11].nome;
                    }
                    break;
                case 12:
                    evidencia13 = GameObject.Find("Text12").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia13.text = evidencias[12].nomeIngles;
                    }
                    else
                    {
                        evidencia13.text = evidencias[12].nome;
                    }
                    break;
                case 13:
                    evidencia14 = GameObject.Find("Text13").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia14.text = evidencias[13].nomeIngles;
                    }
                    else
                    {
                        evidencia14.text = evidencias[13].nome;
                    }
                    break;
                case 14:
                    evidencia15 = GameObject.Find("Text14").GetComponent<Text>();
                    if (PlayerData.Idioma == "ingles")
                    {
                        evidencia15.text = evidencias[14].nomeIngles;
                    }
                    else
                    {
                        evidencia15.text = evidencias[14].nome;
                    }
                    break;
            }
        }
    }
    public void trocarDescricaoPessoas(Text Text)
    {
        description = GameObject.Find("Description").GetComponent<Text>();
        if (Text.tag == "0")
        {
            description.text = pessoas[0].description;
        }
        if (Text.tag == "1")
        {
            description.text = pessoas[1].description;
        }
        if (Text.tag == "2")
        {
            description.text = pessoas[2].description;
        }
        if (Text.tag == "3")
        {
            description.text = pessoas[3].description;
        }
        if (Text.tag == "4")
        {
            description.text = pessoas[4].description;
        }
        if (Text.tag == "5")
        {
            description.text = pessoas[5].description;
        }
        if (Text.tag == "6")
        {
            description.text = pessoas[6].description;
        }
        if (Text.tag == "7")
        {
            description.text = pessoas[7].description;
        }
        if (Text.tag == "8")
        {
            description.text = pessoas[8].description;
        }
        if (Text.tag == "9")
        {
            description.text = pessoas[9].description;
        }
        if (Text.tag == "10")
        {
            description.text = pessoas[10].description;
        }
        if (Text.tag == "11")
        {
            description.text = pessoas[11].description;
        }
        if (Text.tag == "12")
        {
            description.text = pessoas[12].description;
        }
        if (Text.tag == "13")
        {
            description.text = pessoas[13].description;
        }
        if (Text.tag == "14")
        {
            description.text = pessoas[14].description;
        }
    }
    public void Pessoas()
    {
        CadernoLimpo.SetActive(false);
        pessoasTextos.SetActive(true);
        description = GameObject.Find("Description").GetComponent<Text>();
        ImagemObjeto = GameObject.Find("Image").GetComponent<Image>();
        for (i = 0; i < posiçãoPessoa; i++)
        {
            switch (i)
            {
                case 0:
                    pessoa1 = GameObject.Find("Pessoa0").GetComponent<Text>();
                    pessoa1.text = pessoas[0].nome;
                    break;
                case 1:
                    pessoa2 = GameObject.Find("Pessoa1").GetComponent<Text>();
                    pessoa2.text = pessoas[1].nome;
                    break;
                case 2:
                    pessoa3 = GameObject.Find("Pessoa2").GetComponent<Text>();
                    pessoa3.text = pessoas[2].nome;
                    break;
                case 3:
                    pessoa4 = GameObject.Find("Pessoa3").GetComponent<Text>();
                    pessoa4.text = pessoas[3].nome;
                    break;
                case 4:
                    pessoa5 = GameObject.Find("Pessoa4").GetComponent<Text>();
                    pessoa5.text = pessoas[4].nome;
                    break;
                case 5:
                    pessoa6 = GameObject.Find("Pessoa5").GetComponent<Text>();
                    pessoa6.text = pessoas[5].nome;
                    break;
                case 6:
                    pessoa7 = GameObject.Find("Pessoa6").GetComponent<Text>();
                    pessoa7.text = pessoas[6].nome;
                    break;
                case 7:
                    pessoa8 = GameObject.Find("Pessoa7").GetComponent<Text>();
                    pessoa8.text = pessoas[7].nome;
                    break;
                case 8:
                    pessoa9 = GameObject.Find("Pessoa8").GetComponent<Text>();
                    pessoa9.text = pessoas[8].nome;
                    break;
                case 9:
                    pessoa10 = GameObject.Find("Pessoa9").GetComponent<Text>();
                    pessoa10.text = pessoas[9].nome;
                    break;
                case 10:
                    pessoa11 = GameObject.Find("Pessoa10").GetComponent<Text>();
                    pessoa11.text = pessoas[10].nome;
                    break;
                case 11:
                    pessoa12 = GameObject.Find("Pessoa11").GetComponent<Text>();
                    pessoa12.text = pessoas[11].nome;
                    break;
                case 12:
                    pessoa13 = GameObject.Find("Pessoa12").GetComponent<Text>();
                    pessoa13.text = pessoas[12].nome;
                    break;
                case 13:
                    pessoa14 = GameObject.Find("Pessoa13").GetComponent<Text>();
                    pessoa14.text = pessoas[13].nome;
                    break;
                case 14:
                    pessoa15 = GameObject.Find("Pessoa14").GetComponent<Text>();
                    pessoa15.text = pessoas[14].nome;
                    break;
            }
        }
    }
    public bool verificaExistenciaPessoa(Pessoa pessoa)
    {
        if (entrouPessoa == true)
        {
            for (i = 0; i < pessoas.Length; i++)
            {
                if (pessoas[i] != null)
                {
                    if (pessoa.nome == pessoas[i].nome)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public bool verificaExistencia(Evidence evidence)
    {
        if (entrou == true)
        {
            for (i = 0; i < evidencias.Length; i++)
            {
                if (evidencias[i] != null)
                {
                    if (evidence.nome == evidencias[i].nome)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    public void adicionarPessoas(Pessoa pessoa)
    {
        if (verificaExistenciaPessoa(pessoa))
        {
        }
        else
        {
            switch (pessoa.nome)
            {
                case "Sanefuji":
                    Sanefuji = true;
                    break;
                case "Jessie":
                    Jessie = true;
                    break;
                case "Kyle":
                    kyle = true;
                    break;
                case "Steve":
                    Steve = true;
                    break;
                case "Johnny":
                    Jhony = true;
                    break;
                case "Devi":
                    Devi = true;
                    break;
            }
            barulhoAnotando = GameObject.Find("escrita").GetComponent<AudioSource>();
            barulhoAnotando.Play();
            if (entrouPessoa == false)
            {
                pessoas[0] = pessoa;
                posiçãoPessoa = 1;
                entrouPessoa = true;
                return;
            }
            if (posiçãoPessoa == 1)
            {
                pessoas[1] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 2)
            {
                pessoas[2] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 3)
            {
                pessoas[3] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 4)
            {
                pessoas[4] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 5)
            {
                pessoas[5] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 6)
            {
                pessoas[6] = pessoa;

                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 7)
            {
                pessoas[7] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 8)
            {
                pessoas[8] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 9)
            {
                pessoas[9] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 10)
            {
                pessoas[10] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 11)
            {
                pessoas[11] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 12)
            {
                pessoas[12] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 13)
            {
                pessoas[13] = pessoa;
                posiçãoPessoa++;
                return;
            }
            if (posiçãoPessoa == 14)
            {
                pessoas[14] = pessoa;
                posiçãoPessoa++;
                return;
            }

        }
    }

    public void adicionar(Evidence evidence)
    {
        if (verificaExistencia(evidence))
        {
        }
        else
        {
            if(SceneManager.GetActiveScene().buildIndex != 4 && SceneManager.GetActiveScene().buildIndex != 1 ){
                barulhoAnotando = GameObject.Find("escrita").GetComponent<AudioSource>();
                barulhoAnotando.Play();
            }
            if (entrou == false)
            {
                evidencias[0] = evidence;
                posiçãoEvidencias = 1;
                entrou = true;
                return;
            }
            if (posiçãoEvidencias == 1)
            {
                evidencias[1] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 2)
            {
                evidencias[2] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 3)
            {
                evidencias[3] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 4)
            {
                evidencias[4] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 5)
            {
                evidencias[5] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 6)
            {
                evidencias[6] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 7)
            {
                evidencias[7] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 8)
            {
                evidencias[8] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 9)
            {
                evidencias[9] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 10)
            {
                evidencias[10] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 11)
            {
                evidencias[11] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 12)
            {
                evidencias[12] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 13)
            {
                evidencias[13] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 14)
            {
                evidencias[14] = evidence;
                posiçãoEvidencias++;
                return;
            }
            if (posiçãoEvidencias == 15)
            {
                evidencias[15] = evidence;
                posiçãoEvidencias++;
                return;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        abrirCaderno();
        if (repetidor == 50 && MainMenu.NewGame == false)
        {
            LoadPlayer();
            repetidor++;
            Debug.Log("aaaa");
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Destroy_Object();
            }
        }
        else if (repetidor <= 60)
        {
            repetidor++;
        }
    }
    public void Destroy_Object()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        posiçãoEvidencias = data.NumeroDeEvidencias;
        for (j = 0; j < data.NumeroDeEvidencias; j++)
        {
            Debug.Log(data.nomeObjetoEvidencias[j]);
            Destroy(GameObject.Find(data.nomeObjetoEvidencias[j]));
        }
    }
    public void LoadPlayer()
    {
        for (j = 0; j < evidencias.Length; j++)
        {
            evidencias[j] = null;
        }
        PlayerData data = SaveSystem.LoadPlayer();
        LoadPessoas(data);
        contadorPensamentos = data.contadorPensamento;
        posiçãoEvidencias = 0;
        for (j = 0; j < data.NumeroDeEvidencias; j++)
        {
            Debug.Log(data.nomeObjetoEvidencias[j]);
            adicionar(GameObject.Find(data.nomeObjetoEvidencias[j]).GetComponent<Evidence>());
            update[j] = data.update[j];
            if (update[j] == true)
            {
                atualizaDescricao(j);
            }
        }
    }
    public void LoadPessoas(PlayerData data)
    {
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            Sanefuji = data.Sanefuji;
            Jessie = data.Jessie;
            kyle = data.kyle;
            Steve = data.Steve;
            Jhony = data.Jhony;
            Devi = data.Devi;
            TesteJessie = new Pessoa();
            TesteJohny = new Pessoa();
            TesteSteve = new Pessoa();
            TesteDevi = new Pessoa();
            TesteSanefuji = new Pessoa();
            TesteKyle = new Pessoa();
            if (Sanefuji == true)
            {
                TesteSanefuji.nome = "Sanefuji";
                TesteSanefuji.description = "Empresário da alta classe, só pensa em business.";
                adicionarPessoas(TesteSanefuji);
            }
            if (Jessie == true)
            {
                TesteJessie.nome = "Jessie";
                TesteJessie.description = "Jornalista investigativa.";
                adicionarPessoas(TesteJessie);
            }
            if (kyle == true)
            {
                TesteKyle.nome = "kyle";
                TesteKyle.description = "Perito digital da delegacia.";
                adicionarPessoas(TesteKyle);
            }
            if (Steve == true)
            {
                TesteSteve.nome = "Steve";
                TesteSteve.description = "Parceiro do detetive.";
                adicionarPessoas(TesteSteve);
            }
            if (Jhony == true)
            {
                TesteJohny.nome = "Johnny";
                TesteJohny.description = "Policial.";
                adicionarPessoas(TesteJohny);
            }
            if (Devi == true)
            {
                TesteDevi.nome = "Devi";
                TesteDevi.description = "Legista.";
                adicionarPessoas(TesteDevi);
            }
        }
    }
}
