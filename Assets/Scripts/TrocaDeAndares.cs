using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrocaDeAndares : MonoBehaviour
{
    public GameObject ParedeSuperior;
    public GameObject ParedeInferior;
    public static int AndarAtual = 0;
    public int VaiParaQualAndar=0;
    public bool isInRange;
    public static SpriteRenderer SegundoAndarSprite;
    // Update is called once per frame
    void Start(){
        SegundoAndarSprite = GameObject.Find("Delegaciapartesuperior").GetComponent<SpriteRenderer>();
        if(MainMenu.NewGame == false){     
            PlayerData data = SaveSystem.LoadPlayer(); 
            AndarAtual = data.AndarAtual;            
        }
        if(AndarAtual == 0){
            SegundoAndarSprite.color = new Color(255f, 255f, 255f, 1f);
            ParedeSuperior.SetActive(false);
            ParedeInferior.SetActive(true);
        }
        else if(AndarAtual == 1){
            SegundoAndarSprite.color = new Color(255f, 255f, 255f, 0f);
            ParedeSuperior.SetActive(false);
            ParedeInferior.SetActive(true);
        }
        else if(AndarAtual == 2){
            SegundoAndarSprite.color = new Color(255f, 255f, 255f, 1f);
            ParedeSuperior.SetActive(true);
            ParedeInferior.SetActive(false);
        }
    }
    public void Desaparecer(){
        if(SegundoAndarSprite.color.a > 1){
            SegundoAndarSprite.color = new Color(255f, 255f, 255f, 1f);
        }
        SegundoAndarSprite.color = SegundoAndarSprite.color - new Color(0.0f, 0.0f, 0.0f, 0.0083f);
    }

    public void Aparecer(){
        if(SegundoAndarSprite.color.a < 0){
            SegundoAndarSprite.color = new Color(255f, 255f, 255f, 0f);
        }
        SegundoAndarSprite.color = SegundoAndarSprite.color + new Color(0.0f, 0.0f, 0.0f, 0.0083f);
    }
    void FixedUpdate()
    {        
        if (isInRange)
        {
            if(VaiParaQualAndar == 0){
                AndarAtual = 0;
            }
            else if(VaiParaQualAndar == 1){
                ParedeSuperior.SetActive(false);
                ParedeInferior.SetActive(true);
                AndarAtual = 1;
            }
            else if(VaiParaQualAndar == 2){
                ParedeSuperior.SetActive(true);
                ParedeInferior.SetActive(false);
                AndarAtual = 2;
            }
        }
        if(AndarAtual == 2){
            Aparecer();
        }
        else if(AndarAtual == 1){
            Desaparecer();
        } 
        else if(AndarAtual == 0){
            Aparecer();
        }          
    }
    private void OnTriggerEnter2D(Collider2D collision)
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
