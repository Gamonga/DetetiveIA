using System.Collections;
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
    public static float volumeMusica = 0;
    public static float volumeSoundEffects = 0;
    void Start()
    {
        CarregaMusicas();
        SetSoundEffectSlider();
        SetMusicSlider();             
    }

    public void CarregaMusicas(){
        if (File.Exists(Application.persistentDataPath + "/music.fun")){
            PlayerData datamusica = SaveSystem.LoadMusica();
            MusicSlider.value = datamusica.volumeMusica;
            SoundEffectSlider.value = datamusica.volumeSoundEffects;
        }
    }
    public void PlayGame(){
        NewGame = true;
        PlayerData.DificuldadeAtual = 3;        
        CarregaMusicas();
        if(Random.value >= 0.5){
            SceneManager.LoadScene(2);
        }
        else{
            SceneManager.LoadScene(3);
        }
    }

    public void LoadGame(){
        NewGame = false;
        PlayerData data = SaveSystem.LoadPlayer();        
        CarregaMusicas();
        SceneManager.LoadScene(data.level);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void SavePlayer(){
        SaveSystem.SavePlayer(movimento);
        SaveSystem.SaveMusic();
    }
    public void SaveMusica(){
        SaveSystem.SaveMusic();
    }
    
    public void SetVolumeSoundEffects(float volume){
        SoundEffectsMixer.SetFloat("soundEffectsVolume", volume);
        volumeSoundEffects = volume;
    }
    public void SetVolumeGeral(float volume){
        MusicMixer.SetFloat("MusicVolume", volume);
        volumeMusica = volume;
    }

    public void SetSoundEffectSlider(){
        SoundEffectsMixer.GetFloat("soundEffectsVolume",out volumeSoundEffects);
        SoundEffectSlider.value = volumeSoundEffects;
    }

    public void SetMusicSlider(){
        MusicMixer.GetFloat("MusicVolume",out volumeMusica);
        MusicSlider.value = volumeMusica;
    }
}
