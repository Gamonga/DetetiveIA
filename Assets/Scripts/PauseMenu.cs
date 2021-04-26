using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PauseMenu : MonoBehaviour
{
    public Animator Menu;
    public GameObject Pause;
    public GameObject Options;
    public Image Painel;
    private float contador;

    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        abrirPauseMenu();
        if(contador<= 300){
            Painel.color = new Color(0,0,0, 1.0f - contador/300);
            contador++;
        }
        else{
            Destroy(Painel);
        }
    }
    public void Quit(){
        SceneManager.LoadScene(0);
    }
    public void Resume(){
        Menu.SetBool("Abrir", false);
        open = false;
    }
    void abrirPauseMenu()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!open)
            {
                Caderno.PermissaoAbrirCaderno = false;
                Menu.SetBool("Abrir", true);
                open = true;
                Options.SetActive(false);
                Pause.SetActive(true);
            }
            else
            {
                Caderno.PermissaoAbrirCaderno = true;
                Menu.SetBool("Abrir", false);
                open = false;
                Options.SetActive(false);
                Pause.SetActive(true);
            }
        }
    }
}
