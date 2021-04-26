using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Text texto;
    public GameObject botaoSim;
    public GameObject botaoNao;
    public static Animator animator;
    public Dialogue dialogoParceiroDetetiveIndoParaDelegacia;
    public Dialogue dialogoDelegadoExplicando;
    public DialogueControl dialogueControl;
    public bool isInRange;
    public Animator Transition;
    public movimento movimento;
    public static int ActualScene = 0;
    public static int CrimeScene = 2;
    public static Text E;
    private float i;
    public static bool DialogoTransicao;
    public static bool PrimeiraVezDialogoTransicao;
    // Start is called before the first frame update
    void Start()
    {
        PrimeiraVezDialogoTransicao = true;
        animator = GameObject.Find("CarroTransicaoGIF").GetComponent<Animator>();
        PlayerData data = SaveSystem.LoadPlayer();
        if(MainMenu.NewGame == false){
            PrimeiraVezDialogoTransicao = data.PrimeiraVezDialogoTransicao;
        }
        DialogoTransicao = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DialogoTransicao = true;
            animator.SetBool("CarroGif", true);
            dialogueControl.StartDialogue(dialogoParceiroDetetiveIndoParaDelegacia);
        }
        if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0 && PrimeiraVezDialogoTransicao)
        {
            DialogoTransicao = true;
            animator.SetBool("CarroGif", true);
            PrimeiraVezDialogoTransicao = false;
            dialogueControl.StartDialogue(dialogoDelegadoExplicando);
        }
        botaoSim.SetActive(false);
        botaoNao.SetActive(false);
        E = GameObject.Find("E").GetComponent<Text>();
        ActualScene = SceneManager.GetActiveScene().buildIndex;
        if ((SceneManager.GetActiveScene().buildIndex == 1))
        {
            ActualScene = data.actualCrimeScene;
        }
        CrimeScene = ActualScene;
    }
    public static void fechar()
    {
        animator.SetBool("CarroGif", false);
        movimento.ParaPersonagem = false;
        DialogoTransicao = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogoTransicao)
        {
            movimento.ParaPersonagem = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    dialogueControl.DisplayNextSentence(dialogoParceiroDetetiveIndoParaDelegacia);
                }
                if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0)
                {
                    dialogueControl.DisplayNextSentence(dialogoDelegadoExplicando);
                }
            }
        }
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        texto.text = "Do you want to go to the crime scene?";
                    }
                    else
                    {
                        texto.text = "Deseja ir a cena do crime?";
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        texto.text = "Do you want to go to the police station?";
                    }
                    else
                    {
                        texto.text = "Deseja ir a delegacia";
                    }
                }
                Transition.SetBool("Abrir", true);
                botaoSim.SetActive(true);
                botaoNao.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                botaoSim.SetActive(false);
                botaoNao.SetActive(false);
            }
        }
        else
        {
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(movimento);
        SaveSystem.SaveMusic();
    }
    public void Delegacia()
    {
        MainMenu.NewGame = false;
        MainMenu.PrimeiroCaso = false;
        SavePlayer();
        SceneManager.LoadScene(1);
    }

    public void Voltar()
    {
        if (Relatorio.perguntando == false)
        {
            SavePlayer();
            SceneManager.LoadScene(CrimeScene);
        }
    }

    public void No()
    {
        if (isInRange)
        {
            isInRange = false;
            Transition.SetBool("Abrir", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            StopAllCoroutines();
            StartCoroutine(LigaE());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transition.SetBool("Abrir", false);
            isInRange = false;
            StopAllCoroutines();
            E.color = new Color(255, 255, 255, 0);
            botaoSim.SetActive(false);
            botaoNao.SetActive(false);
        }
    }
    IEnumerator DesligaE()
    {
        for (i = 1; i > -0.5; i = i - 0.05f)
        {
            E.color = new Color(255, 255, 255, i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(LigaE());
    }
    IEnumerator LigaE()
    {
        for (i = 0; i < 1.5; i = i + 0.05f)
        {
            E.color = new Color(255, 255, 255, i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(DesligaE());
    }
}