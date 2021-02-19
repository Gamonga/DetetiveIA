using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Animator Menu;
    public GameObject Pause;
    public GameObject Options;

    private bool open;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        abrirPauseMenu();
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
                Menu.SetBool("Abrir", true);
                open = true;
                Options.SetActive(false);
                Pause.SetActive(true);
            }
            else
            {
                Menu.SetBool("Abrir", false);
                open = false;
                Options.SetActive(false);
                Pause.SetActive(true);
            }
        }
    }
}
