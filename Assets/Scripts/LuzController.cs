using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LuzController : MonoBehaviour
{
    public bool Diurno;
    // Start is called before the first frame update
    public Light2D luz;
    private int contador;

    void Start()
    {        
        if((horario.Horario && Diurno)){
            luz.intensity = 1.0f;
        }
        else if(!horario.Horario && !Diurno){
            luz.intensity = 1.0f;
        }
        else{
            luz.intensity = 0.0f;
        }
        contador = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(contador<=10){
            if((horario.Horario && Diurno)){
            luz.intensity = 1.0f;
            }
            else if(!horario.Horario && !Diurno){
                luz.intensity = 1.0f;
            }
            else{
                luz.intensity = 0.0f;
            }
            contador++;
        }
    }
}
