﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class MainMenu : MonoBehaviour
{
    public AudioMixer SoundEffectsMixer;
    public AudioMixer MusicMixer;
    public static bool NewGame = false;
    public movimento movimento;
    public Slider MusicSlider;
    public Slider SoundEffectSlider;
    public static string idioma;
    public static float volumeMusica = 0;
    public static float volumeSoundEffects = 0;
    public GameObject mainmenu;
    public Text NovoJogo;
    public Text Options;
    public Text Options2;
    public Text Back;
    public Text Back2;
    public Text Back3;
    public Text Save;
    public Text Save2;
    public Text Audio;
    public Text Audio2;
    public Text Music;
    public Text SoundEffects;
    public Text Language;
    public Text Language2;
    public Text CarregaGame;
    public Text Quit;
    public GameObject acentos;
    public GameObject acentos2;
    public Image Painel;
    private float contador;
    public static bool PrimeiroCaso = false;
    public Text testemunhaTexto;
    public Animator animatorTutorial;
    public bool entrouTutorial;
    public bool contadorTelaPreta;
    void Start()
    {
        entrouTutorial = false;
        contadorTelaPreta = true;
        contador = 0;

        CarregaMusicas();
        SetSoundEffectSlider();
        SetMusicSlider();
        CarregaIdioma();
    }
    void FixedUpdate()
    {
        if (contador <= 100 && contadorTelaPreta)
        {
            contador++;
            Painel.color = new Color(contador / 100, contador / 100, contador / 100, 1.0f);
            if (contador == 100)
            {
                contador = contador/10;
                contadorTelaPreta = false;
            }
        }
        if (entrouTutorial)
        {
            contador--;
            Painel.color = new Color(contador / 10, contador / 10, contador / 10, 1.0f);
        }
        if (entrouTutorial && Input.GetKeyDown(KeyCode.Escape))
        {
            PlayGameDepoisTutorial();
        }

    }

    public void CarregaIdioma()
    {
        if (File.Exists(Application.persistentDataPath + "/player.fun"))
        {
            idioma = PlayerData.Idioma;
            if (idioma == "portugues")
            {
                EscolheuPortugues();
            }
            else
            {
                EscolheuIngles();
            }
        }
        else
        {
            EscolheuIngles();
        }
    }
    public void CarregaMusicas()
    {
        if (File.Exists(Application.persistentDataPath + "/music.fun"))
        {
            PlayerData datamusica = SaveSystem.LoadMusica();
            MusicSlider.value = datamusica.volumeMusica;
            SoundEffectSlider.value = datamusica.volumeSoundEffects;
        }
    }
    public void PlayGame()
    {
        mainmenu.SetActive(false);
        contadorTelaPreta = false;
        entrouTutorial = true;
        animatorTutorial.SetBool("AbrirTutorial", true);
        if (PlayerData.Idioma == "ingles")
        {
            testemunhaTexto.text = "<color=red>Controles</color>" + "\n" +
            "Para se movimentar use 'W''A''S''D' ou as setas do teclado" + "\n" +
            "interagir com objetos pressione 'E'" + "\n" +
            "avançar nos diálogos pressione 'E'" + "\n" +
            "fechar e abrir o caderno pressione 'TAB'" + "\n" +
            "Abrir menu de pause pressione 'ESC'" + "\n" +
            "Aperte esc para fechar este menu";
        }
        else
        {
            testemunhaTexto.text = "<color=red>Controles</color>" + "\n" +
            "Para se movimentar use 'W''A''S''D' ou as setas do teclado" + "\n" +
            "interagir com objetos pressione 'E'" + "\n" +
            "avançar nos diálogos pressione 'E'" + "\n" +
            "fechar e abrir o caderno pressione 'TAB'" + "\n" +
            "Abrir menu de pause pressione 'ESC'" + "\n" +
            "Aperte esc para fechar este menu";
        }
    }
    public void PlayGameDepoisTutorial()
    {
        NewGame = true;
        PrimeiroCaso = true;
        PlayerData.DificuldadeAtual = 3;
        CarregaMusicas();
        SavePlayer();
        if (Random.value >= 0.5)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

    public void LoadGame()
    {
        NewGame = false;
        PrimeiroCaso = false;
        PlayerData data = SaveSystem.LoadPlayer();
        CarregaMusicas();
        SavePlayer();
        SceneManager.LoadScene(data.level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EscolheuIngles()
    {
        idioma = "ingles";
        NovoJogo.text = "New Game";
        Options.text = "Options";
        CarregaGame.text = "Load Game";
        Quit.text = "Quit";
        Options2.text = "Options";
        Back.text = "Back";
        Back2.text = "Back";
        Back3.text = "Back";
        Save.text = "Save";
        Save2.text = "Save";
        Audio.text = "Audio";
        Audio2.text = "Audio";
        SoundEffects.text = "Sound Effects";
        Music.text = "Music";
        Language.text = "Language";
        Language2.text = "Language";


    }
    public void EscolheuPortugues()
    {
        idioma = "portugues";
        NovoJogo.text = "Novo Jogo";
        Options.text = "Opcoes";
        CarregaGame.text = "Carregar Jogo";
        Quit.text = "Sair";
        Options2.text = "Opcoes";
        Back.text = "Voltar";
        Back2.text = "Voltar";
        Back3.text = "Voltar";
        Save.text = "Salvar";
        Save2.text = "Salvar";
        Audio.text = "Som";
        Audio2.text = "Som";
        SoundEffects.text = "Efeitos Sonoros";
        Music.text = "Música";
        Language.text = "Idioma";
        Language2.text = "Idioma";
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(movimento);
        SaveSystem.SaveMusic();
    }
    public void SaveMusica()
    {
        SaveSystem.SaveMusic();
    }

    public void SetVolumeSoundEffects(float volume)
    {
        SoundEffectsMixer.SetFloat("soundEffectsVolume", volume);
        volumeSoundEffects = volume;
    }
    public void SetVolumeGeral(float volume)
    {
        MusicMixer.SetFloat("MusicVolume", volume);
        volumeMusica = volume;
    }

    public void SetSoundEffectSlider()
    {
        SoundEffectsMixer.GetFloat("soundEffectsVolume", out volumeSoundEffects);
        SoundEffectSlider.value = volumeSoundEffects;
    }

    public void SetMusicSlider()
    {
        MusicMixer.GetFloat("MusicVolume", out volumeMusica);
        MusicSlider.value = volumeMusica;
    }
}
