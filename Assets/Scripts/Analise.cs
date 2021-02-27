using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Analise : MonoBehaviour
{
    public GameObject trocarCenaSimOriginal;
    public GameObject noOriginal;
    public GameObject CadernoLimpo;
    public GameObject Evidencias;
    public GameObject dialogue;
    public GameObject textBox;
    public GameObject trocarCenaSim;
    public GameObject no;
    public Animator TextoConfirma;
    public Animator AnaliseAnimator;
    public Caderno caderno;
    public Dialogue tiDialogo;
    public DialogueControl tiDialogoControl;
    public bool isInRange;
    public static bool terminouConversa;
    public static bool EntrouAnalisando;
    public bool alterouTexto;
    public bool EntrouNtemMaisAnalise;
    public static string tagDaEvidencia;
    public static int contador;
    private bool PoderDarResposta ;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {    
        PoderDarResposta = false;
        alterouTexto = false;
        contador = 3;
        EntrouAnalisando = false;
        terminouConversa = false;
        isInRange = false;    
        EntrouNtemMaisAnalise = false;
        if(MainMenu.NewGame == false){     
            PlayerData data = SaveSystem.LoadPlayer();
            contador = data.contadorAnalise;
        }
    }

    public void Resposta(Text resposta){
        if(isInRange && PoderDarResposta){
            tagDaEvidencia = resposta.tag;
            noOriginal.SetActive(false);
            trocarCenaSimOriginal.SetActive(false); 
            TextoConfirma.SetBool("Abrir", true);
            no.SetActive(true);
            trocarCenaSim.SetActive(true);            
            texto.text = "Entregar para a análise? (Tentativas restantes: " + contador + " )";
        }              
    }
    public void No(){
        if(isInRange){
            CadernoLimpo.SetActive(true);
            Evidencias.SetActive(false);
            AnaliseAnimator.SetBool("Rela",false);
            TextoConfirma.SetBool("Abrir", false);
            PoderDarResposta = false;
        }              
        terminouConversa = false;
    }
    public void confirma(){     
        PoderDarResposta = false;
        CadernoLimpo.SetActive(true);
        Evidencias.SetActive(false);
        AnaliseAnimator.SetBool("Rela",false);
        TextoConfirma.SetBool("Abrir", false);
        dialogue.SetActive(true);
        no.SetActive(false);
        trocarCenaSim.SetActive(false);
        terminouConversa = false;
        if(contador > 0){
            Analisando();
        } 
        contador--;
        SpawnObjects.contador--;   
        switch(tagDaEvidencia){
            case "0":
                caderno.atualizaDescricao(0);
            break;
            case "1":
                caderno.atualizaDescricao(1);
            break;
            case "2":
                caderno.atualizaDescricao(2);
            break;
            case "3":
                caderno.atualizaDescricao(3);
            break;
            case "4":
                caderno.atualizaDescricao(4);
            break;
            case "5":
                caderno.atualizaDescricao(5);
            break;
            case "6":
                caderno.atualizaDescricao(6);
            break;
            case "7":
                caderno.atualizaDescricao(7);
            break;
            case "8":
                caderno.atualizaDescricao(8);
            break;
            case "9":
                caderno.atualizaDescricao(9);
            break;
            case "10":
                caderno.atualizaDescricao(10);
            break;
            case "11":
                caderno.atualizaDescricao(11);
            break;
        }           
    }
    void AntesAnalise(){
        tiDialogo.senteceloop = new string[3];
        tiDialogo.senteceloop[0] = "Gostaria que eu analisasse algo a mais detetive?";
        tiDialogo.senteceloop[1] = "troca";
        tiDialogo.senteceloop[2] = "Se for possível.";
        alterouTexto = true;
    }

    void Analisando(){
        tiDialogo.senteceloop = new string[4];
        tiDialogo.senteceloop[0] = "Vou verficar isso para você detetive";
        tiDialogo.senteceloop[1] = "Espero que ajude no seu caso";
        tiDialogo.senteceloop[2] = "troca";
        tiDialogo.senteceloop[3] = "Qualquer informação já é de grande ajuda";
        tiDialogoControl.StartDialogue(tiDialogo);
        alterouTexto = false;
    }
    void NtemMaisAnalises(){
        tiDialogo.senteceloop = new string[4];
        tiDialogo.senteceloop[0] = "Não estou com tempo para ver isso agora detetive";
        tiDialogo.senteceloop[1] = "Se estivesse com mais tempo poderia ver melhor";
        tiDialogo.senteceloop[2] = "troca";
        tiDialogo.senteceloop[3] = "Tudo bem Kyle, você já foi de grande ajuda";
        EntrouNtemMaisAnalise = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(contador == 0 && EntrouNtemMaisAnalise == false && terminouConversa){
                NtemMaisAnalises();
            }         
            if (EntrouAnalisando && terminouConversa && contador > 0){
                dialogue.SetActive(false);
                AnaliseAnimator.SetBool("Rela",true);
                CadernoLimpo.SetActive(false);
                Evidencias.SetActive(true);
                caderno.EscreverEvidencias();
                textBox.SetActive(false);
                PoderDarResposta = true;
            } 
            if(!EntrouAnalisando && contador > 0 && alterouTexto == false){
                AntesAnalise();
            }           
        }
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
            isInRange = true;
            EntrouAnalisando = false;
            terminouConversa = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            no.SetActive(false);
            trocarCenaSim.SetActive(false);  
            dialogue.SetActive(true);
            noOriginal.SetActive(true);
            trocarCenaSimOriginal.SetActive(true);
            isInRange = false;
            terminouConversa = false;
            CadernoLimpo.SetActive(true);
            Evidencias.SetActive(false);
            AnaliseAnimator.SetBool("Rela",false);
            textBox.SetActive(true);
            TextoConfirma.SetBool("Abrir", false);
        }
    }
}
