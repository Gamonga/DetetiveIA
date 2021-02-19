using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horario : MonoBehaviour
{
    // Start is called before the first frame u
    private float rand;
    public static bool Horario;
    void Start()
    {
        if(MainMenu.NewGame == false){
            PlayerData data = SaveSystem.LoadPlayer(); 
            Horario = data.horas;
        }
        else{
            rand= Random.Range(0.0f,1.0f);
            if(rand >= 0.75){
                Horario = true;
            }
            else{
                Horario = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
