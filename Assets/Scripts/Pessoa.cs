using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pessoa : MonoBehaviour
{
    public string nome;
    [TextArea(3,20)]
    public string description;
    [TextArea(3,20)]
    public string descriptionIngles;
    void Start()
    {
        if (PlayerData.Idioma == "ingles")
        {
            description = descriptionIngles;
        }
    }
}
