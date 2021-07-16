using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
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
    public static string nomePessoaTransicao;
    public static bool jornalistaBrigouComALegista;
    public static bool eraHomemUltimoCaso;
    // Start is called before the first frame update
    void Start()
    {
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
            if (Random.value >= 0.66f)
            {
                nomePessoaTransicao = "parceiro";
                dialogueControl.StartDialogue(dialogoParceiroDetetiveIndoParaDelegacia);
            }
            else if (Random.value < 0.66f && Random.value >= 0.33f)
            {
                nomePessoaTransicao = "delegado";
                dialogoDelegadoNRouba();
                dialogueControl.StartDialogue(dialogoDelegadoTransicaonRouba);
            }
            else if (Random.value < 0.3f)
            {
                nomePessoaTransicao = "legista";
                dialogueControl.StartDialogue(dialogoDelegadoTransicaonRouba);
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            DialogoTransicao = true;
            animator.SetBool("CarroGif", true);
            FinalDoJogoControl.StartDialogue(dialogoFinalDoJogo);
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
                if (Random.value > 0.25f)
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
                        DialogoTransicao = true;
                        animator.SetBool("CarroGif", true);
                        PrimeiraVezDialogoTransicao = false;
                        jornalistaBrigouComALegista = true;
                        if(eraHomemUltimoCaso){
                                ComecoJornalistaBrigaHomemVitima();
                            }
                            else{
                                ComecoJornalistaBrigaMulherVitima();
                            }
                        dialogoComecoJornalistaBrigaComALegistaControl.StartDialogue(dialogoComecoJornalistaBrigaComALegista);
                    }
                    else
                    {
                        DialogoTransicao = true;
                        animator.SetBool("CarroGif", true);
                        PrimeiraVezDialogoTransicao = false;
                        dialogoPolicialNMataIdosaFunction();
                        dialogoPolicialNMataIdosaControl.StartDialogue(dialogoPolicialNMataIdosa);
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


    /*aaaaaa*/
    public void dialogoTINMataVingancaFunction()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoTINMataVinganca.sentencesIngles[0] = "Hi, detective. ";
            dialogoTINMataVinganca.sentencesIngles[1] = "Saw the new C.O.P .. ";
            dialogoTINMataVinganca.sentencesIngles[2] = "troca paisagem";
            dialogoTINMataVinganca.sentencesIngles[3] = "I haven't seen it yet, I'm out of time.";
            dialogoTINMataVinganca.sentencesIngles[4] = "Steve has spoken highly of the movie. What did you think?";
            dialogoTINMataVinganca.sentencesIngles[5] = "troca paisagem";
            dialogoTINMataVinganca.sentencesIngles[6] = "I really liked it, I just had a problem with the protagonist's decisions";
            dialogoTINMataVinganca.sentencesIngles[7] = "troca pensando";
            dialogoTINMataVinganca.sentencesIngles[8] = "Why?";
            dialogoTINMataVinganca.sentencesIngles[9] = "In this movie he is seeking revenge for his wife's death. ";
            dialogoTINMataVinganca.sentencesIngles[10] = "And sons.";
            dialogoTINMataVinganca.sentencesIngles[11] = "And dog.";
            dialogoTINMataVinganca.sentencesIngles[12] = "And in the end he ends up dying because of it.";
            dialogoTINMataVinganca.sentencesIngles[13] = "I didn't like him having this feeling of revenge, I don't think it's very heroic.";
            dialogoTINMataVinganca.sentencesIngles[14] = "That's why I didn't like it so much.";
            dialogoTINMataVinganca.sentencesIngles[15] = "Do you understand, detective?";
            dialogoTINMataVinganca.sentencesIngles[16] = "troca desgosto";
            dialogoTINMataVinganca.sentencesIngles[17] = "...";
            dialogoTINMataVinganca.sentencesIngles[18] = "(SPOILEEEEEEEEEEER!!!!)";
            dialogoTINMataVinganca.sentencesIngles[19] = "finalizar";
        }
        else
        {
            dialogoTINMataVinganca.sentences[0] = "Olá, detetive.";
            dialogoTINMataVinganca.sentences[1] = "Viu o novo filme do C.O.P..";
            dialogoTINMataVinganca.sentences[2] = "troca paisagem";
            dialogoTINMataVinganca.sentences[3] = "Ainda não vi, estou sem tempo.";
            dialogoTINMataVinganca.sentences[4] = "O Steve tem falado bem do filme. O que você achou?";
            dialogoTINMataVinganca.sentences[5] = "troca paisagem";
            dialogoTINMataVinganca.sentences[6] = "Eu gostei bastante, só tive um problema com as decisões do protagonista";
            dialogoTINMataVinganca.sentences[7] = "troca pensando";
            dialogoTINMataVinganca.sentences[8] = "Por que?";
            dialogoTINMataVinganca.sentences[9] = "Nesse filme ele está em busca de vingança pela morte de sua esposa.";
            dialogoTINMataVinganca.sentences[10] = "E filhos.";
            dialogoTINMataVinganca.sentences[11] = "E cachorro.";
            dialogoTINMataVinganca.sentences[12] = "E no final ele acaba morrendo por causa disso.";
            dialogoTINMataVinganca.sentences[13] = "Não gostei dele ter esse sentimento de vingança, não acho muito heroico.";
            dialogoTINMataVinganca.sentences[14] = "Por isso acabou não me agradando tanto.";
            dialogoTINMataVinganca.sentences[15] = "Entendeu, detetive?";
            dialogoTINMataVinganca.sentences[16] = "troca desgosto";
            dialogoTINMataVinganca.sentences[17] = "...";
            dialogoTINMataVinganca.sentences[18] = "(SPOILEEEEEEEEEEER!!!!)";
            dialogoTINMataVinganca.sentences[19] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(dialogoTINMataVinganca);
    }

    /*aaaaaa*/
    public void dialogoTIgostaDeXovensFunction()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoTIgostaDeXovens.sentencesIngles[0] = "Hello detective.";
            dialogoTIgostaDeXovens.sentencesIngles[1] = "troca paisagem";
            dialogoTIgostaDeXovens.sentencesIngles[2] = "Hello Kyle.";
            dialogoTIgostaDeXovens.sentencesIngles[3] = "troca paisagem";
            dialogoTIgostaDeXovens.sentencesIngles[4] = "I saw that there was a journalist behind you today asking you questions.";
            dialogoTIgostaDeXovens.sentencesIngles[5] = "troca embara";
            dialogoTIgostaDeXovens.sentencesIngles[6] = "It was Jessie, she's an investigative journalist for the local paper. She wanted more details about the serial killer.";
            dialogoTIgostaDeXovens.sentencesIngles[7] = "troca paisagem";
            dialogoTIgostaDeXovens.sentencesIngles[8] = "She's pretty hot, would you happen to have her number? For a friend of mine, of course.";
            dialogoTIgostaDeXovens.sentencesIngles[9] = "troca pensando";
            dialogoTIgostaDeXovens.sentencesIngles[10] = "Are you interested? I know there are some ladies here at the police station who are making a fuss about you. Hahaha.";
            dialogoTIgostaDeXovens.sentencesIngles[11] = "troca pensando";
            dialogoTIgostaDeXovens.sentencesIngles[12] = "Unfortunately. Haha.";
            dialogoTIgostaDeXovens.sentencesIngles[13] = "I don't like old people.";
            dialogoTIgostaDeXovens.sentencesIngles[14] = "But the journalist seemed pretty cool to me.";
            dialogoTIgostaDeXovens.sentencesIngles[15] = "My... My friend says she's cool.";
            dialogoTIgostaDeXovens.sentencesIngles[16] = "troca paisagem";
            dialogoTIgostaDeXovens.sentencesIngles[17] = "Hahaha. Your friend, right. I see what I can do.";
            dialogoTIgostaDeXovens.sentencesIngles[18] = "But if I, as a friend, can tell you: she is unbearable.";
            dialogoTIgostaDeXovens.sentencesIngles[19] = "troca paisagem";
            dialogoTIgostaDeXovens.sentencesIngles[20] = "Okay, I believe I can handle it, Detective. Thanks for your help.";
            dialogoTIgostaDeXovens.sentencesIngles[21] = "finalizar";
        }
        else
        {
            dialogoTIgostaDeXovens.sentences[0] = "Olá, detetive.";
            dialogoTIgostaDeXovens.sentences[1] = "troca paisagem";
            dialogoTIgostaDeXovens.sentences[2] = "Olá, Kyle.";
            dialogoTIgostaDeXovens.sentences[3] = "troca paisagem";
            dialogoTIgostaDeXovens.sentences[4] = "Eu vi que tinha uma jornalista atrás de você hoje te enchendo de perguntas.";
            dialogoTIgostaDeXovens.sentences[5] = "troca embara";
            dialogoTIgostaDeXovens.sentences[6] = "Era a Jessie, ela é jornalista investigativa do jornal local. Ela queria mais detalhes sobre o assassino em série.";
            dialogoTIgostaDeXovens.sentences[7] = "troca paisagem";
            dialogoTIgostaDeXovens.sentences[8] = "Ela é bem gata, você por acaso teria o número dela? Para um amigo meu, é claro.";
            dialogoTIgostaDeXovens.sentences[9] = "troca pensando";
            dialogoTIgostaDeXovens.sentences[10] = "Está interessado? Eu sei que tem umas senhorinhas aqui na delegacia que ficam dando mole para você. Hahaha.";
            dialogoTIgostaDeXovens.sentences[11] = "troca pensando";
            dialogoTIgostaDeXovens.sentences[12] = "Infelizmente. Haha.";
            dialogoTIgostaDeXovens.sentences[13] = "Não gosto de gente velha.";
            dialogoTIgostaDeXovens.sentences[14] = "Mas a jornalista me pareceu bem legal.";
            dialogoTIgostaDeXovens.sentences[15] = "Meu.. Meu amigo disse que ela é legal.";
            dialogoTIgostaDeXovens.sentences[16] = "troca paisagem";
            dialogoTIgostaDeXovens.sentences[17] = "Hahaha. Seu amigo, né. Eu vejo o que consigo fazer.";
            dialogoTIgostaDeXovens.sentences[18] = "Mas se eu, como amigo, puder te falar: ela é insuportável.";
            dialogoTIgostaDeXovens.sentences[19] = "troca paisagem";
            dialogoTIgostaDeXovens.sentences[20] = "Tudo bem, acredito que eu dou conta, deteive. Obrigado pela ajuda.";
            dialogoTIgostaDeXovens.sentences[21] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(dialogoTIgostaDeXovens);
    }


    /*aaaaa*/
    public void dialogoPolicialNTortura()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoPolicialFimNTortura.sentencesIngles[0] = "Hard day today, detective?";
            dialogoPolicialFimNTortura.sentencesIngles[1] = "troca paisagem";
            dialogoPolicialFimNTortura.sentencesIngles[2] = "Complicated as always.";
            dialogoPolicialFimNTortura.sentencesIngles[3] = "Tell me Johnny, have you had a really complicated case here in town?";
            dialogoPolicialFimNTortura.sentencesIngles[4] = "troca paisagem";
            dialogoPolicialFimNTortura.sentencesIngles[5] = "Since you asked, I'll tell you a story";
            dialogoPolicialFimNTortura.sentencesIngles[6] = "troca pensando";
            dialogoPolicialFimNTortura.sentencesIngles[7] = "(I hope I don't regret the question)";
            dialogoPolicialFimNTortura.sentencesIngles[8] = "troca paisagem";
            dialogoPolicialFimNTortura.sentencesIngles[9] = "A few years ago, when I joined the police, there was a serial killer.";
            dialogoPolicialFimNTortura.sentencesIngles[10] = "After much study about his methods of murder and his antics, the police chief, ex detective and the staff of the police station found their whereabouts.";
            dialogoPolicialFimNTortura.sentencesIngles[11] = "We closed the place where he was. The policeman and I went in to arrest the murderer, I went from the opposite side of the policeman.";
            dialogoPolicialFimNTortura.sentencesIngles[12] = "But before we could do anything he shot the sheriff in the leg and ran.";
            dialogoPolicialFimNTortura.sentencesIngles[13] = "Luckily I was on the other side and managed to catch the criminal without him being able to react";
            dialogoPolicialFimNTortura.sentencesIngles[14] = "I was very angry with the guy, I wanted to be able to torture him as he did to all his victims.";
            dialogoPolicialFimNTortura.sentencesIngles[15] = "troca pensando";
            dialogoPolicialFimNTortura.sentencesIngles[16] = "And did you?";
            dialogoPolicialFimNTortura.sentencesIngles[17] = "troca pensando";
            dialogoPolicialFimNTortura.sentencesIngles[18] = "No. I didn't go down to his level. I handcuffed him and took him back to the police station.";
            dialogoPolicialFimNTortura.sentencesIngles[19] = "troca paisagem";
            dialogoPolicialFimNTortura.sentencesIngles[20] = "And the chief? Was he alright?";
            dialogoPolicialFimNTortura.sentencesIngles[21] = "Did you feel angry at the killer for the things he did and for the shot in his leg?";
            dialogoPolicialFimNTortura.sentencesIngles[22] = "troca pensando";
            dialogoPolicialFimNTortura.sentencesIngles[23] = "The delegate was responsible for the case of the murders, but he is not an emotional or angry man, he has always been calm.";
            dialogoPolicialFimNTortura.sentencesIngles[24] = "Today the murderer is in a prison outside the city.";
            dialogoPolicialFimNTortura.sentencesIngles[25] = "troca pensando";
            dialogoPolicialFimNTortura.sentencesIngles[26] = "Nice to hear these stories. Thanks, Officer.";
            dialogoPolicialFimNTortura.sentencesIngles[27] = "finalizar";
        }
        else
        {
            dialogoPolicialFimNTortura.sentences[0] = "Dia difícil hoje, detetive?";
            dialogoPolicialFimNTortura.sentences[1] = "troca paisagem";
            dialogoPolicialFimNTortura.sentences[2] = "Complicado como sempre.";
            dialogoPolicialFimNTortura.sentences[3] = "Diga-me Johnny, você teve algum caso bem complicado aqui na cidade?";
            dialogoPolicialFimNTortura.sentences[4] = "troca paisagem";
            dialogoPolicialFimNTortura.sentences[5] = "Já que perguntou, vou te contar uma história";
            dialogoPolicialFimNTortura.sentences[6] = "troca pensando";
            dialogoPolicialFimNTortura.sentences[7] = "(Tomara que não me arrependa da pergunta)";
            dialogoPolicialFimNTortura.sentences[8] = "troca paisagem";
            dialogoPolicialFimNTortura.sentences[9] = "Alguns anos atrás, quando entrei na polícia, tinha um assassino em série.";
            dialogoPolicialFimNTortura.sentences[10] = "Depois de muito estudo sobre seus métodos de assassinato e seus trejeitos, o delegado, ex detetive e o pessoal da delegacia encontraram seu paradeiro.";
            dialogoPolicialFimNTortura.sentences[11] = "Fechamos o local onde ele estava. Eu e o delegado entramos para prender o assassino, fui pelo lado oposto ao delegado.";
            dialogoPolicialFimNTortura.sentences[12] = "Mas antes que pudessemos fazer alguma coisa ele atirou na perna do delegado e correu.";
            dialogoPolicialFimNTortura.sentences[13] = "Para minha sorte eu estava do outro lado e consegui pegar o criminoso sem que ele pudesse reagir";
            dialogoPolicialFimNTortura.sentences[14] = "Estava com muito ódio do sujeito, queria poder torturá-lo como ele fez com todas as suas vítimas.";
            dialogoPolicialFimNTortura.sentences[15] = "troca pensando";
            dialogoPolicialFimNTortura.sentences[16] = "E o fez?";
            dialogoPolicialFimNTortura.sentences[17] = "troca pensando";
            dialogoPolicialFimNTortura.sentences[18] = "Não. Não desci ao nível dele. O algemei e levei de volta para a delegacia.";
            dialogoPolicialFimNTortura.sentences[19] = "troca paisagem";
            dialogoPolicialFimNTortura.sentences[20] = "E o delegado? Ficou bem?";
            dialogoPolicialFimNTortura.sentences[21] = "Sentiu raiva do assassino pelas coisas que ele fez e pelo tiro em sua perna?";
            dialogoPolicialFimNTortura.sentences[22] = "troca pensando";
            dialogoPolicialFimNTortura.sentences[23] = "O delegado era o responsável pelo caso dos assassinatos, mas ele não é um homem emotivo ou que sente raiva, sempre esteve calmo.";
            dialogoPolicialFimNTortura.sentences[24] = "Hoje o assassino está em uma prisão fora da cidade.";
            dialogoPolicialFimNTortura.sentences[25] = "troca pensando";
            dialogoPolicialFimNTortura.sentences[26] = "Bom saber dessas histórias. Obrigado, policial.";
            dialogoPolicialFimNTortura.sentences[27] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(dialogoPolicialFimNTortura);
    }

    /*aaaaaa*/
    public void dialogoDelegadoNRouba()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoDelegadoTransicaonRouba.sentencesIngles[0] = "troca paisagem";
            dialogoDelegadoTransicaonRouba.sentencesIngles[1] = "Chief, did you happen to see Steve's cell phone?";
            dialogoDelegadoTransicaonRouba.sentencesIngles[2] = "troca paisagem";
            dialogoDelegadoTransicaonRouba.sentencesIngles[3] = "I found a cell phone in my room earlier today, I was looking for the owner.";
            dialogoDelegadoTransicaonRouba.sentencesIngles[4] = "troca pensando";
            dialogoDelegadoTransicaonRouba.sentencesIngles[5] = "Let me see.";
            dialogoDelegadoTransicaonRouba.sentencesIngles[6] = "landscape detective";
            dialogoDelegadoTransicaonRouba.sentencesIngles[7] = "I believe that it is the same. He lost his cell phone again and asked me to help him find it.";
            dialogoDelegadoTransicaonRouba.sentencesIngles[8] = "troca paisagem";
            dialogoDelegadoTransicaonRouba.sentencesIngles[9] = "Relax, everything I find lost I try to return to the owner.";
            dialogoDelegadoTransicaonRouba.sentencesIngles[10] = "Unless it's cookies, then I'll eat.";
            dialogoDelegadoTransicaonRouba.sentencesIngles[11] = "troca paisagem";
            if (ComeuAMaeDoPolicial)
            {
                dialogoDelegadoTransicaonRouba.sentencesIngles[12] = "(A mãe do Johnny também)";
                dialogoDelegadoTransicaonRouba.sentencesIngles[13] = "finalizar";
            }
            else
            {
                dialogoDelegadoTransicaonRouba.sentencesIngles[12] = "finalizar";
            }
        }
        else
        {
            dialogoDelegadoTransicaonRouba.sentences[0] = "troca paisagem";
            dialogoDelegadoTransicaonRouba.sentences[1] = "Delegado, por acaso o senhor viu o celular do Steve?";
            dialogoDelegadoTransicaonRouba.sentences[2] = "troca paisagem";
            dialogoDelegadoTransicaonRouba.sentences[3] = "Eu encontrei um celular na minha sala hoje mais cedo, estava procurando o dono.";
            dialogoDelegadoTransicaonRouba.sentences[4] = "troca pensando";
            dialogoDelegadoTransicaonRouba.sentences[5] = "Deixe-me ver.";
            dialogoDelegadoTransicaonRouba.sentences[6] = "detetive paisagem";
            dialogoDelegadoTransicaonRouba.sentences[7] = "Acredito que seja esse mesmo. Ele perdeu o celular de novo e me pediu para ajudar a encontrá-lo.";
            dialogoDelegadoTransicaonRouba.sentences[8] = "troca paisagem";
            dialogoDelegadoTransicaonRouba.sentences[9] = "Tranquilo, tudo que eu encontro perdido tento devolver para o dono.";
            dialogoDelegadoTransicaonRouba.sentences[10] = "A menos que sejam biscoitos, aí eu como.";
            dialogoDelegadoTransicaonRouba.sentences[11] = "troca paisagem";
            if (ComeuAMaeDoPolicial)
            {
                dialogoDelegadoTransicaonRouba.sentences[12] = "(A mãe do Johnny também)";
                dialogoDelegadoTransicaonRouba.sentences[13] = "finalizar";
            }
            else
            {
                dialogoDelegadoTransicaonRouba.sentences[12] = "finalizar";
            }
        }
    }

    /*aaaaa*/
    public void dialogoPolicialNMataIdosaFunction()
    {
        ComeuAMaeDoPolicial = true;
        if (PlayerData.Idioma == "ingles")
        {
            dialogoPolicialNMataIdosa.sentencesIngles[0] = "Hello detective.";
            dialogoPolicialNMataIdosa.sentencesIngles[1] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[2] = "Hi Johnny. How was your day?";
            dialogoPolicialNMataIdosa.sentencesIngles[3] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[4] = "You won't believe it, detective. I will tell you everything.";
            dialogoPolicialNMataIdosa.sentencesIngles[5] = "exchange disgust";
            dialogoPolicialNMataIdosa.sentencesIngles[6] = "(Why did I ask?)";
            dialogoPolicialNMataIdosa.sentencesIngles[7] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[8] = "I went to take my mother to the Association for the Support of the Elderly.";
            dialogoPolicialNMataIdosa.sentencesIngles[9] = "troca pensando";
            dialogoPolicialNMataIdosa.sentencesIngles[10] = "Is everything okay with her?";
            dialogoPolicialNMataIdosa.sentencesIngles[11] = "troca pensando";
            dialogoPolicialNMataIdosa.sentencesIngles[12] = "Yes, she is, she works there. She loves helping the elderly, whenever possible I help them too.";
            dialogoPolicialNMataIdosa.sentencesIngles[13] = "But the important thing was what I saw.";
            dialogoPolicialNMataIdosa.sentencesIngles[14] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[15] = "What?";
            dialogoPolicialNMataIdosa.sentencesIngles[16] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[17] = "The delegate, he was there too.";
            dialogoPolicialNMataIdosa.sentencesIngles[18] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[19] = "How nice of him.";
            dialogoPolicialNMataIdosa.sentencesIngles[20] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[21] = "Nice shit. He was hitting on my mom.";
            dialogoPolicialNMataIdosa.sentencesIngles[22] = "He came by offering cookies and asked if he could wet him later with her.";
            dialogoPolicialNMataIdosa.sentencesIngles[23] = "exchange embara";
            dialogoPolicialNMataIdosa.sentencesIngles[24] = "Hahaha. I didn't expect this one.";
            dialogoPolicialNMataIdosa.sentencesIngles[25] = "troca pensando";
            dialogoPolicialNMataIdosa.sentencesIngles[26] = "Now I only take my mom if I'm sure he won't be there.";
            dialogoPolicialNMataIdosa.sentencesIngles[27] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[28] = "You don't need to get mad about it. Imagine the sheriff as stepfather. Hahaha.";
            dialogoPolicialNMataIdosa.sentencesIngles[29] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[30] = "You laugh because it's not you. Haha.";
            dialogoPolicialNMataIdosa.sentencesIngles[31] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentencesIngles[32] = "I'm glad. Hahaha.";
            dialogoPolicialNMataIdosa.sentencesIngles[33] = "finalizar";
        }
        else
        {
            dialogoPolicialNMataIdosa.sentences[0] = "Olá, detetive.";
            dialogoPolicialNMataIdosa.sentences[1] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[2] = "Olá, Johnny. Como foi o seu dia?";
            dialogoPolicialNMataIdosa.sentences[3] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[4] = "Você nem vai acreditar, detetive. Irei te contar tudo.";
            dialogoPolicialNMataIdosa.sentences[5] = "troca desgosto";
            dialogoPolicialNMataIdosa.sentences[6] = "(Por que eu fui perguntar?)";
            dialogoPolicialNMataIdosa.sentences[7] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[8] = "Eu fui levar minha mãe para a Associação de Amparo aos Idosos.";
            dialogoPolicialNMataIdosa.sentences[9] = "troca pensando";
            dialogoPolicialNMataIdosa.sentences[10] = "Está tudo bem com ela?";
            dialogoPolicialNMataIdosa.sentences[11] = "troca pensando";
            dialogoPolicialNMataIdosa.sentences[12] = "Está sim, ela trabalha lá. Adora ajudar os idosos, sempre que possível eu ajudo eles também.";
            dialogoPolicialNMataIdosa.sentences[13] = "Mas o importante foi o que eu vi.";
            dialogoPolicialNMataIdosa.sentences[14] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[15] = "O que?";
            dialogoPolicialNMataIdosa.sentences[16] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[17] = "O delegado, ele estava lá também.";
            dialogoPolicialNMataIdosa.sentences[18] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[19] = "Que legal da parte dele.";
            dialogoPolicialNMataIdosa.sentences[20] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[21] = "Legal merda nenhuma. Ele estava dando em cima da minha mãe.";
            dialogoPolicialNMataIdosa.sentences[22] = "Ele veio oferecendo biscoitos e perguntou se podia molhar ele mais tarde com ela.";
            dialogoPolicialNMataIdosa.sentences[23] = "troca embara";
            dialogoPolicialNMataIdosa.sentences[24] = "Hahaha. Por essa eu não esperava.";
            dialogoPolicialNMataIdosa.sentences[25] = "troca pensando";
            dialogoPolicialNMataIdosa.sentences[26] = "Agora só levo a minha mãe se eu tiver certeza que ele não vai estar lá.";
            dialogoPolicialNMataIdosa.sentences[27] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[28] = "Não precisa ficar bolado com isso. Imagina o delegado como padrasto. Hahaha.";
            dialogoPolicialNMataIdosa.sentences[29] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[30] = "Você ri porque não é com você. Haha.";
            dialogoPolicialNMataIdosa.sentences[31] = "troca paisagem";
            dialogoPolicialNMataIdosa.sentences[32] = "Ainda bem. Hahaha.";
            dialogoPolicialNMataIdosa.sentences[33] = "finalizar";
        }
    }
    public void ComecoJornalistaBrigaMulherVitima()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[0] = "It's an absurd. A woman can't even get involved in activism in defense of women she's already dead.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[1] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[2] = "You're talking about the previous case, Jessie.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[3] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[4] = "Yes, she was super important to me, I even went to the morgue to take one last photo.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[5] = "Trying to keep alive the image and the messages it gave.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[6] = "But that damn girl had to get in the way.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[7] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[8] = "Who?";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[9] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[10] = "That coroner.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[11] = "She stopped me, called security and everything.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[12] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[13] = "It must have been the biggest shack.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[14] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[15] = "It was. Hahaha.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[16] = "finalizar";
        }
        else
        {
            dialogoComecoJornalistaBrigaComALegista.sentences[0] = "É um absurdo. Uma mulher não pode nem se meter com ativismo em defesa das mulheres que ela já morre.";
            dialogoComecoJornalistaBrigaComALegista.sentences[1] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentences[2] = "Está falando do caso anterior, Jessie.";
            dialogoComecoJornalistaBrigaComALegista.sentences[3] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentences[4] = "Sim, ela era de super importância para mim, até fui ao necrotério tirar uma última foto.";
            dialogoComecoJornalistaBrigaComALegista.sentences[5] = "Tentar manter viva a imagem e as mensagens que ela passou.";
            dialogoComecoJornalistaBrigaComALegista.sentences[6] = "Mas aquela maldita tinha que se meter no meio.";
            dialogoComecoJornalistaBrigaComALegista.sentences[7] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[8] = "Quem?";
            dialogoComecoJornalistaBrigaComALegista.sentences[9] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[10] = "Aquela legista.";
            dialogoComecoJornalistaBrigaComALegista.sentences[11] = "Ela me impediu, chamou os seguranças e tudo.";
            dialogoComecoJornalistaBrigaComALegista.sentences[12] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[13] = "Deve ter sido o maior barraco.";
            dialogoComecoJornalistaBrigaComALegista.sentences[14] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[15] = "Foi mesmo. Hahaha.";
            dialogoComecoJornalistaBrigaComALegista.sentences[16] = "finalizar";
        }
    }
    public void ComecoJornalistaBrigaHomemVitima()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[0] = "It's an absurd. A man like him will die and people will worship him.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[1] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[2] = "You're talking about the previous case, Jessie.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[3] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[4] = "Yes. He was a bastard, a woman abuser, homophobic and sexist.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[5] = "I went to the morgue to take one last photo.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[6] = "Show the world how rotten he really was.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[7] = "But that damn girl had to get in the way.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[8] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[9] = "Who?";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[10] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[11] = "That coroner.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[12] = "She stopped me, called security and everything.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[13] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[14] = "It must have been the biggest shack.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[15] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[16] = "It was. Hahaha.";
            dialogoComecoJornalistaBrigaComALegista.sentencesIngles[17] = "finalizar";
        }
        else
        {
            dialogoComecoJornalistaBrigaComALegista.sentences[0] = "É um absurdo. Um homem como ele morrer e as pessoas o idolatrarem.";
            dialogoComecoJornalistaBrigaComALegista.sentences[1] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentences[2] = "Está falando do caso anterior, Jessie.";
            dialogoComecoJornalistaBrigaComALegista.sentences[3] = "troca pensando";
            dialogoComecoJornalistaBrigaComALegista.sentences[4] = "Sim. Ele era um safado, abusador de mulheres, homofóbico e machista.";
            dialogoComecoJornalistaBrigaComALegista.sentences[5] = "Eu fui ao necrotério tirar uma última foto.";
            dialogoComecoJornalistaBrigaComALegista.sentences[6] = "Mostrar para o mundo o quão podre ele realmente era.";
            dialogoComecoJornalistaBrigaComALegista.sentences[7] = "Mas aquela maldita tinha que se meter no meio.";
            dialogoComecoJornalistaBrigaComALegista.sentences[8] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[9] = "Quem?";
            dialogoComecoJornalistaBrigaComALegista.sentences[10] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[11] = "Aquela legista.";
            dialogoComecoJornalistaBrigaComALegista.sentences[12] = "Ela me impediu, chamou os seguranças e tudo.";
            dialogoComecoJornalistaBrigaComALegista.sentences[13] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[14] = "Deve ter sido o maior barraco.";
            dialogoComecoJornalistaBrigaComALegista.sentences[15] = "troca paisagem";
            dialogoComecoJornalistaBrigaComALegista.sentences[16] = "Foi mesmo. Hahaha.";
            dialogoComecoJornalistaBrigaComALegista.sentences[17] = "finalizar";
        }
    }
    public void finalLegistaNPunhoRaivas()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoFinalLegistaNMataHomens.sentencesIngles[0] = "...";
            dialogoFinalLegistaNMataHomens.sentencesIngles[1] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[2] = "Hi Devi, how are you? Why the ugly face?";
            dialogoFinalLegistaNMataHomens.sentencesIngles[3] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentencesIngles[4] = "No biggie, detective. Only those people from the press who go overboard sometimes.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[5] = "troca pensando";
            dialogoFinalLegistaNMataHomens.sentencesIngles[6] = "Like this? Did something happen recently?";
            dialogoFinalLegistaNMataHomens.sentencesIngles[7] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentencesIngles[8] = "Jessie, the investigative journalist, ended up entering the morgue without permission to see the latest victim of the murders.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[9] = "I'm not one for fighting, I'm very calm. I asked her to leave.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[10] = "But she insisted on staying and seeing the body to take pictures.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[11] = "They have no limits, they don't even respect the dead body";
            dialogoFinalLegistaNMataHomens.sentencesIngles[12] = "troca pensando";
            dialogoFinalLegistaNMataHomens.sentencesIngles[13] = "Journalists?";
            dialogoFinalLegistaNMataHomens.sentencesIngles[14] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[15] = "Yes, there are some who go out of their way to get a headline.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[16] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[17] = "How did the situation end?";
            dialogoFinalLegistaNMataHomens.sentencesIngles[18] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[19] = "I tried to stop her, but as I was never good at fighting, I ended up calling the security guards and they took her away.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[20] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[21] = "The situation is difficult, but I'm on top of the case, it's a little while before the murderer is behind bars.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[22] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[23] = "Hopefully, detective.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[24] = "finalizar";
        }
        else
        {
            dialogoFinalLegistaNMataHomens.sentences[0] = "...";
            dialogoFinalLegistaNMataHomens.sentences[1] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[2] = "Olá Devi, tudo bem? Por que a cara feia?";
            dialogoFinalLegistaNMataHomens.sentences[3] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentences[4] = "Nada de demais, detetive. Só esse pessoal da imprensa que passa dos limites às vezes.";
            dialogoFinalLegistaNMataHomens.sentences[5] = "troca pensando";
            dialogoFinalLegistaNMataHomens.sentences[6] = "Como assim? Algo aconteceu recentemente?";
            dialogoFinalLegistaNMataHomens.sentences[7] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentences[8] = "Jessie, a jornalista investigativa, acabou entrando no necrotério sem permissão para ver a última vítima dos assassinatos.";
            dialogoFinalLegistaNMataHomens.sentences[9] = "Eu não sou de brigar, sou bem calma. Pedi para que ela se retirasse.";
            dialogoFinalLegistaNMataHomens.sentences[10] = "Mas ela insistiu em ficar e ver o corpo para tirar fotos.";
            dialogoFinalLegistaNMataHomens.sentences[11] = "Eles não têm limite, não respeitam nem o corpo morto";
            dialogoFinalLegistaNMataHomens.sentences[12] = "troca pensando";
            dialogoFinalLegistaNMataHomens.sentences[13] = "Os jornalistas?";
            dialogoFinalLegistaNMataHomens.sentences[14] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[15] = "Sim, tem alguns que fazem de tudo para conseguir uma manchete.";
            dialogoFinalLegistaNMataHomens.sentences[16] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[17] = "Como terminou a situação?";
            dialogoFinalLegistaNMataHomens.sentences[18] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[19] = "Eu tentei impedi-la, mas como nunca fui boa de briga acabei chamando os seguranças e eles a retiraram do local.";
            dialogoFinalLegistaNMataHomens.sentences[20] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[21] = "Difícil a situação, mas estou em cima do caso, falta pouco para o assassino estar atrás das grades.";
            dialogoFinalLegistaNMataHomens.sentences[22] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[23] = "Tomara, detetive.";
            dialogoFinalLegistaNMataHomens.sentences[24] = "finalizar";
        }
    }

    /*aaaaa*/
    public void finalLegistaNMataHomem()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoFinalLegistaNMataHomens.sentencesIngles[0] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[1] = "Going home, Devi?";
            dialogoFinalLegistaNMataHomens.sentencesIngles[2] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[3] = "I'm on my way, but since I found you here, I'd like to stop by.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[4] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentencesIngles[5] = "But of course, I would love to.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[6] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentencesIngles[7] = "I don't know if you knew, but I always thought you were so cute and smart, detective.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[8] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentencesIngles[9] = "Wow Devi, I feel the same, is that serious?!";
            dialogoFinalLegistaNMataHomens.sentencesIngles[10] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentencesIngles[11] = "No, hahaha.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[12] = "troca desgosto";
            dialogoFinalLegistaNMataHomens.sentencesIngles[13] = "But... But I...";
            dialogoFinalLegistaNMataHomens.sentencesIngles[14] = "I was playing with you detective, I love playing with men's hearts.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[15] = "I'm going home, see you another day.";
            dialogoFinalLegistaNMataHomens.sentencesIngles[16] = "troca desgosto";
            dialogoFinalLegistaNMataHomens.sentencesIngles[17] = "(Only sadness this life)";
            dialogoFinalLegistaNMataHomens.sentencesIngles[18] = "finalizar";
        }
        else
        {
            dialogoFinalLegistaNMataHomens.sentences[0] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[1] = "Indo para casa, Devi?";
            dialogoFinalLegistaNMataHomens.sentences[2] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[3] = "Estou indo, mas já que te encontrei aqui, gostaria de dar uma passadinha lá.";
            dialogoFinalLegistaNMataHomens.sentences[4] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentences[5] = "Mas é claro, eu adoraria.";
            dialogoFinalLegistaNMataHomens.sentences[6] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentences[7] = "Eu não sei se você sabia, mas eu sempre te achei tão bonito e esperto, detetive.";
            dialogoFinalLegistaNMataHomens.sentences[8] = "troca embara";
            dialogoFinalLegistaNMataHomens.sentences[9] = "Nossa Devi, eu sinto o mesmo, é sério isso?!.";
            dialogoFinalLegistaNMataHomens.sentences[10] = "troca paisagem";
            dialogoFinalLegistaNMataHomens.sentences[11] = "Não! Hahaha.";
            dialogoFinalLegistaNMataHomens.sentences[12] = "troca desgosto";
            dialogoFinalLegistaNMataHomens.sentences[13] = "Mas... Mas eu...";
            dialogoFinalLegistaNMataHomens.sentences[14] = "Estava brincado com você detetive, adoro brincar com o coração dos homens.";
            dialogoFinalLegistaNMataHomens.sentences[15] = "Eu estou indo para casa, te vejo outro dia.";
            dialogoFinalLegistaNMataHomens.sentences[16] = "troca desgosto";
            dialogoFinalLegistaNMataHomens.sentences[17] = "(Só tristezas essa vida)";
            dialogoFinalLegistaNMataHomens.sentences[18] = "finalizar";
        }
        dialogueControlFinal.StartDialogue(dialogoFinalLegistaNMataHomens);
    }

    /*aaaaa*/
    public void trocaTestemunhoJornalista()
    {
        if (PlayerData.Idioma == "ingles")
        {
            dialogoInicioTestemunhaJornalista.sentencesIngles[0] = "I really don't understand, detective.";
            dialogoInicioTestemunhaJornalista.sentencesIngles[1] = "Those psychopaths who spend days planning the death of their victims.";
            dialogoInicioTestemunhaJornalista.sentencesIngles[2] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentencesIngles[3] = "Why do you say that?";
            dialogoInicioTestemunhaJornalista.sentencesIngles[4] = "troca paisagem";
            dialogoInicioTestemunhaJornalista.sentencesIngles[5] = "It's one thing to be a crime of passion or lack of empathy, but killing an innocent in a planned way is beyond comprehensible.";
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

    /*aaaaaa*/
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
            dialogoInicioTestemunhaRico.sentencesIngles[18] = "detective thinking";
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
            dialogoInicioTestemunhaRico.sentences[18] = "detetive pensando";
            dialogoInicioTestemunhaRico.sentences[19] = "(Ainda bem que ele não é assim)";
            dialogoInicioTestemunhaRico.sentences[20] = "finalizar";
        }
    }


    /*aaaa*/
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
            dialogoInicioTestemunhaRico.sentencesIngles[7] = "Sometimes the situation gets tight and people go to illegal ways to get money to pay you in these difficult times.";
            dialogoInicioTestemunhaRico.sentencesIngles[8] = "troca paisagem";
            dialogoInicioTestemunhaRico.sentencesIngles[9] = "Money is money. Haha ha.";
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
                testemunhaTexto.text = "Witnesses" + "\n" +
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
                testemunhaTexto.text = "Testemunhas" + "\n" +
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
                testemunhaTexto.text = "Evidence" + "\n" +
                "Pieces of evidence are clues found at the crime scene. They are registered on your notebook (press 'TAB' to open the notebook)." + "\n" +
                "Pieces of evidence have info that will help you solve the case." + "\n" +
                "They can be updated by talking to the digital expert, in the police station." + "\n" +
                "It is only possible to update a limited number of evidences per case." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "Evidências" + "\n" +
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
                testemunhaTexto.text = "Artificial Intelligence and Progress" + "\n" +
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
                testemunhaTexto.text = "Inteligência Artificial e Progresso" + "\n" +
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
                testemunhaTexto.text = "Controls" + "\n" +
                "Press 'W''A''S''D' or the arrows to move." + "\n" +
                "Press 'E' to interact with objects." + "\n" +
                "Press 'E' to advance through the dialogues." + "\n" +
                "Press 'TAB' to open and close the notebook." + "\n" +
                "Press 'ESC' to open and close the pause menu. " + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "Controles" + "\n" +
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
                testemunhaTexto.text = "Thoughts" + "\n" +
                "Here is where the detective joins two pieces of evidence already found to create a theory." + "\n" +
                "Keep in mind that it only makes sense to create a new theory, something that can't be at the crime scene already." + "\n" +
                "The new theory becomes a thought that occured to the detective." + "\n" +
                "e.g.: Someone being invited to enter the building." + "\n" +
                "Thoughts will always be something immaterial, that can't be physically found at the crime scene." + "\n" +
                "Press 'ESC' to close this menu.";
            }
            else
            {
                testemunhaTexto.text = "Pensamentos" + "\n" +
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
                testemunhaTexto.text = "Report" + "\n" +
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
                testemunhaTexto.text = "Relatório" + "\n" +
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
    /*aaaaa*/
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
            dialogoDelegadoExplicando.sentencesIngles[7] = "detetive paisagem";
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
            dialogoDelegadoExplicando.sentences[7] = "detetive paisagem";
            dialogoDelegadoExplicando.sentences[8] = "Fico feliz que o pessoal esteja gostando.";
            dialogoDelegadoExplicando.sentences[9] = "troca paisagem";
            dialogoDelegadoExplicando.sentences[10] = "Continue assim.";
            dialogoDelegadoExplicando.sentences[11] = "finalizar";
        }
    }

    /*aaaa*/
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
            dialogoDelegadoExplicando.sentencesIngles[13] = "No. I am yes. I am also a delegate there.";
            dialogoDelegadoExplicando.sentencesIngles[14] = "exchange embara";
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

    /*aaaaaa*/
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
            dialogoDelegadoExplicando.sentencesIngles[6] = "I'm sorry, delegate, I've only been doing my job.";
            dialogoDelegadoExplicando.sentencesIngles[7] = "detetive paisagem";
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
            dialogoDelegadoExplicando.sentences[7] = "detetive paisagem";
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
                    switch (nomeDaPessoaTransicao)
                    {
                        case "parceiro":
                            dialogueControl.DisplayNextSentence(dialogoParceiroDetetiveIndoParaDelegacia);
                            break;
                        case "delegado":
                            dialogueControl.DisplayNextSentence(dialogoDelegadoTransicaonRouba);
                            break;
                        case "jornalista":
                            dialogueControl.DisplayNextSentence(dialogoComecoJornalistaBrigaComALegista);
                            break;
                    }
                }
                if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0)
                {
                    eraHomemUltimoCaso = SpawnObjects.SexoMasculino;
                    if (SceneManager.GetActiveScene().buildIndex != 4)
                    {
                        dialogueControl.DisplayNextSentence(dialogoDelegadoExplicando);
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
                nomeDaPessoaNoFinal = "parceiro";
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
                    case "saneguji":
                        break;
                    case "devi":
                        finalLegistaNMataHomem();
                        break;
                    case "policial":
                        dialogoPolicialNTortura();
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
                    dialogueControlFinal.DisplayNextSentence(diaologoFinalParceiro);
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
                                SceneManager.LoadScene(2);
                            }
                            else if (ScenesManager.ActualScene == 2)
                            {
                                SceneManager.LoadScene(3);
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


    /*aaaaa*/
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

    /*aaaa*/
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
                diaologoFinalParceiro.sentencesIngles[10] = "detetive pensando";
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
                diaologoFinalParceiro.sentences[10] = "detetive pensando";
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