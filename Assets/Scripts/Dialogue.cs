using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue:MonoBehaviour
{
    public string nameperson1;
    public string nameperson2;
    [TextArea(3,20)]
    public string[] sentences;
    [TextArea(3,20)]
    public string[] sentences2;
    [TextArea(3,20)]
    public string[] senteceloop;
    [TextArea(3,20)]
    public string[] sentencesIngles;
    [TextArea(3,20)]
    public string[] sentences2Ingles;
    [TextArea(3,20)]
    public string[] senteceloopIngles;
    public Sprite spriteDetetivePaisagem;
    public Sprite spriteDetetivePensando;
    public Sprite spriteDetetiveEmbaraçado;
    public Sprite spriteDetetiveDesgosto;
    public Sprite spriteDetetiveCaderno;
    public Sprite spriteSecundarioPaisagem;
    public Sprite spriteSecundarioPensando;
    public Sprite spriteSecundarioEmbaraçado;
    public Sprite spriteSecundarioDesgosto;
    public Sprite spriteSecundarioCaderno;
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
