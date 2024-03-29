﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int level;
    public bool horas;
    public string[] NomeDosObjetos = new string[40];
    public string[] nomeObjetoEvidenciasCaso1 = new string[40];
    public string[] nomeObjetoEvidenciasCaso2 = new string[40];
    public string[] nomeObjetoEvidenciasCaso3 = new string[40];
    public string[] nomeObjetoEvidenciasCaso4 = new string[40];
    public string[] nomeObjetoEvidenciasCaso5 = new string[40];
    public string[] nomeObjetoEvidenciasCaso6 = new string[40];
    public bool[] update = new bool[40];
    public int NumeroDeObjetos;
    public bool[] isOpen = new bool[40];
    public float volumeMusica;
    public float volumeSoundEffects;
    public float[] position = new float[3];
    public string[] nomeObjetoEvidencias = new string[40];
    public int NumeroDeEvidencias = 0;
    public int AndarAtual = 0;
    public int PortaDaCena = 0;
    public int NumeroDeportas;
    public int actualCrimeScene;
    public string policialUpdate;
    public string policial;
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
    public int selecionaArmaComSangueFalso;
    public string PrimeiraResposta;
    public string SegundaResposta;
    public string TerceiraResposta;
    public string QuartaResposta;
    public string QuintaResposta;
    public string PrimeiraRespostaIngles;
    public string SegundaRespostaIngles;
    public string TerceiraRespostaIngles;
    public string QuartaRespostaIngles;
    public static string Idioma;
    public bool PrecisaDeAuxilioEntradaSaida;
    public bool ajudaEntrada;
    public bool ajudaSaida;
    public bool PanoSangue;
    public bool PortaQuebrada;
    public static int PontuacaoDoPlayer;
    public int numeroAssassino;
    public int numeroAssassinoSegundo;
    public int numeroAssassinoTerceiro;
    public bool PrimeiraVezDialogoTransicao;
    public int NumeroDeCasosJogadoPeloPlayer;
    public bool depoimentoTestemunhaVisto;
    public bool depoimentoTestemunhaOuviu;
    public string OuviuTestemunha;
    public string VistoTestemunha;
    public string RelacaoTestemunha;
    public int RuidoArmaDoCrime;
    public bool entrouTutorialPensamentos;
    public bool entrouTutorialTestemunha;
    public bool entrouTutorialEvidencias;
    public bool entrouTutorialControles;
    public bool entrouTutorialIA;
    public bool entrouTutorialRelatorio;
    public int idadePersonagem;
    public int numeroMotivoVitimaComum;
    public bool ComeuAMaeDoPolicial;
    public bool sexoAtual;
    public bool sexoUltimoCaso;
    public PlayerData(movimento movimento)
    {
        level = SceneManager.GetActiveScene().buildIndex;
        sexoUltimoCaso = ScenesManager.eraHomemUltimoCaso;
        sexoAtual = SpawnObjects.SexoMasculino;
        ComeuAMaeDoPolicial = ScenesManager.ComeuAMaeDoPolicial;
        numeroMotivoVitimaComum = SpawnObjects.numeroMotivoVitimaComum;
        idadePersonagem = SpawnObjects.idadePersonagem;
        entrouTutorialPensamentos = ScenesManager.entrouTutorialPensamentos;
        entrouTutorialTestemunha = ScenesManager.entrouTutorialTestemunha;
        entrouTutorialEvidencias = ScenesManager.entrouTutorialEvidencias;
        entrouTutorialControles = ScenesManager.entrouTutorialControles;
        entrouTutorialIA = ScenesManager.entrouTutorialIA;
        entrouTutorialRelatorio = ScenesManager.entrouTutorialRelatorio;
        RuidoArmaDoCrime = SpawnObjects.RuidoArmaDoCrime;
        OuviuTestemunha = Testemunha.OuviuTestemunha;
        VistoTestemunha = Testemunha.VistoTestemunha; ;
        RelacaoTestemunha = Testemunha.RelacaoTestemunha; ;
        NumeroDeCasosJogadoPeloPlayer = PauseMenu.NumeroDeCasosJogadoPeloPlayer;
        PrimeiraVezDialogoTransicao = ScenesManager.PrimeiraVezDialogoTransicao;
        numeroAssassino = SpawnObjects.numeroAssassino;
        depoimentoTestemunhaVisto = Testemunha.depoimentoTestemunhaVisto;
        PortaQuebrada = SpawnObjects.PortaQuebrada;
        numeroAssassinoSegundo = SpawnObjects.numeroAssassinoSegundo;
        depoimentoTestemunhaOuviu = Testemunha.depoimentoTestemunhaOuviu;
        numeroAssassinoTerceiro = SpawnObjects.numeroAssassinoTerceiro;
        selecionaArmaComSangueFalso = SpawnObjects.selecionaArmaComSangueFalso;
        actualCrimeScene = ScenesManager.ActualScene;
        horas = horario.Horario;
        Idioma = MainMenu.idioma;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            salvaMovimento(movimento);
        }
        NumeroDeEvidencias = Caderno.posiçãoEvidencias;
        NumeroDeObjetos = SpawnObjects.NumeroDeObjetos;
        PrecisaDeAuxilioEntradaSaida = SpawnObjects.PrecisaDeAuxilioEntradaSaida;
        ajudaEntrada = SpawnObjects.ajudaEntrada;
        ajudaSaida = SpawnObjects.ajudaSaida;
        PanoSangue = SpawnObjects.PanoSangue;
        relacaoPergunta = Testemunha.relacaoPergunta;
        ouviuPergunta = Testemunha.ouviuPergunta;
        vistoPergunta = Testemunha.vistoPergunta;
        contadorAnalise = SpawnObjects.contador;
        contadorPensamento = Caderno.contadorPensamentos;
        policialUpdate = SpawnObjects.policialUpdateSalvar;
        policial = SpawnObjects.policialSalvar;
        SalvaRespostas();
        salvapessoas();
        for (i = 0; i < NumeroDeEvidencias; i++)
        {
            SalvaCaderno(i);
        }
        for (i = 0; i < NumeroDeObjetos; i++)
        {
            SalvaObjetos(i);
        }
        PortaDaCena = carregaPortaDaCena();
        NumeroDeportas = carregaNumeroDePortas();
        for (i = 0; i < NumeroDeportas; i++)
        {
            isOpen[PortaDaCena + i] = GameObject.Find("Porta" + (i + PortaDaCena)).GetComponent<PortaController>().isOpen;
        }
        AndarAtual = TrocaDeAndares.AndarAtual;
    }

    public void salvaMovimento(movimento movimento)
    {
        position[0] = movimento.transform.position.x;
        position[1] = movimento.transform.position.y;
        position[2] = movimento.transform.position.z;
    }
    public void SalvaRespostas()
    {
        PrimeiraResposta = SpawnObjects.PrimeiraResposta;
        SegundaResposta = SpawnObjects.SegundaResposta;
        TerceiraResposta = SpawnObjects.TerceiraResposta;
        QuartaResposta = SpawnObjects.QuartaResposta;
        QuintaResposta = SpawnObjects.QuintaResposta;
        PrimeiraRespostaIngles = SpawnObjects.PrimeiraRespostaIngles;
        SegundaRespostaIngles = SpawnObjects.SegundaRespostaIngles;
        TerceiraRespostaIngles = SpawnObjects.TerceiraRespostaIngles;
        QuartaRespostaIngles = SpawnObjects.QuartaRespostaIngles;
    }
    public PlayerData()
    {
        volumeMusica = MainMenu.volumeMusica;
        volumeSoundEffects = MainMenu.volumeSoundEffects;
    }
    public void salvapessoas()
    {
        Sanefuji = Caderno.Sanefuji;
        Jessie = Caderno.Jessie;
        kyle = Caderno.kyle;
        Steve = Caderno.Steve;
        Jhony = Caderno.Jhony;
        Devi = Caderno.Devi;
    }
    public int carregaNumeroDePortas()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                return 0;
            case 1:
                if (TrocaDeAndares.AndarAtual == 2)
                {
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
    public int carregaPortaDaCena()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                return 0;
            case 1:
                if (TrocaDeAndares.AndarAtual == 2)
                {
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

    public void SalvaCaderno(int i)
    {
        Debug.Log("entrou no salvar caderno");
        nomeObjetoEvidencias[i] = Caderno.evidencias[i].NomeObjeto;
        Debug.Log("NumeroDeCasosJogadoPeloPlayer: " + NumeroDeCasosJogadoPeloPlayer);
        switch (NumeroDeCasosJogadoPeloPlayer)
        {
            case 1:
                nomeObjetoEvidenciasCaso1[i] = Caderno.evidencias[i].NomeObjeto;
                break;
            case 2:
                nomeObjetoEvidenciasCaso1[i] = Caderno.nomeObjetoEvidenciasCaso1[i];
                nomeObjetoEvidenciasCaso2[i] = Caderno.evidencias[i].NomeObjeto;
                break;
            case 3:
                nomeObjetoEvidenciasCaso1[i] = Caderno.nomeObjetoEvidenciasCaso1[i];
                nomeObjetoEvidenciasCaso2[i] = Caderno.nomeObjetoEvidenciasCaso2[i];
                nomeObjetoEvidenciasCaso3[i] = Caderno.evidencias[i].NomeObjeto;
                break;
            case 4:
                nomeObjetoEvidenciasCaso1[i] = Caderno.nomeObjetoEvidenciasCaso1[i];
                nomeObjetoEvidenciasCaso2[i] = Caderno.nomeObjetoEvidenciasCaso2[i];
                nomeObjetoEvidenciasCaso3[i] = Caderno.nomeObjetoEvidenciasCaso3[i];
                nomeObjetoEvidenciasCaso4[i] = Caderno.evidencias[i].NomeObjeto;
                break;
            case 5:
                nomeObjetoEvidenciasCaso1[i] = Caderno.nomeObjetoEvidenciasCaso1[i];
                nomeObjetoEvidenciasCaso2[i] = Caderno.nomeObjetoEvidenciasCaso2[i];
                nomeObjetoEvidenciasCaso3[i] = Caderno.nomeObjetoEvidenciasCaso3[i];
                nomeObjetoEvidenciasCaso4[i] = Caderno.nomeObjetoEvidenciasCaso4[i];
                nomeObjetoEvidenciasCaso5[i] = Caderno.evidencias[i].NomeObjeto;
                break;
            case 6:
                nomeObjetoEvidenciasCaso1[i] = Caderno.nomeObjetoEvidenciasCaso1[i];
                nomeObjetoEvidenciasCaso2[i] = Caderno.nomeObjetoEvidenciasCaso2[i];
                nomeObjetoEvidenciasCaso3[i] = Caderno.nomeObjetoEvidenciasCaso3[i];
                nomeObjetoEvidenciasCaso4[i] = Caderno.nomeObjetoEvidenciasCaso4[i];
                nomeObjetoEvidenciasCaso5[i] = Caderno.nomeObjetoEvidenciasCaso5[i];
                nomeObjetoEvidenciasCaso6[i] = Caderno.evidencias[i].NomeObjeto;
                break;
        }
        Debug.Log("nomeObjetoEvidenciasCaso1: " + nomeObjetoEvidenciasCaso1[i]);
        update[i] = Caderno.update[i];
    }
    public void SalvaObjetos(int i)
    {
        NomeDosObjetos[i] = SpawnObjects.NomeDosObjetos[i];
    }

}
