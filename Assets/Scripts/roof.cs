using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class roof : MonoBehaviour
{
    public SpriteRenderer telhado;
    public bool isInRange;    
    public Light2D luzTelhado;
    public Light2D luz2andar;
    public Light2D luz1andar;
    public Light2D luzTraseira1;
    public Light2D luzTraseira2;
    public Light2D luzTraseira3;
    public Light2D luzfrontal;
    public Light2D luzfrontal2;
    public void Desaparecer(){
        if(telhado.color.a > 1){
            telhado.color = new Color(255f, 255f, 255f, 1f);
        }
        telhado.color = telhado.color - new Color(0.0f, 0.0f, 0.0f, 0.05f);
    }

    public void Aparecer(){
        if(telhado.color.a < 0){
            telhado.color = new Color(255f, 255f, 255f, 0f);
        }
        telhado.color = telhado.color + new Color(0.0f, 0.0f, 0.0f, 0.05f);
    }
    void FixedUpdate()
    {
        if (isInRange)
        {
            Desaparecer();
        }
        else{
            Aparecer();
        }
        if((SceneManager.GetActiveScene().buildIndex == 1) && (horario.Horario == false)){
            if(TrocaDeAndares.AndarAtual == 0){
                luzfrontal.intensity = 1f;
                luzfrontal2.intensity = 1f;
                luzTelhado.intensity = 0.8f;
                luz2andar.intensity = 0;
                luz1andar.intensity = 0;
                luzTraseira1.transform.position = new Vector3(-21.75f,33f,-20f);
                luzTraseira2.transform.position = new Vector3(-0.4f,33f,-20f);
                luzTraseira3.transform.position = new Vector3(21.76f,33f,-20f);
            }
            else if(TrocaDeAndares.AndarAtual == 1){
                luzfrontal.intensity = 0;
                luzfrontal2.intensity = 0f;
                luzTelhado.intensity = 0;
                luz2andar.intensity = 0;
                luz1andar.intensity = 0.8f;
                luzTraseira1.transform.position = new Vector3(-21.75f,27.75f,-20f);
                luzTraseira2.transform.position = new Vector3(-0.4f,27.75f,-20f);
                luzTraseira3.transform.position = new Vector3(21.76f,27.75f,-20f);
            }
            else if(TrocaDeAndares.AndarAtual == 2){
                luzfrontal.intensity = 1;
                luzfrontal2.intensity = 1f;
                luzTelhado.intensity = 0;
                luz2andar.intensity = 0.8f;
                luz1andar.intensity = 0;
                luzTraseira1.transform.position = new Vector3(-21.75f,31.7f,-20f);
                luzTraseira2.transform.position = new Vector3(-0.4f,31.7f,-20f);
                luzTraseira3.transform.position = new Vector3(21.76f,31.7f,-20f);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
