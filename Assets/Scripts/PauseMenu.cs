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
    public Text CasosNumeros;
    private float contador;
    private float contadorSecundario;
    public static int NumeroDeCasosJogadoPeloPlayer;

    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.PrimeiroCaso)
        {
            NumeroDeCasosJogadoPeloPlayer = 1;
        }
        else{
            PlayerData data = SaveSystem.LoadPlayer();
            NumeroDeCasosJogadoPeloPlayer = data.NumeroDeCasosJogadoPeloPlayer;
        }
        contador = 0;
        contadorSecundario = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        abrirPauseMenu();
        if (contador <= 400)
        {
            Painel.color = new Color(0, 0, 0, 1.0f - contador / 250);
            if (MainMenu.NewGame)
            {
                CasosNumeros.color = new Color(255, 255, 255, 1.0f - contador / 250);
                if (PlayerData.Idioma == "ingles")
                {
                    CasosNumeros.text = "case " + NumeroDeCasosJogadoPeloPlayer.ToString();
                }
                else
                {
                    CasosNumeros.text = "caso " + NumeroDeCasosJogadoPeloPlayer.ToString() ;
                }
                contadorSecundario++;
                if(contadorSecundario > 75){
                    contador++;
                }
            }
            else{
                contador++;
            }
        }
        else
        {
            Destroy(Painel);
            Destroy(CasosNumeros);
        }
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
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
