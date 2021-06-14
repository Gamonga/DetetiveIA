using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public Text textoNumeroCasos;
    public Caderno cadernoOriginal;
    public GameObject VitimasMulheres;
    public GameObject VitimasHomens;
    public GameObject VitimasJovens;
    public GameObject VitimasVelhos;
    public GameObject VitimasCorruptas;
    public GameObject VitimasRicas;
    public GameObject Delegado;
    public GameObject Policial;
    public GameObject Jornalista;
    public GameObject Legista;
    public GameObject TI;
    public GameObject Rico;
    public GameObject Parceiro;
    public GameObject Roubo;
    public GameObject Evidencias;
    public GameObject Desavença;
    public GameObject Raiva;
    public GameObject Prazer;
    public GameObject Justica;
    public GameObject SemEvidencia;
    public GameObject Finalizar;
    private Queue<string> sentence;
    public Text texto;
    public Animator PixelArt;
    public Animator Transition;
    public Animator caderno;
    public movimento movimento;
    private string fraseAtual;
    public static bool escrevendo = false;
    public string respostaTexto;
    public int numeroDaPergunta;
    public static int Pontuacao;
    public static bool AcertouAssassino;
    public static bool jogoFinalizado;
    public static bool perguntando = false;
    public static int paginaAtual;
    public static int respostaAssassino;
    public static bool acertouAssassino;
    public static int interesseResposta;
    public static bool acertouInteresse;
    public static bool ClickCaderno;
    // Start is called before the first frame update
    void Start()
    {
        DesativaAssassino();
        ClickCaderno = false;
        acertouInteresse = false;
        acertouAssassino = false;
        paginaAtual = 1;
        AcertouAssassino = false;
        jogoFinalizado = false;
        numeroDaPergunta = 1;
        Pontuacao = 0;
        if (PlayerData.Idioma == "ingles")
        {
            textoNumeroCasos.text = "CASE " + paginaAtual.ToString();
        }
        else
        {
            textoNumeroCasos.text = "CASO " + paginaAtual.ToString();
        }
        escrevendo = false;
        sentence = new Queue<string>();
        Finalizar.SetActive(false);
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Enqueue("Já sei o que aconteceu.");
            sentence.Enqueue("O assassino está entre nós nesse exato momento.");
            sentence.Enqueue("E irei mostrar para todos, seguindo o meu raciocínio.");
            sentence.Enqueue("E a solução para essa série de casos pode começar com um simples erro do assassino.");
            sentence.Enqueue("Um item que ele deixou cair em um de seus assassinatos que indica quem ele pode ser.");
            sentence.Enqueue("E aqui está o item:");
            sentence.Enqueue("Esse item não teve correlação com o caso em que ele apareceu.");
            sentence.Enqueue("O assassino também pode falhar e deixar itens como esse pelo local.");
            sentence.Enqueue("Assim como ele deixa os seus interesses de assassinato também transparecer nas vítimas.");
            sentence.Enqueue("E esse interesse é:");
            sentence.Enqueue("Matando todas essas pessoas o assassino deixou claro suas intenções.");
            sentence.Enqueue("O motivo por trás disso tudo.");
            sentence.Enqueue("Ele pode ter mudado de caso a caso, mas o motivo real do assassinato em série é só um.");
            sentence.Enqueue("E esse motivo é:");
            sentence.Enqueue("Com isso eu tenho tudo em mãos para prender o assassino.");
            sentence.Enqueue("Eu tenho o motivo, a relação com a vítima, a oportunidade de estar no local.");
            sentence.Enqueue("O que me leva a um único suspeito.");
            sentence.Enqueue("O verdadeiro assassino:");
        }
        else
        {
            sentence.Enqueue("Já sei o que aconteceu.");
            sentence.Enqueue("O assassino está entre nós nesse exato momento.");
            sentence.Enqueue("E irei mostrar para todos, seguindo o meu raciocínio.");
            sentence.Enqueue("E a solução para essa série de casos pode começar com um simples erro do assassino.");
            sentence.Enqueue("Um item que ele deixou cair em um de seus assassinatos que indica quem ele pode ser.");
            sentence.Enqueue("E aqui está o item:");
            sentence.Enqueue("Esse item não teve correlação com o caso em que ele apareceu.");
            sentence.Enqueue("O assassino também pode falhar e deixar itens como esse pelo local.");
            sentence.Enqueue("Assim como ele deixa os seus interesses de assassinato também transparecer nas vítimas.");
            sentence.Enqueue("E esse interesse é:");
            sentence.Enqueue("Matando todas essas pessoas o assassino deixou claro suas intenções.");
            sentence.Enqueue("O motivo por trás disso tudo.");
            sentence.Enqueue("Ele pode ter mudado de caso a caso, mas o motivo real do assassinato em série é só um.");
            sentence.Enqueue("E esse motivo é:");
            sentence.Enqueue("Com isso eu tenho tudo em mãos para prender o assassino.");
            sentence.Enqueue("Eu tenho o motivo, a relação com a vítima, a oportunidade de estar no local.");
            sentence.Enqueue("O que me leva a um único suspeito.");
            sentence.Enqueue("O verdadeiro assassino:");
        }


        movimento.ParaPersonagem = true;
        Caderno.PermissaoAbrirCaderno = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
    }

    public void ViraPaginaDireita()
    {
        if (paginaAtual == 6)
        {
            return;
        }
        if (PlayerData.Idioma == "ingles")
        {
            textoNumeroCasos.text = "CASE " + paginaAtual.ToString();
        }
        else
        {
            textoNumeroCasos.text = "CASO " + paginaAtual.ToString();
        }
        paginaAtual++;
        cadernoOriginal.ViraPagina();
    }
    public void ViraPaginaEsquerda()
    {
        if (paginaAtual == 1)
        {
            return;
        }
        if (PlayerData.Idioma == "ingles")
        {
            textoNumeroCasos.text = "CASE " + paginaAtual.ToString();
        }
        else
        {
            textoNumeroCasos.text = "CASO " + paginaAtual.ToString();
        }
        paginaAtual--;
        cadernoOriginal.ViraPagina();
    }

    public void FinalizaGame()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (AcertouAssassino == true && Pontuacao == 3)
            {
                /*final bom*/
                SceneManager.LoadScene(2);
            }
            else if (AcertouAssassino == true && Pontuacao < 3)
            {
                /*final medio*/
                SceneManager.LoadScene(3);
            }
            else if (AcertouAssassino == false && Pontuacao == 3)
            {
                /*final medio*/
                SceneManager.LoadScene(3);
            }
            else
            {
                /*final ruim*/
                SceneManager.LoadScene(3);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (jogoFinalizado == false)
        {
            if (ScenesManager.DialogoTransicao == false)
            {
                if (Input.GetKeyDown(KeyCode.E) && escrevendo == true && perguntando == false)
                {
                    StopAllCoroutines();
                    texto.text = fraseAtual;
                    escrevendo = false;
                }
                else if (Input.GetKeyDown(KeyCode.E) && escrevendo == false && perguntando == false)
                {
                    Transition.SetBool("Abrir", true);
                    fraseAtual = sentence.Dequeue();
                    StartCoroutine(typeSentence(fraseAtual));
                    if (fraseAtual == "E aqui está o item:")
                    {
                        ClickCaderno = true;
                        Evidencias.SetActive(true);
                        cadernoOriginal.EscreverEvidencias();
                        caderno.SetBool("Rela", true);
                        SemEvidencia.SetActive(true);
                        perguntando = true;
                    }
                    else if (fraseAtual == "E esse interesse é:")
                    {
                        Evidencias.SetActive(true);
                        cadernoOriginal.EscreverEvidencias();
                        caderno.SetBool("Rela", true);
                        perguntando = true;
                        AtivaInteresse();
                    }
                    else if (fraseAtual == "E esse motivo é:")
                    {
                        Evidencias.SetActive(true);
                        cadernoOriginal.EscreverEvidencias();
                        caderno.SetBool("Rela", true);
                        perguntando = true;
                        Ativa6Botoes();
                    }
                    else if (fraseAtual == "O verdadeiro assassino:")
                    {
                        Evidencias.SetActive(false);
                        caderno.SetBool("Rela", false);
                        perguntando = true;
                        SelecionaAssassino();
                    }
                }
            }
        }
        else
        {
            FinalizaGame();
        }
    }
    public void AtivaInteresse()
    {
        VitimasMulheres.SetActive(true);
        VitimasHomens.SetActive(true);
        VitimasJovens.SetActive(true);
        VitimasVelhos.SetActive(true);
        VitimasCorruptas.SetActive(true);
        VitimasRicas.SetActive(true);
    }
    public void DesativaInteresse()
    {
        VitimasMulheres.SetActive(false);
        VitimasHomens.SetActive(false);
        VitimasJovens.SetActive(false);
        VitimasVelhos.SetActive(false);
        VitimasCorruptas.SetActive(false);
        VitimasRicas.SetActive(false);
    }
    public void DesativaAssassino()
    {
        Delegado.SetActive(false);
        Policial.SetActive(false);
        Jornalista.SetActive(false);
        Legista.SetActive(false);
        TI.SetActive(false);
        Rico.SetActive(false);
        Parceiro.SetActive(false);
    }
    public void SelecionaAssassino()
    {
        Delegado.SetActive(true);
        Policial.SetActive(true);
        Jornalista.SetActive(true);
        Legista.SetActive(true);
        TI.SetActive(true);
        Rico.SetActive(true);
        Parceiro.SetActive(true);
    }
    public void Ativa6Botoes()
    {
        Raiva.SetActive(true);
        Prazer.SetActive(true);
        Desavença.SetActive(true);
        Justica.SetActive(true);
        Roubo.SetActive(true);
    }
    public void Desativa6Botoes()
    {
        Raiva.SetActive(false);
        Prazer.SetActive(false);
        Desavença.SetActive(false);
        Justica.SetActive(false);
        Roubo.SetActive(false);
    }
    public void InteresseMulheres()
    {
        interesseResposta = 0;
        ConfirmaInteresse();
    }
    public void InteresseHomens()
    {
        interesseResposta = 1;
        ConfirmaInteresse();
    }
    public void InteresseJovens()
    {
        interesseResposta = 2;
        ConfirmaInteresse();
    }
    public void InteresseVelhos()
    {
        interesseResposta = 3;
        ConfirmaInteresse();
    }
    public void InteresseCorruptos()
    {
        interesseResposta = 4;
        ConfirmaInteresse();
    }
    public void InteresseRicos()
    {
        interesseResposta = 5;
        ConfirmaInteresse();
    }
    public void ConfirmaInteresse()
    {
        switch (interesseResposta)
        {
            case 0:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
            case 1:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
            case 2:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
            case 3:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
            case 4:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
            case 5:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
            case 6:
                if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
                {
                    acertouInteresse = true;
                }
                break;
        }
        perguntando = false;
        DesativaInteresse();
    }
    public void RaivaResposta()
    {
        respostaTexto = "Raiva";
        Confirma();
    }
    public void SuicidioResposta()
    {
        respostaTexto = "Suicidio";
        Confirma();
    }
    public void PrazerResposta()
    {
        respostaTexto = "Prazer";
        Confirma();
    }
    public void DesavençaResposta()
    {
        respostaTexto = "Desavenca";
        Confirma();
    }
    public void JusticaResposta()
    {
        respostaTexto = "Justica";
        Confirma();
    }
    public void RouboResposta()
    {
        respostaTexto = "Roubo";
        Confirma();
    }
    public void PolicialResposta()
    {
        respostaAssassino = 1;
        ConfirmaAssassino();
    }
    public void JornalistaResposta()
    {
        respostaAssassino = 5;
        ConfirmaAssassino();
    }
    public void DelegadoResposta()
    {
        respostaAssassino = 4;
        ConfirmaAssassino();
    }
    public void ParceiroResposta()
    {
        respostaAssassino = 0;
        ConfirmaAssassino();
    }
    public void LegistaResposta()
    {
        respostaAssassino = 2;
        ConfirmaAssassino();
    }
    public void TIResposta()
    {
        respostaAssassino = 3;
        ConfirmaAssassino();
    }
    public void RicoResposta()
    {
        respostaAssassino = 6;
        ConfirmaAssassino();
    }
    public void AcertouAssassinoDiaologo()
    {

    }
    public void ErrouAssassinoDiaologo()
    {

    }
    public void ConfirmaAssassino()
    {
        switch (respostaAssassino)
        {
            case 0:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
            case 1:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
            case 2:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
            case 3:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
            case 4:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
            case 5:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
            case 6:
                if (respostaAssassino == SpawnObjects.numeroAssassino)
                {
                    acertouAssassino = true;
                    AcertouAssassinoDiaologo();
                }
                break;
        }
        perguntando = false;
        DesativaAssassino();
    }
    public void Resposta(Text resposta)
    {
        if (ClickCaderno)
        {
            respostaTexto = resposta.text;
            SemEvidencia.SetActive(true);
            if (PlayerData.Idioma == "ingles")
            {
                texto.text = "Could this be it?";
            }
            else
            {
                texto.text = "Sera que é isso?";
            }
        }

    }
    public void NoEvidencias()
    {
        if (ClickCaderno)
        {
            if (numeroDaPergunta == 5)
            {
                Evidencias.SetActive(false);
                caderno.SetBool("Rela", false);
                Desativa6Botoes();
                Finalizar.SetActive(true);
            }
            numeroDaPergunta++;
            SemEvidencia.SetActive(false);
            Evidencias.SetActive(false);
            caderno.SetBool("Rela", false);
            perguntando = false;
            fraseAtual = sentence.Dequeue();
            StartCoroutine(typeSentence(fraseAtual));
        }
    }
    public void Confirma()
    {
        switch (SpawnObjects.numeroAssassino)
        {
            case 0:
                if (respostaTexto == "relogio")
                {
                    Pontuacao = 1;
                }
                break;
        }
        Evidencias.SetActive(false);
        caderno.SetBool("Rela", false);
        SemEvidencia.SetActive(false);
        numeroDaPergunta++;
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
        ClickCaderno = false;

    }
    public void No()
    {
        Transition.SetBool("Abrir", false);
        Evidencias.SetActive(false);
        caderno.SetBool("Rela", false);
        sentence.Clear();
        PixelArt.SetBool("On", false);
        movimento.ParaPersonagem = false;
        Caderno.PermissaoAbrirCaderno = true;

    }
    IEnumerator typeSentence(string sentence)
    {
        texto.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            escrevendo = true;
            texto.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
        escrevendo = false;
    }
}
