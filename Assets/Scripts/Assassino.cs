using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Assassino 
{
    public static string NomeAssassino;
    public static int numeroAssassino;
    public static int numeroAssassinoSegundo;
    public static int numeroAssassinoTerceiro;
    public static bool podeContinuar;

    public static void EscolheAssassino(){
        /*
        0 Parceiro do detetive
        1 Policial
        2 Legista
        3 TI
        4 Delegado
        5 Jornalista
        6 Rico
        */
        numeroAssassino = Random.Range(0, 7);
        podeContinuar = false;
        while(!podeContinuar){
            numeroAssassinoSegundo = Random.Range(0, 7);
            numeroAssassinoTerceiro = Random.Range(0, 7);
            if(numeroAssassinoTerceiro != numeroAssassino && numeroAssassinoSegundo != numeroAssassino){
                podeContinuar = true;
            }
        }
    }
}
