using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public Transform CorpoJornalista;
    public Transform CorpoProprietario;
    public Dialogue legistaDialogo;
    public Dialogue TIDialogo;
    public Dialogue policialDialogo;
    public Dialogue jornalistaDialogo;
    public Text texto;
    public GameObject botaoSim;
    public GameObject botaoNao;
    public static Animator animator;
    public Dialogue dialogoTIgostaDeXovens;
    public DialogueControl dialogoTIgostaDeXovensControl;
    public Dialogue dialogoTINMataVinganca;
    public DialogueControl dialogoTINMataVingancaControl;
    public Dialogue dialogoPolicialFimNTortura;
    public DialogueControl dialogoPolicialFimNTorturaControl;
    public Dialogue dialogoDelegadoTransicaonRouba;
    public DialogueControl dialogoDelegadoTransicaonRoubaControl;
    public Dialogue dialogoPolicialNMataIdosa;
    public DialogueControl dialogoPolicialNMataIdosaControl;
    public Dialogue dialogoComecoJornalistaBrigaComALegista;
    public DialogueControl dialogoComecoJornalistaBrigaComALegistaControl;
    public Dialogue dialogoFinalLegistaNMataHomens;
    public DialogueControl dialogoFinalLegistaNMataHomensControl;
    public Dialogue dialogoFinalDoJogo;
    public Dialogue dialogoParceiroDetetiveIndoParaDelegacia;
    public Dialogue dialogoDelegadoExplicando;
    public Dialogue diaologoFinalParceiro;
    public Dialogue dialogoInicioTestemunhaJornalista;
    public Dialogue dialogoInicioTestemunhaRico;
    public DialogueControl FinalDoJogoControl;
    public DialogueControl dialogueControl;
    public DialogueControl dialogueControlFinal;
    public Dialogue diaologoInicialParceiro;
    public DialogueControl dialogueControlInicialParceiro;
    public bool isInRange;
    public Text testemunhaTexto;
    public Animator Transition;
    public Animator animatorTutorial;
    public movimento movimento;
    public static int ActualScene = 0;
    public static int CrimeScene = 2;
    public static Text E;
    private float i;
    private float randomNumber;
    public static bool DialogoTransicao;
    public static bool startaFinal;
    public static bool PrimeiraVezDialogoTransicao;
    public static bool entrouTutorial;
    public static bool entrouTutorialPensamentos;
    public static bool entrouTutorialTestemunha;
    public static bool entrouTutorialEvidencias;
    public static bool entrouTutorialControles;
    public static bool entrouTutorialIA;
    public static bool entrouTutorialRelatorio;
    public static string nomeDaPessoaNoFinal;
    public static string nomeDaPessoaTransicao;
    public static bool ComeuAMaeDoPolicial;
    public static bool dialogoInicioParceirobool;

    public static bool jornalistaBrigouComALegista;
    public static bool eraHomemUltimoCaso;
    // Start is called before the first frame update
    void Start()
    {
        dialogoInicioParceirobool = false;
        jornalistaBrigouComALegista = false;
        ComeuAMaeDoPolicial = false;
        entrouTutorial = false;
        startaFinal = true;
        animator = GameObject.Find("CarroTransicaoGIF").GetComponent<Animator>();
        PlayerData data = SaveSystem.LoadPlayer();
        ComeuAMaeDoPolicial = data.ComeuAMaeDoPolicial;
        if (MainMenu.PrimeiroCaso == false)
        {
            eraHomemUltimoCaso = data.sexoUltimoCaso;
            entrouTutorialPensamentos = data.entrouTutorialPensamentos;
            entrouTutorialTestemunha = data.entrouTutorialTestemunha;
            entrouTutorialEvidencias = data.entrouTutorialEvidencias;
            entrouTutorialControles = data.entrouTutorialControles;
            entrouTutorialIA = data.entrouTutorialIA;
            entrouTutorialRelatorio = data.entrouTutorialRelatorio;
            PrimeiraVezDialogoTransicao = false;
        }
        else
        {
            entrouTutorialPensamentos = false;
            entrouTutorialTestemunha = false;
            entrouTutorialEvidencias = false;
            entrouTutorialControles = false;
            entrouTutorialIA = false;
            entrouTutorialRelatorio = false;
            PrimeiraVezDialogoTransicao = true;
        }
        DialogoTransicao = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DialogoTransicao = true;
            animator.SetBool("CarroGif", true);
            if (Random.value >= 0.5f)
            {
                nomeDaPessoaTransicao = "parceiro";
                dialogueControl.StartDialogue(dialogoParceiroDetetiveIndoParaDelegacia);
            }
            else
            {
                nomeDaPessoaTransicao = "delegado";
                dialogoDelegadoNRouba();
                dialogueControl.StartDialogue(dialogoParceiroDetetiveIndoParaDelegacia);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            DialogoTransicao = true;
            animator.SetBool("CarroGif", true);
            FinalDoJogoControl.StartDialogue(dialogoFinalDoJogo);
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (Random.value >= 0.5f)
            {
                CorpoProprietario.position = new Vector3(100f, 100f, -15);
                CorpoJornalista.position = new Vector3(21.59f, -13.83f, -15);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 4)
        {
            if (PauseMenu.NumeroDeCasosJogadoPeloPlayer > 2)
            {
                trocaTestemunhoJornalista();
                if (Random.value >= 0.5f)
                {
                    trocaTestemunhoRico();
                }
                else
                {
                    trocaTestemunhoRicoNMataJovens();
                }
            }
            if (PrimeiraVezDialogoTransicao)
            {
                DialogoTransicao = true;
                animator.SetBool("CarroGif", true);
                PrimeiraVezDialogoTransicao = false;
                dialogueControl.StartDialogue(dialogoDelegadoExplicando);
            }
            else
            {
                if (Random.value > 0.3f)
                {
                    if (Assassino.numeroAssassinoSegundo == 4 || Assassino.numeroAssassino == 4 || IA.taxaDeAcertos < 0.8f)
                    {
                        DialogoTransicao = true;
                        animator.SetBool("CarroGif", true);
                        PrimeiraVezDialogoTransicao = false;
                        DelegadoInicialCritica();
                        dialogueControl.StartDialogue(dialogoDelegadoExplicando);
                    }
                    else
                    {
                        DialogoTransicao = true;
                        animator.SetBool("CarroGif", true);
                        PrimeiraVezDialogoTransicao = false;
                        DelegadoInicialElogio();
                        dialogueControl.StartDialogue(dialogoDelegadoExplicando);
                    }
                }
                else
                {
                    if (Random.value > 0.5f)
                    {
                        if (Random.value > 0.5f)
                        {
                            DialogoTransicao = true;
                            animator.SetBool("CarroGif", true);
                            PrimeiraVezDialogoTransicao = false;
                            jornalistaBrigouComALegista = true;
                            if (eraHomemUltimoCaso)
                            {
                                ComecoJornalistaBrigaHomemVitima();
                            }
                            else
                            {
                                ComecoJornalistaBrigaMulherVitima();
                            }
                            dialogueControl.StartDialogue(jornalistaDialogo);
                        }
                        else
                        {
                            DialogoTransicao = true;
                            animator.SetBool("CarroGif", true);
                            PrimeiraVezDialogoTransicao = false;
                            dialogoInicioParceirobool = true;
                            dialogueControl.StartDialogue(diaologoInicialParceiro);
                        }
                    }
                    else
                    {
                        DialogoTransicao = true;
                        animator.SetBool("CarroGif", true);
                        PrimeiraVezDialogoTransicao = false;
                        DelegadoNMataIdosos();
                        dialogueControl.StartDialogue(dialogoDelegadoExplicando);
                    }
                }
            }
        }
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            botaoSim.SetActive(false);
            botaoNao.SetActive(false);
            E = GameObject.Find("E").GetComponent<Text>();
        }
        ActualScene = SceneManager.GetActiveScene().buildIndex;
        if ((SceneManager.GetActiveScene().buildIndex == 1))
        {
            ActualScene = data.actualCrimeScene;
        }
        CrimeScene = ActualScene;
    }



    public void dialogoTINMataVingancaFunction()
    {
        if (PlayerData.Idioma == "ingles")
        {
            TIDialogo.sentences[0] = "Hello, detective.";
            TIDialogo.sentences[1] = "Have you watched the new C.O.P. movie?";
            TIDialogo.sentences[2] = "troca paisagem";
            TIDialogo.sentences[3] = "Haven't seen it yet. I have been busy.";
            TIDialogo.sentences[4] = "Steve has been saying good things about it. What do you think?";
            TIDialogo.sentences[5] = "troca paisagem";
            TIDialogo.sentences[6] = "I really liked it, only got a problem with the protagonist's decisions";
            TIDialogo.sentences[7] = "troca pensando";
            TIDialogo.sentences[8] = "Why?";
            TIDialogo.sentences[9] = "In this movie, he is seeking revenge for his wife's death.";
            TIDialogo.sentences[10] = "And his children's.";
            TIDialogo.sentences[11] = "And his dog's.";
            TIDialogo.sentences[12] = "He ends up dying because of it.";
            TIDialogo.sentences[13] = "I didn't like his having feelings of revenge, I don't find it heroic.";
            TIDialogo.sentences[14] = "That I didn't like as much.";
            TIDialogo.sentences[15] = "Right, detective?";
            TIDialogo.sentences[16] = "troca desgosto";
            TIDialogo.sentences[17] = "...";
            TIDialogo.sentences[18] = "(SPOILEEEEEEEEEEER!!!!)";
            TIDialogo.sentences[19] = "finalizar";
        }
        else
        {
            TIDialogo.sentences[0] = "Olá, detetive.";
            TIDialogo.sentences[1] = "Viu o novo filme do C.O.P.?";
            TIDialogo.sentences[2] = "troca paisagem";
            TIDialogo.sentences[3] = "Ainda não vi, estou sem tempo.";
            TIDialogo.sentences[4] = "O Steve tem falado bem do filme. O que você achou?";
            TIDialogo.sentences[5] = "troca paisagem";
            TIDialogo.sentences[6] = "Eu gostei bastante, só tive um problema com as decisões do protagonista";
            TIDialogo.sentences[7] = "troca pensando";
            TIDialogo.sentences[8] = "Por que?";
            TIDialogo.sentences[9] = "Nesse filme ele está em busca de vingança pela morte de sua esposa.";
            TIDialogo.sentences[10] = "E filhos.";
            TIDialogo.sentences[11] = "E cachorro.";
            TIDialogo.sentences[12] = "E no final ele acaba morrendo por causa disso.";
            TIDialogo.sentences[13] = "Não gostei dele ter esse sentimento de vingança, não acho muito heroico.";
            TIDialogo.sentences[14] = "Por isso acabou não me agradando tanto.";
            TIDialogo.sentences[15] = "Entendeu, detetive?";
            TIDialogo.sentences[16] = "troca desgosto";
            TIDialogo.sentences[17] = "...";
            TIDialogo.sentences[18] = "(SPOILEEEEEEEEEEER!!!!)";
            TIDialogo.sentences[19] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(TIDialogo);
    }


    public void dialogoTIgostaDeXovensFunction()
    {
        if (PlayerData.Idioma == "ingles")
        {
            TIDialogo.sentencesIngles[0] = "Hello detective.";
            TIDialogo.sentencesIngles[1] = "troca paisagem";
            TIDialogo.sentencesIngles[2] = "Hello Kyle.";
            TIDialogo.sentencesIngles[3] = "troca paisagem";
            TIDialogo.sentencesIngles[4] = "I saw that there was a journalist behind you today asking you questions.";
            TIDialogo.sentencesIngles[5] = "troca embara";
            TIDialogo.sentencesIngles[6] = "It was Jessie, she's an investigative journalist for the local paper. She wanted more details about the serial killer.";
            TIDialogo.sentencesIngles[7] = "troca paisagem";
            TIDialogo.sentencesIngles[8] = "She's pretty hot, would you happen to have her number? For a friend of mine, of course.";
            TIDialogo.sentencesIngles[9] = "troca pensando";
            TIDialogo.sentencesIngles[10] = "Are you interested? I know there are some ladies here at the police station who are making a fuss about you. Hahaha.";
            TIDialogo.sentencesIngles[11] = "troca pensando";
            TIDialogo.sentencesIngles[12] = "Unfortunately. Haha.";
            TIDialogo.sentencesIngles[13] = "I don't like old people.";
            TIDialogo.sentencesIngles[14] = "But the journalist seemed pretty cool to me.";
            TIDialogo.sentencesIngles[15] = "My... My friend says she's cool.";
            TIDialogo.sentencesIngles[16] = "troca paisagem";
            TIDialogo.sentencesIngles[17] = "Hahaha. Your friend, right. I see what I can do.";
            TIDialogo.sentencesIngles[18] = "But if I, as a friend, can tell you: she is unbearable.";
            TIDialogo.sentencesIngles[19] = "troca paisagem";
            TIDialogo.sentencesIngles[20] = "Okay, I believe I can handle it, detective. Thanks for your help.";
            TIDialogo.sentencesIngles[21] = "finalizar";
        }
        else
        {
            TIDialogo.sentences[0] = "Olá, detetive.";
            TIDialogo.sentences[1] = "troca paisagem";
            TIDialogo.sentences[2] = "Olá, Kyle.";
            TIDialogo.sentences[3] = "troca paisagem";
            TIDialogo.sentences[4] = "Eu vi que tinha uma jornalista atrás de você hoje te enchendo de perguntas.";
            TIDialogo.sentences[5] = "troca embara";
            TIDialogo.sentences[6] = "Era a Jessie, ela é jornalista investigativa do jornal local. Ela queria mais detalhes sobre o assassino em série.";
            TIDialogo.sentences[7] = "troca paisagem";
            TIDialogo.sentences[8] = "Ela é bem gata, você por acaso teria o número dela? Para um amigo meu, é claro.";
            TIDialogo.sentences[9] = "troca pensando";
            TIDialogo.sentences[10] = "Está interessado? Eu sei que tem umas senhorinhas aqui na delegacia que ficam dando mole para você. Hahaha.";
            TIDialogo.sentences[11] = "troca pensando";
            TIDialogo.sentences[12] = "Infelizmente. Haha.";
            TIDialogo.sentences[13] = "Não gosto de gente velha.";
            TIDialogo.sentences[14] = "Mas a jornalista me pareceu bem legal.";
            TIDialogo.sentences[15] = "Meu... Meu amigo disse que ela é legal.";
            TIDialogo.sentences[16] = "troca paisagem";
            TIDialogo.sentences[17] = "Hahaha. Seu amigo, né. Eu vejo o que consigo fazer.";
            TIDialogo.sentences[18] = "Mas se eu, como amigo, puder te falar: ela é insuportável.";
            TIDialogo.sentences[19] = "troca paisagem";
            TIDialogo.sentences[20] = "Tudo bem, acredito que eu dou conta, detetive. Obrigado pela ajuda.";
            TIDialogo.sentences[21] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(TIDialogo);
    }



    public void dialogoPolicialNTortura()
    {
        if (PlayerData.Idioma == "ingles")
        {
            policialDialogo.sentencesIngles[0] = "Hard day today, detective?";
            policialDialogo.sentencesIngles[1] = "troca paisagem";
            policialDialogo.sentencesIngles[2] = "Complicated as always.";
            policialDialogo.sentencesIngles[3] = "Tell me Johnny, have you had a really complicated case here in town?";
            policialDialogo.sentencesIngles[4] = "troca paisagem";
            policialDialogo.sentencesIngles[5] = "Since you asked, I'll tell you a story";
            policialDialogo.sentencesIngles[6] = "troca pensando";
            policialDialogo.sentencesIngles[7] = "(I hope I don't regret asking)";
            policialDialogo.sentencesIngles[8] = "troca paisagem";
            policialDialogo.sentencesIngles[9] = "A few years ago, when I joined the police, there was a serial killer.";
            policialDialogo.sentencesIngles[10] = "After much study about his methods of murder and his antics, the police sheriff, former detective and the staff of the police station found their whereabouts.";
            policialDialogo.sentencesIngles[11] = "We closed the place where he was. The policeman and I went in to arrest the murderer, I went from the opposite side of the policeman.";
            policialDialogo.sentencesIngles[12] = "But before we could do anything he shot the sheriff in the leg and ran.";
            policialDialogo.sentencesIngles[13] = "Luckily I was on the other side and managed to catch the criminal without him being able to react";
            policialDialogo.sentencesIngles[14] = "I was very angry with the guy, I wish I could torture him as he did to all his victims.";
            policialDialogo.sentencesIngles[15] = "troca pensando";
            policialDialogo.sentencesIngles[16] = "And did you do it?";
            policialDialogo.sentencesIngles[17] = "troca pensando";
            policialDialogo.sentencesIngles[18] = "No. I didn't go down to his level. I handcuffed him and took him back to the police station.";
            policialDialogo.sentencesIngles[19] = "troca paisagem";
            policialDialogo.sentencesIngles[20] = "And the sheriff? Was he alright?";
            policialDialogo.sentencesIngles[21] = "Did he feel angry at the killer for the things he did and for the shot in his leg?";
            policialDialogo.sentencesIngles[22] = "troca pensando";
            policialDialogo.sentencesIngles[23] = "The sheriff was responsible for the case of the murders, but he is not an emotional or angry man, he has always been calm.";
            policialDialogo.sentencesIngles[24] = "Today the murderer is in a prison outside the city.";
            policialDialogo.sentencesIngles[25] = "troca pensando";
            policialDialogo.sentencesIngles[26] = "Nice to hear these stories. Thanks, Officer.";
            policialDialogo.sentencesIngles[27] = "finalizar";
        }
        else
        {
            policialDialogo.sentences[0] = "Dia difícil hoje, detetive?";
            policialDialogo.sentences[1] = "troca paisagem";
            policialDialogo.sentences[2] = "Complicado como sempre.";
            policialDialogo.sentences[3] = "Diga-me Johnny, você teve algum caso bem complicado aqui na cidade?";
            policialDialogo.sentences[4] = "troca paisagem";
            policialDialogo.sentences[5] = "Já que perguntou, vou te contar uma história";
            policialDialogo.sentences[6] = "troca pensando";
            policialDialogo.sentences[7] = "(Tomara que não me arrependa da pergunta)";
            policialDialogo.sentences[8] = "troca paisagem";
            policialDialogo.sentences[9] = "Alguns anos atrás, quando entrei na polícia, tinha um assassino em série.";
            policialDialogo.sentences[10] = "Depois de muito estudo sobre seus métodos de assassinato e seus trejeitos, o delegado, ex detetive e o pessoal da delegacia encontraram seu paradeiro.";
            policialDialogo.sentences[11] = "Fechamos o local onde ele estava. Eu e o delegado entramos para prender o assassino, fui pelo lado oposto ao delegado.";
            policialDialogo.sentences[12] = "Mas antes que pudessemos fazer alguma coisa ele atirou na perna do delegado e correu.";
            policialDialogo.sentences[13] = "Para minha sorte eu estava do outro lado e consegui pegar o criminoso sem que ele pudesse reagir";
            policialDialogo.sentences[14] = "Estava com muito ódio do sujeito, queria poder torturá-lo como ele fez com todas as suas vítimas.";
            policialDialogo.sentences[15] = "troca pensando";
            policialDialogo.sentences[16] = "E o fez?";
            policialDialogo.sentences[17] = "troca pensando";
            policialDialogo.sentences[18] = "Não. Não desci ao nível dele. O algemei e levei de volta para a delegacia.";
            policialDialogo.sentences[19] = "troca paisagem";
            policialDialogo.sentences[20] = "E o delegado? Ficou bem?";
            policialDialogo.sentences[21] = "Sentiu raiva do assassino pelas coisas que ele fez e pelo tiro em sua perna?";
            policialDialogo.sentences[22] = "troca pensando";
            policialDialogo.sentences[23] = "O delegado era o responsável pelo caso dos assassinatos, mas ele não é um homem emotivo ou que sente raiva, sempre esteve calmo.";
            policialDialogo.sentences[24] = "Hoje o assassino está em uma prisão fora da cidade.";
            policialDialogo.sentences[25] = "troca pensando";
            policialDialogo.sentences[26] = "Bom saber dessas histórias. Obrigado, policial.";
            policialDialogo.sentences[27] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(policialDialogo);
    }


    public void dialogoDelegadoNRouba()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[0] = "troca paisagem";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[1] = "Sheriff, did you happen to see Steve's cell phone?";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[2] = "troca paisagem";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[3] = "I found a cell phone in my room earlier today, I was looking for the owner.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[4] = "troca pensando";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[5] = "Let me see.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[6] = "paisagem detetive";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[7] = "I believe that it is the same. He lost his cell phone again and asked me to help him find it.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[8] = "troca paisagem";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[9] = "Relax, everything I find lost I try to return to the owner.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[10] = "Unless it's cookies, then I'll eat.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[11] = "troca paisagem";
            if (ComeuAMaeDoPolicial)
            {
                dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[12] = "(Johnny's mother too)";
                dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[13] = "finalizar";
            }
            else
            {
                dialogoParceiroDetetiveIndoParaDelegacia.sentencesIngles[12] = "finalizar";
            }
        }
        else
        {
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[0] = "troca paisagem";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[1] = "Delegado, por acaso o senhor viu o celular do Steve?";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[2] = "troca paisagem";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[3] = "Eu encontrei um celular na minha sala hoje mais cedo, estava procurando o dono.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[4] = "troca pensando";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[5] = "Deixe-me ver.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[6] = "paisagem detetive";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[7] = "Acredito que seja esse mesmo. Ele perdeu o celular de novo e me pediu para ajudar a encontrá-lo.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[8] = "troca paisagem";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[9] = "Tranquilo, tudo que eu encontro perdido tento devolver para o dono.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[10] = "A menos que sejam biscoitos, aí eu como.";
            dialogoParceiroDetetiveIndoParaDelegacia.sentences[11] = "troca paisagem";
            if (ComeuAMaeDoPolicial)
            {
                dialogoParceiroDetetiveIndoParaDelegacia.sentences[12] = "(A mãe do Johnny também)";
                dialogoParceiroDetetiveIndoParaDelegacia.sentences[13] = "finalizar";
            }
            else
            {
                dialogoParceiroDetetiveIndoParaDelegacia.sentences[12] = "finalizar";
            }
        }
    }


    public void dialogoPolicialNMataIdosaFunction()
    {
        ComeuAMaeDoPolicial = true;
        if (PlayerData.Idioma == "ingles")
        {
            policialDialogo.sentencesIngles[0] = "Hello, detective.";
            policialDialogo.sentencesIngles[1] = "troca paisagem";
            policialDialogo.sentencesIngles[2] = "Hi Johnny. How was your day?";
            policialDialogo.sentencesIngles[3] = "troca paisagem";
            policialDialogo.sentencesIngles[4] = "You won't believe it, detective. I will tell you everything.";
            policialDialogo.sentencesIngles[5] = "troca disgust";
            policialDialogo.sentencesIngles[6] = "(Why did I ask?)";
            policialDialogo.sentencesIngles[7] = "troca paisagem";
            policialDialogo.sentencesIngles[8] = "I went to take my mother to the Association for the Support of the Elderly.";
            policialDialogo.sentencesIngles[9] = "troca pensando";
            policialDialogo.sentencesIngles[10] = "Is everything okay with her?";
            policialDialogo.sentencesIngles[11] = "troca pensando";
            policialDialogo.sentencesIngles[12] = "Yes, she is, she works there. She loves helping the elderly, whenever possible I help them too.";
            policialDialogo.sentencesIngles[13] = "But the important thing was what I saw.";
            policialDialogo.sentencesIngles[14] = "troca paisagem";
            policialDialogo.sentencesIngles[15] = "What?";
            policialDialogo.sentencesIngles[16] = "troca paisagem";
            policialDialogo.sentencesIngles[17] = "The sheriff, he was there too.";
            policialDialogo.sentencesIngles[18] = "troca paisagem";
            policialDialogo.sentencesIngles[19] = "How nice of him.";
            policialDialogo.sentencesIngles[20] = "troca paisagem";
            policialDialogo.sentencesIngles[21] = "Nice of him my ass. He was hitting on my mom.";
            policialDialogo.sentencesIngles[22] = "He came by offering cookies and asked if he could wet him later with her.";
            policialDialogo.sentencesIngles[23] = "troca embara";
            policialDialogo.sentencesIngles[24] = "Hahaha. I didn't expect this one.";
            policialDialogo.sentencesIngles[25] = "troca pensando";
            policialDialogo.sentencesIngles[26] = "Now I only take my mom if I'm sure he won't be there.";
            policialDialogo.sentencesIngles[27] = "troca paisagem";
            policialDialogo.sentencesIngles[28] = "You don't need to get mad about it. Imagine the sheriff as stepfather. Hahaha.";
            policialDialogo.sentencesIngles[29] = "troca paisagem";
            policialDialogo.sentencesIngles[30] = "You laugh because it's not you. Haha.";
            policialDialogo.sentencesIngles[31] = "troca paisagem";
            policialDialogo.sentencesIngles[32] = "I'm glad. Hahaha.";
            policialDialogo.sentencesIngles[33] = "finalizar";
        }
        else
        {
            policialDialogo.sentences[0] = "Olá, detetive.";
            policialDialogo.sentences[1] = "troca paisagem";
            policialDialogo.sentences[2] = "Olá, Johnny. Como foi o seu dia?";
            policialDialogo.sentences[3] = "troca paisagem";
            policialDialogo.sentences[4] = "Você nem vai acreditar, detetive. Irei te contar tudo.";
            policialDialogo.sentences[5] = "troca desgosto";
            policialDialogo.sentences[6] = "(Por que eu fui perguntar?)";
            policialDialogo.sentences[7] = "troca paisagem";
            policialDialogo.sentences[8] = "Eu fui levar minha mãe para a Associação de Amparo aos Idosos.";
            policialDialogo.sentences[9] = "troca pensando";
            policialDialogo.sentences[10] = "Está tudo bem com ela?";
            policialDialogo.sentences[11] = "troca pensando";
            policialDialogo.sentences[12] = "Está sim, ela trabalha lá. Adora ajudar os idosos, sempre que possível eu ajudo eles também.";
            policialDialogo.sentences[13] = "Mas o importante foi o que eu vi.";
            policialDialogo.sentences[14] = "troca paisagem";
            policialDialogo.sentences[15] = "O que?";
            policialDialogo.sentences[16] = "troca paisagem";
            policialDialogo.sentences[17] = "O delegado, ele estava lá também.";
            policialDialogo.sentences[18] = "troca paisagem";
            policialDialogo.sentences[19] = "Que legal da parte dele.";
            policialDialogo.sentences[20] = "troca paisagem";
            policialDialogo.sentences[21] = "Legal merda nenhuma. Ele estava dando em cima da minha mãe.";
            policialDialogo.sentences[22] = "Ele veio oferecendo biscoitos e perguntou se podia molhar ele mais tarde com ela.";
            policialDialogo.sentences[23] = "troca embara";
            policialDialogo.sentences[24] = "Hahaha. Por essa eu não esperava.";
            policialDialogo.sentences[25] = "troca pensando";
            policialDialogo.sentences[26] = "Agora só levo a minha mãe se eu tiver certeza que ele não vai estar lá.";
            policialDialogo.sentences[27] = "troca paisagem";
            policialDialogo.sentences[28] = "Não precisa ficar bolado com isso. Imagina o delegado como padrasto. Hahaha.";
            policialDialogo.sentences[29] = "troca paisagem";
            policialDialogo.sentences[30] = "Você ri porque não é com você. Haha.";
            policialDialogo.sentences[31] = "troca paisagem";
            policialDialogo.sentences[32] = "Ainda bem. Hahaha.";
            policialDialogo.sentences[33] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(policialDialogo);
    }
    public void ComecoJornalistaBrigaMulherVitima()
    {
        if (PlayerData.Idioma == "ingles")
        {
            jornalistaDialogo.sentencesIngles[0] = "It's absurd. A woman can't even get involved in activism in defense of women and she's already dead.";
            jornalistaDialogo.sentencesIngles[1] = "troca pensando";
            jornalistaDialogo.sentencesIngles[2] = "You're talking about the previous case, Jessie.";
            jornalistaDialogo.sentencesIngles[3] = "troca pensando";
            jornalistaDialogo.sentencesIngles[4] = "Yes, she was super important to me, I even went to the morgue to take one last photo.";
            jornalistaDialogo.sentencesIngles[5] = "Trying to keep alive the image and the lessons she gave us.";
            jornalistaDialogo.sentencesIngles[6] = "But that damn girl had to get in the way.";
            jornalistaDialogo.sentencesIngles[7] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[8] = "Who?";
            jornalistaDialogo.sentencesIngles[9] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[10] = "That medical examiner.";
            jornalistaDialogo.sentencesIngles[11] = "She stopped me, called security and everything.";
            jornalistaDialogo.sentencesIngles[12] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[13] = "It must have been the biggest shack.";
            jornalistaDialogo.sentencesIngles[14] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[15] = "It was. Hahaha.";
            jornalistaDialogo.sentencesIngles[16] = "finalizar";
        }
        else
        {
            jornalistaDialogo.sentences[0] = "É um absurdo. Uma mulher não pode nem se meter com ativismo em defesa das mulheres que ela já morre.";
            jornalistaDialogo.sentences[1] = "troca pensando";
            jornalistaDialogo.sentences[2] = "Está falando do caso anterior, Jessie.";
            jornalistaDialogo.sentences[3] = "troca pensando";
            jornalistaDialogo.sentences[4] = "Sim, ela era de super importância para mim, até fui ao necrotério tirar uma última foto.";
            jornalistaDialogo.sentences[5] = "Tentar manter viva a imagem e as mensagens que ela passou.";
            jornalistaDialogo.sentences[6] = "Mas aquela maldita tinha que se meter no meio.";
            jornalistaDialogo.sentences[7] = "troca paisagem";
            jornalistaDialogo.sentences[8] = "Quem?";
            jornalistaDialogo.sentences[9] = "troca paisagem";
            jornalistaDialogo.sentences[10] = "Aquela legista.";
            jornalistaDialogo.sentences[11] = "Ela me impediu, chamou os seguranças e tudo.";
            jornalistaDialogo.sentences[12] = "troca paisagem";
            jornalistaDialogo.sentences[13] = "Deve ter sido o maior barraco.";
            jornalistaDialogo.sentences[14] = "troca paisagem";
            jornalistaDialogo.sentences[15] = "Foi mesmo. Hahaha.";
            jornalistaDialogo.sentences[16] = "finalizar";
        }
    }
    public void ComecoJornalistaBrigaHomemVitima()
    {
        if (PlayerData.Idioma == "ingles")
        {
            jornalistaDialogo.sentencesIngles[0] = "It's an absurd. A man like him will die and people will worship him.";
            jornalistaDialogo.sentencesIngles[1] = "troca pensando";
            jornalistaDialogo.sentencesIngles[2] = "You're talking about the previous case, Jessie.";
            jornalistaDialogo.sentencesIngles[3] = "troca pensando";
            jornalistaDialogo.sentencesIngles[4] = "Yes. He was a bastard, a woman abuser, homophobic and sexist.";
            jornalistaDialogo.sentencesIngles[5] = "I went to the morgue to take one last photo.";
            jornalistaDialogo.sentencesIngles[6] = "Show the world how rotten he really was.";
            jornalistaDialogo.sentencesIngles[7] = "But that damn girl had to get in the way.";
            jornalistaDialogo.sentencesIngles[8] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[9] = "Who?";
            jornalistaDialogo.sentencesIngles[10] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[11] = "That medical examiner.";
            jornalistaDialogo.sentencesIngles[12] = "She stopped me, called security and everything.";
            jornalistaDialogo.sentencesIngles[13] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[14] = "It must have been the biggest mess ever.";
            jornalistaDialogo.sentencesIngles[15] = "troca paisagem";
            jornalistaDialogo.sentencesIngles[16] = "It was. Hahaha.";
            jornalistaDialogo.sentencesIngles[17] = "finalizar";
        }
        else
        {
            jornalistaDialogo.sentences[0] = "É um absurdo. Um homem como ele morrer e as pessoas o idolatrarem.";
            jornalistaDialogo.sentences[1] = "troca pensando";
            jornalistaDialogo.sentences[2] = "Está falando do caso anterior, Jessie.";
            jornalistaDialogo.sentences[3] = "troca pensando";
            jornalistaDialogo.sentences[4] = "Sim. Ele era um safado, abusador de mulheres, homofóbico e machista.";
            jornalistaDialogo.sentences[5] = "Eu fui ao necrotério tirar uma última foto.";
            jornalistaDialogo.sentences[6] = "Mostrar para o mundo o quão podre ele realmente era.";
            jornalistaDialogo.sentences[7] = "Mas aquela maldita tinha que se meter no meio.";
            jornalistaDialogo.sentences[8] = "troca paisagem";
            jornalistaDialogo.sentences[9] = "Quem?";
            jornalistaDialogo.sentences[10] = "troca paisagem";
            jornalistaDialogo.sentences[11] = "Aquela legista.";
            jornalistaDialogo.sentences[12] = "Ela me impediu, chamou os seguranças e tudo.";
            jornalistaDialogo.sentences[13] = "troca paisagem";
            jornalistaDialogo.sentences[14] = "Deve ter sido o maior barraco.";
            jornalistaDialogo.sentences[15] = "troca paisagem";
            jornalistaDialogo.sentences[16] = "Foi mesmo. Hahaha.";
            jornalistaDialogo.sentences[17] = "finalizar";
        }
    }
    public void finalLegistaNPunhoRaivas()
    {
        if (PlayerData.Idioma == "ingles")
        {
            legistaDialogo.sentencesIngles[0] = "...";
            legistaDialogo.sentencesIngles[1] = "troca paisagem";
            legistaDialogo.sentencesIngles[2] = "Hi Devi, how are you? Why the long face?";
            legistaDialogo.sentencesIngles[3] = "troca embara";
            legistaDialogo.sentencesIngles[4] = "No biggie, detective. Only those people from the press who go overboard sometimes.";
            legistaDialogo.sentencesIngles[5] = "troca pensando";
            legistaDialogo.sentencesIngles[6] = "What do you mean? Did something happen recently?";
            legistaDialogo.sentencesIngles[7] = "troca embara";
            legistaDialogo.sentencesIngles[8] = "Jessie, the investigative journalist, ended up entering the morgue without permission to see the latest victim of the murders.";
            legistaDialogo.sentencesIngles[9] = "I'm not one for fighting, I'm very calm. I asked her to leave.";
            legistaDialogo.sentencesIngles[10] = "But she insisted on staying and seeing the body to take pictures.";
            legistaDialogo.sentencesIngles[11] = "They have no limits, they don't even respect the dead body";
            legistaDialogo.sentencesIngles[12] = "troca pensando";
            legistaDialogo.sentencesIngles[13] = "Journalists?";
            legistaDialogo.sentencesIngles[14] = "troca paisagem";
            legistaDialogo.sentencesIngles[15] = "Yes, there are some who go out of their way to get a headline.";
            legistaDialogo.sentencesIngles[16] = "troca paisagem";
            legistaDialogo.sentencesIngles[17] = "How did the situation end?";
            legistaDialogo.sentencesIngles[18] = "troca paisagem";
            legistaDialogo.sentencesIngles[19] = "I tried to stop her, but as I was never good at fighting, I ended up calling the security guards and they took her away.";
            legistaDialogo.sentencesIngles[20] = "troca paisagem";
            legistaDialogo.sentencesIngles[21] = "The situation is difficult, but I'm on the case, it's a little while before the murderer is behind bars.";
            legistaDialogo.sentencesIngles[22] = "troca paisagem";
            legistaDialogo.sentencesIngles[23] = "Hopefully, detective.";
            legistaDialogo.sentencesIngles[24] = "finalizar";
        }
        else
        {
            legistaDialogo.sentences[0] = "...";
            legistaDialogo.sentences[1] = "troca paisagem";
            legistaDialogo.sentences[2] = "Olá Devi, tudo bem? Por que a cara feia?";
            legistaDialogo.sentences[3] = "troca embara";
            legistaDialogo.sentences[4] = "Nada de mais, detetive. Só esse pessoal da imprensa que passa dos limites às vezes.";
            legistaDialogo.sentences[5] = "troca pensando";
            legistaDialogo.sentences[6] = "Como assim? Algo aconteceu recentemente?";
            legistaDialogo.sentences[7] = "troca embara";
            legistaDialogo.sentences[8] = "Jessie, a jornalista investigativa, acabou entrando no necrotério sem permissão para ver a última vítima dos assassinatos.";
            legistaDialogo.sentences[9] = "Eu não sou de brigar, sou bem calma. Pedi para que ela se retirasse.";
            legistaDialogo.sentences[10] = "Mas ela insistiu em ficar e ver o corpo para tirar fotos.";
            legistaDialogo.sentences[11] = "Eles não têm limite, não respeitam nem o corpo morto";
            legistaDialogo.sentences[12] = "troca pensando";
            legistaDialogo.sentences[13] = "Os jornalistas?";
            legistaDialogo.sentences[14] = "troca paisagem";
            legistaDialogo.sentences[15] = "Sim, tem alguns que fazem de tudo para conseguir uma manchete.";
            legistaDialogo.sentences[16] = "troca paisagem";
            legistaDialogo.sentences[17] = "Como terminou a situação?";
            legistaDialogo.sentences[18] = "troca paisagem";
            legistaDialogo.sentences[19] = "Eu tentei impedi-la, mas como nunca fui boa de briga acabei chamando os seguranças e eles a retiraram do local.";
            legistaDialogo.sentences[20] = "troca paisagem";
            legistaDialogo.sentences[21] = "Difícil a situação, mas estou em cima do caso, falta pouco para o assassino estar atrás das grades.";
            legistaDialogo.sentences[22] = "troca paisagem";
            legistaDialogo.sentences[23] = "Tomara, detetive.";
            legistaDialogo.sentences[24] = "finalizar";
        }
    }


    public void finalLegistaNMataHomem()
    {
        if (PlayerData.Idioma == "ingles")
        {
            legistaDialogo.sentencesIngles[0] = "troca paisagem";
            legistaDialogo.sentencesIngles[1] = "Going home, Devi?";
            legistaDialogo.sentencesIngles[2] = "troca paisagem";
            legistaDialogo.sentencesIngles[3] = "I'm on my way, but since I found you here, would you like to stop by?";
            legistaDialogo.sentencesIngles[4] = "troca embara";
            legistaDialogo.sentencesIngles[5] = "But of course, I would love to.";
            legistaDialogo.sentencesIngles[6] = "troca embara";
            legistaDialogo.sentencesIngles[7] = "I don't know if you knew, but I always thought you were so cute and smart, detective.";
            legistaDialogo.sentencesIngles[8] = "troca embara";
            legistaDialogo.sentencesIngles[9] = "Wow Devi, I feel the same, is that serious?!";
            legistaDialogo.sentencesIngles[10] = "troca paisagem";
            legistaDialogo.sentencesIngles[11] = "No, hahaha.";
            legistaDialogo.sentencesIngles[12] = "troca desgosto";
            legistaDialogo.sentencesIngles[13] = "But... But I...";
            legistaDialogo.sentencesIngles[14] = "I was playing with you detective, I love playing with men's hearts.";
            legistaDialogo.sentencesIngles[15] = "I'm going home, see you another day.";
            legistaDialogo.sentencesIngles[16] = "troca desgosto";
            legistaDialogo.sentencesIngles[17] = "(Only sadness in this life)";
            legistaDialogo.sentencesIngles[18] = "finalizar";
        }
        else
        {
            legistaDialogo.sentences[0] = "troca paisagem";
            legistaDialogo.sentences[1] = "Indo para casa, Devi?";
            legistaDialogo.sentences[2] = "troca paisagem";
            legistaDialogo.sentences[3] = "Estou indo, mas já que te encontrei aqui, gostaria de dar uma passadinha lá?";
            legistaDialogo.sentences[4] = "troca embara";
            legistaDialogo.sentences[5] = "Mas é claro, eu adoraria.";
            legistaDialogo.sentences[6] = "troca embara";
            legistaDialogo.sentences[7] = "Eu não sei se você sabia, mas eu sempre te achei tão bonito e esperto, detetive.";
            legistaDialogo.sentences[8] = "troca embara";
            legistaDialogo.sentences[9] = "Nossa Devi, eu sinto o mesmo, é sério isso?!.";
            legistaDialogo.sentences[10] = "troca paisagem";
            legistaDialogo.sentences[11] = "Não! Hahaha.";
            legistaDialogo.sentences[12] = "troca desgosto";
            legistaDialogo.sentences[13] = "Mas... Mas eu...";
            legistaDialogo.sentences[14] = "Estava brincado com você detetive, adoro brincar com o coração dos homens.";
            legistaDialogo.sentences[15] = "Eu estou indo para casa, te vejo outro dia.";
            legistaDialogo.sentences[16] = "troca desgosto";
            legistaDialogo.sentences[17] = "(Só tristezas essa vida)";
            legistaDialogo.sentences[18] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(legistaDialogo);
    }


    public void trocaTestemunhoJornalista()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoInicioTestemunhaJornalista.sentencesIngles[0] = "I really don't understand, detective.";
            dialogoInicioTestemunhaJornalista.sentencesIngles[1] = "Those psychopaths who spend days planning the death of their victims.";
            dialogoInicioTestemunhaJornalista.sentencesIngles[2] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentencesIngles[3] = "Why do you say that?";
            dialogoInicioTestemunhaJornalista.sentencesIngles[4] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentencesIngles[5] = "A crime of passion or due to lack of empathy is one thing, but killing an innocent in a planned way is beyond comprehensible.";
            dialogoInicioTestemunhaJornalista.sentencesIngles[6] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentencesIngles[7] = "Any criminal act is incomprehensible.";
            dialogoInicioTestemunhaJornalista.sentencesIngles[8] = "finalizar";
        }
        else
        {
            dialogoInicioTestemunhaJornalista.sentences[0] = "Realmente eu não entendo, detetive.";
            dialogoInicioTestemunhaJornalista.sentences[1] = "Esses psicopatas que passam dias planejando a morte de suas vítimas.";
            dialogoInicioTestemunhaJornalista.sentences[2] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentences[3] = "Por que diz isso?";
            dialogoInicioTestemunhaJornalista.sentences[4] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentences[5] = "Uma coisa é um crime passional ou por falta de empatia, mas matar um inocente de forma planejada é muito além do compreensível.";
            dialogoInicioTestemunhaJornalista.sentences[6] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentences[7] = "Qualquer ato criminoso é incompreensível.";
            dialogoInicioTestemunhaJornalista.sentences[8] = "finalizar";
        }

    }


    public void trocaTestemunhoRicoNMataJovens()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoInicioTestemunhaRico.sentencesIngles[0] = "Your partner is well motivated today, detective.";
            dialogoInicioTestemunhaRico.sentencesIngles[1] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[2] = "If you mean chatty, yes he is.";
            dialogoInicioTestemunhaRico.sentencesIngles[3] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[4] = "This is a very important quality in a person.";
            dialogoInicioTestemunhaRico.sentencesIngles[5] = "That energy, willpower, motivation.";
            dialogoInicioTestemunhaRico.sentencesIngles[6] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[7] = "Yes, this is very important to do a good job and always be able to improve yourself, both professionally and as an individual.";
            dialogoInicioTestemunhaRico.sentencesIngles[8] = "I think it's cool that you think like that.";
            dialogoInicioTestemunhaRico.sentencesIngles[9] = "troca pensando";
            dialogoInicioTestemunhaRico.sentencesIngles[10] = "I didn't hear anything you said, I bet it was a lot of nonsense.";
            dialogoInicioTestemunhaRico.sentencesIngles[11] = "troca desgosto";
            dialogoInicioTestemunhaRico.sentencesIngles[12] = "...";
            dialogoInicioTestemunhaRico.sentencesIngles[13] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[14] = "I'm talking about energy for investments, the stock market, young people have a lot of that";
            dialogoInicioTestemunhaRico.sentencesIngles[15] = "Wanting to earn more money, live the job and...";
            dialogoInicioTestemunhaRico.sentencesIngles[16] = "troca desgosto";
            dialogoInicioTestemunhaRico.sentencesIngles[17] = "(I'm sure Steve isn't like that)";
            dialogoInicioTestemunhaRico.sentencesIngles[18] = "pensando detetive";
            dialogoInicioTestemunhaRico.sentencesIngles[19] = "(I'm glad he's not like that)";
            dialogoInicioTestemunhaRico.sentencesIngles[20] = "finalizar";
        }
        else
        {
            dialogoInicioTestemunhaRico.sentences[0] = "Seu parceiro está bem motivado hoje, detetive.";
            dialogoInicioTestemunhaRico.sentences[1] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[2] = "Se você quer dizer tagarela, sim ele está.";
            dialogoInicioTestemunhaRico.sentences[3] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[4] = "Isso é uma qualidade muito importante em uma pessoa.";
            dialogoInicioTestemunhaRico.sentences[5] = "Essa energia, força de vontade, motivação.";
            dialogoInicioTestemunhaRico.sentences[6] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[7] = "Sim, isso é muito importante para fazer um bom trabalho e poder se melhorar sempre, tanto profissionalmente quanto como indivíduo.";
            dialogoInicioTestemunhaRico.sentences[8] = "Acho legal você pensar assim.";
            dialogoInicioTestemunhaRico.sentences[9] = "troca pensando";
            dialogoInicioTestemunhaRico.sentences[10] = "Não ouvi nada do que você disse, aposto que foi um monte de baboseira.";
            dialogoInicioTestemunhaRico.sentences[11] = "troca desgosto";
            dialogoInicioTestemunhaRico.sentences[12] = "...";
            dialogoInicioTestemunhaRico.sentences[13] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[14] = "Estou falando de energia para investimentos, mercado de ações, os jovens têm muito disso";
            dialogoInicioTestemunhaRico.sentences[15] = "Querer ganhar mais dinheiro, viver o trabalho e ...";
            dialogoInicioTestemunhaRico.sentences[16] = "troca desgosto";
            dialogoInicioTestemunhaRico.sentences[17] = "(Tenho certeza que o Steve não é assim)";
            dialogoInicioTestemunhaRico.sentences[18] = "pensando detetive";
            dialogoInicioTestemunhaRico.sentences[19] = "(Ainda bem que ele não é assim)";
            dialogoInicioTestemunhaRico.sentences[20] = "finalizar";
        }
    }



    public void trocaTestemunhoRico()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoInicioTestemunhaRico.sentencesIngles[0] = "Another dead victim on one of my properties.";
            dialogoInicioTestemunhaRico.sentencesIngles[1] = "It kills my business.";
            dialogoInicioTestemunhaRico.sentencesIngles[2] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[3] = "It must be very difficult for the victim's family.";
            dialogoInicioTestemunhaRico.sentencesIngles[4] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[5] = "As long as they pay me, that's fine.";
            dialogoInicioTestemunhaRico.sentencesIngles[6] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[7] = "Sometimes people go through hardships and have to resort to illegal ways to get money to pay you in these difficult times.";
            dialogoInicioTestemunhaRico.sentencesIngles[8] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[9] = "Money is money. Hahaha.";
            dialogoInicioTestemunhaRico.sentencesIngles[10] = "finalizar";
        }
        else
        {
            dialogoInicioTestemunhaRico.sentences[0] = "Mais uma vítima morta em uma das minhas propriedades.";
            dialogoInicioTestemunhaRico.sentences[1] = "Isso acaba com os meu negócios.";
            dialogoInicioTestemunhaRico.sentences[2] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[3] = "Deve ser bem difícil para a família da vítima.";
            dialogoInicioTestemunhaRico.sentences[4] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[5] = "Contanto que eles me paguem, está tudo bem.";
            dialogoInicioTestemunhaRico.sentences[6] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[7] = "As vezes a situação fica apertada e as pessoas partem para formas ilegais de conseguir dinheiro para te pagar nesses tempos difíceis.";
            dialogoInicioTestemunhaRico.sentences[8] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentences[9] = "Dinheiro é dinheiro. Hahaha.";
            dialogoInicioTestemunhaRico.sentences[10] = "finalizar";
        }
    }
    public void tutorialTestemunha()
    {
        if (!entrouTutorialTestemunha)
        {
            entrouTutorialTestemunha = true;
            entrouTutorial = true;
            movimento.ParaPersonagem = true;
            animatorTutorial.SetBool("AbrirTutorial", true);
            if (PlayerData.Idioma == "ingles")
            {
                testemunhaTexto.text = "<color=red>Witnesses</color>" + "\n" +
                "Witnesses are people found at the crime scene. It's possible to ask them questions about the murder." + "\n" +
                "To each question asked, the witness will tell their version of the case, and it's up to the detective to know if what they are saying is true or false." + "\n" +
                "There are 3 possible answers to each testimony." + "\n" +
                "Believe: used when sure that the testimony is true." + "\n" +
                "Doubt: used when it's not possible to confirm or reject the testimony." + "\n" +
                "Disagree: used when sure that the testimony is false. On disagreeing, you will have to support with some evidence the reason why you disagree with the testimony." + "\n" +
                "If you are right about the testimony, extra information will be revealed." + "\n" +
                "The questions and answers will be added as evidence in your notebook." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "<color=red>Testemunhas</color>" + "\n" +
                "Testemunhas são pessoas encontradas na cena do crime. É possível fazer perguntas para elas sobre o assassinato." + "\n" +
                "A cada pergunta feita, a testemunha irá contar sua versão do caso, e cabe ao detetive saber se o que ela está dizendo é verdade ou mentira." + "\n" +
                "Existem 3 possibilidades de respostas para cada testemunho." + "\n" +
                "Acreditar: usado quando se tem certeza de que o testemunho é verdadeiro." + "\n" +
                "Duvidar: usado quando não se pode confirmar nada sobre o testemunho." + "\n" +
                "Discordar: usado quando se tem certeza de que o testemunho é falso. Ao discordar, você terá que provar com alguma evidência o porquê do detetive discordar da testemunha." + "\n" +
                "Caso você acerte a verdade sobre o testemunho, informações extras serão reveladas." + "\n" +
                "As perguntas e respostas serão adicionadas como evidências para o seu caderno." + "\n" +
                "Aperte  'ESC'  para fechar este menu.";
            }
        }
    }
    public void tutorialEvidencias()
    {
        if (!entrouTutorialEvidencias)
        {
            entrouTutorialEvidencias = true;
            entrouTutorial = true;
            movimento.ParaPersonagem = true;
            animatorTutorial.SetBool("AbrirTutorial", true);
            if (PlayerData.Idioma == "ingles")
            {
                testemunhaTexto.text = "<color=red>Evidence</color>" + "\n" +
                "Pieces of evidence are clues found at the crime scene. They are registered on your notebook (press 'TAB' to open the notebook)." + "\n" +
                "Pieces of evidence have info that will help you solve the case." + "\n" +
                "They can be updated by talking to the digital expert, in the police station." + "\n" +
                "It is only possible to update a limited number of evidences per case." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "<color=red>Evidências</color>" + "\n" +
                "Evidências são pistas encontradas na cena do crime. Elas são anotadas no seu caderno (aperte 'TAB' para abrir o caderno)." + "\n" +
                "As evidências possuem informações que te ajudarão a solucionar o caso." + "\n" +
                "Elas podem ser atualizadas conversando com o perito digital, que se encontra na delgacia." + "\n" +
                "Só é possivel atualizar um numero limitado de evidências por caso." + "\n" +
                "Aperte 'ESC' para fechar este menu.";
            }

        }

    }
    public void tutorialIA()
    {
        if (!entrouTutorialIA)
        {
            entrouTutorialIA = true;
            entrouTutorial = true;
            movimento.ParaPersonagem = true;
            animatorTutorial.SetBool("AbrirTutorial", true);
            if (PlayerData.Idioma == "ingles")
            {
                testemunhaTexto.text = "<color=red>Artificial Intelligence and Progress</color>" + "\n" +
                "Upon finishing a case, the murderer rethinks their methods." + "\n" +
                "Based on your previous guesses, both right and wrong, the murderer improves their methods." + "\n" +
                "Over the course of the 9 cases, the detective is never guaranteed to guess right or wrong, only the murderer will have this information." + "\n" +
                "But every murderer maintains a certain behavior pattern. Some of their actions are repeated, some are avoided." + "\n" +
                "Be careful, the murderer may be anyone around you." + "\n" +
                "At the end of the 9 cases, the detective knowing about the previously solved cases, must find out who the murderer is." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "<color=red>Inteligência Artificial e Progresso</color>" + "\n" +
                "Ao finalizar um caso, o assassino repensa seus métodos." + "\n" +
                "Baseado nos seus acertos e erros ele melhora e aprimora os seus métodos." + "\n" +
                "Ao longo dos 9 casos, o detetive nunca saberá se está acertando ou errando, somente o assassino terá essas informações." + "\n" +
                "Mas todo assassino mantém um certo padrão de comportamento. Com ações que eles repetem, e outras que evitam." + "\n" +
                "Tome cuidado, o assassino pode ser qualquer um a sua volta." + "\n" +
                "Ao final dos 9 casos, o detetive sabendo dos casos resolvidos por ele anteriormente, deve descobrir quem é o assassino." + "\n" +
                "Aperte 'ESC' para fechar este menu.";
            }

        }
    }
    public void tutorialComandos()
    {
        if (!entrouTutorialControles)
        {
            entrouTutorialControles = true;
            entrouTutorial = true;
            movimento.ParaPersonagem = true;

            animatorTutorial.SetBool("AbrirTutorial", true);
            if (PlayerData.Idioma == "ingles")
            {
                testemunhaTexto.text = "<color=red>Controls</color>" + "\n" +
                "Press 'W''A''S''D' or the arrows to move." + "\n" +
                "Press 'E' to interact with objects." + "\n" +
                "Press 'E' to advance through the dialogues." + "\n" +
                "Press 'TAB' to open and close the notebook." + "\n" +
                "Press 'ESC' to open and close the pause menu. " + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "<color=red>Controles</color>" + "\n" +
                "Para se movimentar, use 'W''A''S''D' ou as setas do teclado." + "\n" +
                "Para interagir com objetos, pressione 'E'." + "\n" +
                "Para avançar nos diálogos, pressione 'E'." + "\n" +
                "Para abrir e fechar o caderno, pressione 'TAB'." + "\n" +
                "Para abrir e fechar o menu de pause, pressione 'ESC'. " + "\n" +
                "Aperte 'ESC' para fechar este menu.";
            }
        }
    }
    public void tutorialPensamentos()
    {
        if (!entrouTutorialPensamentos)
        {
            entrouTutorialPensamentos = true;
            entrouTutorial = true;
            movimento.ParaPersonagem = true;
            animatorTutorial.SetBool("AbrirTutorial", true);
            if (PlayerData.Idioma == "ingles")
            {
                testemunhaTexto.text = "<color=red>Thoughts</color>" + "\n" +
                "Here is where the detective joins two pieces of evidence already found to create a theory." + "\n" +
                "Keep in mind that it only makes sense to create a new theory, something that can't be at the crime scene already." + "\n" +
                "The new theory becomes a thought that occured to the detective." + "\n" +
                "e.g.: Someone being invited to enter the building." + "\n" +
                "Thoughts will always be something immaterial, that can't be physically found at the crime scene." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "<color=red>Pensamentos</color>" + "\n" +
                "Aqui é onde o detetive junta duas evidências já encontradas para gerar uma teoria." + "\n" +
                "Tenha em mente que só faz sentido criar uma teoria nova, que não seja possível encontrar na cena do crime." + "\n" +
                "A teoria nova se torna um pensamento que o detetive teve." + "\n" +
                "Exemplo: alguém ter sido convidado a entrar." + "\n" +
                "Os pensamentos serão sempre algo imaterial, que não é possivel encontrar no local físico da cena do crime." + "\n" +
                "Aperte 'ESC' para fechar este menu.";
            }
        }
    }
    public void tutorialRelatorio()
    {
        if (!entrouTutorialRelatorio)
        {
            entrouTutorialRelatorio = true;
            entrouTutorial = true;
            movimento.ParaPersonagem = true;
            animatorTutorial.SetBool("AbrirTutorial", true);
            if (PlayerData.Idioma == "ingles")
            {
                testemunhaTexto.text = "<color=red>Report</color>" + "\n" +
                "At the end of each case, the detective has to put his theories on the paper." + "\n" +
                "The report is how the player explains the case, and it's composed of 5 questions." + "\n" +
                "How did the murderer get in?" + "\n" +
                "Where did the murderer kill the victim?" + "\n" +
                "What is the weapon of the crime?" + "\n" +
                "How did the murderer get out?" + "\n" +
                "What is the motive of the crime?" + "\n" +
                "These questions are answered by the evidence found at the crime scene, except for the motive." + "\n" +
                "The possible motives are divided in 6 types." + "\n" +
                "Robbery: the murderer entered the place to steal and, without premeditated intent, killed the victim." + "\n" +
                "Fury: the murderer, in a moment of fury, killed the victim without premeditated intent." + "\n" +
                "Justice: when the murderer, with premeditated and supposedly impartial intent, killed the victim, judging them as guilty for something." + "\n" +
                "Revenge: when the murderer, with premeditated and selfishly motivated intent, killed the victim, judging them as guilty for something." + "\n" +
                "Pleasure: when the murderer killed the victim in a torturing manner for the murderer's own pleasure." + "\n" +
                "Suicide: there was no murderer." + "\n" +
                "Upon completion of the report, the case is closed and the detective will continue to the next case." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "<color=red>Relatório</color>" + "\n" +
                "Ao final de cada caso, o detetive precisa colocar suas teorias no papel." + "\n" +
                "O relatório é como o caso é explicado pelo jogador, sendo composto por 5 perguntas." + "\n" +
                "Como o assassino entrou?" + "\n" +
                "Onde o assassino matou a vítima?" + "\n" +
                "Qual a arma do crime?" + "\n" +
                "Por onde o assassino saiu?" + "\n" +
                "Qual o motivo do assassinato?" + "\n" +
                "Essas perguntas são respondidas com as evidências encontradas na cena do crime, exceto o motivo." + "\n" +
                "Os motivos possíveis são divididos em 6 tipos." + "\n" +
                "Roubo: o assassino entrou no local para roubar e, de forma não planejada, matou a vítima." + "\n" +
                "Raiva: o assassino, em um momento de fúria não planejada, acabou matando a vítima." + "\n" +
                "Justiça: quando o assassino, de forma previamente planejada e imparcial, matou a vítima, julgando-a ser culpada por algo." + "\n" +
                "Vingança: quando o assassino, de forma previamente planejada e pessoal, matou a vítima, julgando-a ser culpada por algo." + "\n" +
                "Prazer: quando o assassino matou a vítima de forma torturante por um prazer próprio." + "\n" +
                "Suicídio: não houve nenhum assassino." + "\n" +
                "Completando o relatório, o caso é encerrado e o detetive seguirá para um novo caso." + "\n" +
                "Aperte 'ESC' para fechar este menu.";
            }

        }

    }
    public void fechaJanela()
    {
        entrouTutorial = false;
        movimento.ParaPersonagem = false;
        animatorTutorial.SetBool("AbrirTutorial", false);
    }
    public static void fechar()
    {
        animator.SetBool("CarroGif", false);
        movimento.ParaPersonagem = false;
        DialogoTransicao = false;
    }

    public void DelegadoInicialElogio()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoDelegadoExplicando.sentencesIngles[0] = "Thanks for the ride, detective.";
            dialogoDelegadoExplicando.sentencesIngles[1] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[2] = "No problem, sir.";
            dialogoDelegadoExplicando.sentencesIngles[3] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[4] = "You have done a good job, the people at the police station have been appreciating your work.";
            dialogoDelegadoExplicando.sentencesIngles[5] = "troca embara";
            dialogoDelegadoExplicando.sentencesIngles[6] = "Thank you, i'm only doing my job.";
            dialogoDelegadoExplicando.sentencesIngles[7] = "paisagem detetive";
            dialogoDelegadoExplicando.sentencesIngles[8] = "I'm glad that people are enjoying it.";
            dialogoDelegadoExplicando.sentencesIngles[9] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[10] = "Keep it up.";
            dialogoDelegadoExplicando.sentencesIngles[11] = "finalizar";
        }
        else
        {
            dialogoDelegadoExplicando.sentences[0] = "Obrigado pela carona, detetive.";
            dialogoDelegadoExplicando.sentences[1] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[2] = "Não tem problemas senhor.";
            dialogoDelegadoExplicando.sentences[3] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[4] = "Você tem feito um bom trabalho, o pessoal na delegacia tem gostado do seu trabalho.";
            dialogoDelegadoExplicando.sentences[5] = "troca embara";
            dialogoDelegadoExplicando.sentences[6] = "Obrigado, só tenho feito o meu trabalho.";
            dialogoDelegadoExplicando.sentences[7] = "paisagem detetive";
            dialogoDelegadoExplicando.sentences[8] = "Fico feliz que o pessoal esteja gostando.";
            dialogoDelegadoExplicando.sentences[9] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[10] = "Continue assim.";
            dialogoDelegadoExplicando.sentences[11] = "finalizar";
        }
    }


    public void DelegadoNMataIdosos()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoDelegadoExplicando.sentencesIngles[0] = "I heard that today's case is going to be ugly.";
            dialogoDelegadoExplicando.sentencesIngles[1] = "troca embara";
            dialogoDelegadoExplicando.sentencesIngles[2] = "I have never heard of a beautiful case.";
            dialogoDelegadoExplicando.sentencesIngles[3] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[4] = "But this one is uglier than hitting the mother.";
            dialogoDelegadoExplicando.sentencesIngles[5] = "troca embara";
            dialogoDelegadoExplicando.sentencesIngles[6] = "...";
            dialogoDelegadoExplicando.sentencesIngles[7] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[8] = "Anyway, I won't be able to help you in this case.";
            dialogoDelegadoExplicando.sentencesIngles[9] = "I have to go to the Elderly Support Association meeting.";
            dialogoDelegadoExplicando.sentencesIngles[10] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[11] = "That's nice, sheriff. I bet you don't need to be the usual sheriff over there. Hahaha.";
            dialogoDelegadoExplicando.sentencesIngles[12] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[13] = "No. I am yes. I am also a sheriff there.";
            dialogoDelegadoExplicando.sentencesIngles[14] = "troca embara";
            dialogoDelegadoExplicando.sentencesIngles[15] = "...";
            dialogoDelegadoExplicando.sentencesIngles[16] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[17] = "...";
            dialogoDelegadoExplicando.sentencesIngles[18] = "There they give me cookies. I love cookies";
            dialogoDelegadoExplicando.sentencesIngles[19] = "finalizar";
        }
        else
        {
            dialogoDelegadoExplicando.sentences[0] = "Ouvi dizer que o caso de hoje vai ser feio.";
            dialogoDelegadoExplicando.sentences[1] = "troca embara";
            dialogoDelegadoExplicando.sentences[2] = "Nunca ouvi falar de um caso bonito.";
            dialogoDelegadoExplicando.sentences[3] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[4] = "Mas esse é mais feio que bater na mãe.";
            dialogoDelegadoExplicando.sentences[5] = "troca embara";
            dialogoDelegadoExplicando.sentences[6] = "...";
            dialogoDelegadoExplicando.sentences[7] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[8] = "De qualquer forma, não poderei te ajudar nesse caso.";
            dialogoDelegadoExplicando.sentences[9] = "Tenho que ir à reunião da Associação de Amparo aos Idosos.";
            dialogoDelegadoExplicando.sentences[10] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[11] = "Que legal, delegado. Aposto que por lá você não precisa ser o delegado de sempre. Hahaha.";
            dialogoDelegadoExplicando.sentences[12] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[13] = "Não. Eu sou sim. Também sou um delegado lá.";
            dialogoDelegadoExplicando.sentences[14] = "troca embara";
            dialogoDelegadoExplicando.sentences[15] = "...";
            dialogoDelegadoExplicando.sentences[16] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[17] = "...";
            dialogoDelegadoExplicando.sentences[18] = "Lá eles me dão biscoitos. Adoro biscoitos";
            dialogoDelegadoExplicando.sentences[19] = "finalizar";
        }
    }


    public void DelegadoInicialCritica()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoDelegadoExplicando.sentencesIngles[0] = "We need to talk, detective.";
            dialogoDelegadoExplicando.sentencesIngles[1] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[2] = "Some problem, sir?";
            dialogoDelegadoExplicando.sentencesIngles[3] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[4] = "You have not done a good job, the people at the police station have not been very fond of your work.";
            dialogoDelegadoExplicando.sentencesIngles[5] = "troca embara";
            dialogoDelegadoExplicando.sentencesIngles[6] = "I'm sorry, sheriff, I've only been doing my job.";
            dialogoDelegadoExplicando.sentencesIngles[7] = "paisagem detetive";
            dialogoDelegadoExplicando.sentencesIngles[8] = "I will try to improve.";
            dialogoDelegadoExplicando.sentencesIngles[9] = "troca paisagem";
            dialogoDelegadoExplicando.sentencesIngles[10] = "I hope so.";
            dialogoDelegadoExplicando.sentencesIngles[11] = "finalizar";
        }
        else
        {
            dialogoDelegadoExplicando.sentences[0] = "Precisamos conversar, detetive.";
            dialogoDelegadoExplicando.sentences[1] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[2] = "Algum problema, senhor?";
            dialogoDelegadoExplicando.sentences[3] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[4] = "Você não tem feito um bom trabalho, as pessoas na delegacia não têm gostado muito de como você está conduzindo os casos.";
            dialogoDelegadoExplicando.sentences[5] = "troca embara";
            dialogoDelegadoExplicando.sentences[6] = "Me desculpa, delegado, eu só tenho tentado fazer o meu trabalho.";
            dialogoDelegadoExplicando.sentences[7] = "paisagem detetive";
            dialogoDelegadoExplicando.sentences[8] = "Eu irei melhorar.";
            dialogoDelegadoExplicando.sentences[9] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[10] = "Assim espero.";
            dialogoDelegadoExplicando.sentences[11] = "finalizar";
        }
    }

    public void ParceiroDetetiveNMataMulher()
    {
        if (PlayerData.Idioma == "ingles")
        {
            diaologoFinalParceiro.sentences[0] = "";
        }
        else
        {
            diaologoFinalParceiro.sentences[0] = "";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (entrouTutorial && Input.GetKeyDown(KeyCode.Escape))
        {
            fechaJanela();
        }
        if (DialogoTransicao)
        {
            movimento.ParaPersonagem = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    randomNumber = Random.value;
                    if(randomNumber >= 0.66f ){
                        nomeDaPessoaTransicao = "parceiro";
                    }
                    if(randomNumber >= 0.33f && randomNumber < 0.66f){
                        nomeDaPessoaTransicao = "delegado";
                    }
                    if(randomNumber < 0.33f){
                        nomeDaPessoaTransicao = "jornalista";
                    }
                    switch (nomeDaPessoaTransicao)
                    {
                        case "parceiro":
                            dialogueControl.DisplayNextSentence(dialogoParceiroDetetiveIndoParaDelegacia);
                            break;
                        case "delegado":
                            dialogueControl.DisplayNextSentence(dialogoParceiroDetetiveIndoParaDelegacia);
                            break;
                        case "jornalista":
                            dialogueControl.DisplayNextSentence(dialogoDelegadoExplicando);
                            break;
                    }
                }
                if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0)
                {
                    eraHomemUltimoCaso = SpawnObjects.SexoMasculino;
                    if (SceneManager.GetActiveScene().buildIndex != 4)
                    {
                        if (jornalistaBrigouComALegista)
                        {
                            dialogueControl.DisplayNextSentence(jornalistaDialogo);
                        }
                        else
                        {
                            if (dialogoInicioParceirobool)
                            {
                                dialogueControl.DisplayNextSentence(diaologoInicialParceiro);
                            }
                            else
                            {
                                dialogueControl.DisplayNextSentence(dialogoDelegadoExplicando);
                            }
                        }
                    }
                    else
                    {
                        FinalDoJogoControl.DisplayNextSentence(dialogoFinalDoJogo);
                    }
                }
            }
        }
        if (Relatorio.jogoFinalizado)
        {
            if (startaFinal)
            {
                randomNumber = Random.value;
                if (randomNumber >= 0.75f)
                {
                    nomeDaPessoaNoFinal = "parceiro";
                }
                if (randomNumber >= 0.5f && randomNumber < 0.75f)
                {
                    nomeDaPessoaNoFinal = "devi";
                }
                if (randomNumber >= 0.25f && randomNumber < 0.5f)
                {
                    nomeDaPessoaNoFinal = "policial";
                }
                if (randomNumber >= 0.0f && randomNumber < 0.25f)
                {
                    nomeDaPessoaNoFinal = "TI";
                }
                switch (nomeDaPessoaNoFinal)
                {
                    case "parceiro":
                        if (Random.value >= 0.5f)
                        {
                            diaologoFinalParceiroFuncao();
                        }
                        else
                        {
                            diaologoFinalParceiroFuncaoNTortura();
                        }
                        break;
                    case "sanefuji":
                        break;
                    case "devi":
                        if (Random.value >= 0.5f)
                        {
                            finalLegistaNPunhoRaivas();
                        }
                        else
                        {
                            finalLegistaNMataHomem();
                        }
                        break;
                    case "policial":
                        if (Random.value >= 0.5f)
                        {
                            dialogoPolicialNMataIdosaFunction();
                        }
                        else
                        {
                            dialogoPolicialNTortura();
                        }
                        break;
                    case "TI":
                        if (Random.value > 0.5f)
                        {
                            dialogoTIgostaDeXovensFunction();
                        }
                        else
                        {
                            dialogoTINMataVingancaFunction();
                        }
                        break;
                }
                startaFinal = false;
                Analise.terminouConversa = false;
            }
        }
        else
        {
            if (!startaFinal)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    MainMenu.PrimeiroCaso = false;
                    switch (nomeDaPessoaNoFinal)
                    {
                        case "parceiro":
                            dialogueControlFinal.DisplayNextSentence(diaologoFinalParceiro);
                            break;
                        case "devi":
                            dialogueControlFinal.DisplayNextSentence(legistaDialogo);
                            break;
                        case "policial":
                            dialogueControlFinal.DisplayNextSentence(policialDialogo);
                            break;
                        case "TI":
                            dialogueControlFinal.DisplayNextSentence(TIDialogo);
                            break;
                    }
                    if (Analise.terminouConversa == true)
                    {
                        TrocaDeAndares.AndarAtual = 0;
                        if (PauseMenu.NumeroDeCasosJogadoPeloPlayer == 6)
                        {
                            SavePlayer();
                            SceneManager.LoadScene(4);
                        }
                        else
                        {
                            PauseMenu.NumeroDeCasosJogadoPeloPlayer++;
                            SavePlayer();
                            if (ScenesManager.ActualScene == 3)
                            {
                                if (Random.value > 0.5f)
                                {
                                    SceneManager.LoadScene(5);
                                }
                                else
                                {
                                    SceneManager.LoadScene(2);
                                }
                            }
                            else if (ScenesManager.ActualScene == 2)
                            {
                                if (Random.value > 0.5f)
                                {
                                    SceneManager.LoadScene(3);
                                }
                                else
                                {
                                    SceneManager.LoadScene(5);
                                }
                            }
                            else if (ScenesManager.ActualScene == 5)
                            {
                                if (Random.value > 0.5f)
                                {
                                    SceneManager.LoadScene(3);
                                }
                                else
                                {
                                    SceneManager.LoadScene(2);
                                }
                            }
                        }

                    }
                }
            }
        }
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        texto.text = "Do you want to go to the crime scene?";
                    }
                    else
                    {
                        texto.text = "Deseja ir a cena do crime?";
                    }
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        texto.text = "Do you want to go to the police station?";
                    }
                    else
                    {
                        texto.text = "Deseja ir a delegacia";
                    }
                }
                Transition.SetBool("Abrir", true);
                botaoSim.SetActive(true);
                botaoNao.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                botaoSim.SetActive(false);
                botaoNao.SetActive(false);
            }
        }
        else
        {
        }
    }



    public void diaologoFinalParceiroFuncaoNTortura()
    {
        if (!MainMenu.PrimeiroCaso)
        {
            if (PlayerData.Idioma == "ingles")
            {
                diaologoFinalParceiro.sentencesIngles[0] = "Detective, can I have a word with you?";
                diaologoFinalParceiro.sentencesIngles[1] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[2] = "Sure, Steve. What's the problem?";
                diaologoFinalParceiro.sentencesIngles[3] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[4] = "Sanefuji is having some very strange conversations with me.";
                diaologoFinalParceiro.sentencesIngles[5] = "troca pensando";
                diaologoFinalParceiro.sentencesIngles[6] = "Like this?";
                diaologoFinalParceiro.sentencesIngles[7] = "troca pensando";
                diaologoFinalParceiro.sentencesIngles[8] = "He's talking about business, big data, artificial intelligence in the market and other weird words.";
                diaologoFinalParceiro.sentencesIngles[9] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[10] = "(Poor Steve, that kind of person just talks about it)";
                diaologoFinalParceiro.sentencesIngles[11] = "troca pensando";
                diaologoFinalParceiro.sentencesIngles[12] = "I couldn't understand anything he said";
                diaologoFinalParceiro.sentencesIngles[13] = "It's excruciating to be with someone like that by your side 24 hours, I hate it.";
                diaologoFinalParceiro.sentencesIngles[14] = "I would never do that to anyone.";
                diaologoFinalParceiro.sentencesIngles[15] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[16] = "Good, Steve. It just shows you're not a money freak. Hahaha.";
                diaologoFinalParceiro.sentencesIngles[17] = "finalizar";
            }
            else
            {
                diaologoFinalParceiro.sentences[0] = "Detetive, posso trocar uma palavrinha com você?";
                diaologoFinalParceiro.sentences[1] = "troca paisagem";
                diaologoFinalParceiro.sentences[2] = "Claro, Steve. Qual o problema?";
                diaologoFinalParceiro.sentences[3] = "troca paisagem";
                diaologoFinalParceiro.sentences[4] = "O Sanefuji está com uns papos muito estranhos para cima de mim.";
                diaologoFinalParceiro.sentences[5] = "troca pensando";
                diaologoFinalParceiro.sentences[6] = "Como assim?";
                diaologoFinalParceiro.sentences[7] = "troca pensando";
                diaologoFinalParceiro.sentences[8] = "Ele está falando sobre business, big data , artificial intelligence no mercado e outras palavras estranhas.";
                diaologoFinalParceiro.sentences[9] = "troca paisagem";
                diaologoFinalParceiro.sentences[10] = "(Coitado do Steve, esse tipo de pessoa só fala disso)";
                diaologoFinalParceiro.sentences[11] = "troca pensando";
                diaologoFinalParceiro.sentences[12] = "Eu não consegui entender nada do que ele falou";
                diaologoFinalParceiro.sentences[13] = "É torturante ficar com alguém assim ao seu lado 24 horas, eu detesto isso.";
                diaologoFinalParceiro.sentences[14] = "Jamais faria isso com alguém.";
                diaologoFinalParceiro.sentences[15] = "troca paisagem";
                diaologoFinalParceiro.sentences[16] = "Que bom, Steve. Isso só mostra que você não é um maluco por dinheiro. Hahaha.";
                diaologoFinalParceiro.sentences[17] = "finalizar";
            }
        }
        dialogueControlFinal.StartDialogue(diaologoFinalParceiro);
    }


    public void diaologoFinalParceiroFuncao()
    {
        if (!MainMenu.PrimeiroCaso)
        {
            if (PlayerData.Idioma == "ingles")
            {
                diaologoFinalParceiro.sentencesIngles[0] = "Complicated case today.";
                diaologoFinalParceiro.sentencesIngles[1] = "How can someone commit crimes like that?";
                diaologoFinalParceiro.sentencesIngles[2] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[3] = "We are here to solve the case.";
                diaologoFinalParceiro.sentencesIngles[4] = "Don't spend a lot of time thinking about him.";
                diaologoFinalParceiro.sentencesIngles[5] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[6] = "It was my first detective case.";
                diaologoFinalParceiro.sentencesIngles[7] = "It is different from what I expected.";
                diaologoFinalParceiro.sentencesIngles[8] = "troca pensando";
                diaologoFinalParceiro.sentencesIngles[9] = "(maybe it is an experience unlike anything he has ever seen)";
                diaologoFinalParceiro.sentencesIngles[10] = "pensando detetive";
                diaologoFinalParceiro.sentencesIngles[11] = "It's okay, in my first case as a partner, I pissed myself all over.";
                diaologoFinalParceiro.sentencesIngles[12] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[13] = "I don't believe it!";
                diaologoFinalParceiro.sentencesIngles[14] = "You must be kidding.";
                diaologoFinalParceiro.sentencesIngles[15] = "troca embara";
                diaologoFinalParceiro.sentencesIngles[16] = "I'm just kidding.";
                diaologoFinalParceiro.sentencesIngles[17] = "But in fact it was difficult for me, it is difficult for everyone the first time.";
                diaologoFinalParceiro.sentencesIngles[18] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[19] = "Thank you, detective.";
                diaologoFinalParceiro.sentencesIngles[20] = "I hope this doesn't happen very often.";
                diaologoFinalParceiro.sentencesIngles[21] = "troca paisagem";
                diaologoFinalParceiro.sentencesIngles[22] = "I came to this city, because I knew it was more peaceful.";
                diaologoFinalParceiro.sentencesIngles[23] = "I believe that we will not have many cases of murder.";
                diaologoFinalParceiro.sentencesIngles[24] = "finalizar";
            }
            else
            {
                diaologoFinalParceiro.sentences[0] = "Caso complicado hoje.";
                diaologoFinalParceiro.sentences[1] = "Como pode alguem cometer crimes assim?";
                diaologoFinalParceiro.sentences[2] = "troca paisagem";
                diaologoFinalParceiro.sentences[3] = "Estamos aqui para desvendar o caso.";
                diaologoFinalParceiro.sentences[4] = "Não gaste muito tempo pensando nele.";
                diaologoFinalParceiro.sentences[5] = "troca paisagem";
                diaologoFinalParceiro.sentences[6] = "Foi o meu primeira caso detetive.";
                diaologoFinalParceiro.sentences[7] = "É diferente do que eu esperava.";
                diaologoFinalParceiro.sentences[8] = "troca pensando";
                diaologoFinalParceiro.sentences[9] = "(talvez seja uma experiência diferente de tudo que ele já tenha visto)";
                diaologoFinalParceiro.sentences[10] = "pensando detetive";
                diaologoFinalParceiro.sentences[11] = "Esta tudo bem, no meu primeiro caso como parceiro, eu me mijei todo.";
                diaologoFinalParceiro.sentences[12] = "troca paisagem";
                diaologoFinalParceiro.sentences[13] = "Não acreito nisso!";
                diaologoFinalParceiro.sentences[14] = "Só pode ser brincadeira.";
                diaologoFinalParceiro.sentences[15] = "troca embara";
                diaologoFinalParceiro.sentences[16] = "Estou brincando só.";
                diaologoFinalParceiro.sentences[17] = "Mas de fato foi algo díficil para mim, é díficil para todo mundo na primeira vez.";
                diaologoFinalParceiro.sentences[18] = "troca paisagem";
                diaologoFinalParceiro.sentences[19] = "Obrigado detetive.";
                diaologoFinalParceiro.sentences[20] = "Espero que isso não aconteça com muita frequência.";
                diaologoFinalParceiro.sentences[21] = "troca paisagem";
                diaologoFinalParceiro.sentences[22] = "Eu vim para essa cidade, por que eu soube que era mais tranquila.";
                diaologoFinalParceiro.sentences[23] = "Acredito que não teremos muitos casos de assassinato.";
                diaologoFinalParceiro.sentences[24] = "finalizar";
            }
        }
        dialogueControlFinal.StartDialogue(diaologoFinalParceiro);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(movimento);
        SaveSystem.SaveMusic();
    }
    public void Delegacia()
    {
        MainMenu.NewGame = false;
        SavePlayer();
        SceneManager.LoadScene(1);

    }

    public void Voltar()
    {
        if (Relatorio.perguntando == false)
        {
            SavePlayer();
            SceneManager.LoadScene(CrimeScene);
        }

    }

    public void No()
    {
        if (isInRange)
        {
            isInRange = false;
            Transition.SetBool("Abrir", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            StopAllCoroutines();
            StartCoroutine(LigaE());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transition.SetBool("Abrir", false);
            isInRange = false;
            StopAllCoroutines();
            E.color = new Color(255, 255, 255, 0);
            botaoSim.SetActive(false);
            botaoNao.SetActive(false);
        }
    }
    IEnumerator DesligaE()
    {
        for (i = 1; i > -0.5; i = i - 0.05f)
        {
            E.color = new Color(255, 255, 255, i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(LigaE());
    }
    IEnumerator LigaE()
    {
        for (i = 0; i < 1.5; i = i + 0.05f)
        {
            E.color = new Color(255, 255, 255, i);
            yield return new WaitForSeconds(0.03f);
        }
        StartCoroutine(DesligaE());
    }
}