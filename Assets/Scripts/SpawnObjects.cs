using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnObjects : MonoBehaviour
{
    public static bool SexoMasculino;
    public static int NumeroDeportas = 0;
    public static int selecionaArmaComSangueFalso;
    static bool entrouNoTexto = false;
    public Animator animator;
    public Caderno caderno;
    public static string[] NomeDosObjetos = new string[40];
    public static int NumeroDeObjetos;
    public GameObject PanoBranco;
    public Evidence PanoBrancoEvidence;
    public GameObject CartaoAlcool;
    public Evidence CartaoAlcoolEvidence;
    public GameObject CartaoPolicia;
    public Evidence CartaoPoliciaEvidence;
    public GameObject CartaoFilme;
    public Evidence CartaoFilmeEvidence;
    public GameObject Relogio;
    public Evidence RelogioEvidence;
    public GameObject Pano;
    public Evidence PanoEvidence;
    public GameObject Convite;
    public Evidence ConviteEvidence;
    public GameObject CanoContundente;
    public Evidence CanoContundenteEvidence;
    public GameObject CanoContundenteSangue;
    public Evidence CanoContundenteSangueEvidence;
    public GameObject CanoPerfuração;
    public Evidence CanoPerfuraçãoEvidence;
    public GameObject CanoPerfuraçãoSangue;
    public Evidence CanoPerfuraçãoSangueEvidence;
    public GameObject Sufocamento;
    public Evidence SufocamentoEvidence;
    public GameObject Punhos;
    public Evidence PunhosEvidence;
    public GameObject Destrocos;
    public Evidence DestrocosEvidence;
    public GameObject ManchaSangue;
    public Evidence ManchaSangueEvidence;
    public GameObject ManchaSangueTortura;
    public Evidence ManchaSangueTorturaEvidence;
    public GameObject Revolver;
    public Evidence RevolverEvidence;
    public GameObject PortaDeSaida;
    public Evidence PortaDeSaidaEvidence;
    public GameObject Imagem;
    public Evidence ImagemEvidence;
    public GameObject CofreFechado;
    public Evidence CofreFechadoEvidence;
    public GameObject CofreVazio;
    public Evidence CofreVazioEvidence;
    public GameObject CofreDinheiro;
    public Evidence CofreDinheiroEvidence;
    public GameObject Celular;
    public Evidence CelularEvidence;
    public GameObject Camera;
    public Evidence CameraEvidence;
    public GameObject CaixaDeRemedio;
    public Evidence CaixaDeRemedioEvidence;
    public GameObject BastaoDeBeisebolSangue;
    public Evidence BastaoDeBeisebolSangueEvidence;
    public GameObject BastaoDeBeisebol;
    public Evidence BastaoDeBeisebolEvidence;
    public GameObject Bala;
    public Evidence BalaEvidence;
    public GameObject Testemunha;
    public Evidence TestemunhaEvidence;
    public GameObject Policial;
    public Evidence PolicialEvidence;
    public GameObject Laudo;
    public Evidence LaudoEvidence;
    public GameObject Prato;
    public Evidence PratoEvidence;
    public GameObject FacaNormal;
    public Evidence FacaNormalEvidence;
    public GameObject FacaNormalSemSangue;
    public Evidence FacaNormalSemSangueEvidence;
    public GameObject JanelaQuebradaPedraExterior;
    public Evidence JanelaQuebradaPedraExteriorEvidence;
    public GameObject JanelaQuebradaPedraInterior;
    public Evidence JanelaQuebradaPedraInteriorEvidence;
    public GameObject FacaCozinha;
    public Evidence FacaCozinhaEvidence;
    public GameObject CorpoMorto3;
    public Evidence CorpoMorto3Evidence;
    public Evidence CorpoMorto4Evidence;
    public GameObject CorpoMorto4;
    public GameObject CorpoMorto1;
    public Evidence CorpoMorto1Evidence;
    public Evidence CorpoMorto2Evidence;
    public GameObject CorpoMorto2;
    public GameObject CorpoMorto3M;
    public Evidence CorpoMorto3MEvidence;
    public Evidence CorpoMorto4FEvidence;
    public GameObject CorpoMorto4F;
    public GameObject CorpoMorto1F;
    public Evidence CorpoMorto1FEvidence;
    public Evidence CorpoMorto2FEvidence;
    public GameObject CorpoMorto2F;
    public GameObject BilheteCulposo;
    public Evidence BilheteCulposoEvidence;
    public Text dialogueText;
    private static Evidence[] Armas;
    private static Evidence[] Corpos;
    private static Evidence[] CorposDisponiveis;
    private static bool SpawnCofre;
    private static bool TemPorta;
    private static bool TemJanela;
    private static bool JanelaQuebrada;
    public static bool PrecisaDeAuxilioEntradaSaida;
    public static bool PortaQuebrada;
    public static bool PortaArrombadaDentro;
    private static bool FoiConvidado;
    private static bool PedraInteriorJanela;
    private static bool TemConvite;
    private static int QuantidadeCorposDisponiveis;
    public static bool depoimentoTestemunhaVisto;
    public static bool depoimentoTestemunhaOuviu;
    public static string policialUpdateSalvar;
    public static string policialSalvar;
    public static string PrimeiraRespostaFinal;
    public static string SegundaRespostaFinal;
    public static string TerceiraRespostaFinal;
    public static string PrimeiraResposta;
    public static string SegundaResposta;
    public static string TerceiraResposta;
    public static string QuartaResposta;
    public static string QuintaResposta;
    public static string PrimeiraRespostaInglesFinal;
    public static string SegundaRespostaInglesFinal;
    public static string TerceiraRespostaInglesFinal;
    public static string PrimeiraRespostaIngles;
    public static string SegundaRespostaIngles;
    public static string TerceiraRespostaIngles;
    public static string QuartaRespostaIngles;
    public static string VistoVerdade;
    public static string OuviuVerdade;
    public static bool weaponInstantDeath;
    public static bool TemPlanejamento;
    public static bool NTemPlanejamento;
    public static bool Raiva;
    public static bool Justica;
    public static bool Tortura;
    public static bool Vinganca;
    public static bool Roubo;
    public static bool ContinuaNoLoop;
    public static bool ajudaEntrada;
    public static bool ajudaSaida;
    private static Vector3 PosicaoCorpoMorto;
    public static int RuidoArmaDoCrime;
    private int i = 0;
    private int j = 0;
    public int PortaDaCena = 0;
    public static int idadePersonagem = 0;
    /*static private float selecionador = 0;*/
    static private int selecionadorint = 0;
    static private int numeroSelecionadoParaResposta = 0;
    private int NumeroArmas;
    public static int contador;
    public static bool PanoSangue;
    public static int intProximoCaso;
    public static int numeroAssassino;
    public static int numeroAssassinoSegundo;
    public static int numeroAssassinoTerceiro;
    public static int numeroMotivoVitimaComum;
    private int sangueOriginal;
    private int numeroDoForLocal = 0;
    // Start is called before the first frame update
    void Start()
    {
        PanoSangue = false;
        PlayerData.DificuldadeAtual = 0;
        NumeroDeObjetos = 0;
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            NumeroDeportas = carregaNumeroDePortas();
            PortaDaCena = carregaPortaDaCena();
        }
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            if (IA.taxaDeAcertos >= 0.8 && PauseMenu.NumeroDeCasosJogadoPeloPlayer >= 5)
            {
                switch (numeroAssassino)
                {
                    case 0:
                        if (Random.value > 0.5f)
                        {
                            InstantiateCartaoPolicia();
                        }
                        else
                        {
                            InstantiateCartaoFilme();
                        }
                        break;
                    case 1:
                        if (Random.value > 0.5f)
                        {
                            InstantiateCartaoPolicia();
                        }
                        else
                        {
                            InstantiateCartaoFilme();
                        }
                        break;
                    case 2:
                        if (Random.value > 0.5f)
                        {
                            InstantiateCartaoAlcool();
                        }
                        else
                        {
                            InstantiatePanoBranco();
                        }
                        break;
                    case 3:
                        if (Random.value > 0.5f)
                        {
                            InstantiatePanoBranco();
                        }
                        else
                        {
                            InstantiateCartaoFilme();
                        }
                        break;
                    case 4:
                        if (Random.value > 0.5f)
                        {
                            InstantiateRelogio();
                        }
                        else
                        {
                            InstantiateCartaoPolicia();
                        }
                        break;
                    case 5:
                        if (Random.value > 0.5f)
                        {
                            InstantiateCartaoFilme();
                        }
                        else
                        {
                            InstantiateCartaoAlcool();
                        }
                        break;
                    case 6:
                        if (Random.value > 0.5f)
                        {
                            InstantiateRelogio();
                        }
                        else
                        {
                            InstantiatePanoBranco();
                        }
                        break;
                }
            }
            if (MainMenu.NewGame == false)
            {
                PlayerData data = SaveSystem.LoadPlayer();
                SexoMasculino = data.sexoAtual;
                idadePersonagem = data.idadePersonagem;
                RuidoArmaDoCrime = data.RuidoArmaDoCrime;
                numeroAssassino = data.numeroAssassino;
                numeroAssassinoSegundo = data.numeroAssassinoSegundo;
                numeroAssassinoTerceiro = data.numeroAssassinoTerceiro;
                numeroMotivoVitimaComum = data.numeroMotivoVitimaComum;
                selecionaArmaComSangueFalso = data.selecionaArmaComSangueFalso;
                ColocaSangueFalso();
                contador = data.contadorAnalise;
                PanoSangue = data.PanoSangue;
                policialSalvar = data.policial;
                policialUpdateSalvar = data.policialUpdate;
                PrecisaDeAuxilioEntradaSaida = data.PrecisaDeAuxilioEntradaSaida;
                ajudaEntrada = data.ajudaEntrada;
                ajudaSaida = data.ajudaSaida;
                PortaQuebrada = data.PortaQuebrada;
                LoadRespostas(data);
                for (i = 0; i < data.NumeroDeObjetos; i++)
                {
                    LoadPlayer(data, i);
                }
                for (i = 0; i < NumeroDeportas; i++)
                {
                    if (SceneManager.GetActiveScene().buildIndex != 1)
                    {
                        GameObject.Find("Porta" + (i + PortaDaCena)).GetComponent<PortaController>().isOpen = data.isOpen[i + PortaDaCena];
                    }
                }
            }
            else
            {
                InstantiateTestemunha();
                if (!MainMenu.PrimeiroCaso)
                {
                    idadePersonagem = IdadeSet();
                    contador = 3;
                    intProximoCaso = IA.geraProximoCaso();
                    if (intProximoCaso == -1)
                    {
                        if (SceneManager.GetActiveScene().buildIndex == 3)
                        {
                            InstantiatePortaSaida();
                        }
                        for (i = 0; i < 4; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    SelecionaArma();
                                    break;
                                case 1:
                                    SelecionaLocal();
                                    break;
                                case 2:
                                    SelecionaEntradaSaida();
                                    break;
                                case 3:
                                    SelecionaMotivo();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        for (i = 0; i < 5; i++)
                        {
                            if (IA.gabaritoMotivo[intProximoCaso % 3, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        QuintaResposta = "Roubo";
                                        break;
                                    case 1:
                                        QuintaResposta = "Prazer";
                                        break;
                                    case 2:
                                        QuintaResposta = "Desavenca";
                                        break;
                                    case 3:
                                        QuintaResposta = "Justica";
                                        break;
                                    case 4:
                                        QuintaResposta = "Raiva";
                                        break;
                                }
                            }
                        }
                        for (i = 0; i < 81; i++)
                        {
                            if (IA.gabaritoArma[intProximoCaso % 3, i] == 1)
                            {
                                switch (i)
                                {
                                    case 0:
                                        sangueOriginal = 0;
                                        TerceiraResposta = BastaoDeBeisebolEvidence.nome;
                                        TerceiraRespostaIngles = BastaoDeBeisebolEvidence.nomeIngles;
                                        break;
                                    case 1:
                                        sangueOriginal = 1;
                                        TerceiraResposta = BastaoDeBeisebolSangueEvidence.nome;
                                        TerceiraRespostaIngles = BastaoDeBeisebolSangueEvidence.nomeIngles;
                                        break;
                                    case 2:
                                        sangueOriginal = 2;
                                        TerceiraResposta = CaixaDeRemedioEvidence.nome;
                                        TerceiraRespostaIngles = CaixaDeRemedioEvidence.nomeIngles;
                                        break;
                                    case 3:
                                        sangueOriginal = 3;
                                        TerceiraResposta = FacaCozinhaEvidence.nome;
                                        TerceiraRespostaIngles = FacaCozinhaEvidence.nomeIngles;
                                        break;
                                    case 4:
                                        sangueOriginal = 4;
                                        TerceiraResposta = FacaNormalSemSangueEvidence.nome;
                                        TerceiraRespostaIngles = FacaNormalSemSangueEvidence.nomeIngles;
                                        break;
                                    case 5:
                                        sangueOriginal = 5;
                                        TerceiraResposta = FacaNormalEvidence.nome;
                                        TerceiraRespostaIngles = FacaNormalEvidence.nomeIngles;
                                        break;
                                    case 6:
                                        sangueOriginal = 6;
                                        TerceiraResposta = PunhosEvidence.nome;
                                        TerceiraRespostaIngles = PunhosEvidence.nomeIngles;
                                        break;
                                    case 7:
                                        sangueOriginal = 7;
                                        TerceiraResposta = RevolverEvidence.nome;
                                        TerceiraRespostaIngles = RevolverEvidence.nomeIngles;
                                        break;
                                    case 8:
                                        sangueOriginal = 8;
                                        TerceiraResposta = RevolverEvidence.nome;
                                        TerceiraRespostaIngles = RevolverEvidence.nomeIngles;
                                        break;
                                    case 9:
                                        sangueOriginal = 9;
                                        TerceiraResposta = CanoPerfuraçãoEvidence.nome;
                                        TerceiraRespostaIngles = CanoPerfuraçãoEvidence.nomeIngles;
                                        break;
                                    case 10:
                                        sangueOriginal = 10;
                                        TerceiraResposta = SufocamentoEvidence.nome;
                                        TerceiraRespostaIngles = SufocamentoEvidence.nomeIngles;
                                        break;
                                    case 11:
                                        sangueOriginal = 11;
                                        TerceiraResposta = CanoPerfuraçãoSangueEvidence.nome;
                                        TerceiraRespostaIngles = CanoPerfuraçãoSangueEvidence.nomeIngles;
                                        break;
                                    case 12:
                                        sangueOriginal = 12;
                                        TerceiraResposta = CanoContundenteEvidence.nome;
                                        TerceiraRespostaIngles = CanoContundenteEvidence.nomeIngles;
                                        break;
                                    case 13:
                                        sangueOriginal = 13;
                                        TerceiraResposta = CanoContundenteSangueEvidence.nome;
                                        TerceiraRespostaIngles = CanoContundenteSangueEvidence.nomeIngles;
                                        break;
                                }
                            }
                            if (IA.gabaritoLocal[intProximoCaso % 3, i] == 1)
                            {
                                switch (i)
                                {
                                    case 43:
                                        SegundaResposta = CorpoMorto1Evidence.nome;
                                        SegundaRespostaIngles = CorpoMorto1Evidence.nomeIngles;
                                        break;
                                    case 44:
                                        SegundaResposta = CorpoMorto2Evidence.nome;
                                        SegundaRespostaIngles = CorpoMorto2Evidence.nomeIngles;
                                        break;
                                    case 45:
                                        SegundaResposta = CorpoMorto3Evidence.nome;
                                        SegundaRespostaIngles = CorpoMorto3Evidence.nomeIngles;
                                        break;
                                    case 46:
                                        SegundaResposta = CorpoMorto4Evidence.nome;
                                        SegundaRespostaIngles = CorpoMorto4Evidence.nomeIngles;
                                        break;
                                    case 58:
                                        SegundaResposta = ManchaSangueEvidence.nome;
                                        SegundaRespostaIngles = ManchaSangueEvidence.nomeIngles;
                                        break;
                                }
                            }
                            if (IA.gabaritoEntrada[intProximoCaso % 3, i] == 1)
                            {
                                switch (i)
                                {
                                    case 29:
                                        PrimeiraResposta = ConviteEvidence.nome;
                                        PrimeiraRespostaIngles = ConviteEvidence.nomeIngles;
                                        break;
                                    case 34:
                                        PrimeiraResposta = PolicialEvidence.nome;
                                        PrimeiraRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 35:
                                        PrimeiraResposta = PolicialEvidence.nome;
                                        PrimeiraRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 36:
                                        PrimeiraResposta = PolicialEvidence.nome;
                                        PrimeiraRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 37:
                                        PrimeiraResposta = PolicialEvidence.nome;
                                        PrimeiraRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 39:
                                        PrimeiraResposta = PortaDeSaidaEvidence.nome;
                                        PrimeiraRespostaIngles = PortaDeSaidaEvidence.nomeIngles;
                                        break;
                                    case 40:
                                        PrimeiraResposta = CelularEvidence.nome;
                                        PrimeiraRespostaIngles = CelularEvidence.nomeIngles;
                                        break;
                                    case 41:
                                        PrimeiraResposta = CelularEvidence.nome;
                                        PrimeiraRespostaIngles = CelularEvidence.nomeIngles;
                                        break;
                                    case 42:
                                        PrimeiraResposta = CelularEvidence.nome;
                                        PrimeiraRespostaIngles = CelularEvidence.nomeIngles;
                                        break;
                                    case 79:
                                        PrimeiraResposta = JanelaQuebradaPedraInteriorEvidence.nome;
                                        PrimeiraRespostaIngles = JanelaQuebradaPedraInteriorEvidence.nomeIngles;
                                        break;
                                    case 80:
                                        PrimeiraResposta = JanelaQuebradaPedraExteriorEvidence.nome;
                                        PrimeiraRespostaIngles = JanelaQuebradaPedraExteriorEvidence.nomeIngles;
                                        break;
                                }
                            }
                            if (IA.gabaritoSaida[intProximoCaso % 3, i] == 1)
                            {
                                switch (i)
                                {
                                    case 29:
                                        QuartaResposta = ConviteEvidence.nome;
                                        QuartaRespostaIngles = ConviteEvidence.nomeIngles;
                                        break;
                                    case 34:
                                        QuartaResposta = PolicialEvidence.nome;
                                        QuartaRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 35:
                                        QuartaResposta = PolicialEvidence.nome;
                                        QuartaRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 36:
                                        QuartaResposta = PolicialEvidence.nome;
                                        QuartaRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 37:
                                        QuartaResposta = PolicialEvidence.nome;
                                        QuartaRespostaIngles = PolicialEvidence.nomeIngles;
                                        break;
                                    case 39:
                                        QuartaResposta = PortaDeSaidaEvidence.nome;
                                        QuartaRespostaIngles = PortaDeSaidaEvidence.nomeIngles;
                                        break;
                                    case 40:
                                        QuartaResposta = CelularEvidence.nome;
                                        QuartaRespostaIngles = CelularEvidence.nomeIngles;
                                        break;
                                    case 41:
                                        QuartaResposta = CelularEvidence.nome;
                                        QuartaRespostaIngles = CelularEvidence.nomeIngles;
                                        break;
                                    case 42:
                                        QuartaResposta = CelularEvidence.nome;
                                        QuartaRespostaIngles = CelularEvidence.nomeIngles;
                                        break;
                                    case 79:
                                        QuartaResposta = JanelaQuebradaPedraInteriorEvidence.nome;
                                        QuartaRespostaIngles = JanelaQuebradaPedraInteriorEvidence.nomeIngles;
                                        break;
                                    case 80:
                                        QuartaResposta = JanelaQuebradaPedraExteriorEvidence.nome;
                                        QuartaRespostaIngles = JanelaQuebradaPedraExteriorEvidence.nomeIngles;
                                        break;
                                }
                            }
                            depoimentoTestemunhaOuviu = false;
                            if (Random.value > 0.5f)
                            {
                                depoimentoTestemunhaOuviu = true;
                            }
                            if (IA.evidencias[intProximoCaso, i] == 1)
                            {
                                GeraCasoIA(i);
                            }
                            ColocaSangueFalso();
                            GeraTestemunho();
                        }
                    }
                }
                else
                {
                    numeroMotivoVitimaComum = Assassino.numeroMotivoVitimaComum;
                    numeroAssassino = Assassino.numeroAssassino;
                    numeroAssassinoSegundo = Assassino.numeroAssassinoSegundo;
                    numeroAssassinoTerceiro = Assassino.numeroAssassinoTerceiro;
                    idadePersonagem = IdadeSet();
                    contador = 3;
                    if (SceneManager.GetActiveScene().buildIndex == 3)
                    {
                        InstantiatePortaSaida();
                    }
                    for (i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                SelecionaArma();
                                break;
                            case 1:
                                SelecionaLocal();
                                break;
                            case 2:
                                SelecionaEntradaSaida();
                                break;
                            case 3:
                                SelecionaMotivo();
                                break;
                        }
                    }
                }
            }
        }
        else
        {
            InstantiateBilheteCulposo();
            InstantiateCorpoMorto2();
            InstantiateCorpoMorto1();
            InstantiateCorpoMorto3();
            InstantiateCorpoMorto4();
            InstantiateCofreDinheiro();
            InstantiateCofreFechado();
            InstantiateCofreVazio();
            InstantiateFacaCozinha();
            InstantiateFacaNormalSemSangue();
            InstantiateFacaNormal();
            InstantiateJanelaQuebradaPedraInterior();
            InstantiateJanelaQuebradaPedraExterior();
            InstantiatePratos();
            InstantiateLaudo();
            InstantiatePolicial();
            InstantiateTestemunha();
            InstantiateBastao();
            InstantiateBastaoSangue();
            InstantiateRevolver();
            InstantiateCaixaRemedio();
            InstantiateCelular();
            InstantiateManchaSangue();
            InstantiateManchaSangueTortura();
            InstantiateCofreDinheiroHonesto();
            InstantiatePortaSaida();
            InstantiateDestrocos();
            InstantiatePunhos();
            InstantiateConvite();
            InstantiateCanocontundente();
            InstantiateCanoContundenteSangue();
            InstantiateSufocamento();
            InstantiatePano();
            InstantiateCanoPerfuracaoSangue();
            InstantiateCanoperfuracao();
            InstantiateCorpoMorto2F();
            InstantiateCorpoMorto1F();
            InstantiateCorpoMorto3M();
            InstantiateCorpoMorto4F();
        }
    }
    public int IdadeSet()
    {
        if (numeroAssassino == 1 || numeroAssassino == 3)
        {
            return Random.Range(0, 7) * 3 + 36; /* 36 ATÉ 54 */
        }
        if (numeroAssassino == 4)
        {
            return Random.Range(0, 6) * 3 + 18; /* 18 ATÉ 36*/
        }
        if (numeroMotivoVitimaComum == 3)
        {
            return Random.Range(0, 4) * 3 + 36; /* 45 ATÉ 54 */
        }
        if (numeroMotivoVitimaComum == 2)
        {
            return Random.Range(0, 4) * 3 + 18; /* 18 ATÉ 27*/
        }
        return Random.Range(0, 13) * 3 + 18;
    }
    public void GeraTestemunho()
    {
        if (Random.value > 0.5f)
        {
            depoimentoTestemunhaVisto = true;
        }
        else
        {
            depoimentoTestemunhaVisto = false;
        }
        /*1*/
        if (PedraInteriorJanela && PortaArrombadaDentro && depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }
        /*2*/
        if (PedraInteriorJanela && !PortaArrombadaDentro && !depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }
        /*3*/
        if (!PedraInteriorJanela && !PortaArrombadaDentro && depoimentoTestemunhaVisto)
        {
            VistoVerdade = "false";
        }
        /*4*/
        if (!PedraInteriorJanela && PortaArrombadaDentro && !depoimentoTestemunhaVisto)
        {
            VistoVerdade = "true";
        }
        /*5*/
        if (PedraInteriorJanela && !PortaArrombadaDentro && depoimentoTestemunhaVisto)
        {
            VistoVerdade = "true";
        }
        /*6*/
        if (PedraInteriorJanela && PortaArrombadaDentro && !depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }
        /*7*/
        if (!PedraInteriorJanela && PortaArrombadaDentro && depoimentoTestemunhaVisto)
        {
            VistoVerdade = "false";
        }
        /*8*/
        if (!PedraInteriorJanela && !PortaArrombadaDentro && !depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }

        if (PedraInteriorJanela && !PortaQuebrada && depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }
        if (PedraInteriorJanela && !PortaQuebrada && !depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }
        if (!PedraInteriorJanela && !PortaQuebrada && depoimentoTestemunhaVisto)
        {
            VistoVerdade = "false";
        }
        if (!PedraInteriorJanela && !PortaQuebrada && !depoimentoTestemunhaVisto)
        {
            VistoVerdade = "duvida";
        }
    }
    public void GeraCasoIA(int i)
    {
        switch (i)
        {
            case 0:
                if (sangueOriginal != 0)
                {
                    selecionaArmaComSangueFalso = 0;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                RuidoArmaDoCrime = 1;
                InstantiateBastao();
                break;
            case 1:
                if (sangueOriginal != 1)
                {
                    selecionaArmaComSangueFalso = 1;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                RuidoArmaDoCrime = 1;
                InstantiateBastaoSangue();
                break;
            case 2:
                RuidoArmaDoCrime = 0;
                if (sangueOriginal != 2)
                {
                    selecionaArmaComSangueFalso = 2;
                }
                if (Armas[selecionadorint].weaponRuido == 0 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                if (Armas[selecionadorint].weaponRuido == 0 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                InstantiateCaixaRemedio();
                break;
            case 3:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 3)
                {
                    selecionaArmaComSangueFalso = 3;
                }
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                InstantiateFacaCozinha();
                break;
            case 4:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 4)
                {
                    selecionaArmaComSangueFalso = 4;
                }
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                InstantiateFacaNormalSemSangue();
                break;
            case 5:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 5)
                {
                    selecionaArmaComSangueFalso = 5;
                }
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                InstantiateFacaNormal();
                break;
            case 6:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 6)
                {
                    selecionaArmaComSangueFalso = 6;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                InstantiatePunhos();
                break;
            case 7:
                RuidoArmaDoCrime = 2;
                if (sangueOriginal != 7)
                {
                    selecionaArmaComSangueFalso = 7;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                InstantiateRevolver();
                break;
            case 8:
                RuidoArmaDoCrime = 2;
                if (sangueOriginal != 8)
                {
                    selecionaArmaComSangueFalso = 8;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                InstantiateRevolver();
                break;
            case 9:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 9)
                {
                    selecionaArmaComSangueFalso = 9;
                }
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                InstantiateCanoperfuracao();
                break;
            case 10:
                RuidoArmaDoCrime = 0;
                if (sangueOriginal != 10)
                {
                    selecionaArmaComSangueFalso = 10;
                }
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                InstantiateSufocamento();
                break;
            case 11:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 11)
                {
                    selecionaArmaComSangueFalso = 11;
                }
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                InstantiateCanoPerfuracaoSangue();
                break;
            case 12:
                RuidoArmaDoCrime = 1;
                if (sangueOriginal != 12)
                {
                    selecionaArmaComSangueFalso = 12;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                InstantiateCanocontundente();
                break;
            case 13:
                if (sangueOriginal != 13)
                {
                    selecionaArmaComSangueFalso = 13;
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                InstantiateCanoContundenteSangue();
                break;
            case 28:
                InstantiatePratos();
                break;
            case 29:
                InstantiateConvite();
                break;
            case 34:
                policialSalvar = PolicialEvidence.description;
                policialUpdateSalvar = PolicialEvidence.descriptionUpdate;
                InstantiatePolicial();
                break;
            case 35:
                PortaQuebrada = false;
                if (PlayerData.Idioma == "ingles")
                {
                    PolicialEvidence.description = "No signs of movement and when I got here the door was unlocked.";
                    PolicialEvidence.descriptionUpdate = "No signs of movement and when I got here the door was unlocked.";
                }
                else
                {
                    PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva destrancada.";
                    PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva destrancada.";
                }
                policialSalvar = PolicialEvidence.description;
                policialUpdateSalvar = PolicialEvidence.descriptionUpdate;
                InstantiatePolicial();
                break;
            case 36:
                PortaArrombadaDentro = true;
                PortaQuebrada = true;
                if (PlayerData.Idioma == "ingles")
                {
                    PolicialEvidence.description = "No signs of movement and when I got here the door was broken.";
                    PolicialEvidence.descriptionUpdate = "No signs of movement and when I got here the door was broken. From the inside.";
                }
                else
                {
                    PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada.";
                    PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada. De fora para dentro.";
                }
                policialSalvar = PolicialEvidence.description;
                policialUpdateSalvar = PolicialEvidence.descriptionUpdate;
                InstantiatePolicial();
                break;
            case 37:
                PortaArrombadaDentro = false;
                PortaQuebrada = true;
                if (PlayerData.Idioma == "ingles")
                {
                    PolicialEvidence.description = "No signs of movement and when I got here the door was broken.";
                    PolicialEvidence.descriptionUpdate = "No signs of movement and when I got here the door was broken. From the outside.";
                }
                else
                {
                    PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada.";
                    PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada. De dentro para fora.";
                }
                policialSalvar = PolicialEvidence.description;
                policialUpdateSalvar = PolicialEvidence.descriptionUpdate;
                InstantiatePolicial();
                break;
            case 39:
                InstantiatePortaSaida();
                break;
            case 40:
                ajudaEntrada = true;
                PortaQuebrada = false;
                PrecisaDeAuxilioEntradaSaida = true;
                if (PlayerData.Idioma == "ingles")
                {
                    CelularEvidence.descriptionIngles = "Cell phone belonging to the victim.";
                    CelularEvidence.descriptionUpdateIngles = "Cell phone belonging to the victim. Message saved on the phone 'Agreed! I'll be waiting for you here, see you later.', unidentified number.";
                }
                else
                {
                    CelularEvidence.description = "Celular pertencente à vítima.";
                    CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Mensagem salva no celular 'Combinado! estárei te aguardando aqui em casa, até mais tarde.', mensagem enviada para um numero anônimo.";
                }
                InstantiateCelular();
                break;
            case 41:
                ajudaEntrada = true;
                PrecisaDeAuxilioEntradaSaida = true;
                PortaQuebrada = true;
                if (PlayerData.Idioma == "ingles")
                {
                    CelularEvidence.descriptionIngles = "Cell phone belonging to the victim.";
                    CelularEvidence.descriptionUpdateIngles = "Cell phone belonging to the victim. Note found on the phone 'To buy materials to fix the hinge'";
                }
                else
                {
                    CelularEvidence.description = "Celular pertencente à vítima.";
                    CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Anotação encontrada no celular 'Comprar materiais para consertar a dobradiça da porta'";
                }
                InstantiateCelular();
                break;
            case 42:
                ajudaSaida = true;
                PrecisaDeAuxilioEntradaSaida = true;
                if (PlayerData.Idioma == "ingles")
                {
                    CelularEvidence.descriptionIngles = "Cell phone belonging to the victim.";
                    CelularEvidence.descriptionUpdateIngles = "Cell phone belonging to the victim. Phone's schedule doesn't show anything set for today.";
                }
                else
                {
                    CelularEvidence.description = "Celular pertencente à vítima.";
                    CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Agenda do celular não mostra nada marcado na data de hoje.";
                }
                InstantiateCelular();
                break;
            case 43:
                if (Random.value > 0.5f)
                {
                    if (SpawnObjects.numeroAssassino == 0 || SpawnObjects.numeroAssassino == 5)
                    {
                        InstantiateCorpoMorto1();
                    }
                    else
                    {
                        if (numeroMotivoVitimaComum == 1)
                        {
                            if (Random.value > 0.5f)
                            {
                                InstantiateCorpoMorto1F();
                            }
                            else
                            {
                                if (SpawnObjects.numeroAssassino != 2)
                                {
                                    InstantiateCorpoMorto1();
                                }
                                else
                                {
                                    InstantiateCorpoMorto1F();
                                }
                            }
                        }
                        else
                        {
                            InstantiateCorpoMorto1F();
                        }
                    }
                }
                else
                {
                    if (numeroMotivoVitimaComum == 0)
                    {
                        if (Random.value > 0.5f)
                        {
                            InstantiateCorpoMorto1F();
                        }
                        else
                        {
                            if (SpawnObjects.numeroAssassino != 2)
                            {
                                InstantiateCorpoMorto1();
                            }
                            else
                            {
                                InstantiateCorpoMorto1F();
                            }
                        }
                    }
                    else
                    {
                        if (SpawnObjects.numeroAssassino != 2)
                        {
                            InstantiateCorpoMorto1();
                        }
                        else
                        {
                            InstantiateCorpoMorto1F();
                        }
                    }
                }
                break;
            case 44:
                if (Random.value > 0.5f)
                {
                    if (SpawnObjects.numeroAssassino == 0 || SpawnObjects.numeroAssassino == 5)
                    {
                        InstantiateCorpoMorto2();
                    }
                    else
                    {
                        if (numeroMotivoVitimaComum == 1)
                        {
                            if (Random.value > 0.5f)
                            {
                                InstantiateCorpoMorto2F();
                            }
                            else
                            {
                                if (SpawnObjects.numeroAssassino != 2)
                                {
                                    InstantiateCorpoMorto2();
                                }
                                else
                                {
                                    InstantiateCorpoMorto2F();
                                }
                            }
                        }
                        else
                        {
                            InstantiateCorpoMorto2F();
                        }
                    }
                }
                else
                {
                    if (numeroMotivoVitimaComum == 0)
                    {
                        if (Random.value > 0.5f)
                        {
                            InstantiateCorpoMorto2F();
                        }
                        else
                        {
                            if (SpawnObjects.numeroAssassino != 2)
                            {
                                InstantiateCorpoMorto2();
                            }
                            else
                            {
                                InstantiateCorpoMorto2F();
                            }
                        }
                    }
                    else
                    {
                        if (SpawnObjects.numeroAssassino != 2)
                        {
                            InstantiateCorpoMorto2();
                        }
                        else
                        {
                            InstantiateCorpoMorto2F();
                        }
                    }
                }
                break;
            case 45:
                if (Random.value > 0.5f)
                {
                    if (SpawnObjects.numeroAssassino == 0 || SpawnObjects.numeroAssassino == 5)
                    {
                        InstantiateCorpoMorto3();
                    }
                    else
                    {
                        if (numeroMotivoVitimaComum == 1)
                        {
                            if (Random.value > 0.5f)
                            {
                                if (SpawnObjects.numeroAssassino != 2)
                                {
                                    InstantiateCorpoMorto3();
                                }
                                else
                                {
                                    InstantiateCorpoMorto3M();
                                }
                            }
                            else
                            {
                                InstantiateCorpoMorto3M();
                            }
                        }
                        else
                        {
                            InstantiateCorpoMorto3M();
                        }
                    }
                }
                else
                {
                    if (numeroMotivoVitimaComum == 0)
                    {
                        if (Random.value > 0.5f)
                        {
                            if (SpawnObjects.numeroAssassino != 2)
                            {
                                InstantiateCorpoMorto3();
                            }
                            else
                            {
                                InstantiateCorpoMorto3M();
                            }
                        }
                        else
                        {
                            if (SpawnObjects.numeroAssassino == 0 || SpawnObjects.numeroAssassino == 5)
                            {
                                InstantiateCorpoMorto3();
                            }
                            else
                            {
                                InstantiateCorpoMorto3M();
                            }
                        }
                    }
                    else
                    {
                        if (SpawnObjects.numeroAssassino != 2)
                        {
                            InstantiateCorpoMorto3();
                        }
                        else
                        {
                            InstantiateCorpoMorto3M();
                        }
                    }
                }
                break;
            case 46:
                if (Random.value > 0.5f)
                {
                    if (SpawnObjects.numeroAssassino == 0 || SpawnObjects.numeroAssassino == 5)
                    {
                        InstantiateCorpoMorto4();
                    }
                    else
                    {
                        if (numeroMotivoVitimaComum == 1)
                        {
                            if (Random.value > 0.5f)
                            {
                                InstantiateCorpoMorto4F();
                            }
                            else
                            {
                                if (SpawnObjects.numeroAssassino != 2)
                                {
                                    InstantiateCorpoMorto4();
                                }
                                else
                                {
                                    InstantiateCorpoMorto4F();
                                }
                            }
                        }
                        else
                        {
                            InstantiateCorpoMorto4F();
                        }
                    }
                }
                else
                {
                    if (numeroMotivoVitimaComum == 0)
                    {
                        if (Random.value > 0.5f)
                        {
                            InstantiateCorpoMorto4F();
                        }
                        else
                        {
                            if (SpawnObjects.numeroAssassino != 2)
                            {
                                InstantiateCorpoMorto4();
                            }
                            else
                            {
                                InstantiateCorpoMorto4F();
                            }
                        }
                    }
                    else
                    {
                        if (SpawnObjects.numeroAssassino != 2)
                        {
                            InstantiateCorpoMorto4();
                        }
                        else
                        {
                            InstantiateCorpoMorto4F();
                        }
                    }
                }
                break;
            case 51:
                break;
            case 52:
                break;
            case 58:
                if (Random.value > 0.5f)
                {
                    InstantiateManchaSangue();
                }
                if (Random.value > 0.5f)
                {
                    InstantiateManchaSangueTortura();
                }
                break;
            case 59:
                InstantiateCofreVazio();
                break;
            case 60:
                InstantiateCofreFechado();
                break;
            case 61:
                InstantiateCofreDinheiro();
                break;
            case 62:
                InstantiateCofreDinheiroHonesto();
                break;
            case 63:
                InstantiateBilheteCulposo();
                break;
            case 68:
                InstantiatePanoSangue();
                break;
            case 70:
                if (IA.evidencias[intProximoCaso, 68] == 0)
                {
                    InstantiatePano();
                }
                break;
            case 74:
                break;
            case 76:
                break;
            case 77:
                InstantiateLaudo();
                break;
            case 78:
                InstantiateDestrocos();
                break;
            case 79:
                InstantiateJanelaQuebradaPedraInterior();
                PedraInteriorJanela = true;
                break;
            case 80:
                InstantiateJanelaQuebradaPedraExterior();
                PedraInteriorJanela = false;
                break;

        }
    }
    public void ColocaSangueFalso()
    {
        Armas = new Evidence[15];
        Armas[0] = FacaNormalEvidence;
        Armas[1] = FacaNormalSemSangueEvidence;
        Armas[2] = FacaCozinhaEvidence;
        Armas[3] = BastaoDeBeisebolSangueEvidence;
        Armas[4] = BastaoDeBeisebolEvidence;
        Armas[5] = RevolverEvidence;
        Armas[6] = CaixaDeRemedioEvidence;
        Armas[7] = PunhosEvidence;
        Armas[8] = CanoContundenteEvidence;
        Armas[9] = CanoPerfuraçãoEvidence;
        Armas[10] = CanoPerfuraçãoSangueEvidence;
        Armas[11] = CanoContundenteSangueEvidence;
        Armas[12] = SufocamentoEvidence;
        Armas[selecionaArmaComSangueFalso].descriptionUpdate = Armas[selecionaArmaComSangueFalso].description + " Sangue falso.";
        Armas[selecionaArmaComSangueFalso].descriptionUpdateIngles = Armas[selecionaArmaComSangueFalso].descriptionIngles + " False blood.";
    }
    public void LoadRespostas(PlayerData data)
    {
        PrimeiraResposta = data.PrimeiraResposta;
        SegundaResposta = data.SegundaResposta;
        TerceiraResposta = data.TerceiraResposta;
        QuartaResposta = data.QuartaResposta;
        QuintaResposta = data.QuintaResposta;
        PrimeiraRespostaIngles = data.PrimeiraRespostaIngles;
        SegundaRespostaIngles = data.SegundaRespostaIngles;
        TerceiraRespostaIngles = data.TerceiraRespostaIngles;
        QuartaRespostaIngles = data.QuartaRespostaIngles;
        Debug.Log(PrimeiraResposta + "aaa" + SegundaResposta + "aaa" + TerceiraResposta + "aaa" + QuartaResposta + "aaa" + QuintaResposta);
    }
    public void SelecionaMotivo()
    {
        Roubo = false;
        Justica = false;
        Tortura = false;
        Vinganca = false;
        Raiva = false;
        if (TemPlanejamento)
        {
            Tortura = true;
            Vinganca = true;
            Justica = true;
        }
        if (NTemPlanejamento)
        {
            Raiva = true;
            Roubo = true;
        }
        if (weaponInstantDeath)
        {
            Tortura = false;
            Vinganca = false;
        }
        if (!weaponInstantDeath)
        {
            Justica = false;
            Roubo = false;
        }
        ContinuaNoLoop = true;
        SpawnCofre = false;
        while (ContinuaNoLoop)
        {
            selecionadorint = Random.Range(0, 5);
            switch (selecionadorint)
            {
                case 0:
                    if (Roubo)
                    {
                        ContinuaNoLoop = false;
                        if (Random.value > 0.5f)
                        {
                            InstantiateCofreDinheiro();
                        }
                        else
                        {
                            InstantiateCofreVazio();
                        }
                        QuintaResposta = "Roubo";
                    }
                    else if (!SpawnCofre)
                    {
                        SpawnCofre = true;
                        if (Random.value > 0.5f)
                        {
                            InstantiateCofreDinheiroHonesto();
                        }
                        else
                        {
                            InstantiateCofreFechado();
                        }
                    }
                    break;
                case 1:
                    if (Tortura)
                    {
                        ContinuaNoLoop = false;
                        LaudoEvidence.descriptionUpdate = LaudoEvidence.descriptionUpdate + ". Morreu de Forma Lenta.";
                        if (Random.value > 0.5f)
                        {
                            InstantiateManchaSangue();
                            InstantiateManchaSangueTortura();
                        }
                        else
                        {
                            InstantiateManchaSangue();
                        }
                        QuintaResposta = "Prazer";
                    }
                    else
                    {
                        if (Random.value > 0.5f)
                        {
                            InstantiateManchaSangueTortura();
                        }
                        else
                        {
                            InstantiateManchaSangue();
                        }
                    }
                    break;
                case 2:
                    if (Vinganca)
                    {
                        ContinuaNoLoop = false;
                        InstantiateBilheteCulposo();
                        QuintaResposta = "Desavenca";
                    }
                    break;
                case 3:
                    if (Justica)
                    {
                        ContinuaNoLoop = false;
                        InstantiateBilheteCulposo();
                        QuintaResposta = "Justica";
                    }
                    break;
                case 4:
                    if (Raiva && FoiConvidado)
                    {
                        ContinuaNoLoop = false;
                        InstantiateBilheteCulposo();
                        QuintaResposta = "Raiva";
                    }
                    break;
            }
        }
    }
    public void SelecionaEntradaSaida()
    {
        TemConvite = false;
        TemPorta = false;
        TemJanela = false;
        PortaQuebrada = false;
        JanelaQuebrada = false;
        PedraInteriorJanela = false;
        PortaArrombadaDentro = false;
        depoimentoTestemunhaVisto = false;
        PrecisaDeAuxilioEntradaSaida = false;
        ajudaEntrada = false;
        ajudaSaida = false;
        FoiConvidado = false;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                TemConvite = true;
                TemPorta = true;
                TemJanela = true;
                break;
            case 3:
                TemConvite = true;
                TemPorta = true;
                TemJanela = false;
                JanelaQuebrada = false;
                break;
        }
        if (Random.value > 0.5f)
        {
            PortaQuebrada = true;
        }
        if (Random.value > 0.5f)
        {
            depoimentoTestemunhaVisto = true;
        }
        if (Random.value > 0.5f)
        {
            JanelaQuebrada = true;
        }
        if (Random.value > 0.5f)
        {
            PedraInteriorJanela = true;
        }
        if (Random.value > 0.5f)
        {
            PortaArrombadaDentro = true;
        }
        if (Random.value > 0.5f)
        {
            FoiConvidado = true;
        }
        if (TemJanela && JanelaQuebrada && PedraInteriorJanela)
        {
            FoiConvidado = false;
            InstantiateJanelaQuebradaPedraInterior();
        }
        if (TemJanela && JanelaQuebrada && !PedraInteriorJanela)
        {
            FoiConvidado = false;
            InstantiateJanelaQuebradaPedraExterior();
        }
        if (TemConvite && FoiConvidado == true)
        {
            InstantiatePratos();
        }
        if (TemConvite)
        {
            InstantiateConvite();
        }
        if (TemPorta && PortaQuebrada && PortaArrombadaDentro)
        {
            if (PlayerData.Idioma == "ingles")
            {
                PolicialEvidence.description = "No signs of movement and when I got here the door was broken.";
                PolicialEvidence.descriptionUpdate = "No signs of movement and when I got here the door was broken. From the inside.";
            }
            else
            {
                PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada.";
                PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada. De fora para dentro.";
            }
        }
        if (TemPorta && PortaQuebrada && !PortaArrombadaDentro)
        {
            if (PlayerData.Idioma == "ingles")
            {
                PolicialEvidence.description = "No signs of movement and when I got here the door was broken.";
                PolicialEvidence.descriptionUpdate = "No signs of movement and when I got here the door was broken. From the outside.";
            }
            else
            {
                PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada.";
                PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada. De dentro para fora.";
            }
        }
        if (TemPorta && !PortaQuebrada)
        {
            if (PlayerData.Idioma == "ingles")
            {
                PolicialEvidence.description = "No signs of movement and when I got here the door was unlocked.";
                PolicialEvidence.descriptionUpdate = "No signs of movement and when I got here the door was unlocked.";
            }
            else
            {
                PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva destrancada.";
                PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva destrancada.";
            }
        }
        policialSalvar = PolicialEvidence.description;
        policialUpdateSalvar = PolicialEvidence.descriptionUpdate;
        InstantiatePolicial();
        if (PortaQuebrada && JanelaQuebrada)
        {
            /*1 depoimentou testemunha = true, quer dizer que entrou*/
            if (PedraInteriorJanela && PortaArrombadaDentro && depoimentoTestemunhaVisto)
            {
                VistoVerdade = "duvida";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    PrimeiraResposta = "Vidro Quebrado";
                    PrimeiraRespostaIngles = "Broken glass";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PrimeiraResposta = "Porta de saida";
                    PrimeiraRespostaIngles = "Building exit";
                }
                PrecisaDeAuxilioEntradaSaida = true;
                ajudaSaida = true;
            }
            /*2*/
            if (PedraInteriorJanela && !PortaArrombadaDentro && !depoimentoTestemunhaVisto)
            {
                VistoVerdade = "duvida";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    PrimeiraResposta = "Vidro Quebrado";
                    PrimeiraRespostaIngles = "Broken glass";
                    QuartaRespostaIngles = "Broken glass";
                    QuartaResposta = "Vidro Quebrado";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PrimeiraResposta = "Porta de saida";
                    PrimeiraRespostaIngles = "Building exit";
                    QuartaResposta = "Porta de saida";
                    QuartaRespostaIngles = "Building exit";
                }
            }
            /*3*/
            if (!PedraInteriorJanela && !PortaArrombadaDentro && depoimentoTestemunhaVisto)
            {
                VistoVerdade = "false";
                PrimeiraResposta = "Convite";
                PrimeiraRespostaIngles = "Invitation";
                QuartaResposta = "Informações do policial";
                QuartaRespostaIngles = "Policeman's notes";
            }
            /*4*/
            if (!PedraInteriorJanela && PortaArrombadaDentro && !depoimentoTestemunhaVisto)
            {
                VistoVerdade = "true";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    PrimeiraResposta = "Informações do policial";
                    PrimeiraRespostaIngles = "Policeman's notes";
                    QuartaResposta = "Vidro Quebrado";
                    QuartaRespostaIngles = "Broken glass";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PrimeiraResposta = "Informações do policial";
                    PrimeiraRespostaIngles = "Policeman's notes";
                    QuartaResposta = "Porta de saida";
                    QuartaRespostaIngles = "Building exit";
                }
            }
            /*5*/
            if (PedraInteriorJanela && !PortaArrombadaDentro && depoimentoTestemunhaVisto)
            {
                VistoVerdade = "true";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    PrimeiraResposta = "Vidro Quebrado";
                    PrimeiraRespostaIngles = "Broken glass";
                    QuartaResposta = "Informações do policial";
                    QuartaRespostaIngles = "Policeman's notes";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PrimeiraResposta = "Porta de saida";
                    PrimeiraRespostaIngles = "Building exit";
                    QuartaResposta = "Informações do policial";
                    QuartaRespostaIngles = "Policeman's notes";
                }
            }
            /*6*/
            if (PedraInteriorJanela && PortaArrombadaDentro && !depoimentoTestemunhaVisto)
            {
                VistoVerdade = "duvida";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    QuartaResposta = "Vidro Quebrado";
                    QuartaRespostaIngles = "Broken glass";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    QuartaResposta = "Porta de saida";
                    QuartaRespostaIngles = "Building exit";
                }
                PrecisaDeAuxilioEntradaSaida = true;
                ajudaEntrada = true;
            }
            /*7*/
            if (!PedraInteriorJanela && PortaArrombadaDentro && depoimentoTestemunhaVisto)
            {
                VistoVerdade = "false";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    PrimeiraResposta = "Informações do policial";
                    PrimeiraRespostaIngles = "Policeman's notes";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PrimeiraResposta = "Informações do policial";
                    PrimeiraRespostaIngles = "Policeman's notes";
                }
                PrecisaDeAuxilioEntradaSaida = true;
                ajudaSaida = true;
            }
            /*8*/
            if (!PedraInteriorJanela && !PortaArrombadaDentro && !depoimentoTestemunhaVisto)
            {
                VistoVerdade = "duvida";
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    QuartaResposta = "Vidro Quebrado";
                    QuartaRespostaIngles = "Broken glass";
                    PrimeiraResposta = "Convite";
                    PrimeiraRespostaIngles = "Invitation";
                }
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    PrimeiraResposta = "Convite";
                    PrimeiraRespostaIngles = "Invitation";
                    QuartaResposta = "Porta de saida";
                    QuartaRespostaIngles = "Building exit";
                }
            }
        }
        if (!PortaQuebrada || !JanelaQuebrada)
        {
            PrecisaDeAuxilioEntradaSaida = true;
            ajudaSaida = true;
            ajudaEntrada = true;
        }
        if (PrecisaDeAuxilioEntradaSaida)
        {
            InstantiateCelular();
        }
    }
    public void SelecionaLocal()
    {
        QuantidadeCorposDisponiveis = 0;
        Corpos = new Evidence[10];
        CorposDisponiveis = new Evidence[10];
        if (SpawnObjects.numeroAssassino != 0 && SpawnObjects.numeroAssassino != 5)
        {
            if (SpawnObjects.numeroAssassino != 2)
            {
                Corpos[0] = CorpoMorto1Evidence;
                Corpos[1] = CorpoMorto2Evidence;
                Corpos[2] = CorpoMorto3Evidence;
                Corpos[3] = CorpoMorto4Evidence;
                Corpos[4] = CorpoMorto1FEvidence;
                Corpos[5] = CorpoMorto2FEvidence;
                Corpos[6] = CorpoMorto3MEvidence;
                Corpos[7] = CorpoMorto4FEvidence;
                numeroDoForLocal = 8;
            }
            else
            {
                Corpos[0] = CorpoMorto3Evidence;
                Corpos[1] = CorpoMorto1FEvidence;
                Corpos[2] = CorpoMorto2FEvidence;
                Corpos[3] = CorpoMorto4FEvidence;
                numeroDoForLocal = 4;
            }

        }
        else
        {
            Corpos[0] = CorpoMorto1Evidence;
            Corpos[1] = CorpoMorto2Evidence;
            Corpos[2] = CorpoMorto4Evidence;
            Corpos[3] = CorpoMorto3MEvidence;
            numeroDoForLocal = 4;
        }
        for (j = 0; j < numeroDoForLocal; j++)
        {
            if (Corpos[j].weaponDescription == Armas[numeroSelecionadoParaResposta].weaponDescription)
            {
                CorposDisponiveis[QuantidadeCorposDisponiveis] = Corpos[j];
                QuantidadeCorposDisponiveis++;
            }
        }
        selecionadorint = Random.Range(0, QuantidadeCorposDisponiveis);
        carregaObjetos(CorposDisponiveis[selecionadorint].NomeObjeto);
        weaponInstantDeath = CorposDisponiveis[selecionadorint].weaponInstantDeath;
        NTemPlanejamento = CorposDisponiveis[selecionadorint].NTemPlanejamento;
        TemPlanejamento = CorposDisponiveis[selecionadorint].TemPlanejamento;
        numeroSelecionadoParaResposta = selecionadorint;
        SegundaResposta = CorposDisponiveis[selecionadorint].nome;
        SegundaRespostaIngles = CorposDisponiveis[selecionadorint].nomeIngles;
    }
    public void SelecionaLaudo(string Nome)
    {
        switch (Nome)
        {
            case "corte":
                if (PlayerData.Idioma == "ingles")
                {
                    LaudoEvidence.descriptionIngles = "Died around 10:00. Signs of cutting were found.";
                    LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. Signs of cutting were found.";
                }
                else
                {
                    LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                }
                break;
            case "contundente":
                if (PlayerData.Idioma == "ingles")
                {
                    LaudoEvidence.descriptionIngles = "Died around 10:00. Sings of contusion were found.";
                    LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. Sings of contusion were found.";
                }
                else
                {
                    LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                }
                break;
            case "veneno":
                if (PlayerData.Idioma == "ingles")
                {
                    LaudoEvidence.descriptionIngles = "Died around 10:00. No signs of harm were found.";
                    LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. No signs of harm were found.";
                }
                else
                {
                    LaudoEvidence.description = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                }
                break;
            case "armaDeFogo":
                if (PlayerData.Idioma == "ingles")
                {
                    LaudoEvidence.descriptionIngles = "Died around 10:00. Sings of perforation were found.";
                    LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. Sings of perforation were found.";
                }
                else
                {
                    LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                }
                break;
        }
        InstantiateLaudo();
    }
    public void SelecionaArma()
    {
        depoimentoTestemunhaOuviu = false;
        if (Random.value > 0.5f)
        {
            depoimentoTestemunhaOuviu = true;
        }
        Armas = new Evidence[15];
        Armas[0] = FacaNormalEvidence;
        Armas[1] = FacaNormalSemSangueEvidence;
        Armas[2] = FacaCozinhaEvidence;
        Armas[3] = BastaoDeBeisebolSangueEvidence;
        Armas[4] = BastaoDeBeisebolEvidence;
        Armas[5] = RevolverEvidence;
        Armas[6] = CaixaDeRemedioEvidence;
        Armas[7] = PunhosEvidence;
        Armas[8] = CanoContundenteEvidence;
        Armas[9] = CanoPerfuraçãoEvidence;
        Armas[10] = CanoPerfuraçãoSangueEvidence;
        Armas[11] = CanoContundenteSangueEvidence;
        Armas[12] = SufocamentoEvidence;
        if (PlayerData.DificuldadeAtual <= 0)
        {
            NumeroArmas = 2;
        }
        else if (PlayerData.DificuldadeAtual <= 2 && PlayerData.DificuldadeAtual >= 1)
        {
            NumeroArmas = 2;
        }
        else if (PlayerData.DificuldadeAtual <= 6 && PlayerData.DificuldadeAtual >= 3)
        {
            NumeroArmas = 3;
        }
        selecionadorint = Random.Range(0, 13);
        if (selecionadorint == 7)
        {
            InstantiateDestrocos();
        }
        for (j = 0; j < NumeroArmas; j++)
        {
            if (j == 0)
            {
                carregaObjetos(Armas[selecionadorint].NomeObjeto);
                numeroSelecionadoParaResposta = selecionadorint;
                TerceiraResposta = Armas[selecionadorint].nome;
                TerceiraRespostaIngles = Armas[selecionadorint].nomeIngles;
                RuidoArmaDoCrime = Armas[selecionadorint].weaponRuido;
                if (Armas[selecionadorint].weaponRuido == 1)
                {
                    OuviuVerdade = "duvida";
                }
                if (Armas[selecionadorint].weaponRuido == 0 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                if (Armas[selecionadorint].weaponRuido == 0 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "true";
                }
                if (Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu)
                {
                    OuviuVerdade = "false";
                }
                SelecionaLaudo(Armas[numeroSelecionadoParaResposta].weaponDescription);
                if (selecionadorint == 1 || selecionadorint == 4 || selecionadorint == 8 || selecionadorint == 9)
                {
                    InstantiatePanoSangue();
                    PanoSangue = true;
                }
            }
            else
            {
                while (selecionadorint == numeroSelecionadoParaResposta)
                {
                    selecionadorint = Random.Range(0, 8);
                }
                if (selecionadorint == 7)
                {
                    InstantiateDestrocos();
                }
                if (Armas[selecionadorint].sangue)
                {
                    selecionaArmaComSangueFalso = selecionadorint;
                    Armas[selecionadorint].descriptionUpdate = Armas[selecionadorint].description + " Sangue falso.";
                    Armas[selecionadorint].descriptionUpdateIngles = Armas[selecionadorint].descriptionIngles + " False blood.";
                }
                carregaObjetos(Armas[selecionadorint].NomeObjeto);
            }
        }
        if (Random.value > 0.5f && PanoSangue == false)
        {
            InstantiatePano();
            PanoSangue = true;
        }
    }
    public int carregaNumeroDePortas()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                return 0;
            case 1:
                if (TrocaDeAndares.AndarAtual == 2)
                {
                    return 4;
                }
                return 5;
            case 2:
                return 3;
            case 3:
                return 6;
        }
        return 0;
    }
    public int carregaPortaDaCena()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                return 0;
            case 1:
                if (TrocaDeAndares.AndarAtual == 2)
                {
                    return 6;
                }
                return 1;
            case 2:
                return 10;
            case 3:
                return 15;
        }
        return 0;
    }
    public void carregaObjetos(string Nome)
    {
        switch (Nome)
        {
            case "Bilhete(Clone)":
                InstantiateBilheteCulposo();
                break;
            case "CorpoMorto2(Clone)":
                InstantiateCorpoMorto2();
                break;
            case "CorpoMorto1(Clone)":
                InstantiateCorpoMorto1();
                break;
            case "CorpoMorto3(Clone)":
                InstantiateCorpoMorto3();
                break;
            case "CorpoMorto4(Clone)":
                InstantiateCorpoMorto4();
                break;
            case "Cofre com dinheiro(Clone)":
                InstantiateCofreDinheiro();
                break;
            case "CofreFechado(Clone)":
                InstantiateCofreFechado();
                break;
            case "CofreVazio(Clone)":
                InstantiateCofreVazio();
                break;
            case "FacaCozinha(Clone)":
                InstantiateFacaCozinha();
                break;
            case "FacaSerradaSemSangue(Clone)":
                InstantiateFacaNormalSemSangue();
                break;
            case "FacaNormal(Clone)":
                InstantiateFacaNormal();
                break;
            case "pedra_dentro(Clone)":
                InstantiateJanelaQuebradaPedraInterior();
                break;
            case "pedra_fora(Clone)":
                InstantiateJanelaQuebradaPedraExterior();
                break;
            case "Prato(Clone)":
                InstantiatePratos();
                break;
            case "Laudo(Clone)":
                InstantiateLaudo();
                break;
            case "Informações do policial(Clone)":
                InstantiatePolicial();
                break;
            case "Informações da testemunha(Clone)":
                InstantiateTestemunha();
                break;
            case "BastaoDeBeisebol(Clone)":
                InstantiateBastao();
                break;
            case "BastaoDeBeisebolComSangue(Clone)":
                InstantiateBastaoSangue();
                break;
            case "Revolver(Clone)":
                InstantiateRevolver();
                break;
            case "Caixa de remedio(Clone)":
                InstantiateCaixaRemedio();
                break;
            case "Celular(Clone)":
                InstantiateCelular();
                break;
            case "ManchaSangue(Clone)":
                InstantiateManchaSangue();
                break;
            case "ManchaSangueTortura(Clone)":
                InstantiateManchaSangueTortura();
                break;
            case "Cofre com dinheiro honesto(Clone)":
                InstantiateCofreDinheiroHonesto();
                break;
            case "Porta de saida(Clone)":
                InstantiatePortaSaida();
                break;
            case "Destrocos(Clone)":
                InstantiateDestrocos();
                break;
            case "Punhos(Clone)":
                InstantiatePunhos();
                break;
            case "Convite(Clone)":
                InstantiateConvite();
                break;
            case "CanoNormalContundente(Clone)":
                InstantiateCanocontundente();
                break;
            case "CanoSangueContundente(Clone)":
                InstantiateCanoContundenteSangue();
                break;
            case "Sufocamento(Clone)":
                InstantiateSufocamento();
                break;
            case "Pano(Clone)":
                InstantiatePano();
                break;
            case "CanoSanguePerfurante(Clone)":
                InstantiateCanoPerfuracaoSangue();
                break;
            case "CanoNormalPerfurante(Clone)":
                InstantiateCanoperfuracao();
                break;
            case "CorpoMorto2F(Clone)":
                InstantiateCorpoMorto2F();
                break;
            case "CorpoMorto1F(Clone)":
                InstantiateCorpoMorto1F();
                break;
            case "CorpoMorto3M(Clone)":
                InstantiateCorpoMorto3M();
                break;
            case "CorpoMorto4F(Clone)":
                InstantiateCorpoMorto4F();
                break;
        }
    }
    public void LoadPlayer(PlayerData data, int i)
    {
        switch (data.nomeObjetoEvidencias[i])
        {
            case "Bilhete(Clone)":
                InstantiateBilheteCulposo();
                break;
            case "CorpoMorto2F(Clone)":
                InstantiateCorpoMorto2F();
                break;
            case "CorpoMorto1F(Clone)":
                InstantiateCorpoMorto1F();
                break;
            case "CorpoMorto3M(Clone)":
                InstantiateCorpoMorto3M();
                break;
            case "CorpoMorto4F(Clone)":
                InstantiateCorpoMorto4F();
                break;
            case "CorpoMorto2(Clone)":
                InstantiateCorpoMorto2();
                break;
            case "CorpoMorto1(Clone)":
                InstantiateCorpoMorto1();
                break;
            case "CorpoMorto3(Clone)":
                InstantiateCorpoMorto3();
                break;
            case "CorpoMorto4(Clone)":
                InstantiateCorpoMorto4();
                break;
            case "Cofre com dinheiro(Clone)":
                InstantiateCofreDinheiro();
                break;
            case "CofreFechado(Clone)":
                InstantiateCofreFechado();
                break;
            case "CofreVazio(Clone)":
                InstantiateCofreVazio();
                break;
            case "FacaCozinha(Clone)":
                InstantiateFacaCozinha();
                break;
            case "FacaSerradaSemSangue(Clone)":
                InstantiateFacaNormalSemSangue();
                break;
            case "FacaNormal(Clone)":
                InstantiateFacaNormal();
                break;
            case "pedra_dentro(Clone)":
                InstantiateJanelaQuebradaPedraInterior();
                break;
            case "pedra_fora(Clone)":
                InstantiateJanelaQuebradaPedraExterior();
                break;
            case "Prato(Clone)":
                InstantiatePratos();
                break;
            case "Laudo(Clone)":
                InstantiateLaudo();
                break;
            case "Informações do policial(Clone)":
                InstantiatePolicial();
                break;
            case "Informações da testemunha(Clone)":
                InstantiateTestemunha();
                break;
            case "BastaoDeBeisebol(Clone)":
                InstantiateBastao();
                break;
            case "BastaoDeBeisebolComSangue(Clone)":
                InstantiateBastaoSangue();
                break;
            case "Revolver(Clone)":
                InstantiateRevolver();
                break;
            case "Caixa de remedio(Clone)":
                InstantiateCaixaRemedio();
                break;
            case "Celular(Clone)":
                InstantiateCelular();
                break;
            case "ManchaSangue(Clone)":
                InstantiateManchaSangue();
                break;
            case "ManchaSangueTortura(Clone)":
                InstantiateManchaSangueTortura();
                break;
            case "Cofre com dinheiro honesto(Clone)":
                InstantiateCofreDinheiroHonesto();
                break;
            case "Porta de saida(Clone)":
                InstantiatePortaSaida();
                break;
            case "Destrocos(Clone)":
                InstantiateDestrocos();
                break;
            case "Punhos(Clone)":
                InstantiatePunhos();
                break;
            case "Convite(Clone)":
                InstantiateConvite();
                break;
            case "CanoNormalContundente(Clone)":
                InstantiateCanocontundente();
                break;
            case "CanoSangueContundente(Clone)":
                InstantiateCanoContundenteSangue();
                break;
            case "Sufocamento(Clone)":
                InstantiateSufocamento();
                break;
            case "Pano(Clone)":
                InstantiatePano();
                break;
            case "CanoSanguePerfurante(Clone)":
                InstantiateCanoPerfuracaoSangue();
                break;
            case "CanoNormalPerfurante(Clone)":
                InstantiateCanoperfuracao();
                break;
        }
    }
    public void PanoNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Piece of cloth was added to the notebook";
            }
            else
            {
                dialogueText.text = "Pedaço de pano foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CanoNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Piece of pipe was added to the notebook";
            }
            else
            {
                dialogueText.text = "Pedaço de cano foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void DestrocosNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Wreckage was added to the notebook";
            }
            else
            {
                dialogueText.text = "Destroços foram adicionadas ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }

    public void CorpoMortoNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Information about the victim was added to the notebook";
            }
            else
            {
                dialogueText.text = "Informações sobre a vítima foram adicionadas ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void FacaNormalNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = FacaNormalEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = FacaNormalEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void FacaCozinhaNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = FacaCozinhaEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = FacaCozinhaEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void FacaNormalSemSangueNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = FacaNormalSemSangueEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = FacaNormalSemSangueEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void ManchaSangueTorturaNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Bloodstains distant was added to the notebook";
            }
            else
            {
                dialogueText.text = "Mancha de Sangue distante foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void JanelaQuebradaPedraInteriorEvidenceNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = JanelaQuebradaPedraInteriorEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = JanelaQuebradaPedraInteriorEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void JanelaQuebradaPedraExteriorEvidenceNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = JanelaQuebradaPedraExteriorEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = JanelaQuebradaPedraExteriorEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void BilheteCulposoEvidenceNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = BilheteCulposoEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = BilheteCulposoEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void PratoEvidenceNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = PratoEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = PratoEvidence.nome + " foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void RevolverNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Revolver was added to the notebook";
            }
            else
            {
                dialogueText.text = "Revólver foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CartaoNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Card was added to the notebook";
            }
            else
            {
                dialogueText.text = "Cartão foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void PedacoBrancoPanoNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Piece of white cloth was added to the notebook";
            }
            else
            {
                dialogueText.text = "Pano branco foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void RelogioNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Watch was added to the notebook";
            }
            else
            {
                dialogueText.text = "Relógio foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CofreVazioNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Empty safe was added to the notebook";
            }
            else
            {
                dialogueText.text = "Cofre vazio foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CofreFechadoNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Closed safe was added to the notebook";
            }
            else
            {
                dialogueText.text = "Cofre fechado foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CofreDinheiroNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Safe with money was added to the notebook";
            }
            else
            {
                dialogueText.text = "Cofre com dinheiro foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CaixaRemedioNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Medicine box added to notebook";
            }
            else
            {
                dialogueText.text = "Caixa de rémedio foi adicionada ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CameraNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = FacaCozinhaEvidence.nomeIngles + " was added to the notebook";
            }
            else
            {
                dialogueText.text = FacaCozinhaEvidence.nome + " foi adicionado ao caderno";
            }
            dialogueText.text = "Camera foi adicionada ao caderno";
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void BastaoDeBeisebolNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Baseball bat was added to the notebook";
            }
            else
            {
                dialogueText.text = "Bastão de beisebol foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void BastaoDeBeisebolSangueNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Baseball bat with blood was added to the notebook";
            }
            else
            {
                dialogueText.text = "Bastão de beisebol com sangue foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }
    public void CelularNome()
    {
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if (!entrouNoTexto)
        {
            animator.SetBool("Abrir", true);
            if (PlayerData.Idioma == "ingles")
            {
                dialogueText.text = "Cell phone was added to the notebook";
            }
            else
            {
                dialogueText.text = "Celular foi adicionado ao caderno";
            }
            entrouNoTexto = true;
        }
        else
        {
            animator.SetBool("Abrir", false);
            entrouNoTexto = false;
        }
    }

    public void FechaJanela()
    {
        animator.SetBool("Abrir", false);
        entrouNoTexto = false;
    }
    public void InstantiateImagem()
    {
        GameObject ImagemClone = Instantiate(Imagem) as GameObject;
        ImagemClone.transform.position = new Vector3(50f, 50f, -5);
        caderno.adicionar(ImagemEvidence);
        NomeDosObjetos[NumeroDeObjetos] = "Imagem(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateDestrocos()
    {
        GameObject DestrocosClone = Instantiate(Destrocos) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                DestrocosClone.transform.position = new Vector3(9.28f, 0.12f, -5);
                break;
            case 2:
                DestrocosClone.transform.position = new Vector3(9.28f, -4.03f, -5);
                break;
            case 3:
                DestrocosClone.transform.position = new Vector3(-9.9f, -9.13f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Destrocos(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateManchaSangue()
    {
        if (QuintaResposta == "Prazer")
        {
            ManchaSangueEvidence.descriptionUpdate = ManchaSangueEvidence.description + " Sangue da vítima, perto do corpo, derramada por volta das 01:50.";
            ManchaSangueEvidence.descriptionUpdateIngles = ManchaSangueEvidence.descriptionIngles + " Victim's blood, near the body, spilled around 01:50.";
        }
        GameObject ManchaSangueClone = Instantiate(ManchaSangue) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                ManchaSangueClone.transform.position = new Vector3(PosicaoCorpoMorto.x - 1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
            case 2:
                ManchaSangueClone.transform.position = new Vector3(PosicaoCorpoMorto.x - 1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
            case 3:
                ManchaSangueClone.transform.position = new Vector3(PosicaoCorpoMorto.x - 1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "ManchaSangue(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateManchaSangueTortura()
    {
        if (QuintaResposta == "Prazer")
        {
            ManchaSangueTorturaEvidence.descriptionUpdate = ManchaSangueTorturaEvidence.description + " Sangue da vítima, na cozinha, derramada por volta das 00:50.";
            ManchaSangueTorturaEvidence.descriptionUpdateIngles = ManchaSangueTorturaEvidence.descriptionIngles + " Victim's blood, in the kitchen, spilled around 00:50.";
            SegundaResposta = ManchaSangueTorturaEvidence.nome;
            SegundaRespostaIngles = ManchaSangueTorturaEvidence.nomeIngles;
        }
        else
        {
            if (Random.value > 0.5f)
            {
                ManchaSangueTorturaEvidence.descriptionUpdate = ManchaSangueTorturaEvidence.description + " Sangue da vítima, na cozinha, derramada por volta das 09:30.";
                ManchaSangueTorturaEvidence.descriptionUpdateIngles = ManchaSangueTorturaEvidence.descriptionIngles + " Victim's blood, in the kitchen, spilled around 09:30.";
                SegundaResposta = ManchaSangueTorturaEvidence.nome;
                SegundaRespostaIngles = ManchaSangueTorturaEvidence.nomeIngles;
            }
            else
            {
                ManchaSangueTorturaEvidence.descriptionUpdate = ManchaSangueTorturaEvidence.description + " Sangue da vítima, na cozinha, derramada por volta das 10:05.";
                ManchaSangueTorturaEvidence.descriptionUpdateIngles = ManchaSangueTorturaEvidence.descriptionIngles + " Victim's blood, in the kitchen, spilled around 10:05.";
            }
        }
        GameObject ManchaSangueTorturaClone = Instantiate(ManchaSangueTortura) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                ManchaSangueTortura.transform.position = new Vector3(PosicaoCorpoMorto.x - 1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
            case 2:
                ManchaSangueTortura.transform.position = new Vector3(4.92f, -6.66f, -4);
                break;
            case 3:
                ManchaSangueTortura.transform.position = new Vector3(-4.79f, -2.12f, -4);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "ManchaSangueTortura(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCelular()
    {
        if (PrecisaDeAuxilioEntradaSaida)
        {
            if (ajudaEntrada)
            {
                if (!PortaQuebrada)
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        CelularEvidence.descriptionIngles = "Cell phone belonging to the victim.";
                        CelularEvidence.descriptionUpdateIngles = "Cell phone belonging to the victim. Message saved on the phone 'Agreed! I'll be waiting for you here, see you later.', unidentified number.";
                    }
                    else
                    {
                        CelularEvidence.description = "Celular pertencente à vítima.";
                        CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Mensagem salva no celular 'Combinado! estárei te aguardando aqui em casa, até mais tarde.', mensagem enviada para um numero anônimo.";
                    }
                    PrimeiraResposta = "Convite";
                    PrimeiraRespostaIngles = "Invitation";
                }
                else
                {
                    if (PlayerData.Idioma == "ingles")
                    {
                        CelularEvidence.descriptionIngles = "Cell phone belonging to the victim.";
                        CelularEvidence.descriptionUpdateIngles = "Cell phone belonging to the victim. Note found on the phone 'To buy materials to fix the hinge'";
                    }
                    else
                    {
                        CelularEvidence.description = "Celular pertencente à vítima.";
                        CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Anotação encontrada no celular 'Comprar materiais para consertar a dobradiça da porta'";
                    }
                    PrimeiraResposta = "Informações do policial";
                    PrimeiraRespostaIngles = "Policeman's notes";
                }
            }
            if (ajudaSaida)
            {
                if (PlayerData.Idioma == "ingles")
                {
                    CelularEvidence.descriptionIngles = "Cell phone belonging to the victim.";
                    CelularEvidence.descriptionUpdateIngles = "Cell phone belonging to the victim. Phone's schedule doesn't show anything set for today.";
                }
                else
                {
                    CelularEvidence.description = "Celular pertencente à vítima.";
                    CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Agenda do celular não mostra nada marcado na data de hoje.";
                }
                QuartaResposta = "Informações do policial";
                QuartaRespostaIngles = "Policeman's notes";
            }
        }
        GameObject CelularClone = Instantiate(Celular) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CelularClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                CelularClone.transform.position = new Vector3(0.85f, -4.12f, -5);
                break;
            case 3:
                CelularClone.transform.position = new Vector3(-10f, -17f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Celular(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateBastaoSangue()
    {
        GameObject BastaoDeBeisebolSangueClone = Instantiate(BastaoDeBeisebolSangue) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                BastaoDeBeisebolSangueClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                BastaoDeBeisebolSangueClone.transform.position = new Vector3(-6.9f, 2.76f, -5);
                break;
            case 3:
                BastaoDeBeisebolSangueClone.transform.position = new Vector3(-16.72f, -4.79f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "BastaoDeBeisebolComSangue(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateBastao()
    {
        GameObject BastaoDeBeisebolClone = Instantiate(BastaoDeBeisebol) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                BastaoDeBeisebolClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                BastaoDeBeisebolClone.transform.position = new Vector3(-6.9f, 2.76f, -5);
                break;
            case 3:
                BastaoDeBeisebolClone.transform.position = new Vector3(-16.72f, -4.79f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "BastaoDeBeisebol(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCamera()
    {
        GameObject CameraClone = Instantiate(Camera) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CameraClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                break;
            case 3:
                CameraClone.transform.position = new Vector3(-1.47f, -3.51f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Camera(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCaixaRemedio()
    {
        GameObject CaixaDeRemedioClone = Instantiate(CaixaDeRemedio) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CaixaDeRemedioClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                CaixaDeRemedioClone.transform.position = new Vector3(10.52f, -10.83f, -5);
                break;
            case 3:
                CaixaDeRemedioClone.transform.position = new Vector3(-1.47f, -3.51f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Caixa de remedio(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCofreDinheiro()
    {
        GameObject CofreDinheiroClone = Instantiate(CofreDinheiro) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CofreDinheiroClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                CofreDinheiroClone.transform.position = new Vector3(10.7f, 5.38f, -5);
                break;
            case 3:
                CofreDinheiroClone.transform.position = new Vector3(-17.98f, 23.95f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Cofre com dinheiro(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCofreDinheiroHonesto()
    {
        if (PlayerData.Idioma == "ingles")
        {
            CofreDinheiroEvidence.descriptionUpdate = "Safe with a large amount of stored value. The victim declared possession of the money.";
        }
        else
        {
            CofreDinheiroEvidence.descriptionUpdate = "Cofre com uma grande quantidade de valor guardado. A vítima declarou a posse do dinheiro.";
        }
        CofreDinheiroEvidence.descriptionUpdate = "Cofre com uma grande quantidade de valor guardado. A vítima declarou a posse do dinheiro.";
        GameObject CofreDinheiroClone = Instantiate(CofreDinheiro) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CofreDinheiroClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                CofreDinheiroClone.transform.position = new Vector3(10.7f, 5.38f, -5);
                break;
            case 3:
                CofreDinheiroClone.transform.position = new Vector3(-17.98f, 23.95f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Cofre com dinheiro(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCofreFechado()
    {
        GameObject CofreFechadoClone = Instantiate(CofreFechado) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CofreFechadoClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                CofreFechadoClone.transform.position = new Vector3(10.7f, 5.38f, -5);
                break;
            case 3:
                CofreFechadoClone.transform.position = new Vector3(-17.98f, 23.95f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CofreFechado(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCofreVazio()
    {
        GameObject CofreVazioInteriorClone = Instantiate(CofreVazio) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CofreVazioInteriorClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                CofreVazioInteriorClone.transform.position = new Vector3(10.7f, 5.38f, -5);
                break;
            case 3:
                CofreVazioInteriorClone.transform.position = new Vector3(-17.98f, 23.95f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CofreVazio(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateJanelaQuebradaPedraInterior()
    {
        GameObject JanelaQuebradaPedraInteriorClone = Instantiate(JanelaQuebradaPedraInterior) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                JanelaQuebradaPedraInteriorClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 2:
                JanelaQuebradaPedraInteriorClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
            case 3:
                JanelaQuebradaPedraInteriorClone.transform.position = new Vector3(6.3f, 6.24f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "pedra_dentro(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateJanelaQuebradaPedraExterior()
    {
        GameObject JanelaQuebradaPedraExteriorClone = Instantiate(JanelaQuebradaPedraExterior) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                JanelaQuebradaPedraExteriorClone.transform.position = new Vector3(7.473f, 7.256f, -5);
                break;
            case 2:
                JanelaQuebradaPedraExteriorClone.transform.position = new Vector3(7.473f, 7.256f, -5);
                break;
            case 3:
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "pedra_fora(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePratos()
    {
        GameObject PratoClone = Instantiate(Prato) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PratoClone.transform.position = new Vector3(5f, -8.29f, -5);
                break;
            case 2:
                PratoClone.transform.position = new Vector3(5f, -8.29f, -5);
                break;
            case 3:
                PratoClone.transform.position = new Vector3(-2.2f, -13.57f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Prato(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateLaudo()
    {
        if (MainMenu.NewGame == false)
        {
            switch (TerceiraResposta)
            {
                case "corte":
                    if (PlayerData.Idioma == "ingles")
                    {
                        LaudoEvidence.descriptionIngles = "Died around 10:00. Signs of cutting were found.";
                        LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. Signs of cutting were found.";
                    }
                    else
                    {
                        LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                        LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                    }
                    break;
                case "contundente":
                    if (PlayerData.Idioma == "ingles")
                    {
                        LaudoEvidence.descriptionIngles = "Died around 10:00. Sings of contusion were found.";
                        LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. Sings of contusion were found.";
                    }
                    else
                    {
                        LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                        LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                    }
                    break;
                case "veneno":
                    if (PlayerData.Idioma == "ingles")
                    {
                        LaudoEvidence.descriptionIngles = "Died around 10:00. No signs of harm were found.";
                        LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. No signs of harm were found.";
                    }
                    else
                    {
                        LaudoEvidence.description = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                        LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                    }
                    break;
                case "armaDeFogo":
                    if (PlayerData.Idioma == "ingles")
                    {
                        LaudoEvidence.descriptionIngles = "Died around 10:00. Sings of perforation were found.";
                        LaudoEvidence.descriptionUpdateIngles = "Died around 10:00. Sings of perforation were found.";
                    }
                    else
                    {
                        LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                        LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                    }
                    break;
            }
        }
        GameObject LaudoClone = Instantiate(Laudo) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                LaudoClone.transform.position = new Vector3(-7.16f, -1.83f, 0);
                break;
            case 2:
                LaudoClone.transform.position = new Vector3(-7.16f, -1.83f, 0);
                break;
            case 3:
                LaudoClone.transform.position = new Vector3(-14.25f, -9.34f, 0);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Laudo(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateTestemunha()
    {
        if (MainMenu.NewGame == false)
        {
            PlayerData data = SaveSystem.LoadPlayer();
            if (PlayerData.Idioma == "ingles")
            {
                TestemunhaEvidence.descriptionIngles = "<b>What was seen?</b>" + "\n" + data.VistoTestemunha + "\n" +
                "<b>What was heard?</b>" + "\n" + data.OuviuTestemunha + "\n" +
                "<b>Relationship with the victim?</b>" + "\n" + data.RelacaoTestemunha;
            }
            else
            {
                TestemunhaEvidence.description = "<b>O que foi visto?</b>" + "\n" + data.VistoTestemunha + "\n" +
                "<b>O que foi ouvido?</b>" + "\n" + data.OuviuTestemunha + "\n" +
                "<b>Relação com a vítima?</b>" + "\n" + data.RelacaoTestemunha;
            }
        }
        GameObject TestemunhalClone = Instantiate(Testemunha) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                TestemunhalClone.transform.position = new Vector3(-6.9f, -15.36f, 0);
                break;
            case 2:
                TestemunhalClone.transform.position = new Vector3(-6.9f, -15.36f, 0);
                break;
            case 3:
                TestemunhalClone.transform.position = new Vector3(16.64f, -17.55f, 0);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Informações da testemunha(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePolicial()
    {
        if (PlayerData.Idioma == "ingles")
        {
            PolicialEvidence.descriptionIngles = policialSalvar;
            PolicialEvidence.descriptionUpdateIngles = policialUpdateSalvar;
        }
        else
        {
            PolicialEvidence.description = policialSalvar;
            PolicialEvidence.descriptionUpdate = policialUpdateSalvar;
        }
        GameObject PolicialClone = Instantiate(Policial) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PolicialClone.transform.position = new Vector3(-1.34f, -24.79f, 0);
                break;
            case 2:
                PolicialClone.transform.position = new Vector3(-1.34f, -24.79f, 0);
                break;
            case 3:
                PolicialClone.transform.position = new Vector3(5.81f, -17.42f, 0);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Informações do policial(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateBilheteCulposo()
    {
        GameObject BilheteCulposoClone = Instantiate(BilheteCulposo) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                BilheteCulposoClone.transform.position = new Vector3(4f, 0f, -5);
                break;
            case 2:
                BilheteCulposoClone.transform.position = new Vector3(-9.49f, 4.58f, -5);
                break;
            case 3:
                BilheteCulposoClone.transform.position = new Vector3(-8.39f, 21.73f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Bilhete(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateFacaNormal()
    {
        GameObject FacaNormalClone = Instantiate(FacaNormal) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                FacaNormalClone.transform.position = new Vector3(0, -8, -5);
                break;
            case 2:
                FacaNormalClone.transform.position = new Vector3(0, -8, -5);
                break;
            case 3:
                FacaNormalClone.transform.position = new Vector3(-4.64f, -1.99f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "FacaNormal(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateRevolver()
    {
        GameObject RevolverClone = Instantiate(Revolver) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                RevolverClone.transform.position = new Vector3(0, -8, -5);
                break;
            case 2:
                RevolverClone.transform.position = new Vector3(-6.95f, -21.66f, -5);
                break;
            case 3:
                RevolverClone.transform.position = new Vector3(0.9f, -2.34f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Revolver(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateFacaNormalSemSangue()
    {
        GameObject FacaNormalSemSangueClone = Instantiate(FacaNormalSemSangue) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                FacaNormalSemSangueClone.transform.position = new Vector3(-8, -10, -5);
                break;
            case 2:
                FacaNormalSemSangueClone.transform.position = new Vector3(-8, -10, -5);
                break;
            case 3:
                FacaNormalSemSangueClone.transform.position = new Vector3(-1.3f, -3.6f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "FacaSerradaSemSangue(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateFacaCozinha()
    {
        GameObject FacaCozinhaClone = Instantiate(FacaCozinha) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                FacaCozinhaClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                FacaCozinhaClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 3:
                FacaCozinhaClone.transform.position = new Vector3(-24.57f, -18.92f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "FacaCozinha(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCanocontundente()
    {
        GameObject CanoContundenteClone = Instantiate(CanoContundente) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CanoContundenteClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CanoContundenteClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CanoContundenteClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CanoNormalContundente(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCanoperfuracao()
    {
        GameObject CanoContundenteClone = Instantiate(CanoContundente) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CanoContundenteClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CanoContundenteClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CanoContundenteClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CanoNormalPerfurante(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePanoBranco()
    {
        GameObject PanoBrancoClone = Instantiate(PanoBranco) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PanoBrancoClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                PanoBrancoClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                PanoBrancoClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "PedacoPanoBranco(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCartaoPolicia()
    {
        GameObject CartaoPoliciaClone = Instantiate(CartaoPolicia) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CartaoPoliciaClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CartaoPoliciaClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CartaoPoliciaClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CartaoPolical(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCartaoAlcool()
    {
        GameObject CartaoAlcoolClone = Instantiate(CartaoAlcool) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CartaoAlcoolClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CartaoAlcoolClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CartaoAlcoolClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CartaoAlcool(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCartaoFilme()
    {
        GameObject CartaoFilmeClone = Instantiate(CartaoFilme) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CartaoFilmeClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CartaoFilmeClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CartaoFilmeClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CartaoFilme(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateRelogio()
    {
        GameObject RelogioClone = Instantiate(Relogio) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                RelogioClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                RelogioClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                RelogioClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Relogio(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCanoContundenteSangue()
    {
        GameObject CanoContundenteSangueClone = Instantiate(CanoContundenteSangue) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CanoContundenteSangueClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CanoContundenteSangueClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CanoContundenteSangueClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CanoSangueContundente(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCanoPerfuracaoSangue()
    {
        GameObject CanoContundenteSangueClone = Instantiate(CanoContundenteSangue) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CanoContundenteSangueClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                CanoContundenteSangueClone.transform.position = new Vector3(12.56f, -18.26f, -5);
                break;
            case 3:
                CanoContundenteSangueClone.transform.position = new Vector3(-13.3f, 17.47f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CanoSanguePerfurante(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateSufocamento()
    {
        GameObject SufocamentoClone = Instantiate(Sufocamento) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                SufocamentoClone.transform.position = new Vector3(40f, 40f, -5);
                break;
            case 2:
                SufocamentoClone.transform.position = new Vector3(40f, 40f, -5);
                break;
            case 3:
                SufocamentoClone.transform.position = new Vector3(40f, 40f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Sufocamento(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePano()
    {
        if (PanoSangue)
        {
            if (PlayerData.Idioma == "ingles")
            {
                PanoEvidence.descriptionUpdate = "A piece of cloth. Cloth is soiled with the victim's blood.";
            }
            else
            {
                PanoEvidence.descriptionUpdate = "Um pedaço de pano. Pano está sujo de sangue da vítima.";
            }
        }
        GameObject PanoClone = Instantiate(Pano) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PanoClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                PanoClone.transform.position = new Vector3(-2.43f, -2.82f, -5);
                break;
            case 3:
                PanoClone.transform.position = new Vector3(-4.67f, 7.19f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Pano(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePanoSangue()
    {
        if (PlayerData.Idioma == "ingles")
        {
            PanoEvidence.descriptionUpdate = "A piece of cloth. Cloth is soiled with the victim's blood.";
        }
        else
        {
            PanoEvidence.descriptionUpdate = "Um pedaço de pano. Pano está sujo de sangue da vítima.";
        }
        GameObject PanoClone = Instantiate(Pano) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PanoClone.transform.position = new Vector3(-13.39f, 9.82f, -5);
                break;
            case 2:
                PanoClone.transform.position = new Vector3(-2.43f, -2.82f, -5);
                break;
            case 3:
                PanoClone.transform.position = new Vector3(-4.67f, 7.19f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Pano(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePortaSaida()
    {
        GameObject PortaDeSaidaClone = Instantiate(PortaDeSaida) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PortaDeSaidaClone.transform.position = new Vector3(9.836f, -16.8f, -5);
                break;
            case 2:
                break;
            case 3:
                PortaDeSaidaClone.transform.position = new Vector3(9.836f, -16.8f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Porta de saida(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePunhos()
    {
        GameObject PunhosClone = Instantiate(Punhos) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                PunhosClone.transform.position = new Vector3(40f, 40f, -5);
                break;
            case 2:
                PunhosClone.transform.position = new Vector3(40f, 40f, -5);
                break;
            case 3:
                PunhosClone.transform.position = new Vector3(40f, 40f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Punhos(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateConvite()
    {
        GameObject ConviteClone = Instantiate(Convite) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                ConviteClone.transform.position = new Vector3(41f, 41f, -5);
                break;
            case 2:
                ConviteClone.transform.position = new Vector3(41f, 41f, -5);
                break;
            case 3:
                ConviteClone.transform.position = new Vector3(41f, 41f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Convite(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto1()
    {
        SexoMasculino = true;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto1Evidence.descriptionIngles = "Body found (Mascuilne) in the living room with a cut on the back.";
                            CorpoMorto1Evidence.descriptionUpdateIngles = "Body found (Masculine) in the living room with a cut on the back. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto1Evidence.description = "Corpo encontrado (Masculino) na sala com um corte nas costas.";
                            CorpoMorto1Evidence.descriptionUpdate = "Corpo encontrado (Masculino) na sala com um corte nas costas. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto1Evidence.descriptionIngles = "Body found (Mascuilne) in the balcony with a cut on the back.";
                            CorpoMorto1Evidence.descriptionUpdateIngles = "Body found (Masculine) in the balcony with a cut on the back. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto1Evidence.description = "Corpo encontrado (Masculino) na varanda com um corte nas costas.";
                            CorpoMorto1Evidence.descriptionUpdate = "Corpo encontrado (Masculino) na varanda com um corte nas costas. Sujeito morava sozinho.";
                        }
                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto1Evidence.descriptionIngles = "Body found (Mascuilne) in the living room with a cut on the back.";
                    CorpoMorto1Evidence.descriptionUpdateIngles = "Body found (Masculine) in the living room with a cut on the back. Person lived alone.";
                }
                else
                {
                    CorpoMorto1Evidence.description = "Corpo encontrado (Masculino) na sala com um corte nas costas.";
                    CorpoMorto1Evidence.descriptionUpdate = "Corpo encontrado (Masculino) na sala com um corte nas costas. Sujeito morava sozinho.";
                }
                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto1Evidence.descriptionIngles = "Body found (Mascuilne) in the balcony with a cut on the back.";
                    CorpoMorto1Evidence.descriptionUpdateIngles = "Body found (Masculine) in the balcony with a cut on the back. Person lived alone.";
                }
                else
                {
                    CorpoMorto1Evidence.description = "Corpo encontrado (Masculino) na varanda com um corte nas costas.";
                    CorpoMorto1Evidence.descriptionUpdate = "Corpo encontrado (Masculino) na varanda com um corte nas costas. Person lived alone.";
                }
                break;
        }
        CorpoMorto1Evidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto1Evidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        GameObject CorpoMorto1Clone = Instantiate(CorpoMorto1) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto1Clone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto1Clone.transform.position;
                break;
            case 2:
                CorpoMorto1Clone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto1Clone.transform.position;
                break;
            case 3:
                CorpoMorto1Clone.transform.position = new Vector3(3.28f, -30.21f, -5);
                PosicaoCorpoMorto = CorpoMorto1Clone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto1(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto2()
    {
        SexoMasculino = true;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto2Evidence.descriptionIngles = "Body found (Masculine) in the bedroom with bruises all over.";
                            CorpoMorto2Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bedroom with bruises all over. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto2Evidence.description = "Corpo encontrado (Masculino) no quarto com hematomas pelo corpo.";
                            CorpoMorto2Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no quarto com hematomas pelo corpo. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto2Evidence.descriptionIngles = "Body found (Masculine) in the bathroom with bruises all over.";
                            CorpoMorto2Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bathroom with bruises all over. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto2Evidence.description = "Corpo encontrado (Masculino) no banheiro com hematomas pelo corpo.";
                            CorpoMorto2Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no banheiro com hematomas pelo corpo. Sujeito morava sozinho.";
                        }

                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto2Evidence.descriptionIngles = "Body found (Masculine) in the bedroom with bruises all over.";
                    CorpoMorto2Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bedroom with bruises all over. Person lived alone.";
                }
                else
                {
                    CorpoMorto2Evidence.description = "Corpo encontrado (Masculino) no quarto com hematomas pelo corpo.";
                    CorpoMorto2Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no quarto com hematomas pelo corpo. Sujeito morava sozinho.";
                }

                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto2Evidence.descriptionIngles = "Body found (Masculine) in the bathroom with bruises all over.";
                    CorpoMorto2Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bathroom with bruises all over. Person lived alone.";
                }
                else
                {
                    CorpoMorto2Evidence.description = "Corpo encontrado (Masculino) no banheiro com hematomas pelo corpo.";
                    CorpoMorto2Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no banheiro com hematomas pelo corpo. Sujeito morava sozinho.";
                }
                break;
        }
        CorpoMorto2Evidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto2Evidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        GameObject CorpoMorto2Clone = Instantiate(CorpoMorto2) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto2Clone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto2Clone.transform.position;
                break;
            case 2:
                CorpoMorto2Clone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto2Clone.transform.position;
                break;
            case 3:
                CorpoMorto2Clone.transform.position = new Vector3(-3.39f, 18.99f, -5);
                PosicaoCorpoMorto = CorpoMorto2Clone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto2(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto3()
    {
        SexoMasculino = false;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto3Evidence.descriptionIngles = "Body found (Feminine) in the living room with a perforation.";
                            CorpoMorto3Evidence.descriptionUpdateIngles = "Body found (Feminine) in the living room with a perforation. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto3Evidence.description = "Corpo encontrado (Feminino) na sala com uma perfuração.";
                            CorpoMorto3Evidence.descriptionUpdate = "Corpo encontrado (Feminino) na sala com uma perfuração. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto3Evidence.descriptionIngles = "Body found (Feminine) in the balcony with a perforation.";
                            CorpoMorto3Evidence.descriptionUpdateIngles = "Body found (Feminine) in the balcony with a perforation. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto3Evidence.description = "Corpo encontrado (Feminino) na varanda com uma perfuração.";
                            CorpoMorto3Evidence.descriptionUpdate = "Corpo encontrado (Feminino) na varanda com uma perfuração. Sujeito morava sozinho.";
                        }
                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto3Evidence.descriptionIngles = "Body found (Feminine) in the living room with a perforation.";
                    CorpoMorto3Evidence.descriptionUpdateIngles = "Body found (Feminine) in the living room with a perforation. Person lived alone.";
                }
                else
                {
                    CorpoMorto3Evidence.description = "Corpo encontrado (Feminino) na sala com uma perfuração.";
                    CorpoMorto3Evidence.descriptionUpdate = "Corpo encontrado (Feminino) na sala uma perfuração. Sujeito morava sozinho.";
                }
                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto3Evidence.descriptionIngles = "Body found (Feminine) in the balcony with a perforation.";
                    CorpoMorto3Evidence.descriptionUpdateIngles = "Body found (Feminine) in the balcony with a perforation. Person lived alone.";
                }
                else
                {
                    CorpoMorto3Evidence.description = "Corpo encontrado (Feminino) na varanda uma perfuração.";
                    CorpoMorto3Evidence.descriptionUpdate = "Corpo encontrado (Feminino) na varanda uma perfuração. Sujeito morava sozinho.";
                }
                break;
        }
        CorpoMorto3Evidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto3Evidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        GameObject CorpoMorto3Clone = Instantiate(CorpoMorto3) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto3Clone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto3Clone.transform.position;
                break;
            case 2:
                CorpoMorto3Clone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto3Clone.transform.position;
                break;
            case 3:
                CorpoMorto3Clone.transform.position = new Vector3(3.28f, -30.21f, -5);
                PosicaoCorpoMorto = CorpoMorto3Clone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto3(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto4()
    {
        SexoMasculino = true;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto4Evidence.descriptionIngles = "Body found (Masculine) in the bedroom.";
                            CorpoMorto4Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bedroom. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto4Evidence.description = "Corpo encontrado (Masculino) no quarto.";
                            CorpoMorto4Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no quarto. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto4Evidence.descriptionIngles = "Body found (Masculine) in the bathroom. .";
                            CorpoMorto4Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bathroom. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto4Evidence.description = "Corpo encontrado (Masculino) no banheiro.";
                            CorpoMorto4Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no banheiro. Sujeito morava sozinho.";
                        }
                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto4Evidence.descriptionIngles = "Body found (Masculine) in the bedroom.";
                    CorpoMorto4Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bedroom. Person lived alone.";
                }
                else
                {
                    CorpoMorto4Evidence.description = "Corpo encontrado (Masculino) no quarto.";
                    CorpoMorto4Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no quarto. Sujeito morava sozinho.";
                }
                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto4Evidence.descriptionIngles = "Body found (Masculine) in the bathroom. .";
                    CorpoMorto4Evidence.descriptionUpdateIngles = "Body found (Masculine) in the bathroom. Person lived alone.";
                }
                else
                {
                    CorpoMorto4Evidence.description = "Corpo encontrado (Masculino) no banheiro.";
                    CorpoMorto4Evidence.descriptionUpdate = "Corpo encontrado (Masculino) no banheiro. Sujeito morava sozinho.";
                }
                break;
        }
        CorpoMorto4Evidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto4Evidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        GameObject CorpoMorto4Clone = Instantiate(CorpoMorto4) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto4Clone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto4Clone.transform.position;
                break;
            case 2:
                CorpoMorto4Clone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto4Clone.transform.position;
                break;
            case 3:
                CorpoMorto4Clone.transform.position = new Vector3(-3.39f, 18.99f, -5);
                PosicaoCorpoMorto = CorpoMorto4Clone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto4(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto1F()
    {
        SexoMasculino = false;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto1FEvidence.descriptionIngles = "Body found (Feminine) in the living room with a cut on the back.";
                            CorpoMorto1FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the living room with a cut on the back. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto1FEvidence.description = "Corpo encontrado (Feminino) na sala com um corte nas costas.";
                            CorpoMorto1FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) na sala com um corte nas costas. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto1FEvidence.descriptionIngles = "Body found (Feminine) in the balcony with a cut on the back.";
                            CorpoMorto1FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the balcony with a cut on the back. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto1FEvidence.description = "Corpo encontrado (Feminino) na varanda com um corte nas costas.";
                            CorpoMorto1FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) na varanda com um corte nas costas. Sujeito morava sozinho.";
                        }
                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto1FEvidence.descriptionIngles = "Body found (Feminine) in the living room with a cut on the back.";
                    CorpoMorto1FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the living room with a cut on the back. Person lived alone.";
                }
                else
                {
                    CorpoMorto1FEvidence.description = "Corpo encontrado (Feminino) na sala com um corte nas costas.";
                    CorpoMorto1FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) na sala com um corte nas costas. Sujeito morava sozinho.";
                }
                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto1FEvidence.descriptionIngles = "Body found (Feminine) in the balcony with a cut on the back.";
                    CorpoMorto1FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the balcony with a cut on the back. Person lived alone.";
                }
                else
                {
                    CorpoMorto1FEvidence.description = "Corpo encontrado (Feminino) na varanda com um corte nas costas.";
                    CorpoMorto1FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) na varanda com um corte nas costas. Person lived alone.";
                }
                break;
        }
        CorpoMorto1FEvidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto1FEvidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";

        GameObject CorpoMorto1FClone = Instantiate(CorpoMorto1F) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto1FClone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto1FClone.transform.position;
                break;
            case 2:
                CorpoMorto1FClone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto1FClone.transform.position;
                break;
            case 3:
                CorpoMorto1FClone.transform.position = new Vector3(3.28f, -30.21f, -5);
                PosicaoCorpoMorto = CorpoMorto1FClone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto1F(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto2F()
    {
        SexoMasculino = false;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto2FEvidence.descriptionIngles = "Body found (Feminine) in the bedroom with bruises all over.";
                            CorpoMorto2FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bedroom with bruises all over. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto2FEvidence.description = "Corpo encontrado (Feminino) no quarto com hematomas pelo corpo.";
                            CorpoMorto2FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no quarto com hematomas pelo corpo. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto2FEvidence.descriptionIngles = "Body found (Feminine) in the bathroom with bruises all over.";
                            CorpoMorto2FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bathroom with bruises all over. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto2FEvidence.description = "Corpo encontrado (Feminino) no banheiro com hematomas pelo corpo.";
                            CorpoMorto2FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no banheiro com hematomas pelo corpo. Sujeito morava sozinho.";
                        }

                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto2FEvidence.descriptionIngles = "Body found (Feminine) in the bedroom with bruises all over.";
                    CorpoMorto2FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bedroom with bruises all over. Person lived alone.";
                }
                else
                {
                    CorpoMorto2FEvidence.description = "Corpo encontrado (Feminino) no quarto com hematomas pelo corpo.";
                    CorpoMorto2FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no quarto com hematomas pelo corpo. Sujeito morava sozinho.";
                }

                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto2FEvidence.descriptionIngles = "Body found (Feminine) in the bathroom with bruises all over.";
                    CorpoMorto2FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bathroom with bruises all over. Person lived alone.";
                }
                else
                {
                    CorpoMorto2FEvidence.description = "Corpo encontrado (Feminino) no banheiro com hematomas pelo corpo.";
                    CorpoMorto2FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no banheiro com hematomas pelo corpo. Sujeito morava sozinho.";
                }
                break;
        }
        CorpoMorto2FEvidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto2FEvidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";

        GameObject CorpoMorto2FClone = Instantiate(CorpoMorto2F) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto2FClone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto2FClone.transform.position;
                break;
            case 2:
                CorpoMorto2FClone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto2FClone.transform.position;
                break;
            case 3:
                CorpoMorto2FClone.transform.position = new Vector3(-3.39f, 18.99f, -5);
                PosicaoCorpoMorto = CorpoMorto2FClone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto2F(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto3M()
    {
        SexoMasculino = true;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto3MEvidence.descriptionIngles = "Body found (Masculine) in the living room with a perforation.";
                            CorpoMorto3MEvidence.descriptionUpdateIngles = "Body found (Masculine) in the living room with a perforation. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto3MEvidence.description = "Corpo encontrado (Masculino) na sala com uma perfuração.";
                            CorpoMorto3MEvidence.descriptionUpdate = "Corpo encontrado (Masculino) na sala com uma perfuração. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto3MEvidence.descriptionIngles = "Body found (Masculine) in the balcony with a perforation.";
                            CorpoMorto3MEvidence.descriptionUpdateIngles = "Body found (Masculine) in the balcony with a perforation. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto3MEvidence.description = "Corpo encontrado (Masculino) na varanda com uma perfuração.";
                            CorpoMorto3MEvidence.descriptionUpdate = "Corpo encontrado (Masculino) na varanda com uma perfuração. Sujeito morava sozinho.";
                        }
                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto3MEvidence.descriptionIngles = "Body found (Masculine) in the living room with a perforation.";
                    CorpoMorto3MEvidence.descriptionUpdateIngles = "Body found (Masculine) in the living room with a perforation. Person lived alone.";
                }
                else
                {
                    CorpoMorto3MEvidence.description = "Corpo encontrado (Masculino) na sala com uma perfuração.";
                    CorpoMorto3MEvidence.descriptionUpdate = "Corpo encontrado (Masculino) na sala uma perfuração. Sujeito morava sozinho.";
                }
                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto3MEvidence.descriptionIngles = "Body found (Masculine) in the balcony with a perforation.";
                    CorpoMorto3MEvidence.descriptionUpdateIngles = "Body found (Masculine) in the balcony with a perforation. Person lived alone.";
                }
                else
                {
                    CorpoMorto3MEvidence.description = "Corpo encontrado (Masculino) na varanda uma perfuração.";
                    CorpoMorto3MEvidence.descriptionUpdate = "Corpo encontrado (Masculino) na varanda uma perfuração. Sujeito morava sozinho.";
                }
                break;
        }
        CorpoMorto3MEvidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto3MEvidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";

        GameObject CorpoMorto3MClone = Instantiate(CorpoMorto3M) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto3MClone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto3MClone.transform.position;
                break;
            case 2:
                CorpoMorto3MClone.transform.position = new Vector3(-7f, -4.5f, -5);
                PosicaoCorpoMorto = CorpoMorto3MClone.transform.position;
                break;
            case 3:
                CorpoMorto3MClone.transform.position = new Vector3(3.28f, -30.21f, -5);
                PosicaoCorpoMorto = CorpoMorto3MClone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto3M(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto4F()
    {
        SexoMasculino = false;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                switch (ScenesManager.ActualScene)
                {
                    case 2:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto4FEvidence.descriptionIngles = "Body found (Feminine) in the bedroom.";
                            CorpoMorto4FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bedroom. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto4FEvidence.description = "Corpo encontrado (Feminino) no quarto.";
                            CorpoMorto4FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no quarto. Sujeito morava sozinho.";
                        }
                        break;
                    case 3:
                        if (PlayerData.Idioma == "ingles")
                        {
                            CorpoMorto4FEvidence.descriptionIngles = "Body found (Feminine) in the bathroom. .";
                            CorpoMorto4FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bathroom. Person lived alone.";
                        }
                        else
                        {
                            CorpoMorto4FEvidence.description = "Corpo encontrado (Feminino) no banheiro.";
                            CorpoMorto4FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no banheiro. Sujeito morava sozinho.";
                        }
                        break;
                }
                break;
            case 2:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto4FEvidence.descriptionIngles = "Body found (Feminine) in the bedroom.";
                    CorpoMorto4FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bedroom. Person lived alone.";
                }
                else
                {
                    CorpoMorto4FEvidence.description = "Corpo encontrado (Feminino) no quarto.";
                    CorpoMorto4FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no quarto. Sujeito morava sozinho.";
                }
                break;
            case 3:
                if (PlayerData.Idioma == "ingles")
                {
                    CorpoMorto4FEvidence.descriptionIngles = "Body found (Feminine) in the bathroom. .";
                    CorpoMorto4FEvidence.descriptionUpdateIngles = "Body found (Feminine) in the bathroom. Person lived alone.";
                }
                else
                {
                    CorpoMorto4FEvidence.description = "Corpo encontrado (Feminino) no banheiro.";
                    CorpoMorto4FEvidence.descriptionUpdate = "Corpo encontrado (Feminino) no banheiro. Sujeito morava sozinho.";
                }
                break;
        }
        CorpoMorto4FEvidence.description = CorpoMorto1Evidence.description + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        CorpoMorto4FEvidence.descriptionUpdate = CorpoMorto1Evidence.descriptionUpdate + "\n" + "(idade: " + idadePersonagem.ToString() + " )";
        GameObject CorpoMorto4FClone = Instantiate(CorpoMorto4F) as GameObject;
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                break;
            case 1:
                CorpoMorto4FClone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto4FClone.transform.position;
                break;
            case 2:
                CorpoMorto4FClone.transform.position = new Vector3(4.32f, 0f, -5);
                PosicaoCorpoMorto = CorpoMorto4FClone.transform.position;
                break;
            case 3:
                CorpoMorto4FClone.transform.position = new Vector3(-3.39f, 18.99f, -5);
                PosicaoCorpoMorto = CorpoMorto4FClone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto4F(Clone)";
        NumeroDeObjetos++;
    }
    void Update()
    {

    }
}
