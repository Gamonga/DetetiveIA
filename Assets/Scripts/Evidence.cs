using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Evidence : MonoBehaviour
{

    public string nome;
    public bool sangue;
    [TextArea(3,10)]
    public string description;
    [TextArea(3,10)]
    public string descriptionUpdate;
    public string tamanho;
    public Sprite ImagemObjeto;
    public string NomeObjeto;
    public int NumeroCaderno;
    public int weaponRuido;
    public bool weaponInstantDeath;
    public bool TemPlanejamento;
    public bool NTemPlanejamento;
    public string weaponDescription;  
    public int Dificuldade;     
    public int tierArma;    
}
