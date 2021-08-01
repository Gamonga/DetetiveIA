using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public Dialogue dialogodelegadodetetive;
    public DialogueControl dialogodelegadodetetivecontrol;
    public Text textoNumeroCasos;
    public Caderno cadernoOriginal;
    public GameObject FundoPreto;
    public Text textCreditos;
    public Rigidbody2D rbCreditos;
    public GameObject Creditos;
    public GameObject preencherOUaceitarResposta;
    public GameObject VitimasMulheres;
    public GameObject VitimasHomens;
    public GameObject VitimasJovens;
    public GameObject VitimasVelhos;
    public GameObject VitimasCorruptas;
    public GameObject VitimasRicas;
    public GameObject VitimasMulheresFinal;
    public GameObject VitimasHomensFinal;
    public GameObject VitimasJovensFinal;
    public GameObject VitimasVelhosFinal;
    public GameObject VitimasCorruptasFinal;
    public GameObject VitimasRicasFinal;
    public GameObject Delegado;
    public GameObject Policial;
    public GameObject Jornalista;
    public GameObject Legista;
    public GameObject TI;
    public GameObject Rico;
    public GameObject Parceiro;
    public GameObject Evidencias;
    public GameObject Roubo;
    public GameObject Desavença;
    public GameObject Raiva;
    public GameObject Prazer;
    public GameObject Justica;
    public GameObject RouboFinal;
    public GameObject DesavençaFinal;
    public GameObject RaivaFinal;
    public GameObject PrazerFinal;
    public GameObject JusticaFinal;
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
    public static bool PerguntaFinal;
    public static int FinalNumero;
    public static int ContadorTime;
    public static bool SubindoCreditos;
    public static bool DelegadoFalando;
    public static bool FinalDialiogoBool;
    // Start is called before the first frame update
    void Start()
    {
        FinalDialiogoBool = false;
        DelegadoFalando = false;
        FundoPreto.SetActive(false);
        ContadorTime = 0;
        SubindoCreditos = false;
        DesativaAssassino();
        PerguntaFinal = false;
        ClickCaderno = false;
        acertouInteresse = false;
        acertouAssassino = false;
        paginaAtual = 1;
        jogoFinalizado = false;
        numeroDaPergunta = 1;
        Pontuacao = 0;
        escrevendo = false;
        sentence = new Queue<string>();
        Finalizar.SetActive(false);
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Enqueue("I already know what happened.");
            sentence.Enqueue("The killer is among us right now.");
            sentence.Enqueue("And I will show it to everyone, following my reasoning.");
            sentence.Enqueue("And the solution to this series of cases starts with a simple killer error.");
            sentence.Enqueue("An item he dropped in one of his murders that indicates who he might be.");
            sentence.Enqueue("And here is the item:");
            sentence.Enqueue("This item had no correlation with the case in which it appeared.");
            sentence.Enqueue("The assassin also failed and left items like this around the place.");
            sentence.Enqueue("It also has targets of your choice.");
            sentence.Enqueue("And these targets are:");
            sentence.Enqueue("By killing all these people, the assassin made his intentions clear.");
            sentence.Enqueue("The reason behind all this.");
            sentence.Enqueue("He may have changed from case to case, but the real motive for the serial murders is just one.");
            sentence.Enqueue("And that reason is:");
            sentence.Enqueue("With that I have everything in hand to arrest the murderer.");
            sentence.Enqueue("I have the motive, the relationship with the victim, the opportunity to be there.");
            sentence.Enqueue("Which brings me to a single suspect.");
            sentence.Enqueue("The real killer:");
        }
        else
        {
            sentence.Enqueue("Já sei o que aconteceu.");
            sentence.Enqueue("O assassino está entre nós nesse exato momento.");
            sentence.Enqueue("E irei mostrar para todos, seguindo o meu raciocínio.");
            sentence.Enqueue("E a solução para essa série de casos começa com um simples erro do assassino.");
            sentence.Enqueue("Um item que ele deixou cair em um de seus assassinatos que indica quem ele pode ser.");
            sentence.Enqueue("E aqui está o item:");
            sentence.Enqueue("Esse item não teve correlação com o caso em que ele apareceu.");
            sentence.Enqueue("O assassino também falhou e deixou itens como esse pelo local.");
            sentence.Enqueue("Ele também tem alvos de sua preferência.");
            sentence.Enqueue("E estes alvos são:");
            sentence.Enqueue("Matando todas essas pessoas o assassino deixou claro suas intenções.");
            sentence.Enqueue("O motivo por trás disso tudo.");
            sentence.Enqueue("Ele pode ter mudado de caso a caso, mas o motivo real dos assassinatos em série é só um.");
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
        paginaAtual++;
        if (PlayerData.Idioma == "ingles")
        {
            textoNumeroCasos.text = "CASE " + paginaAtual.ToString();
        }
        else
        {
            textoNumeroCasos.text = "CASO " + paginaAtual.ToString();
        }
        cadernoOriginal.ViraPagina();
    }
    public void ViraPaginaEsquerda()
    {
        if (paginaAtual == 1)
        {
            return;
        }
        paginaAtual--;
        if (PlayerData.Idioma == "ingles")
        {
            textoNumeroCasos.text = "CASE " + paginaAtual.ToString();
        }
        else
        {
            textoNumeroCasos.text = "CASO " + paginaAtual.ToString();
        }
        cadernoOriginal.ViraPagina();
    }

    public void ConversaFinalVitoria()
    {
        if (PlayerData.Idioma == "ingles")
        {
            sentence.Clear();
            sentence.Enqueue("Detective, congratulations on your excellent work today.");
            sentence.Enqueue("But I have one last question. Like?");
            sentence.Enqueue("How did you know the killer was one of us");
            sentence.Enqueue("That the killer was among us.");
            sentence.Enqueue("troca paisagem");
            sentence.Enqueue("That's easy Steve.");
            sentence.Enqueue("Every case I made my report.");
            sentence.Enqueue("The assassin improved his methods, analyzed my steps and always hindered my investigation.");
            sentence.Enqueue("Only someone close to me could do such things.");
            sentence.Enqueue("troca pensando");
            sentence.Enqueue("That's why you're the detective and I'm just Steve");
            sentence.Enqueue("troca pensando");
            sentence.Enqueue("Someday you get there. Haha ha.");
        }
        else
        {
            sentence.Clear();
            sentence.Enqueue("Detetive, parabéns pelo seu excelente trabalho hoje.");
            sentence.Enqueue("Mas eu tenho uma última pergunta. Como?");
            sentence.Enqueue("Como você sabia que o assassino era um de nós");
            sentence.Enqueue("Que o asssassino estava entre a gente.");
            sentence.Enqueue("troca paisagem");
            sentence.Enqueue("Essa é fácil Steve.");
            sentence.Enqueue("A cada caso que eu fazia meu relatório.");
            sentence.Enqueue("O assassino melhorava seus métodos, analisava meus passos e sempre dificultava a minha investigação.");
            sentence.Enqueue("Só alguem próximo a mim poderia fazer umas coisas dessas.");
            sentence.Enqueue("troca pensando");
            sentence.Enqueue("Por isso você é o detetive e eu só o Steve");
            sentence.Enqueue("troca pensando");
            sentence.Enqueue("Um dia você chega lá. Hahaha.");
        }
    }
    public void SobeCreditos()
    {
    }
    public void FinalizaGame()
    {
        if (AcertouAssassino == true && Pontuacao == 4)
        {
            Debug.Log("final bom");
            FinalNumero = 3;
            if (PlayerData.Idioma == "ingles")
            {
                sentence.Clear();
                sentence.Enqueue("Nooooooooooooooo.");
                sentence.Enqueue("HOW IS IT POSSIBLE?!!!");
                sentence.Enqueue("You know everything and everyone detective.");
                sentence.Enqueue("AHHHHHHHHHHHH.");
                sentence.Enqueue("exchange landscape");
                sentence.Enqueue("He needed time to think and his mistakes.");
                sentence.Enqueue("And that's exactly what you gave me.");
                sentence.Enqueue("You are under arrest for the crime of 6 murders.");
            }
            else
            {
                sentence.Clear();
                sentence.Enqueue("Nãooooooooooooooo.");
                sentence.Enqueue("COMO É POSSÍVEL?!!!");
                sentence.Enqueue("Você sabe de tudo e de todos detetive.");
                sentence.Enqueue("AHHHHHHHHHHHH.");
                sentence.Enqueue("troca paisagem");
                sentence.Enqueue("Precisava de tempo para pensar e de erros seus.");
                sentence.Enqueue("E isso foi exatamente o que você me deu.");
                sentence.Enqueue("Você está preso pelo crime de 6 assassinatos.");
            }
            if (PlayerData.Idioma == "ingles")
            {
                textCreditos.text = "After a long and arduous investigation, the detective and his companions brought the murderer to justice upon presentation of evidence. His guilt was proven and sentenced, finally bringing peace and tranquility to all.";
            }
            else
            {
                textCreditos.text = "Depois de longa e árdua investigação o detetive e seus companheiros trouxeram o assassino à justiça mediante apresentação de evidências. Sua culpa foi provada e teve sua senteça decretada, trazendo finalmente paz e tranquilidade para todos.";
            }
        }
        else if (AcertouAssassino == true && Pontuacao < 4)
        {
            Debug.Log("final medio");
            FinalNumero = 2;
            if (PlayerData.Idioma == "ingles")
            {
                textCreditos.text = "Even after a long and arduous investigation, the detective was unable to bring the murderer to justice lacking evidence and support. The murders stopped happening, even with the serial killer on the loose. It is believed that the detective contributed to the end of the murders, but with nothing proven it's just a myth that roams the police station.";
            }
            else
            {
                textCreditos.text = "Mesmo depois de longa e árdua investigação o detetive não conseguiu trazer o assassino à justiça faltando evidências e embasamento. Os assassinatos pararam de acontecer, mesmo com o assassino em série a solta. Acredita-se que o detetive contribuiu com o fim dos assassinatos, mas com nada provado é só um mito que vaga pela delegacia.";
            }
            Creditos.SetActive(true);
        }
        else if (AcertouAssassino == false && Pontuacao == 3)
        {
            Debug.Log("final medio");
            FinalNumero = 1;
            if (PlayerData.Idioma == "ingles")
            {
                textCreditos.text = "Even after a long and arduous investigation, the detective was unable to bring the murderer to justice lacking evidence and support. The murders stopped happening, even with the serial killer on the loose. It is believed that the detective contributed to the end of the murders, but with nothing proven it's just a myth that roams the police station.";
            }
            else
            {
                textCreditos.text = "Mesmo depois de longa e árdua investigação o detetive não conseguiu trazer o assassino à justiça faltando evidências e embasamento. Os assassinatos pararam de acontecer, mesmo com o assassino em série a solta. Acredita-se que o detetive contribuiu com o fim dos assassinatos, mas com nada provado é só um mito que vaga pela delegacia.";
            }
            Creditos.SetActive(true);
        }
        else
        {
            Debug.Log("final ruim");
            FinalNumero = 0;
            if (PlayerData.Idioma == "ingles")
            {
                textCreditos.text = "Even after a long and arduous investigation, the detective was unable to bring the murderer to justice lacking evidence and support. The murders continued to happen, with the serial killer on the loose and the policewoman unable to do anything else, the detective had to leave his post in the city.";
            }
            else
            {
                textCreditos.text = "Mesmo depois de longa e árdua investigação o detetive não conseguiu trazer o assassino à justiça faltando evidências e embasamento. Os assassinatos continuaram acontecendo, com o assassino em série solto e a policial não conseguindo fazer mais nada, o detetive teve que deixar seu posto na cidade.";
            }
            Creditos.SetActive(true);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (jogoFinalizado == false)
        {
            if (ScenesManager.DialogoTransicao == false)
            {
                if (DelegadoFalando == false)
                {
                    Transition.SetBool("Abrir", true);
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
                        if (fraseAtual == "E aqui está o item:" || fraseAtual == "E aqui está o item:")
                        {
                            cadernoOriginal.ViraPagina();
                            ClickCaderno = true;
                            Evidencias.SetActive(true);
                            cadernoOriginal.EscreverEvidencias();
                            caderno.SetBool("Rela", true);
                            SemEvidencia.SetActive(true);
                            perguntando = true;
                        }
                        else if (fraseAtual == "E estes alvos são:" || fraseAtual == "And these targets are:")
                        {
                            Evidencias.SetActive(true);
                            cadernoOriginal.EscreverEvidencias();
                            caderno.SetBool("Rela", true);
                            perguntando = true;
                            AtivaInteresse();
                        }
                        else if (fraseAtual == "E esse motivo é:" || fraseAtual == "And that reason is:")
                        {
                            Evidencias.SetActive(true);
                            cadernoOriginal.EscreverEvidencias();
                            caderno.SetBool("Rela", true);
                            perguntando = true;
                            Ativa6Botoes();
                        }
                        else if (fraseAtual == "O verdadeiro assassino:" || fraseAtual == "The real killer:")
                        {
                            Evidencias.SetActive(false);
                            caderno.SetBool("Rela", false);
                            perguntando = true;
                            SelecionaAssassino();
                        }
                        else if (fraseAtual == "E essa coisa é:" || fraseAtual == "E aqui está o item:")
                        {
                            Evidencias.SetActive(true);
                            cadernoOriginal.EscreverEvidencias();
                            caderno.SetBool("Rela", true);
                            perguntando = true;
                            PerguntaFinal = true;
                            interesseResposta = -1;
                            respostaTexto = "";
                            AtivaUltimosBotoes();
                        }
                        else if (fraseAtual == "I will continue my search for the murderer." || fraseAtual == "Continuarei na minha busca pelo assassino.")
                        {
                            Transition.SetBool("Abrir", false);
                            jogoFinalizado = true;
                            Creditos.SetActive(true);
                            FundoPreto.SetActive(true);
                        }
                    }
                }
                else
                {
                    Transition.SetBool("Abrir", false);
                    FinalizaGame();
                    if (FinalDialiogoBool == true)
                    {
                        DelegadoFalando = false;
                        jogoFinalizado = true;
                        Creditos.SetActive(true);
                        FundoPreto.SetActive(true);
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (FinalDialiogoBool == false)
                        {
                            dialogodelegadodetetivecontrol.DisplayNextSentence(dialogodelegadodetetive);
                        }
                    }
                }
            }
        }
        else
        {
            // if(ContadorTime<1000){
            //     Creditos.SetActive(false);
            // }
            // else{
            //     ContadorTime++;
            // }
        }
    }
    public void DesativaUltimosBotoes()
    {
        VitimasMulheresFinal.SetActive(false);
        VitimasHomensFinal.SetActive(false);
        VitimasJovensFinal.SetActive(false);
        VitimasVelhosFinal.SetActive(false);
        VitimasCorruptasFinal.SetActive(false);
        VitimasRicasFinal.SetActive(false);
        RouboFinal.SetActive(false);
        DesavençaFinal.SetActive(false);
        RaivaFinal.SetActive(false);
        PrazerFinal.SetActive(false);
        JusticaFinal.SetActive(false);
    }
    public void AtivaUltimosBotoes()
    {
        VitimasMulheresFinal.SetActive(true);
        VitimasHomensFinal.SetActive(true);
        VitimasJovensFinal.SetActive(true);
        VitimasVelhosFinal.SetActive(true);
        VitimasCorruptasFinal.SetActive(true);
        VitimasRicasFinal.SetActive(true);
        RouboFinal.SetActive(true);
        DesavençaFinal.SetActive(true);
        RaivaFinal.SetActive(true);
        PrazerFinal.SetActive(true);
        JusticaFinal.SetActive(true);
    }
    public void UltimaResposta()
    {
        DesativaUltimosBotoes();
        switch (SpawnObjects.numeroAssassino)
        {
            case 0:
                if (interesseResposta == 3)
                {
                    Pontuacao++;
                }
                break;
            case 1:
                if (interesseResposta == 0)
                {
                    Pontuacao++;
                }
                break;
            case 2:
                if (interesseResposta == 0 || respostaTexto == "Justica")
                {
                    Pontuacao++;
                }
                break;
            case 3:
                if (interesseResposta == 0 || respostaTexto == "Prazer")
                {
                    Pontuacao++;
                }
                break;
            case 4:
                if (interesseResposta == 2 || respostaTexto == "Justica")
                {
                    Pontuacao++;
                }
                break;
            case 5:
                if (interesseResposta == 1 || respostaTexto == "Raiva")
                {
                    Pontuacao++;
                }
                break;
            case 6:
                if (interesseResposta == 3 || respostaTexto == "Raiva" || respostaTexto == "Roubo")
                {
                    Pontuacao++;
                }
                break;
        }
        perguntando = false;
        caderno.SetBool("Rela", false);
        FinalizaGame();
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
        FundoPreto.SetActive(false);
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
        FundoPreto.SetActive(true);
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
        if (interesseResposta == SpawnObjects.numeroMotivoVitimaComum)
        {
            acertouInteresse = true;
            Pontuacao++;
        }
        else
        {
            acertouInteresse = false;
        }
        Evidencias.SetActive(false);
        caderno.SetBool("Rela", false);
        numeroDaPergunta++;
        perguntando = false;
        fraseAtual = sentence.Dequeue();
        StartCoroutine(typeSentence(fraseAtual));
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
        AcertouAssassino = true;
        Debug.Log("acertou assassino");
        if (Pontuacao < 3)
        {
            if (PlayerData.Idioma == "ingles")
            {
                dialogodelegadodetetive.sentencesIngles[0] = "Detective, I tell everyone here that your work has been admirable.";
                dialogodelegadodetetive.sentencesIngles[1] = "With their impeccable report, I believe we are on the right track to catch the murderer.";
                dialogodelegadodetetive.sentencesIngles[2] = "But it's too early to draw conclusions.";
                dialogodelegadodetetive.sentencesIngles[3] = "troca paisagem";
                dialogodelegadodetetive.sentencesIngles[4] = "Maybe I was too hasty.";
                dialogodelegadodetetive.sentencesIngles[5] = "I will continue my search for the murderer.";
                dialogodelegadodetetive.sentencesIngles[6] = "finalizar";
            }
            else
            {
                dialogodelegadodetetive.sentences[0] = "Detetive, digo por todos aqui que seu trabalho tem sido admiravel.";
                dialogodelegadodetetive.sentences[1] = "Com seus relátorio impecaveis, acredito que estamos no caminho certo para pegar o assassino.";
                dialogodelegadodetetive.sentences[2] = "Mas ainda é muito cedo para tirar conclusões.";
                dialogodelegadodetetive.sentences[3] = "troca paisagem";
                dialogodelegadodetetive.sentences[4] = "Talvez eu tenha me precipitado.";
                dialogodelegadodetetive.sentences[5] = "Continuarei na minha busca pelo assassino.";
                dialogodelegadodetetive.sentences[6] = "finalizar";

            }
            dialogodelegadodetetivecontrol.StartDialogue(dialogodelegadodetetive);
            DelegadoFalando = true;
            FinalizaGame();
        }
        else
        {
            switch (SpawnObjects.numeroAssassino)
            {
                case 0:
                    break;
            }
            if (PlayerData.Idioma == "ingles")
            {
                sentence.Clear();
                sentence.Enqueue("Calm down, why me?");
                sentence.Enqueue("Among all the people here I am the most honest and fair.");
                sentence.Enqueue("You must be going crazy, detective.");
                sentence.Enqueue("How do you know it's me and not anyone else here.");
                sentence.Enqueue("You can't prove it.");
                sentence.Enqueue("troca paisagem");
                sentence.Enqueue("I'll show you something you've done that others wouldn't do.");
                sentence.Enqueue("Something only you would be capable of.");
                sentence.Enqueue("And this thing is:");
            }
            else
            {
                sentence.Clear();
                sentence.Enqueue("Calma ai, porque eu?");
                sentence.Enqueue("Dentre todas as pessoas aqui eu sou a mais honesta e justa.");
                sentence.Enqueue("Você deve estar ficando maluco detetive.");
                sentence.Enqueue("Como você sabe que sou eu e não qualquer outra daqui.");
                sentence.Enqueue("Você não tem como provar.");
                sentence.Enqueue("troca paisagem");
                sentence.Enqueue("Eu irei mostrar algo que você fez e o que os demais não fariam.");
                sentence.Enqueue("Algo que somente você seria capaz.");
                sentence.Enqueue("E essa coisa é:");
            }
        }
    }
    public void ErrouAssassinoDiaologo()
    {
        AcertouAssassino = false;
        if (Pontuacao == 3)
        {
            if (PlayerData.Idioma == "ingles")
            {
                dialogodelegadodetetive.sentencesIngles[0] = "Detective, I tell everyone here that your work has been admirable.";
                dialogodelegadodetetive.sentencesIngles[1] = "With their impeccable report, I believe we are on the right track to catch the murderer.";
                dialogodelegadodetetive.sentencesIngles[2] = "But it's too early to draw conclusions.";
                dialogodelegadodetetive.sentencesIngles[3] = "troca paisagem";
                dialogodelegadodetetive.sentencesIngles[4] = "Maybe I was too hasty.";
                dialogodelegadodetetive.sentencesIngles[5] = "I will continue my search for the murderer.";
                dialogodelegadodetetive.sentencesIngles[6] = "finalizar";
            }
            else
            {
                dialogodelegadodetetive.sentences[0] = "Detetive, digo por todos aqui que seu trabalho tem sido admiravel.";
                dialogodelegadodetetive.sentences[1] = "Com seus relátorio impecaveis, acredito que estamos no caminho certo para pegar o assassino.";
                dialogodelegadodetetive.sentences[2] = "Mas ainda é muito cedo para tirar conclusões.";
                dialogodelegadodetetive.sentences[3] = "troca paisagem";
                dialogodelegadodetetive.sentences[4] = "Talvez eu tenha me precipitado.";
                dialogodelegadodetetive.sentences[5] = "Continuarei na minha busca pelo assassino.";
                dialogodelegadodetetive.sentences[6] = "finalizar";

            }
            dialogodelegadodetetivecontrol.StartDialogue(dialogodelegadodetetive);
            DelegadoFalando = true;
        }
        else
        {
            if (PlayerData.Idioma == "ingles")
            {
                dialogodelegadodetetive.sentencesIngles[0] = "Detective, I tell everyone here that your work has been disgraceful.";
                dialogodelegadodetetive.sentencesIngles[1] = "With your inaccurate reports, I don't think we're getting anywhere.";
                dialogodelegadodetetive.sentencesIngles[2] = "It's too early to draw conclusions, you shouldn't have called us here unnecessarily.";
                dialogodelegadodetetive.sentencesIngles[3] = "troca paisagem";
                dialogodelegadodetetive.sentencesIngles[4] = "Maybe I was too hasty.";
                dialogodelegadodetetive.sentencesIngles[5] = "I will continue my search for the murderer.";
                dialogodelegadodetetive.sentencesIngles[6] = "finalizar";
            }
            else
            {
                dialogodelegadodetetive.sentences[0] = "Detetive, digo por todos aqui que seu trabalho tem sido lastimável.";
                dialogodelegadodetetive.sentences[1] = "Com seus relátorio imprecisos, acredito que não estamos chegando a lugar nenhum.";
                dialogodelegadodetetive.sentences[2] = "Ainda é muito cedo para tirar conclusões, não deveria ter nos chamado aqui desnecessariamente.";
                dialogodelegadodetetive.sentences[3] = "troca paisagem";
                dialogodelegadodetetive.sentences[4] = "Talvez eu tenha me precipitado.";
                dialogodelegadodetetive.sentences[5] = "Continuarei na minha busca pelo assassino.";
                dialogodelegadodetetive.sentences[6] = "finalizar";
            }
            dialogodelegadodetetivecontrol.StartDialogue(dialogodelegadodetetive);
            DelegadoFalando = true;
        }
        fraseAtual = sentence.Dequeue();
        FinalizaGame();

    }
    public void ConfirmaAssassino()
    {
        perguntando = false;
        DesativaAssassino();
        if (respostaAssassino == SpawnObjects.numeroAssassino)
        {
            acertouAssassino = true;
            Pontuacao++;
            AcertouAssassinoDiaologo();
        }
        else
        {
            acertouAssassino = false;
            ErrouAssassinoDiaologo();
        }
    }
    public void Resposta(Text resposta)
    {
        if (ClickCaderno)
        {
            preencherOUaceitarResposta.SetActive(true);
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
        if (PerguntaFinal)
        {
            switch (SpawnObjects.numeroAssassino)
            {
                case 0:
                    if (respostaTexto == "Bilhete de filme" || respostaTexto == "Cartão")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 1:
                    if (respostaTexto == "Bilhete de filme" || respostaTexto == "Cartão")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 2:
                    if (respostaTexto == "Cartão A.A." || respostaTexto == "Pano branco")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 3:
                    if (respostaTexto == "Bilhete de filme" || respostaTexto == "Pano branco")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 4:
                    if (respostaTexto == "Relógio" || respostaTexto == "Cartão")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 5:
                    if (respostaTexto == "Cartão A.A." || respostaTexto == "Bilhete de filme")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 6:
                    if (respostaTexto == "Relógio" || respostaTexto == "Pano branco")
                    {
                        Pontuacao = 1;
                    }
                    break;

            }
        }
        else
        {
            switch (SpawnObjects.numeroAssassino)
            {
                case 0:
                    if (respostaTexto == "Bilhete de filme" || respostaTexto == "Cartão")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 1:
                    if (respostaTexto == "Bilhete de filme" || respostaTexto == "Cartão")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 2:
                    if (respostaTexto == "Cartão A.A." || respostaTexto == "Pano branco")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 3:
                    if (respostaTexto == "Bilhete de filme" || respostaTexto == "Pano branco")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 4:
                    if (respostaTexto == "Relógio" || respostaTexto == "Cartão")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 5:
                    if (respostaTexto == "Cartão A.A." || respostaTexto == "Bilhete de filme")
                    {
                        Pontuacao = 1;
                    }
                    break;
                case 6:
                    if (respostaTexto == "Relógio" || respostaTexto == "Pano branco")
                    {
                        Pontuacao = 1;
                    }
                    break;
            }
            Desativa6Botoes();
            preencherOUaceitarResposta.SetActive(false);
            Evidencias.SetActive(false);
            caderno.SetBool("Rela", false);
            SemEvidencia.SetActive(false);
            numeroDaPergunta++;
            perguntando = false;
            fraseAtual = sentence.Dequeue();
            StartCoroutine(typeSentence(fraseAtual));
            ClickCaderno = false;
        }

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
