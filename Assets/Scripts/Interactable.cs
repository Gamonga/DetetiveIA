using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    private bool entrouUmaVez = false;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public UnityEvent FechaJanela;
    public static Text E;
    public static Text ContornoE0;
    public static Text ContornoE1;
    public static Text ContornoE2;
    public static Text ContornoE3;

    private float i;

    // Start is called before the first frame update
    void Start()
    {
        E = GameObject.Find("E").GetComponent<Text>();
        ContornoE0 = GameObject.Find("ContornoE0").GetComponent<Text>();
        ContornoE1 = GameObject.Find("ContornoE1").GetComponent<Text>();
        ContornoE2 = GameObject.Find("ContornoE2").GetComponent<Text>();
        ContornoE3 = GameObject.Find("ContornoE3").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {                
            if (Input.GetKeyDown(interactKey))
            {
                Caderno.PermissaoAbrirCaderno = false;
                StopAllCoroutines();
                E.color = new Color(255,255,255,0);
                entrouUmaVez = true;
                interactAction?.Invoke();
            }
        }
        else{
            if(entrouUmaVez){
                entrouUmaVez = false;
                FechaJanela?.Invoke();
            }
        }
    }    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            StopAllCoroutines();
            E.color = new Color(255,255,255,0);
            ContornoE0.color = new Color(0,0,0,0);
            ContornoE1.color = new Color(0,0,0,0);
            ContornoE2.color = new Color(0,0,0,0);
            ContornoE3.color = new Color(0,0,0,0);
            StartCoroutine(LigaE());    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Caderno.PermissaoAbrirCaderno = true;
            isInRange = false;
            StopAllCoroutines();
            E.color = new Color(255,255,255,0);
            ContornoE0.color = new Color(0,0,0,0);
            ContornoE1.color = new Color(0,0,0,0);
            ContornoE2.color = new Color(0,0,0,0);
            ContornoE3.color = new Color(0,0,0,0);
            
        }
    }
    IEnumerator DesligaE ()
    {
        for(i=1;i>-0.5;i = i - 0.05f){
            E.color = new Color(255,255,255,i);
            ContornoE0.color = new Color(0,0,0,i);
            ContornoE1.color = new Color(0,0,0,i);
            ContornoE2.color = new Color(0,0,0,i);
            ContornoE3.color = new Color(0,0,0,i);
            yield return new WaitForSeconds(0.03f);
        }
        if(!Relatorio.entrouPreencher){
            StartCoroutine(LigaE());
        }
    }
    IEnumerator LigaE ()
    {
        for(i=0;i<1.5;i = i + 0.05f){
            E.color = new Color(255,255,255,i);
            ContornoE0.color = new Color(0,0,0,i);
            ContornoE1.color = new Color(0,0,0,i);
            ContornoE2.color = new Color(0,0,0,i);
            ContornoE3.color = new Color(0,0,0,i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(DesligaE());
    }
}
