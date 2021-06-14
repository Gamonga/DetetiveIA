using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class TrocaIdioma : MonoBehaviour
{
    public Text sim;
    public Text nao;
    public Text roubo;
    public Text justiça;
    public Text tortura;
    public Text finalizar;
    public Text suicidio;
    public Text desvença;
    public Text Raiva;
    public Text nomeDetetive;
    public Text nomeParceiro;
    public Text pessoas;
    public Text evidencias;
    public Text pensamentos;
    public Text juntarPensamentos;
    public Text preencher;
    public Text selecionaOutro;
    public Text simAnalise;
    public Text noAnalise;
    public Text semEvidencias;
    public Text anotacoes;
    public Text departamentoPolica;
    public Text servirProteger;
    public Text acredita;
    public Text duvida;
    public Text discorda;
    public Text visto;
    public Text ouviu;
    public Text relacao;
    public Text simTextoBox;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerData.Idioma == "ingles")
        {
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                sim.text = "Yes";
                nao.text = "Not now";
                nomeDetetive.text = "Detective: David Mills";
                nomeParceiro.text = "Partner: Stevie Gary";
                juntarPensamentos.text = "Bring the thoughts together";
                selecionaOutro.text = "Select other thoughts";
                anotacoes.text = "Notes:";
                departamentoPolica.text = "Police Department of Grande Vale";
                servirProteger.text = "'Serve and Protect'";
                pessoas.text = "Persons";
                evidencias.text = "Evidences";
                pensamentos.text = "Thoughts";
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                roubo.text = "Theft";
                justiça.text = "Jusitce";
                tortura.text = "Pleasure";
                finalizar.text = "Deliver Report";
                suicidio.text = "Suicide";
                desvença.text = "Revenge";
                Raiva.text = "Anger";
                preencher.text = "Make the report";
                simAnalise.text = "Yes";
                noAnalise.text = "Not now";
                semEvidencias.text = "No evidence";
            }
            if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 4)
            {
                acredita.text = "Believe";
                duvida.text = "Doubt";
                discorda.text = "Disagree";
                visto.text = "What was seen?";
                ouviu.text = "What was heard?";
                relacao.text = "Relationship with the victim?";
                simTextoBox.text = "Yes";
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                sim.text = "Sim";
                nao.text = "Agora não";
                nomeDetetive.text = "Detetive: David Mills";
                nomeParceiro.text = "Pareceiro: Stevie Gary";
                juntarPensamentos.text = "Juntar os pensamentos";
                selecionaOutro.text = "Selecionar outros pensamentos";
                anotacoes.text = "Anotações:";
                departamentoPolica.text = "Departamento de polícia de Grande Vale";
                servirProteger.text = "'Servir e Proteger'";
                pessoas.text = "Pessoas";
                evidencias.text = "Evidências";
                pensamentos.text = "Pensamentos";
            }
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                roubo.text = "Roubo";
                justiça.text = "Justiça";
                tortura.text = "Prazer";
                finalizar.text = "Entregar Relatório";
                suicidio.text = "Suicídio";
                desvença.text = "Vingança";
                Raiva.text = "Raiva";
                preencher.text = "Fazer o relatório";
                simAnalise.text = "Sim";
                noAnalise.text = "Agora não";
                semEvidencias.text = "Sem evidências";
            }
            if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 4)
            {
                acredita.text = "Acreditar";
                duvida.text = "Duvidar";
                discorda.text = "Discordar";
                visto.text = "O que foi visto?";
                ouviu.text = "O que foi ouvido?";
                relacao.text = "Relação com a vítima?";
                simTextoBox.text = "Sim";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
