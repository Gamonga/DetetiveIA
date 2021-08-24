using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public bool AcusaçãoBool;
    public Text textoCreditos;
    public Dialogue acusacaoParceiro;
    public Dialogue acusacaoPolicial;
    public Dialogue acusacaoLegista;
    public Dialogue acusacaoTI;
    public Dialogue acusacaoDelegado;
    public Dialogue acusacaoRico;
    public Dialogue acusacaoJornalista;
    public DialogueControl controleAcusacao;
    public DialogueControl controleAcusacao2;
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
    private static float i;
    private static int creditoInt;
    // Start is called before the first frame update
    void Start()
    {
        FinalNumero = 0;
        creditoInt = 0;
        AcertouAssassino = false;
        AcusaçãoBool = false;
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
            sentence.Enqueue("Só alguém próximo a mim poderia fazer umas coisas dessas.");
            sentence.Enqueue("troca pensando");
            sentence.Enqueue("Por isso você é o detetive e eu só o Steve");
            sentence.Enqueue("troca pensando");
            sentence.Enqueue("Um dia você chega lá. Hahaha.");
        }
    }
    public void FinalizaGame()
    {
        if (AcertouAssassino == true && Pontuacao == 4)
        {
            DelegadoFalando = true;
            AcusaçãoBool = true;
            Debug.Log("final bom");
            FinalNumero = 3;
            switch (SpawnObjects.numeroAssassino)
            {
                case 0:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoParceiro.sentencesIngles[0] = "HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA";
                        acusacaoParceiro.sentencesIngles[1] = "BriLlIaNT DETECTIVE!";
                        acusacaoParceiro.sentencesIngles[2] = "Finally, someone here in this police station thinks.";
                        acusacaoParceiro.sentencesIngles[3] = "I've been playing the fool for so long and to this day no one has noticed what I planned from the beginning";
                        acusacaoParceiro.sentencesIngles[4] = "Clean up the scum of this city. All of them killed by me.";
                        acusacaoParceiro.sentencesIngles[5] = "HAHAHAHA. Detective, only you would be able to see behind my mask.";
                        acusacaoParceiro.sentencesIngles[6] = "I admit I killed them all, and I feel no remorse in any of them.";
                        acusacaoParceiro.sentencesIngles[7] = "But how, detective? How did you know that the murderer was amongus.";
                        acusacaoParceiro.sentencesIngles[8] = "troca paisagem";
                        acusacaoParceiro.sentencesIngles[9] = "Steve, you thought you were very smart because you were always with me.";
                        acusacaoParceiro.sentencesIngles[10] = "That was exactly the problem, with everything I got right and wrong.";
                        acusacaoParceiro.sentencesIngles[11] = "The assassin adapted, improved his assassination plans based on my choices, only someone very close to me could act that way.";
                        acusacaoParceiro.sentencesIngles[12] = "Your mistake was wanting to be too good to trick me.";
                        acusacaoParceiro.sentencesIngles[13] = "troca paisagem";
                        acusacaoParceiro.sentencesIngles[14] = "HAHAHAH. Excellent.";
                        acusacaoParceiro.sentencesIngles[15] = "Congratulations, detective. You won.";
                        acusacaoParceiro.sentencesIngles[16] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoParceiro);
                    }
                    else
                    {
                        acusacaoParceiro.sentences[0] = "HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA";
                        acusacaoParceiro.sentences[1] = "BrIlHanTe DETETIVE!";
                        acusacaoParceiro.sentences[2] = "Finalmente alguém aqui nessa delegacia pensa.";
                        acusacaoParceiro.sentences[3] = "Eu faço esse papel de bobo por tanto tempo e até hoje ninguém reparou o que eu planejava desde o começo";
                        acusacaoParceiro.sentences[4] = "Limpar a escória dessa cidade. Todos eles mortos por mim.";
                        acusacaoParceiro.sentences[5] = "HAHAHAHA. Detetive só você mesmo para conseguir ver por trás da minha máscara.";
                        acusacaoParceiro.sentences[6] = "Eu adimito: eu matei todos eles, e não sinto remorso nenhum.";
                        acusacaoParceiro.sentences[7] = "Mas como, detetive? Como você sabia que o assassino estava entre um de nós.";
                        acusacaoParceiro.sentences[8] = "troca paisagem";
                        acusacaoParceiro.sentences[9] = "Steve, você se achou muito esperto pois sempre estava comigo.";
                        acusacaoParceiro.sentences[10] = "O problema foi exatamente esse, a cada acerto e erro que eu cometia.";
                        acusacaoParceiro.sentences[11] = "O assassino se adaptava, melhorava seus planos de assassinato baseado nas minhas escolhas, somente alguém muito próximo a mim poderia agir dessa forma.";
                        acusacaoParceiro.sentences[12] = "Seu erro foi querer ser bom demais para me pegar.";
                        acusacaoParceiro.sentences[13] = "troca paisagem";
                        acusacaoParceiro.sentences[14] = "HAHAHAH. Esplêndido.";
                        acusacaoParceiro.sentences[15] = "Parabéns, detetive. Você ganhou.";
                        acusacaoParceiro.sentences[16] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoParceiro);
                    }
                    break;
                case 1:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoPolicial.sentencesIngles[1] = "After so much time, so much planning.";
                        acusacaoPolicial.sentencesIngles[2] = "I ended up being caught in the end.";
                        acusacaoPolicial.sentencesIngles[3] = "Everything I did was with good intentions. Are you satisfied, detective? ";
                        acusacaoPolicial.sentencesIngles[4] = "I killed all those people, and I don't feel remorse about it.";
                        acusacaoPolicial.sentencesIngles[5] = "troca paisagem";
                        acusacaoPolicial.sentencesIngles[6] = "The road to hell is paved with good intentions.";
                        acusacaoPolicial.sentencesIngles[7] = "I only did my job here, Johnny. You're under arrest.";
                        acusacaoPolicial.sentencesIngles[8] = "troca pensando";
                        acusacaoPolicial.sentencesIngles[9] = "Congratulations, detective. You won.";
                        acusacaoPolicial.sentencesIngles[10] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoPolicial);
                    }
                    else
                    {
                        acusacaoPolicial.sentences[1] = "Depois de tanto tempo, tanto planejamento.";
                        acusacaoPolicial.sentences[2] = "Acabei sendo descoberto no final.";
                        acusacaoPolicial.sentences[3] = "Tudo que eu fiz foi com boas intenções. Você está satisfeito, detetive? ";
                        acusacaoPolicial.sentences[4] = "Eu matei todas aquelas pessoas, e não sinto remorso nisso.";
                        acusacaoPolicial.sentences[5] = "troca paisagem";
                        acusacaoPolicial.sentences[6] = "De boas intenções o inferno está cheio.";
                        acusacaoPolicial.sentences[7] = "Só fiz o meu trabalho aqui, Johnny. Você está preso.";
                        acusacaoPolicial.sentences[8] = "troca pensando";
                        acusacaoPolicial.sentences[9] = "Parabéns, detetive. Você ganhou.";
                        acusacaoPolicial.sentences[10] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoPolicial);
                    }
                    break;
                case 2:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoLegista.sentencesIngles[1] = "And I thought that this police station only had imbeciles.";
                        acusacaoLegista.sentencesIngles[2] = "Amazing deduction, detective. I won't even contest.";
                        acusacaoLegista.sentencesIngles[3] = "I killed them all, every one of them.";
                        acusacaoLegista.sentencesIngles[4] = "And only someone like you, detective, to see through my plans.";
                        acusacaoLegista.sentencesIngles[5] = "troca paisagem";
                        acusacaoLegista.sentencesIngles[6] = "I only do what I was hired to do.";
                        acusacaoLegista.sentencesIngles[7] = "And for you, Devi, it's the end of your murders.";
                        acusacaoLegista.sentencesIngles[8] = "troca paisagem";
                        acusacaoLegista.sentencesIngles[9] = "Congratulations, detective. You won.";
                        acusacaoLegista.sentencesIngles[10] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoLegista);
                    }
                    else
                    {
                        acusacaoLegista.sentencesIngles[1] = "E eu achando que essa delegacia só tinha imbecis.";
                        acusacaoLegista.sentencesIngles[2] = "Dedução incrivel, detetive. Não irei nem contestar.";
                        acusacaoLegista.sentencesIngles[3] = "Eu matei todos, cada um deles.";
                        acusacaoLegista.sentencesIngles[4] = "E só alguém como você, detetive, para ver por trás dos meus planos.";
                        acusacaoLegista.sentencesIngles[5] = "troca paisagem";
                        acusacaoLegista.sentencesIngles[6] = "Só faço o que fui contratado para fazer.";
                        acusacaoLegista.sentencesIngles[7] = "E para você, Devi, é o fim dos seus assassinatos.";
                        acusacaoLegista.sentencesIngles[8] = "troca paisagem";
                        acusacaoLegista.sentencesIngles[9] = "Parabéns, detetive. Você ganhou.";
                        acusacaoLegista.sentencesIngles[10] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoLegista);
                    }
                    break;
                case 3:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoTI.sentencesIngles[0] = "HOw? HoW? How?";
                        acusacaoTI.sentencesIngles[1] = "...";
                        acusacaoTI.sentencesIngles[2] = "...";
                        acusacaoTI.sentencesIngles[3] = "Congratulations detective, only someone like you to catch me";
                        acusacaoTI.sentencesIngles[4] = "I have nothing to comment. I killed them all.";
                        acusacaoTI.sentencesIngles[5] = "troca paisagem";
                        acusacaoTI.sentencesIngles[6] = "You may have tried to improve your methods and improved in each case.";
                        acusacaoTI.sentencesIngles[7] = "But in the end it didn't matter at all, you will pay for your crimes.";
                        acusacaoTI.sentencesIngles[8] = "troca pensando";
                        acusacaoTI.sentencesIngles[9] = "After so many obstacles I've put in your way.";
                        acusacaoTI.sentencesIngles[10] = "I was caught, I was defeated";
                        acusacaoTI.sentencesIngles[11] = "Congratulations, detective. You won.";
                        acusacaoTI.sentencesIngles[12] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoTI);
                    }
                    else
                    {
                        acusacaoTI.sentences[0] = "Como? Como? Como?";
                        acusacaoTI.sentences[1] = "...";
                        acusacaoTI.sentences[2] = "...";
                        acusacaoTI.sentences[3] = "Parabéns detetive, só alguém como você para me descobrir";
                        acusacaoTI.sentences[4] = "Não tenho nada a comentar. Eu matei todos eles.";
                        acusacaoTI.sentences[5] = "troca paisagem";
                        acusacaoTI.sentences[6] = "Você pode ter tentado melhorar seus métodos e aprimorado a cada caso.";
                        acusacaoTI.sentences[7] = "Mas no final das contas não importou de nada, você irá pagar pelos seus crimes.";
                        acusacaoTI.sentences[8] = "troca pensando";
                        acusacaoTI.sentences[9] = "Após tantos impecilhos que eu coloquei em seu caminho.";
                        acusacaoTI.sentences[10] = "Eu fui pego, fui derrotado";
                        acusacaoTI.sentences[11] = "Parabéns, detetive. Você ganhou.";
                        acusacaoTI.sentences[12] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoTI);
                    }
                    break;
                case 4:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoDelegado.sentencesIngles[0] = "After so many years, after so many cases, will you reduce me to this?!";
                        acusacaoDelegado.sentencesIngles[1] = "Compare me with the rubbish I arrested. You all are ungrateful.";
                        acusacaoDelegado.sentencesIngles[2] = "They should be thanking me for doing this clean in this town.";
                        acusacaoDelegado.sentencesIngles[3] = "troca embara";
                        acusacaoDelegado.sentencesIngles[4] = "You're out of your mind.";
                        acusacaoDelegado.sentencesIngles[5] = "paisagem detetive";
                        acusacaoDelegado.sentencesIngles[6] = "And will be arrested for the murder of 6 people, that fact is immutable.";
                        acusacaoDelegado.sentencesIngles[7] = "troca embara";
                        acusacaoDelegado.sentencesIngles[8] = "I killed them all and I don't regret it.";
                        acusacaoDelegado.sentencesIngles[9] = "Unfortunately the only truth here is that in the cat and mouse game I lost.";
                        acusacaoDelegado.sentencesIngles[10] = "I'm going to be arrested and all of you will regret it, I hope you're happy detective.";
                        acusacaoDelegado.sentencesIngles[11] = "Congratulations, detective. You won.";
                        acusacaoDelegado.sentencesIngles[12] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoDelegado);
                    }
                    else
                    {
                        acusacaoDelegado.sentences[0] = "Depois de tantos anos, de tantos casos, vocês irão me reduzir a isto?!";
                        acusacaoDelegado.sentences[1] = "Me comparar com os lixos que eu prendi. Vocês são uns ingratos.";
                        acusacaoDelegado.sentences[2] = "Deveriam estar me agradecendo por fazer essa limpa nessa cidade. ";
                        acusacaoDelegado.sentences[3] = "troca embara";
                        acusacaoDelegado.sentences[4] = "Você está fora de sí.";
                        acusacaoDelegado.sentences[5] = "paisagem detetive";
                        acusacaoDelegado.sentences[6] = "E será preso pela assassinato de 6 pessoas, esse fato é imutável.";
                        acusacaoDelegado.sentences[7] = "troca embara";
                        acusacaoDelegado.sentences[8] = "Matei todos eles e não me arrependo.";
                        acusacaoDelegado.sentences[9] = "Infelizmente a única verdade aqui é que no jogo de gato e rato eu perdi.";
                        acusacaoDelegado.sentences[10] = "Vou ser preso e todos vocês iram se arrepender com isso, espero que esteja feliz detetive.";
                        acusacaoDelegado.sentences[11] = "Parabéns, detetive. Você ganhou.";
                        acusacaoDelegado.sentences[12] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoDelegado);
                    }
                    break;
                case 5:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoJornalista.sentencesIngles[1] = "Nooooooooooooooo.";
                        acusacaoJornalista.sentencesIngles[2] = "HOW IS IT POSSIBLE?!!!";
                        acusacaoJornalista.sentencesIngles[3] = "You know everything and everyone detective.";
                        acusacaoJornalista.sentencesIngles[4] = "AHHHHHHHHHHHH.";
                        acusacaoJornalista.sentencesIngles[5] = "troca paisagem";
                        acusacaoJornalista.sentencesIngles[6] = "I needed time to think and yours mistakes.";
                        acusacaoJornalista.sentencesIngles[7] = "And that's exactly what you gave me.";
                        acusacaoJornalista.sentencesIngles[8] = "You are under arrest for the crime of 6 murders.";
                        acusacaoJornalista.sentencesIngles[9] = "troca paisagem";
                        acusacaoJornalista.sentencesIngles[10] = "Congratulations, detective. You won.";
                        acusacaoJornalista.sentencesIngles[11] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoJornalista);
                    }
                    else
                    {
                        acusacaoJornalista.sentences[1] = "Nãooooooooooooooo.";
                        acusacaoJornalista.sentences[2] = "COMO É POSSÍVEL?!!!";
                        acusacaoJornalista.sentences[3] = "Você sabe de tudo e de todos detetive.";
                        acusacaoJornalista.sentences[4] = "AHHHHHHHHHHHH.";
                        acusacaoJornalista.sentences[5] = "troca paisagem";
                        acusacaoJornalista.sentences[6] = "Precisava de tempo para pensar e de seus erros.";
                        acusacaoJornalista.sentences[7] = "E isso foi exatamente o que você me deu.";
                        acusacaoJornalista.sentences[8] = "Você está presa pelo crime de 6 assassinatos.";
                        acusacaoJornalista.sentences[9] = "troca paisagem";
                        acusacaoJornalista.sentences[10] = "Parabéns, detetive. Você ganhou.";
                        acusacaoJornalista.sentences[11] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoJornalista);

                    }
                    break;
                case 6:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoRico.sentencesIngles[0] = "That's right, I killed them all.";
                        acusacaoRico.sentencesIngles[1] = "troca paisagem";
                        acusacaoRico.sentencesIngles[2] = "...";
                        acusacaoRico.sentencesIngles[3] = "troca paisagem";
                        acusacaoRico.sentencesIngles[4] = "...";
                        acusacaoRico.sentencesIngles[5] = "troca embara";
                        acusacaoRico.sentencesIngles[6] = "That's it? without speech?";
                        acusacaoRico.sentencesIngles[7] = "troca paisagem";
                        acusacaoRico.sentencesIngles[8] = "I don't need to say anything, my lawyers will clear the bar for me. Money will save me, with it I can do everything.";
                        acusacaoRico.sentencesIngles[9] = "troca embara";
                        acusacaoRico.sentencesIngles[10] = "It doesn't work that well, you won't get a fine. In this town, murder is not bailed out by law.";
                        acusacaoRico.sentencesIngles[11] = "troca embara";
                        acusacaoRico.sentencesIngles[12] = "...";
                        acusacaoRico.sentencesIngles[13] = "OMG, detective, there were only 6 victims, it was nothing serious, I can pay you as much as you want. I can't go to jail, I still have a lot to gain.";
                        acusacaoRico.sentencesIngles[14] = "troca pensando";
                        acusacaoRico.sentencesIngles[15] = "Yes, you will win, you will get many years in jail. You're stuck.";
                        acusacaoRico.sentencesIngles[16] = "exchange thinking";
                        acusacaoRico.sentencesIngles[17] = "Congratulations, detective. You won.";
                        acusacaoRico.sentencesIngles[18] = "You won a lawsuit from me for wanting to arrest me for my murders.";
                        acusacaoRico.sentencesIngles[19] = "troca embara";
                        acusacaoRico.sentencesIngles[20] = "(This one has gone over the edge, can't speak sense anymore.)";
                        acusacaoRico.sentencesIngles[21] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoRico);
                    }
                    else
                    {
                        acusacaoRico.sentences[0] = "É isso mesmo, matei todos eles.";
                        acusacaoRico.sentences[1] = "troca paisagem";
                        acusacaoRico.sentences[2] = "...";
                        acusacaoRico.sentences[3] = "troca paisagem";
                        acusacaoRico.sentences[4] = "...";
                        acusacaoRico.sentences[5] = "troca embara";
                        acusacaoRico.sentences[6] = "É isso? sem discurso?";
                        acusacaoRico.sentences[7] = "troca paisagem";
                        acusacaoRico.sentences[8] = "Eu não preciso falar nada, meus advogados irão me limpara a barra. O dinheiro irá me salvar, com ele eu posso fazer tudo.";
                        acusacaoRico.sentences[9] = "troca embara";
                        acusacaoRico.sentences[10] = "Não funciona bem assim, você não será julgado por uma multa qualquer. Nessa cidade, assassinato não tem fiança pela lei. ";
                        acusacaoRico.sentences[11] = "troca embara";
                        acusacaoRico.sentences[12] = "...";
                        acusacaoRico.sentences[13] = "MDS, detetive, foram só 6 assassinatos, não foi nada grave, eu posso pagar o quanto vocês quiserem. Eu não posso ir preso, tenho muito a ganhar ainda.";
                        acusacaoRico.sentences[14] = "troca pensando";
                        acusacaoRico.sentences[15] = "Você vai ganhar sim, vai ganhar muitos anos de cadeia. Você está preso.";
                        acusacaoRico.sentences[16] = "troca pensando";
                        acusacaoRico.sentences[17] = "Parabéns, detetive. Você ganhou.";
                        acusacaoRico.sentences[18] = "Você ganhou um processo meu por querer me prender pelos meu assassinatos.";
                        acusacaoRico.sentences[19] = "troca embara";
                        acusacaoRico.sentences[20] = "(Esse ai já despirocou de vez, não está falando mais nada com nada)";
                        acusacaoRico.sentences[21] = "finalizar";
                        controleAcusacao2.StartDialogue(acusacaoRico);
                    }
                    break;
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
            FinalDialiogoBool = false;
            dialogodelegadodetetivecontrol.StartDialogue(dialogodelegadodetetive);
            DelegadoFalando = true;
            AcusaçãoBool = false;

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
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (jogoFinalizado == false)
        {
            if (ScenesManager.DialogoTransicao == false)
            {
                if (!DelegadoFalando && !AcusaçãoBool)
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
                            StartCoroutine(LigaE());
                        }
                    }
                }
                else if (!AcusaçãoBool && DelegadoFalando)
                {
                    Transition.SetBool("Abrir", false);
                    if (FinalDialiogoBool == true)
                    {
                        FinalizaGame();
                        DelegadoFalando = false;
                        jogoFinalizado = true;
                        Creditos.SetActive(true);
                        FundoPreto.SetActive(true);
                        StartCoroutine(LigaE());
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (FinalDialiogoBool == false)
                        {
                            dialogodelegadodetetivecontrol.DisplayNextSentence(dialogodelegadodetetive);
                        }
                    }
                }
                else if (AcusaçãoBool && !DelegadoFalando)
                {
                    Transition.SetBool("Abrir", false);
                    if (FinalDialiogoBool == true)
                    {
                        Evidencias.SetActive(true);
                        cadernoOriginal.EscreverEvidencias();
                        caderno.SetBool("Rela", true);
                        perguntando = true;
                        PerguntaFinal = true;
                        interesseResposta = -1;
                        respostaTexto = "";
                        AtivaUltimosBotoes();
                        Transition.SetBool("Abrir", true);
                    }
                    else
                    {
                        Transition.SetBool("Abrir", false);
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (FinalDialiogoBool == false)
                        {
                            switch (SpawnObjects.numeroAssassino)
                            {
                                case 0:
                                    controleAcusacao.DisplayNextSentence(acusacaoParceiro);
                                    break;
                                case 1:
                                    controleAcusacao.DisplayNextSentence(acusacaoPolicial);
                                    break;
                                case 2:
                                    controleAcusacao.DisplayNextSentence(acusacaoLegista);
                                    break;
                                case 3:
                                    controleAcusacao.DisplayNextSentence(acusacaoTI);
                                    break;
                                case 4:
                                    controleAcusacao.DisplayNextSentence(acusacaoDelegado);
                                    break;
                                case 5:
                                    controleAcusacao.DisplayNextSentence(acusacaoJornalista);
                                    break;
                                case 6:
                                    controleAcusacao.DisplayNextSentence(acusacaoRico);
                                    break;
                            }
                        }
                    }
                }
                else if (AcusaçãoBool && DelegadoFalando)
                {
                    Transition.SetBool("Abrir", false);
                    if (FinalDialiogoBool == true)
                    {
                        DelegadoFalando = false;
                        jogoFinalizado = true;
                        Creditos.SetActive(true);
                        FundoPreto.SetActive(true);
                        StartCoroutine(LigaE());
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (FinalDialiogoBool == false)
                        {
                            switch (SpawnObjects.numeroAssassino)
                            {
                                case 0:
                                    controleAcusacao2.DisplayNextSentence(acusacaoParceiro);
                                    break;
                                case 1:
                                    controleAcusacao2.DisplayNextSentence(acusacaoPolicial);
                                    break;
                                case 2:
                                    controleAcusacao2.DisplayNextSentence(acusacaoLegista);
                                    break;
                                case 3:
                                    controleAcusacao2.DisplayNextSentence(acusacaoTI);
                                    break;
                                case 4:
                                    controleAcusacao2.DisplayNextSentence(acusacaoDelegado);
                                    break;
                                case 5:
                                    controleAcusacao2.DisplayNextSentence(acusacaoJornalista);
                                    break;
                                case 6:
                                    controleAcusacao2.DisplayNextSentence(acusacaoRico);
                                    break;
                            }
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
    public void controlCredits()
    {
        switch (creditoInt)
        {
            case 1:
                switch (FinalNumero)
                {
                    case 0:
                        if (PlayerData.Idioma == "ingles")
                        {
                            textCreditos.text = "<color=red>Bad End</color>";
                        }
                        else
                        {
                            textCreditos.text = "<color=red>Final Ruim</color>";
                        }
                        break;
                    case 1:
                        if (PlayerData.Idioma == "ingles")
                        {
                            textCreditos.text = "<color=white>Neutral End</color>";
                        }
                        else
                        {
                            textCreditos.text = "<color=white>Final Neutro</color>";
                        }
                        break;
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            textCreditos.text = "<color=white>Neutral End</color>";
                        }
                        else
                        {
                            textCreditos.text = "<color=white>Final Neutro</color>";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            textCreditos.text = "<color=blue>Good End</color>";
                        }
                        else
                        {
                            textCreditos.text = "<color=blue>Final Bom</color>";
                        }
                        break;
                }
                break;
            case 2:
                textCreditos.text = "A game by" + "\n" +
                    "Gamonga Tensou";
                break;
            case 3:
                textCreditos.text = "Music             Sound Effects" + "\n" +
                    "Kaoid!D          Gamonga Tensou";
                break;
            case 4:
                textCreditos.text = "Translation & Correction - English" + "\n" +
                    "Mafagafo";
                break;
            case 5:
                textCreditos.text = "Design/Art            Script/Director"+ "\n" +
                    "Gamonga Tensou          Gamonga Tensou";
                break;
            case 6:
                textCreditos.text = "Beta Testers"+ "\n" + "\n" +
                    "lcsampaio" + "\n" +
                    "Kaoid!D" + "\n" +
                    "Wassup" + "\n" +
                    "LucasTyph" + "\n" +
                    "Felipe USP";
                break;
            case 7:
                textCreditos.text = "Special Thanks"+ "\n" + "\n" +
                    "Jubs" + "\n" +
                    "Raphael Marques de Barros" + "\n" +
                    "WesComp" + "\n" +
                    "Satrus" + "\n" +
                    "Felipe Senpai" + "\n" +
                    "Rubens Surfista";
                break;
            case 8:
                textCreditos.text = "And a Special Thanks to You for playing my game";
                break;
        }
    }
    IEnumerator DesligaE()
    {
        for (i = 1; i > -0.5; i = i - 0.01f)
        {
            textoCreditos.color = new Color(255, 255, 255, i);
            yield return new WaitForSeconds(0.025f);
        }
        creditoInt++;
        controlCredits();
        StartCoroutine(LigaE());
    }
    IEnumerator LigaE()
    {
        for (i = 0; i < 1.5; i = i + 0.01f)
        {
            textoCreditos.color = new Color(255, 255, 255, i);
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(DesligaE());
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
        FinalDialiogoBool = false;
        AcusaçãoBool = false;
        DelegadoFalando = true;
        DesativaUltimosBotoes();
        switch (SpawnObjects.numeroAssassino)
        {
            case 0:
                if (interesseResposta == 3)
                {
                    AcusaçãoBool = true;
                    Pontuacao++;
                }
                break;
            case 1:
                if (interesseResposta == 0)
                {
                    AcusaçãoBool = true;
                    Pontuacao++;
                }
                break;
            case 2:
                if (interesseResposta == 0 || respostaTexto == "Justica")
                {
                    AcusaçãoBool = true;
                    Pontuacao++;
                }
                break;
            case 3:
                if (interesseResposta == 0 || respostaTexto == "Prazer")
                {
                    AcusaçãoBool = true;
                    Pontuacao++;
                }
                break;
            case 4:
                if (interesseResposta == 2 || respostaTexto == "Justica")
                {
                    AcusaçãoBool = true;
                    Pontuacao++;
                }
                break;
            case 5:
                if (interesseResposta == 1 || respostaTexto == "Raiva")
                {
                    AcusaçãoBool = true;
                    Pontuacao++;
                }
                break;
            case 6:
                if (interesseResposta == 3 || respostaTexto == "Raiva" || respostaTexto == "Roubo")
                {
                    AcusaçãoBool = true;
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
            FinalDialiogoBool = false;
            dialogodelegadodetetivecontrol.StartDialogue(dialogodelegadodetetive);
            DelegadoFalando = true;
            FinalizaGame();
        }
        else
        {
            AcusaçãoBool = true;
            DelegadoFalando = false;
            switch (SpawnObjects.numeroAssassino)
            {
                case 0:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoParceiro.sentencesIngles[0] = "Man, how come I never thought about that before?";
                        acusacaoParceiro.sentencesIngles[1] = "But detective, I'm always with you.";
                        acusacaoParceiro.sentencesIngles[2] = "Why are you accusing me like that?";
                        acusacaoParceiro.sentencesIngles[3] = "If I were you I would have suspected Jony, this policeman is definitely the killer.";
                        acusacaoParceiro.sentencesIngles[4] = "troca paisagem";
                        acusacaoParceiro.sentencesIngles[5] = "I'll show you that behind that silly mask you wear.";
                        acusacaoParceiro.sentencesIngles[6] = "There is a serial killer.";
                        acusacaoParceiro.sentencesIngles[7] = "The police officer cannot be charged with the series of crimes.";
                        acusacaoParceiro.sentencesIngles[8] = "You have victims and motives that the police officer would never have.";
                        acusacaoParceiro.sentencesIngles[9] = "What you did that Johnny wouldn't do is:";
                        acusacaoParceiro.sentencesIngles[10] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoParceiro);
                    }
                    else
                    {
                        acusacaoParceiro.sentences[0] = "Caraca, como eu nunca pensei nisso antes?";
                        acusacaoParceiro.sentences[1] = "Mas detetive, estou sempre com você.";
                        acusacaoParceiro.sentences[2] = "Por que está me acusando dessa maneira?";
                        acusacaoParceiro.sentences[3] = "Se eu fosse você teria desconfiado do Jony, esse policial com certeza é o assassino.";
                        acusacaoParceiro.sentences[4] = "troca paisagem";
                        acusacaoParceiro.sentences[5] = "Irei mostrar que por trás dessa máscara de bobo que você usa.";
                        acusacaoParceiro.sentences[6] = "Existe um assassino em série.";
                        acusacaoParceiro.sentences[7] = "O policial não pode ser acusado dos crimes em série.";
                        acusacaoParceiro.sentences[8] = "Você tem vítimas e motivos que o policial jamais teria.";
                        acusacaoParceiro.sentences[9] = "O que você fez que o Johnny não faria é:";
                        acusacaoParceiro.sentences[10] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoParceiro);
                    }
                    break;
                case 1:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoPolicial.sentencesIngles[0] = "Me? Detective, what is this charge?";
                        acusacaoPolicial.sentencesIngles[1] = "There are people much more suspicious than me.";
                        acusacaoPolicial.sentencesIngles[2] = "Look at Steve! He's obviously the killer.";
                        acusacaoPolicial.sentencesIngles[3] = "troca paisagem";
                        acusacaoPolicial.sentencesIngles[4] = "You did something Steve would never do.";
                        acusacaoPolicial.sentencesIngles[5] = "He made victims and had reasons that poor Steve doesn't even have the ability to think.";
                        acusacaoPolicial.sentencesIngles[6] = "What you did that Steve wouldn't do is:";
                        acusacaoPolicial.sentencesIngles[7] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoPolicial);
                    }
                    else
                    {
                        acusacaoPolicial.sentences[0] = "Eu? Detetive, que acusação é essa?";
                        acusacaoPolicial.sentences[1] = "Tem pessoas muito mais suspeitas do que eu.";
                        acusacaoPolicial.sentences[2] = "Olha o Steve! Ele obviamente é o assassino.";
                        acusacaoPolicial.sentences[3] = "troca paisagem";
                        acusacaoPolicial.sentences[4] = "Você fez algo que o Steve jamais faria.";
                        acusacaoPolicial.sentences[5] = "Fez vítimas e teve motivos que o coitado do Steve nem tem capacidade de pensar.";
                        acusacaoPolicial.sentences[6] = "O que você fez que o Steve não faria é:";
                        acusacaoPolicial.sentences[7] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoPolicial);
                    }
                    break;
                case 2:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoLegista.sentencesIngles[0] = "Calm down, why me?";
                        acusacaoLegista.sentencesIngles[1] = "Among all the people here I am the most honest and fair.";
                        acusacaoLegista.sentencesIngles[2] = "You must be going crazy, detective.";
                        acusacaoLegista.sentencesIngles[3] = "How do you know it's me and not the journalist, for instance?";
                        acusacaoLegista.sentencesIngles[4] = "You can't prove it.";
                        acusacaoLegista.sentencesIngles[5] = "troca paisagem";
                        acusacaoLegista.sentencesIngles[6] = "I'll show you something you did that others wouldn't do.";
                        acusacaoLegista.sentencesIngles[7] = "Something only you would be capable of.";
                        acusacaoLegista.sentencesIngles[8] = "What you did that Jessie wouldn't do is:";
                        acusacaoLegista.sentencesIngles[9] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoLegista);
                    }
                    else
                    {
                        acusacaoLegista.sentences[0] = "Calma aí, por que eu?";
                        acusacaoLegista.sentences[1] = "Dentre todas as pessoas aqui eu sou a mais honesta e justa.";
                        acusacaoLegista.sentences[2] = "Você deve estar ficando maluco, detetive.";
                        acusacaoLegista.sentences[3] = "Como você sabe que sou eu e não a jornalista, como exemplo?";
                        acusacaoLegista.sentences[4] = "Você não tem como provar.";
                        acusacaoLegista.sentences[5] = "troca paisagem";
                        acusacaoLegista.sentences[6] = "Eu irei mostrar algo que você fez e que os demais não fariam.";
                        acusacaoLegista.sentences[7] = "Algo que somente você seria capaz.";
                        acusacaoLegista.sentences[8] = "O que você fez que a Jessie não faria é:";
                        acusacaoLegista.sentences[9] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoLegista);
                    }
                    break;
                case 3:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoTI.sentencesIngles[0] = "Detective, you must be kidding.";
                        acusacaoTI.sentencesIngles[1] = "It's not logical to accuse me.";
                        acusacaoTI.sentencesIngles[2] = "Among everyone here in this room I am the cleanest.";
                        acusacaoTI.sentencesIngles[3] = "Why didn't you accuse Steve?";
                        acusacaoTI.sentencesIngles[4] = "You lost track.";
                        acusacaoTI.sentencesIngles[5] = "troca paisagem";
                        acusacaoTI.sentencesIngles[6] = "You did something Steve would never do.";
                        acusacaoTI.sentencesIngles[7] = "You made victims and had reasons that poor Steve doesn't even have the ability to think.";
                        acusacaoTI.sentencesIngles[8] = "What you did that Steve wouldn't do is:";
                        acusacaoTI.sentencesIngles[9] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoTI);
                    }
                    else
                    {
                        acusacaoTI.sentences[0] = "Detetive, você só pode estar brincando.";
                        acusacaoTI.sentences[1] = "Não tem lógica me acusar.";
                        acusacaoTI.sentences[2] = "Dentre todos aqui nessa sala eu sou o mais limpo.";
                        acusacaoTI.sentences[3] = "Por que não acusou o Steve?";
                        acusacaoTI.sentences[4] = "Você perdeu a noção.";
                        acusacaoTI.sentences[5] = "troca paisagem";
                        acusacaoTI.sentences[6] = "Você fez algo que o Steve jamais faria.";
                        acusacaoTI.sentences[7] = "Fez vítimas e teve motivos que o coitado do Steve nem tem capacidade de pensar.";
                        acusacaoTI.sentences[8] = "O que você fez que o Steve não faria é:";
                        acusacaoTI.sentences[9] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoTI);
                    }
                    break;
                case 4:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoDelegado.sentencesIngles[0] = "Is that some kind of joke, detective?";
                        acusacaoDelegado.sentencesIngles[1] = "Do you have any idea what kind of accusation you are making?";
                        acusacaoDelegado.sentencesIngles[2] = "To accuse one of your work partners.";
                        acusacaoDelegado.sentencesIngles[3] = "Your own boss.";
                        acusacaoDelegado.sentencesIngles[4] = "Why not accuse someone like Sanefuji?";
                        acusacaoDelegado.sentencesIngles[5] = "troca paisagem";
                        acusacaoDelegado.sentencesIngles[6] = "Sanefuji wouldn't do something you did.";
                        acusacaoDelegado.sentencesIngles[7] = "What you did that Sanefuji wouldn't do is:";
                        acusacaoDelegado.sentencesIngles[8] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoDelegado);
                    }
                    else
                    {
                        acusacaoDelegado.sentences[0] = "Isso é um tipo de piada, detetive?";
                        acusacaoDelegado.sentences[1] = "Você tem ideia do tipo de acusação que está fazendo?";
                        acusacaoDelegado.sentences[2] = "Acusar um dos seus parceiros de trabalho.";
                        acusacaoDelegado.sentences[3] = "Seu próprio chefe.";
                        acusacaoDelegado.sentences[4] = "Por que não acusa alguém como o Sanefuji?";
                        acusacaoDelegado.sentences[5] = "troca paisagem";
                        acusacaoDelegado.sentences[6] = "O Sanefuji não faria algo que você fez.";
                        acusacaoDelegado.sentences[7] = "O que você fez que o Sanefuji não faria é:";
                        acusacaoDelegado.sentences[8] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoDelegado);
                    }
                    break;
                case 5:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoJornalista.sentencesIngles[0] = "Here comes one more attack on the poor journalist.";
                        acusacaoJornalista.sentencesIngles[1] = "Answer me, detective. Why?";
                        acusacaoJornalista.sentencesIngles[2] = "Why does it have to be the journalist?";
                        acusacaoJornalista.sentencesIngles[3] = "Why don't you accuse the medical examiner?!";
                        acusacaoJornalista.sentencesIngles[4] = "troca paisagem";
                        acusacaoJornalista.sentencesIngles[5] = "Despite being an investigative journalist, you left many clues for me.";
                        acusacaoJornalista.sentencesIngles[6] = "Devi wouldn't do something you did.";
                        acusacaoJornalista.sentencesIngles[7] = "What you did that Devi wouldn't do is:";
                        acusacaoJornalista.sentencesIngles[8] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoJornalista);
                    }
                    else
                    {
                        acusacaoJornalista.sentences[0] = "Lá vem mais um atacar a pobre jornalista.";
                        acusacaoJornalista.sentences[1] = "Me responda, detetive. Por que?";
                        acusacaoJornalista.sentences[2] = "Por que logo a jornalista?";
                        acusacaoJornalista.sentences[3] = "Por que não acusa a legista?!";
                        acusacaoJornalista.sentences[4] = "troca paisagem";
                        acusacaoJornalista.sentences[5] = "Apesar de jornalista investigativa, você deixou muitas pistas para mim.";
                        acusacaoJornalista.sentences[6] = "A Devi não faria algo que você fez.";
                        acusacaoJornalista.sentences[7] = "O que você fez que a Devi não faria é:";
                        acusacaoJornalista.sentences[8] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoJornalista);

                    }
                    break;
                case 6:
                    if (PlayerData.Idioma == "ingles")
                    {
                        acusacaoRico.sentencesIngles[0] = "I'm sorry, is this some kind of joke I'm too rich to understand?";
                        acusacaoRico.sentencesIngles[1] = "Among all here I am the cleanest and most honest.";
                        acusacaoRico.sentencesIngles[2] = "Detective, you're just accusing me because I'm not part of your gang.";
                        acusacaoRico.sentencesIngles[3] = "I would like to see you accuse the sheriff.";
                        acusacaoRico.sentencesIngles[4] = "troca paisagem";
                        acusacaoRico.sentencesIngles[5] = "I will do better than that. I will show that it is not the sheriff.";
                        acusacaoRico.sentencesIngles[6] = "Showing that you are the real killer.";
                        acusacaoRico.sentencesIngles[7] = "What you did that the sheriff would not do is:";
                        acusacaoRico.sentencesIngles[8] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoRico);
                    }
                    else
                    {
                        acusacaoRico.sentences[0] = "Me desculpe, isso é um tipo de piada que eu sou rico demais para entender?";
                        acusacaoRico.sentences[1] = "Entre todos aqui eu sou o mais limpo e honesto.";
                        acusacaoRico.sentences[2] = "Detetive, só está me acusando porque não sou parte da sua gangue.";
                        acusacaoRico.sentences[3] = "Queria ver você acusar o delegado.";
                        acusacaoRico.sentences[4] = "troca paisagem";
                        acusacaoRico.sentences[5] = "Farei melhor do que isso. Irei mostrar que não é o delegado.";
                        acusacaoRico.sentences[6] = "Mostrando que você é o nosso verdadeiro assassino.";
                        acusacaoRico.sentences[7] = "O que você fez que o delegado não faria é:";
                        acusacaoRico.sentences[8] = "finalizar";
                        controleAcusacao.StartDialogue(acusacaoRico);
                    }
                    break;
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
            FinalDialiogoBool = false;
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
            FinalDialiogoBool = false;
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
