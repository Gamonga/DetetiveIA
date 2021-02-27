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
    public bool isInRange;
    public Animator Transition;
    public movimento movimento;
    public static int ActualScene = 0;
    public static int CrimeScene = 2;
    public static Text E;
    private float i;
    // Start is called before the first frame update
    void Start()
    {
        botaoSim.SetActive(false);
        botaoNao.SetActive(false);
        E = GameObject.Find("E").GetComponent<Text>();
        PlayerData data = SaveSystem.LoadPlayer(); 
        ActualScene = data.actualCrimeScene;
        if((SceneManager.GetActiveScene().buildIndex!=1) && (SceneManager.GetActiveScene().buildIndex!=0)){
            ActualScene = SceneManager.GetActiveScene().buildIndex;
            CrimeScene = ActualScene;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if(isInRange){            
            if (Input.GetKeyDown(KeyCode.E)){ 
                if(SceneManager.GetActiveScene().buildIndex == 1){
                    texto.text = "Deseja ir a cena do crime?";
                }   
                else{
                    texto.text = "Deseja ir a delegacia?";
                }
                Transition.SetBool("Abrir", true);
                botaoSim.SetActive(true);
                botaoNao.SetActive(true);
            }
        }
        else{
        }
    }
    public void SavePlayer(){
        SaveSystem.SavePlayer(movimento);
        SaveSystem.SaveMusic();
    }
    public void Delegacia(){
        MainMenu.NewGame = false;
        SavePlayer();
        SceneManager.LoadScene(1);
    }

    public void Voltar(){
        if(Relatorio.perguntando == false){
            SavePlayer();
            SceneManager.LoadScene(CrimeScene);
        }
    }

    public void No(){
        isInRange = false;
        Transition.SetBool("Abrir", false);
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
            E.color = new Color(255,255,255,0);
            botaoSim.SetActive(false);
            botaoNao.SetActive(false);
        }
    }
    IEnumerator DesligaE ()
    {
        for(i=1;i>-0.5;i = i - 0.05f){
            E.color = new Color(255,255,255,i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(LigaE());
    }
    IEnumerator LigaE ()
    {
        for(i=0;i<1.5;i = i + 0.05f){
            E.color = new Color(255,255,255,i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(DesligaE());
    }
}