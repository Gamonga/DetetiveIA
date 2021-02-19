using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpo : MonoBehaviour
{
    private string nomeCompleto;
    
    string NameGenerator()
    {
        string nome;
        string sobrenome;
        nome = "Paulo";
        sobrenome = "Rubens";
        return (nome + sobrenome);
    }
    // Start is called before the first frame update
    void Start()
    {
        nomeCompleto = NameGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
