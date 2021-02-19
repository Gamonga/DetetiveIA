using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue:MonoBehaviour
{
    public string nameperson1;
    public string nameperson2;
    public string[] sentences;
    public string[] sentences2;
    public string[] senteceloop;
    public Sprite sprite1;
    public Sprite sprite2;
    private float selecionador = 0;

    public bool random = true;

    void Start()
    {
        selecionador = Random.Range(0.0f,1.0f);
        if (selecionador >= 0.5 && random)
        {
            if(sentences2 !=null){
                sentences = sentences2;
            }
        }
    }

}
