using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PortaController : MonoBehaviour
{
    public bool isOpen = false;
    public string NomePorta;
    public AudioSource barulhoPorta;
    public GameObject PortaAberta;
    public GameObject PortaFechada;
    public PortaController proximaPorta;
    private int repetidor = 0;
    public bool portaOriginal;

    void Start()
    {
        repetidor = 0;
    }
    public void LoadPorta()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (!isOpen)
            {
                PortaAberta.SetActive(false);
                PortaFechada.SetActive(true);
            }
            else
            {
                PortaAberta.SetActive(true);
                PortaFechada.SetActive(false);
            }
        }
        else{
            PortaAberta.SetActive(false);
            PortaFechada.SetActive(true);
        }
    }
    public void OpenDoor()
    {
        proximaPorta.isOpen = !isOpen;
        proximaPorta.barulhoPorta.playOnAwake = true;
        if (isOpen)
        {
            isOpen = false;
            PortaAberta.SetActive(false);
            PortaFechada.SetActive(true);
        }
        else
        {
            isOpen = true;
            PortaAberta.SetActive(true);
            PortaFechada.SetActive(false);
        }
    }

    public void Update()
    {
        if (repetidor == 5 && MainMenu.NewGame == false && portaOriginal)
        {
            LoadPorta();
        }
        if (repetidor < 6)
        {
            repetidor++;
        }
    }
}
