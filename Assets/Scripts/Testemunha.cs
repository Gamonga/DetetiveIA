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
    public string NomeDaTestemunha;
    private string evidenciaUsada;
    private string NomeEvidenciaDiscordaOuviu;
    private string NomeEvidenciaDiscordaViu;
    private string NomeEvidenciaDiscordaRelacao;
    public GameObject RelaçãoComVitimaB;
    private Queue<string> sentence;
    public Text texto;
    public Text Nome;
    private bool isInRange;
    private bool relacaoPergunta;
    private bool ouviuPergunta;
    private bool vistoPergunta;
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
    // Start is called before the first frame update
    void Start()
    {   
        entrouPreencher = false;
        escrevendo = false;
        sentence = new Queue<string>();   
        relacaoPergunta = true;
        ouviuPergunta = true;
        perguntando = false;
        vistoPergunta = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){            
            if (Input.GetKeyDown(KeyCode.E) && entrouPreencher == false){
                Caderno.PermissaoAbrirCaderno = false;
                DecideVerdades();
                sentence.Enqueue("Prazer me chamo " + NomeDaTestemunha);
                sentence.Enqueue("O que deseja saber detetive?");
                dialogo.SetBool("isOpen", true);           
                entrouPreencher = true;     
                fraseAtual = sentence.Dequeue();
                StartCoroutine(typeSentence(fraseAtual));
            }
            else if(Input.GetKeyDown(KeyCode.E) && entrouPreencher == true && escrevendo == false && perguntando == false){                          
                fraseAtual = sentence.Dequeue();
                if(fraseAtual != "Pergunta" && fraseAtual != "Terminou"){
                    StartCoroutine(typeSentence(fraseAtual));
                }      
                else if(fraseAtual == "Pergunta"){
                    ConcordaB.SetActive(true);
                    DiscordaB.SetActive(true);
                    DuvidaB.SetActive(true); 
                    perguntando = true;
                }
                else if(fraseAtual == "Terminou"){
                    fraseAtual = "O que deseja saber detetive?";
                    StartCoroutine(typeSentence(fraseAtual));
                    if(vistoPergunta){
                        VistoB.SetActive(true);
                    }
                    if(ouviuPergunta){
                        OuviuB.SetActive(true);
                    }
                    if(relacaoPergunta){
                        RelaçãoComVitimaB.SetActive(true);
                    }                   
                    perguntando = true;
                }
                if(fraseAtual == "O que deseja saber detetive?"){
                    if(vistoPergunta){
                        VistoB.SetActive(true);
                    }
                    if(ouviuPergunta){
                        OuviuB.SetActive(true);
                    }
                    if(relacaoPergunta){
                        RelaçãoComVitimaB.SetActive(true);
                    }                   
                    perguntando = true;
                }
            }
            else if(Input.GetKeyDown(KeyCode.E) && entrouPreencher == true && escrevendo == true && perguntando == false){                
                StopAllCoroutines();
                texto.text = fraseAtual;
                escrevendo = false;
            }            
        }
        else{
        } 
    }
    public void DecideVerdades(){
        Nome.text = NomeDaTestemunha;
        VistoVerdade = SpawnObjects.VistoVerdade;
        OuviuVerdade = SpawnObjects.OuviuVerdade;
        RelaçãoVerdade = "true";
    }
    public void Concorda(){
        sentence.Clear();
        switch(PerguntaFeita){
            case "visto":
                if(VistoVerdade == "true"){
                    sentence.Enqueue("Acredito que ele tenha entrado por lá tbm");
                }
                else{
                    sentence.Enqueue("Isso é tudo que eu sei detetive");
                }
                sentence.Enqueue("Terminou");
                vistoPergunta = false;
            break;
            case "ouviu":
                if(OuviuVerdade == "true"){
                    sentence.Enqueue("Ouvi um disparo de arma para falar a verdade");
                }
                else{
                    sentence.Enqueue("Isso é tudo que eu sei detetive");
                }
                sentence.Enqueue("Terminou");
                ouviuPergunta = false;
            break;
            case "relacao":
                if(RelaçãoVerdade == "true"){
                    sentence.Enqueue("Só sei que ele gostava de ficar sozinho");
                }
                else{
                    sentence.Enqueue("Isso é tudo que eu sei detetive");
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
    public void escolheuEvidencia(Text evidencia){
        sentence.Clear();
        if(isInRange){
            evidenciaUsada = evidencia.text;
            switch(PerguntaFeita){
                case "visto":
                    if(VistoVerdade == "false"){
                        if(evidenciaUsada == NomeEvidenciaDiscordaViu){
                            sentence.Enqueue("Acredito que ele tenha entrado por lá tbm");
                        }
                        else{
                            sentence.Enqueue("Fazer acusações falsas é algo grave detetive");
                        }
                    }
                    else{
                        sentence.Enqueue("Isso é tudo que eu sei detetive");
                    }
                    sentence.Enqueue("Terminou");
                    vistoPergunta = false;
                break;
                case "ouviu":
                    if(OuviuVerdade == "false"){
                        if(evidenciaUsada == NomeEvidenciaDiscordaOuviu){
                            sentence.Enqueue("Ouvi um disparo de arma para falar a verdade");
                        }
                        else{
                            sentence.Enqueue("Fazer acusações falsas é algo grave detetive");
                        }
                    }
                    else{
                        sentence.Enqueue("Isso é tudo que eu sei detetive");
                    }
                    sentence.Enqueue("Terminou");
                    ouviuPergunta = false;
                break;
                case "relacao":
                    if(RelaçãoVerdade == "false"){
                        if(evidenciaUsada == NomeEvidenciaDiscordaRelacao){
                            sentence.Enqueue("Só sei que ele gostava de ficar sozinho");
                        }
                        else{
                            sentence.Enqueue("Fazer acusações falsas é algo grave detetive");
                        }                    
                    }
                    else{
                        sentence.Enqueue("Isso é tudo que eu sei detetive");
                    }
                    sentence.Enqueue("Terminou");
                    relacaoPergunta = false;
                break;           
            }
            caderno.SetBool("Rela",false);
            dialogo.SetBool("isOpen", true);
            perguntando = false;
            fraseAtual = sentence.Dequeue();
            StartCoroutine(typeSentence(fraseAtual));
        }
    }
    public void Discorda(){
        sentence.Enqueue("Você teria alguma prova para discorda do que eu disse?");
        CadernoLimpo.SetActive(false);
        Evidencias.SetActive(true);
        caderno.SetBool("Rela",true);
        dialogo.SetBool("isOpen", false);
        ConcordaB.SetActive(false);
        DiscordaB.SetActive(false);
        DuvidaB.SetActive(false);        
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void Duvida(){
        sentence.Clear();
        switch(PerguntaFeita){
            case "visto":
                if(VistoVerdade == "duvida"){
                    sentence.Enqueue("Acredito que ele tenha entrado por lá tbm");
                }
                else{
                    sentence.Enqueue("Isso é tudo que eu sei detetive");
                }
                sentence.Enqueue("Terminou");
                vistoPergunta = false;
            break;
            case "ouviu":
                if(OuviuVerdade == "duvida"){
                    sentence.Enqueue("Ouvi um disparo de arma para falar a verdade");
                }
                else{
                    sentence.Enqueue("Isso é tudo que eu sei detetive");
                }
                sentence.Enqueue("Terminou");
                ouviuPergunta = false;
            break;
            case "relacao":
                if(RelaçãoVerdade == "duvida"){
                    sentence.Enqueue("Só sei que ele gostava de ficar sozinho");
                }
                else{
                    sentence.Enqueue("Isso é tudo que eu sei detetive");
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
    public void Visto(){
        PerguntaFeita = "visto";
        sentence.Enqueue("Estava bem tarde, e eu assustado consegui só ver pela fresta da porta");
        sentence.Enqueue("Eu vi um homem saindo pela no meio do escuro");
        sentence.Enqueue("Pergunta");
        VistoB.SetActive(false);
        OuviuB.SetActive(false);
        RelaçãoComVitimaB.SetActive(false);         
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void Ouviu(){
        PerguntaFeita = "ouviu";
        sentence.Enqueue("Eu não consegui ouvir muita coisa");
        sentence.Enqueue("Acredito que nesse quesito não tenha muito para te falar");
        sentence.Enqueue("Pergunta");
        VistoB.SetActive(false);
        OuviuB.SetActive(false);
        RelaçãoComVitimaB.SetActive(false); 
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }
    public void RelaçãoComVitima(){
        PerguntaFeita = "relacao";
        sentence.Enqueue("Eu o conhecia só de vista");
        sentence.Enqueue("Sempre achei ele um homem tranquilo com todos");
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sentence.Clear();
            Nome.text = "";
            texto.text = "Deseja voltar a cena do crime?";
            dialogo.SetBool("isOpen", false);
            Caderno.PermissaoAbrirCaderno = true;
            caderno.SetBool("Rela",false);
            ConcordaB.SetActive(false);
            DiscordaB.SetActive(false);
            DuvidaB.SetActive(false);
            VistoB.SetActive(false);
            OuviuB.SetActive(false);
            RelaçãoComVitimaB.SetActive(false); 
            isInRange = false;
            perguntando = false;
            entrouPreencher = false;
        }
    }

    IEnumerator typeSentence (string sentence)
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
