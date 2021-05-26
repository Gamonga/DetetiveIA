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
    public Dialogue dialogoParceiroDetetiveIndoParaDelegacia;
    public Dialogue dialogoDelegadoExplicando;
    public Dialogue diaologoFinalParceiro;
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


    // Start is called before the first frame update
    void Start()
    {
        entrouTutorial = false;
        startaFinal = true;
        PrimeiraVezDialogoTransicao = true;
        animator = GameObject.Find("CarroTransicaoGIF").GetComponent<Animator>();
        PlayerData data = SaveSystem.LoadPlayer();
        if (MainMenu.PrimeiroCaso == false)
        {
            entrouTutorialPensamentos = data.entrouTutorialPensamentos;
            entrouTutorialTestemunha = data.entrouTutorialTestemunha;
            entrouTutorialEvidencias = data.entrouTutorialEvidencias;
            entrouTutorialControles = data.entrouTutorialControles;
            entrouTutorialIA = data.entrouTutorialIA;
            entrouTutorialRelatorio = data.entrouTutorialRelatorio;
            PrimeiraVezDialogoTransicao = data.PrimeiraVezDialogoTransicao;
        }
        else
        {
            entrouTutorialPensamentos = false;
            entrouTutorialTestemunha = false;
            entrouTutorialEvidencias = false;
            entrouTutorialControles = false;
            entrouTutorialIA = false;
            entrouTutorialRelatorio = false;
        }
        DialogoTransicao = false;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DialogoTransicao = true;
            animator.SetBool("CarroGif", true);
            dialogueControl.StartDialogue(dialogoParceiroDetetiveIndoParaDelegacia);
        }
        if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (PrimeiraVezDialogoTransicao)
            {
                DialogoTransicao = true;
                animator.SetBool("CarroGif", true);
                PrimeiraVezDialogoTransicao = false;
                dialogueControl.StartDialogue(dialogoDelegadoExplicando);
            }
            else
            {
                if (Assassino.numeroAssassinoSegundo == 4 || Assassino.numeroAssassinoSegundo == 4)
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
        }
        botaoSim.SetActive(false);
        botaoNao.SetActive(false);
        E = GameObject.Find("E").GetComponent<Text>();
        ActualScene = SceneManager.GetActiveScene().buildIndex;
        if ((SceneManager.GetActiveScene().buildIndex == 1))
        {
            ActualScene = data.actualCrimeScene;
        }
        CrimeScene = ActualScene;
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
                testemunhaTexto.text = "Testemunhas" + "\n" +
                "Testemunhas sao pessoas encontradas na cena do crime, é possivel fazer perguntas para elas sobre o assassinato" + "\n" +
                "A cada pergunta feita, a testemunha, irá contar sua versão do caso, e cabe ao detetive saber se o que ela esta dizendo é verdade ou mentira" + "\n" +
                "Existem 3 possiblidades de respsotas possiveis para cada testemunho" + "\n" +
                "Acreditar: usado quando se tem certeza que o testemunho é verdadeiro" + "\n" +
                "duvidar: usado quando não se pode afirmar nada sobre o testemunho" + "\n" +
                "discordar: usado quando se tem certeza que o testemunho é falso, ao discordar vc terá que provar com alguma evidência do pq o detetive discorda da testemunha" + "\n" +
                "Caso vc acerte a verdade sobre o testemunho, informações extras serao reveladas" + "\n" +
                "As perguntas e respostas serão adicionadas como evidências para o seu caderno" + "\n" +
                "Aperte 'ESC' para fechar este menu.";
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
                testemunhaTexto.text = "Evidencias" + "\n" +
                "Evidencias sao pistas encontradas na cena do crime, elas sao anotados no seu caderno (aperte tab para abrir o caderno)" + "\n" +
                "As evidências possuem informações que te ajudarão a solucionar o caso " + "\n" +
                "Aperte 'ESC' para fechar este menu.";
            }
            else
            {
                testemunhaTexto.text = "Evidências" + "\n" +
                "Evidências são pistas encontradas na cena do crime. Elas são anotadas no seu caderno (aperte 'TAB' para abrir o caderno)." + "\n" +
                "As evidências possuem informações que te ajudarão a solucionar o caso." + "\n" +
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
                testemunhaTexto.text = "Inteligencia Artificial e Progresso" + "\n" +
                "Ao finalizar um caso o assassino repensa os seus métodos" + "\n" +
                "Baseado nos seus acertos e erros ele melhora e aprimora os seus métodos" + "\n" +
                "Ao longo dos 9 casos, o detetive nunca saberá se esta acertando ou errando, somente o assasino terá essas informações" + "\n" +
                "Mas todo assassino mantem um certo padrão de coisas que eles fazem por querer e coisas que eles evitam" + "\n" +
                "Tome cuidado, o assassino pode ser qualquer um á sua volta" + "\n" +
                "E ao final do nono caso, o detetive, sabendo dos casos resolvidos por ele anteriormente, deve descobrir quem é o assassino" + "\n" +
                "Aperte 'ESC' para fechar este menu.";
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
                testemunhaTexto.text = "Controles" + "\n" +
                "Para se movimentar use 'W''A''S''D' ou as setas do teclado." + "\n" +
                "Para interagir com objetos pressione 'E'." + "\n" +
                "Para avançar nos diálogos pressione 'E'." + "\n" +
                "Para fechar e abrir o caderno pressione 'TAB'." + "\n" +
                "Para Abrir menu de pause pressione  'ESC' " + "\n" +
                "Aperte 'ESC' para fechar este menu.";
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
                testemunhaTexto.text = "Pensamentos" + "\n" +
                "Aqui é onde o detetive junta duas evidências já encontradas para gerar uma teoria" + "\n" +
                "Tenha em mente que so faz sentido criar uma teoria nova, que nao seja possivel encontrar na cena do crime" + "\n" +
                "A teoria nova se torna um pensamento que o detetive teve" + "\n" +
                "Exemplo: alguem ter sido convidado a entrar" + "\n" +
                "os pensamentos serão sempre algo imaterial, que não é possivel encontrar no local fisico da cena do crime" + "\n" +
                "Aperte 'ESC' para fechar este menu.";
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
                testemunhaTexto.text = "Relatorio" + "\n" +
                "Ao final de cada caso o detetive precisa colocar suas teorias no papel" + "\n" +
                "O relatorio é como o caso é explicado pelo jogador, sendo compostor por 5 perguntas" + "\n" +
                "Como o assassino entrou?" + "\n" +
                "Onde o assassino matou á vítima?" + "\n" +
                "Qual a arma do crime?" + "\n" +
                "Por onde o assassino saiu?" + "\n" +
                "Motivo do assassinato?" + "\n" +
                "Essas perguntas são respondidas com as evidências encontradas na cena do crime, exceto o motivo" + "\n" +
                "Os motivos possiveis são dividios em 6 tipos" + "\n" +
                "Roubo: o assassino entrou no local para roubar e sem querer matou a vítima" + "\n" +
                "Raiva: o assassino em um momento de fúria, não planejada, acabou matando a vítima " + "\n" +
                "Justiça: quando o assassino, de forma previamente planejada e imparcial, matou á vítima, julgando-a ser culpada por algo" + "\n" +
                "Vingança: quando o assassino, de forma previamente planejada e pessoal, matou á vítima, julgando-a ser culpada por algo" + "\n" +
                "Prazer: quando o assassino matou á vítima de forma torturante para um prazer próprio" + "\n" +
                "Suicídio: não houve nenhum assassino" + "\n" +
                "Completando o relátorio o caso é encerrado e o detetive seguirá para um novo caso" + "\n" +
                "Aperte 'ESC' para fechar este menu.";
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
    public void DelegadoInicialElogio()
    {
        dialogoDelegadoExplicando.sentences[0] = "Obrigado pela carona, detetive.";
        dialogoDelegadoExplicando.sentences[1] = "troca paisagem";
        dialogoDelegadoExplicando.sentences[2] = "Não tem problemas senhor.";
        dialogoDelegadoExplicando.sentences[3] = "troca paisagem";
        dialogoDelegadoExplicando.sentences[4] = "Você tem feito um bom trabalho, o pessoal na delegacia tem gostado do seu trabalho.";
        dialogoDelegadoExplicando.sentences[5] = "troca embara";
        dialogoDelegadoExplicando.sentences[6] = "Oobrigado, só tenho feito o meu trabalho.";
        dialogoDelegadoExplicando.sentences[7] = "detetive paisagem";
        dialogoDelegadoExplicando.sentences[8] = "Fico feliz que o pessoal esteja gostando.";
        dialogoDelegadoExplicando.sentences[9] = "troca paisagem";
        dialogoDelegadoExplicando.sentences[10] = "Continue assim.";
        dialogoDelegadoExplicando.sentences[11] = "finalizar";

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
    public void DelegadoInicialCritica()
    {
        dialogoDelegadoExplicando.sentences[0] = "We need to talk detective.";
        dialogoDelegadoExplicando.sentences[1] = "troca paisagem";
        dialogoDelegadoExplicando.sentences[2] = "Some problem sir.";
        dialogoDelegadoExplicando.sentences[3] = "troca paisagem";
        dialogoDelegadoExplicando.sentences[4] = "You have not done a good job, the people at the police station have not been very fond of your work.";
        dialogoDelegadoExplicando.sentences[5] = "troca embara";
        dialogoDelegadoExplicando.sentences[6] = "I'm sorry, delegate, I've only been doing my job.";
        dialogoDelegadoExplicando.sentences[7] = "detetive paisagem";
        dialogoDelegadoExplicando.sentences[8] = "I will try to improve.";
        dialogoDelegadoExplicando.sentences[9] = "troca paisagem";
        dialogoDelegadoExplicando.sentences[10] = "I hope so.";
        dialogoDelegadoExplicando.sentences[11] = "finalizar";

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
                    dialogueControl.DisplayNextSentence(dialogoParceiroDetetiveIndoParaDelegacia);
                }
                if (SceneManager.GetActiveScene().buildIndex != 1 && SceneManager.GetActiveScene().buildIndex != 0)
                {
                    dialogueControl.DisplayNextSentence(dialogoDelegadoExplicando);
                }
            }
        }
        if (movimento.comecaDialogoFinal)
        {
            if (startaFinal)
            {
                switch (nomeDaPessoaNoFinal)
                {
                    case "parceiro":
                        diaologoFinalParceiroFuncao();
                        break;
                    case "saneguji":
                        break;
                    case "devi":
                        break;
                    case "policial":
                        break;
                }
                startaFinal = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogueControlFinal.DisplayNextSentence(diaologoFinalParceiro);
                    if (Analise.terminouConversa == true)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
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
    public void diaologoFinalParceiroFuncao()
    {
        if (!MainMenu.PrimeiroCaso)
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
        MainMenu.PrimeiroCaso = false;
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