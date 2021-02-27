using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData 
{
    public int level;    
    public bool horas;
    public string[] NomeDosObjetos = new string[30];
    public int NumeroDeObjetos;    
    public bool[] isOpen= new bool[25];
    public float volumeMusica;
    public float volumeSoundEffects;
    public float[] position= new float[3];    
    public string[] nomeObjetoEvidencias= new string[30];
    public int NumeroDeEvidencias = 0;
    public int AndarAtual = 0;
    public int PortaDaCena = 0;
    public int NumeroDeportas;
    public int actualCrimeScene;
    public int i = 0;
    public static int DificuldadeAtual;
    public bool kyle;
    public bool Steve;
    public bool Jessie;
    public bool Jhony;
    public bool Sanefuji;
    public bool Devi;
    public bool relacaoPergunta;
    public bool ouviuPergunta;
    public bool vistoPergunta;
    public int contadorAnalise;
    public int contadorPensamento;
    public string PrimeiraResposta;
    public string SegundaResposta;
    public string TerceiraResposta;
    public string QuartaResposta;
    public string QuintaResposta;
    public PlayerData(movimento movimento){
        level = SceneManager.GetActiveScene().buildIndex;
        actualCrimeScene = ScenesManager.ActualScene;
        horas = horario.Horario;
        position[0] = movimento.transform.position.x;
        position[1] = movimento.transform.position.y;
        position[2] = movimento.transform.position.z;      
        NumeroDeEvidencias = Caderno.posiçãoEvidencias;
        NumeroDeObjetos = SpawnObjects.NumeroDeObjetos;
        relacaoPergunta = Testemunha.relacaoPergunta;
        ouviuPergunta = Testemunha.ouviuPergunta;
        vistoPergunta = Testemunha.vistoPergunta;
        contadorAnalise= SpawnObjects.contador;
        contadorPensamento = Caderno.contadorPensamentos;
        SalvaRespostas();
        salvapessoas();
        for(i=0;i<NumeroDeEvidencias;i++){
            SalvaCaderno(i);
        }
        for(i=0;i<NumeroDeObjetos;i++){
            SalvaObjetos(i);
        }        
        PortaDaCena = carregaPortaDaCena();
        NumeroDeportas = carregaNumeroDePortas();
        for(i=0;i<NumeroDeportas;i++){
            isOpen[PortaDaCena+i] = GameObject.Find("Porta"+(i+PortaDaCena)).GetComponent<PortaController>().isOpen;
        }
        AndarAtual = TrocaDeAndares.AndarAtual;
    }
    public void SalvaRespostas(){
        PrimeiraResposta = SpawnObjects.PrimeiraResposta;
        SegundaResposta = SpawnObjects.SegundaResposta;
        TerceiraResposta = SpawnObjects.TerceiraResposta;
        QuartaResposta = SpawnObjects.QuartaResposta;
        QuintaResposta = SpawnObjects.QuintaResposta;
    }
    public PlayerData(){
        volumeMusica = MainMenu.volumeMusica;
        volumeSoundEffects = MainMenu.volumeSoundEffects;
    }
    public void salvapessoas(){
        Sanefuji = Caderno.Sanefuji;
        Jessie = Caderno.Jessie;
        kyle = Caderno.kyle;
        Steve = Caderno.Steve;
        Jhony = Caderno.Jhony;
        Devi = Caderno.Devi;
    }
    public int carregaNumeroDePortas(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                return 0; 
            case 1:
                if(TrocaDeAndares.AndarAtual == 2){
                    return 4;
                }
                return 5;    
            case 2:
                return 3;    
            case 3:
                return 6;  
        }
        return 0;
    }
    public int carregaPortaDaCena(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                return 0; 
            case 1:
                if(TrocaDeAndares.AndarAtual == 2){
                    return 6;
                }  
                return 1;  
            case 2:
                return 10;  
            case 3:
                return 15;   
        }
        return 0;
    }

    public void SalvaCaderno(int i){            
        nomeObjetoEvidencias[i] = Caderno.evidencias[i].NomeObjeto;
    }
    public void SalvaObjetos(int i){     
        NomeDosObjetos[i] = SpawnObjects.NomeDosObjetos[i];
    }

}
