using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnObjects : MonoBehaviour
{
    public static int NumeroDeportas = 0;
    static bool entrouNoTexto = false;
    public Animator animator;
    public Caderno caderno;
    public static string[] NomeDosObjetos = new string[20];
    public static int NumeroDeObjetos;
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
    public static string PrimeiraResposta;
    public static string SegundaResposta;
    public static string TerceiraResposta;
    public static string QuartaResposta;
    public static string QuintaResposta;
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
    private int i = 0;
    private int j = 0;
    public int PortaDaCena = 0;
    /*static private float selecionador = 0;*/
    static private int selecionadorint = 0;
    static private int numeroSelecionadoParaResposta = 0;
    private int NumeroArmas;
    public static int contador;
    public static bool PanoSangue;
    // Start is called before the first frame update
    void Start()
    {       
        PanoSangue = false;
        PlayerData.DificuldadeAtual = 0;    
        NumeroDeObjetos = 0;
        NumeroDeportas = carregaNumeroDePortas();
        PortaDaCena = carregaPortaDaCena();
        if(MainMenu.NewGame == false){     
            PlayerData data = SaveSystem.LoadPlayer(); 
            contador = data.contadorAnalise;
            PanoSangue = data.PanoSangue;
            policialUpdateSalvar = data.policialUpdate;
            PrecisaDeAuxilioEntradaSaida = data.PrecisaDeAuxilioEntradaSaida;
            ajudaEntrada = data.ajudaEntrada;
            ajudaSaida = data.ajudaSaida;
            LoadRespostas(data);
            for(i=0; i<data.NumeroDeObjetos;i++){
                LoadPlayer(data, i);
            }
            for(i=0;i<NumeroDeportas;i++){
                GameObject.Find("Porta"+(i+PortaDaCena)).GetComponent<PortaController>().isOpen = data.isOpen[i+PortaDaCena];
            }
        }
        else{       
            contador = 3;
            if(SceneManager.GetActiveScene().buildIndex == 3){
                InstantiatePortaSaida();
            }
            for(i=0;i<4;i++){
                switch(i){
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
    public void LoadRespostas(PlayerData data){
        PrimeiraResposta = data.PrimeiraResposta;
        SegundaResposta = data.SegundaResposta;
        TerceiraResposta = data.TerceiraResposta;
        QuartaResposta = data.QuartaResposta;
        QuintaResposta = data.QuintaResposta;
        Debug.Log(PrimeiraResposta +"aaa"+ SegundaResposta +"aaa"+ TerceiraResposta +"aaa"+ QuartaResposta +"aaa"+ QuintaResposta);
    }
    public void SelecionaMotivo(){
        Roubo = false;
        Justica = false;
        Tortura = false;
        Vinganca = false;
        Raiva = false;
        if(TemPlanejamento){
            Tortura = true;
            Vinganca = true;
            Justica = true;
        }
        if(NTemPlanejamento){
            Raiva = true;
            Roubo = true;
        }
        if(weaponInstantDeath){
            Tortura = false;
            Vinganca = false;
        }
        if(!weaponInstantDeath){
            Justica = false;
            Roubo = false;
        }
        ContinuaNoLoop = true;
        SpawnCofre = false;
        while(ContinuaNoLoop){
            selecionadorint = Random.Range(0,5);
            switch(selecionadorint){
                case 0:
                    if(Roubo){
                        ContinuaNoLoop = false;
                        if(Random.value > 0.5f){
                            InstantiateCofreDinheiro();
                        }
                        else{
                            InstantiateCofreVazio();
                        }
                        QuintaResposta = "Roubo";
                    }
                    else if(!SpawnCofre){
                        SpawnCofre = true;
                        if(Random.value > 0.5f){
                            InstantiateCofreDinheiroHonesto();
                        }
                        else{
                            InstantiateCofreFechado();
                        }                        
                    }
                    break;
                case 1:
                    if(Tortura){
                        ContinuaNoLoop = false;
                        LaudoEvidence.descriptionUpdate =  LaudoEvidence.descriptionUpdate + ". Morreu de Forma Lenta.";
                        InstantiateManchaSangue();
                        QuintaResposta = "Prazer";
                    }
                    break;
                case 2:
                    if(Vinganca){
                        ContinuaNoLoop = false;
                        InstantiateBilheteCulposo();
                        QuintaResposta = "Desavenca";
                    }
                    break;
                case 3:
                    if(Justica){
                        ContinuaNoLoop = false;
                        InstantiateBilheteCulposo();
                        QuintaResposta = "Justica";
                    }
                    break;
                case 4:
                    if(Raiva && FoiConvidado){
                        ContinuaNoLoop = false;
                        InstantiateBilheteCulposo();
                        QuintaResposta = "Raiva";
                    }
                    break;
            }
        }
    }
    public void SelecionaEntradaSaida(){
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
        switch(SceneManager.GetActiveScene().buildIndex){
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
        if(Random.value > 0.5f){
            PortaQuebrada = true;
        }
        if(Random.value > 0.5f){
            depoimentoTestemunhaVisto = true;
        }
        if(Random.value > 0.5f){
            JanelaQuebrada = true;
        }
        if(Random.value > 0.5f){
            PedraInteriorJanela = true;
        }
        if(Random.value > 0.5f){
            PortaArrombadaDentro = true;
        }
        if(Random.value > 0.5f){
            FoiConvidado = true;
        }
        if(TemJanela && JanelaQuebrada && PedraInteriorJanela){
            FoiConvidado = false;
            InstantiateJanelaQuebradaPedraInterior();
        }
        if(TemJanela && JanelaQuebrada && !PedraInteriorJanela){
            FoiConvidado = false;
            InstantiateJanelaQuebradaPedraExterior();
        }
        if(TemConvite && FoiConvidado == true){
            InstantiatePratos();
        }
        if(TemConvite){
            InstantiateConvite();
        }
        if(TemPorta && PortaQuebrada && PortaArrombadaDentro){
            PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada.";
            PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada. De fora para dentro.";
            InstantiatePolicial();
        }
        if(TemPorta && PortaQuebrada && !PortaArrombadaDentro){
            PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada.";
            PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva quebrada. De dentro para fora.";
            InstantiatePolicial();
        }
        if(TemPorta && !PortaQuebrada){
            PolicialEvidence.description = "Nenhum sinal de movimento e quando cheguei a porta estáva destrancada.";
            PolicialEvidence.descriptionUpdate = "Nenhum sinal de movimento e quando cheguei a porta estáva destrancada.";
            InstantiatePolicial();
        }
        policialUpdateSalvar = PolicialEvidence.descriptionUpdate;
        if(PortaQuebrada && JanelaQuebrada){
            /*1 depoimentou testemunha = true, quer dizer que entrou*/
            if(PedraInteriorJanela && PortaArrombadaDentro && depoimentoTestemunhaVisto){
                VistoVerdade = "duvida";
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    PrimeiraResposta = "Vidro Quebrado";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    PrimeiraResposta = "Porta de saida";
                }
                PrecisaDeAuxilioEntradaSaida = true;
                ajudaSaida = true;
            }
            /*2*/
            if(PedraInteriorJanela && !PortaArrombadaDentro && !depoimentoTestemunhaVisto){
                VistoVerdade = "duvida";
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    PrimeiraResposta = "Vidro Quebrado";
                    QuartaResposta = "Vidro Quebrado";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    PrimeiraResposta = "Porta de saida";
                    QuartaResposta = "Porta de saida";
                }
            }
            /*3*/
            if(!PedraInteriorJanela && !PortaArrombadaDentro && depoimentoTestemunhaVisto){
                VistoVerdade = "false";            
                PrimeiraResposta = "Convite";
                QuartaResposta = "Informações do policial";            
            }
            /*4*/
            if(!PedraInteriorJanela && PortaArrombadaDentro && !depoimentoTestemunhaVisto){
                VistoVerdade = "true";            
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    PrimeiraResposta = "Informações do policial";
                    QuartaResposta = "Vidro Quebrado";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    PrimeiraResposta = "Informações do policial";
                    QuartaResposta = "Porta de saida";
                }           
            }
            /*5*/
            if(PedraInteriorJanela && !PortaArrombadaDentro && depoimentoTestemunhaVisto){
                VistoVerdade = "true";            
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    PrimeiraResposta = "Vidro Quebrado";
                    QuartaResposta = "Informações do policial";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    PrimeiraResposta = "Porta de saida";
                    QuartaResposta = "Informações do policial";
                }           
            }
            /*6*/
            if(PedraInteriorJanela && PortaArrombadaDentro && !depoimentoTestemunhaVisto){
                VistoVerdade = "duvida";            
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    QuartaResposta = "Vidro Quebrado";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    QuartaResposta = "Porta de saida";                
                }           
                PrecisaDeAuxilioEntradaSaida = true;
                ajudaEntrada =true;
            }
            /*7*/
            if(!PedraInteriorJanela && PortaArrombadaDentro && depoimentoTestemunhaVisto){
                VistoVerdade = "false";            
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    PrimeiraResposta = "Informações do policial";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    PrimeiraResposta = "Informações do policial";
                }           
                PrecisaDeAuxilioEntradaSaida = true;
                ajudaSaida = true;
            }
            /*8*/
            if(!PedraInteriorJanela && !PortaArrombadaDentro && !depoimentoTestemunhaVisto){
                VistoVerdade = "duvida";            
                if(SceneManager.GetActiveScene().buildIndex == 2){
                    QuartaResposta = "Vidro Quebrado";
                    PrimeiraResposta = "Convite";
                }
                if(SceneManager.GetActiveScene().buildIndex == 3){
                    PrimeiraResposta = "Convite";
                    QuartaResposta = "Porta de saida";
                }           
            }
        }
        if(!PortaQuebrada || !JanelaQuebrada){
            PrecisaDeAuxilioEntradaSaida = true;
            ajudaSaida = true;
            ajudaEntrada = true;
        }
        if(PrecisaDeAuxilioEntradaSaida){
            InstantiateCelular();
        }
    }
    public void SelecionaLocal(){
        QuantidadeCorposDisponiveis = 0;
        Corpos = new Evidence[5];
        CorposDisponiveis = new Evidence[5];
        Corpos[0] = CorpoMorto1Evidence; 
        Corpos[1] = CorpoMorto2Evidence; 
        Corpos[2] = CorpoMorto3Evidence; 
        Corpos[3] = CorpoMorto4Evidence; 
        for(j=0;j<4;j++){
            if(Corpos[j].weaponDescription == Armas[numeroSelecionadoParaResposta].weaponDescription){
                CorposDisponiveis[QuantidadeCorposDisponiveis] = Corpos[j];
                QuantidadeCorposDisponiveis++;                
            }
        }
        selecionadorint = Random.Range(0,QuantidadeCorposDisponiveis);
        carregaObjetos(CorposDisponiveis[selecionadorint].NomeObjeto);
        weaponInstantDeath = CorposDisponiveis[selecionadorint].weaponInstantDeath;
        NTemPlanejamento = CorposDisponiveis[selecionadorint].NTemPlanejamento;
        TemPlanejamento = CorposDisponiveis[selecionadorint].TemPlanejamento;
        numeroSelecionadoParaResposta = selecionadorint;
        SegundaResposta = CorposDisponiveis[selecionadorint].nome;        
    }
    public void SelecionaLaudo(string Nome){
        switch(Nome){
            case "corte":
                LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
            break;
            case "contundente":
                LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
            break;
            case "veneno":
                LaudoEvidence.description = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
            break;
            case "armaDeFogo":
                LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
            break;
        }
        InstantiateLaudo();
    }
    public void SelecionaArma(){
        depoimentoTestemunhaOuviu = false;
        if(Random.value > 0.5f){
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
        if(PlayerData.DificuldadeAtual <= 0){
            NumeroArmas = 2;            
        }       
        else if(PlayerData.DificuldadeAtual <= 2 && PlayerData.DificuldadeAtual >= 1){
            NumeroArmas = 2;
        }
        else if(PlayerData.DificuldadeAtual <= 6 && PlayerData.DificuldadeAtual >= 3){
            NumeroArmas = 3;
        }
        selecionadorint = Random.Range(0,8);
        if(selecionadorint == 7){
            InstantiateDestrocos();
        }
        for(j=0;j<NumeroArmas;j++){
            if(j == 0){
                carregaObjetos(Armas[selecionadorint].NomeObjeto);
                numeroSelecionadoParaResposta = selecionadorint;
                TerceiraResposta = Armas[selecionadorint].nome;
                if(Armas[selecionadorint].weaponRuido == 1){
                    OuviuVerdade = "duvida";
                }
                if(Armas[selecionadorint].weaponRuido == 0 && depoimentoTestemunhaOuviu){
                    OuviuVerdade = "false";
                }
                if(Armas[selecionadorint].weaponRuido == 0 && !depoimentoTestemunhaOuviu){
                    OuviuVerdade = "true";
                }
                if(Armas[selecionadorint].weaponRuido > 1 && depoimentoTestemunhaOuviu){
                    OuviuVerdade = "true";
                }
                if(Armas[selecionadorint].weaponRuido > 1 && !depoimentoTestemunhaOuviu){
                    OuviuVerdade = "false";
                }
                SelecionaLaudo(Armas[numeroSelecionadoParaResposta].weaponDescription);
                if(selecionadorint == 1 ||  selecionadorint == 4 || selecionadorint == 8 || selecionadorint == 9){
                    InstantiatePanoSangue();
                    PanoSangue = true;
                }
            }
            else{
                while(selecionadorint == numeroSelecionadoParaResposta){
                    selecionadorint = Random.Range(0,8);
                }
                if(selecionadorint == 7){
                    InstantiateDestrocos();
                }
                if(Armas[selecionadorint].sangue){
                    Armas[selecionadorint].descriptionUpdate = Armas[selecionadorint].description + " Sangue falso."; 
                }
                carregaObjetos(Armas[selecionadorint].NomeObjeto);      
            }
        }
        if(Random.value > 0.5f && PanoSangue == false){
            InstantiatePano();
            PanoSangue = true;
        }
    }
    public int carregaNumeroDePortas(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                return 0; 
            case 1:
                if(TrocaDeAndares.AndarAtual == 2){
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
    public int carregaPortaDaCena(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                return 0; 
            case 1:
                if(TrocaDeAndares.AndarAtual == 2){
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
    public void carregaObjetos(string Nome){
        switch(Nome){
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
                InstantiateConvite();
                break;
            case "CanoNormalPerfurante(Clone)":
                InstantiateConvite();
                break;
            case "CanoSangueContundente(Clone)":
                InstantiateConvite();
                break;
            case "CanoSanguePerfurante(Clone)":
                InstantiateConvite();
                break;
            case "Sufocamento(Clone)":
                InstantiateConvite();
                break;
            case "Pano(Clone)":
                InstantiateConvite();
                break;
        }
    }
    public void LoadPlayer(PlayerData data, int i){
        switch(data.NomeDosObjetos[i]){            
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
                InstantiateConvite();
                break;
            case "CanoNormalPerfurante(Clone)":
                InstantiateConvite();
                break;
            case "CanoSangueContundente(Clone)":
                InstantiateConvite();
                break;
            case "CanoSanguePerfurante(Clone)":
                InstantiateConvite();
                break;
            case "Sufocamento(Clone)":
                InstantiateConvite();
                break;
            case "Pano(Clone)":
                InstantiateConvite();
                break;
        }
    }
    public void PanoNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Pedaço de pano foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CanoNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Pedaço de cano foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void DestrocosNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Destroços foram adicionadas ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    
    public void CorpoMortoNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Informações sobre a vítima foram adicionadas ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void FacaNormalNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = FacaNormalEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void FacaCozinhaNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = FacaCozinhaEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void FacaNormalSemSangueNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = FacaNormalSemSangueEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void JanelaQuebradaPedraInteriorEvidenceNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = JanelaQuebradaPedraInteriorEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void JanelaQuebradaPedraExteriorEvidenceNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = JanelaQuebradaPedraExteriorEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void BilheteCulposoEvidenceNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = BilheteCulposoEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void PratoEvidenceNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = PratoEvidence.nome + " foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void RevolverNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Revólver foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CofreVazioNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Cofre vazio foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CofreFechadoNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Cofre fechado foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CofreDinheiroNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Cofre com dinheiro foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CaixaRemedioNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Caixa de rémedio foi adicionada ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CameraNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Camera foi adicionada ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void BastaoDeBeisebolNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Bastão de beisebol foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void BastaoDeBeisebolSangueNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Bastão de beisebol com sangue foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }
    public void CelularNome(){
        animator = GameObject.Find("TransitionBox").GetComponent<Animator>();
        dialogueText = GameObject.Find("TextoTransition").GetComponent<Text>();
        if(!entrouNoTexto){            
            animator.SetBool("Abrir",true);
            dialogueText.text = "Celular foi adicionado ao caderno";
            entrouNoTexto = true;
        }
        else{
            animator.SetBool("Abrir",false);
            entrouNoTexto = false;
        }
    }

    public void FechaJanela(){        
        animator.SetBool("Abrir",false);
    }
    public void InstantiateImagem(){
        GameObject ImagemClone = Instantiate(Imagem) as GameObject;
        ImagemClone.transform.position = new Vector3(50f, 50f, -5);  
        caderno.adicionar(ImagemEvidence);
        NomeDosObjetos[NumeroDeObjetos] = "Imagem(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateDestrocos(){
        GameObject DestrocosClone = Instantiate(Destrocos) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                DestrocosClone.transform.position = new Vector3(9.28f,0.12f, -5);
                break;
            case 2:
                DestrocosClone.transform.position = new Vector3(9.28f,-4.03f, -5);
                break;
            case 3:
                DestrocosClone.transform.position = new Vector3(-9.9f,-9.13f, -5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Destrocos(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateManchaSangue(){
        GameObject ManchaSangueClone = Instantiate(ManchaSangue) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                ManchaSangueClone.transform.position = new Vector3(PosicaoCorpoMorto.x -1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
            case 2:
                ManchaSangueClone.transform.position = new Vector3(PosicaoCorpoMorto.x -1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
            case 3:
                ManchaSangueClone.transform.position = new Vector3(PosicaoCorpoMorto.x -1.5f, PosicaoCorpoMorto.y - 0.12f, -4);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "ManchaSangue(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCelular(){
        if(PrecisaDeAuxilioEntradaSaida){
            if(ajudaEntrada){
                if(!PortaQuebrada){
                    CelularEvidence.description = "Celular pertencente à vítima.";
                    CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Mensagem salva no celular 'Combinado! estárei te aguardando aqui em casa, até mais tarde.', mensagem enviada para um numero anônimo.";
                    PrimeiraResposta = "Convite";
                }
                else{
                    CelularEvidence.description = "Celular pertencente à vítima.";
                    CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Anotação encontrada no celular 'Comprar materiais para consertar a dobradiça da porta'";
                    PrimeiraResposta = "Informações do policial";  
                }
            }
            if(ajudaSaida){
                CelularEvidence.description = "Celular pertencente à vítima.";
                CelularEvidence.descriptionUpdate = "Celular pertencente à vítima. Agenda do celular não mostra nada marcado na data de hoje.";
                QuartaResposta = "Informações do policial"; 
            }
        }
        GameObject CelularClone = Instantiate(Celular) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateBastaoSangue(){
        GameObject BastaoDeBeisebolSangueClone = Instantiate(BastaoDeBeisebolSangue) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateBastao(){
        GameObject BastaoDeBeisebolClone = Instantiate(BastaoDeBeisebol) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateCamera(){
        GameObject CameraClone = Instantiate(Camera) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateCaixaRemedio(){
        GameObject CaixaDeRemedioClone = Instantiate(CaixaDeRemedio) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateCofreDinheiro(){
        GameObject CofreDinheiroClone = Instantiate(CofreDinheiro) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateCofreDinheiroHonesto(){
        CofreDinheiroEvidence.descriptionUpdate = "Cofre com uma grande quantidade de valor guardado. A vítima declarou a posse do dinheiro.";
        GameObject CofreDinheiroClone = Instantiate(CofreDinheiro) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateCofreFechado(){
        GameObject CofreFechadoClone = Instantiate(CofreFechado) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateCofreVazio(){
        GameObject CofreVazioInteriorClone = Instantiate(CofreVazio) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateJanelaQuebradaPedraInterior(){
        GameObject JanelaQuebradaPedraInteriorClone = Instantiate(JanelaQuebradaPedraInterior) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateJanelaQuebradaPedraExterior(){
        GameObject JanelaQuebradaPedraExteriorClone = Instantiate(JanelaQuebradaPedraExterior) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiatePratos(){        
        GameObject PratoClone = Instantiate(Prato) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateLaudo(){
        if(MainMenu.NewGame == false){
            switch(TerceiraResposta){
                case "corte":
                    LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de corte.";
                break;
                case "contundente":
                    LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de contusão.";
                break;
                case "veneno":
                    LaudoEvidence.description = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Não foram encontrados sinais de ferimentos no corpo.";
                break;
                case "armaDeFogo":
                    LaudoEvidence.description = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                    LaudoEvidence.descriptionUpdate = "Morreu por volta das 10:00. Foram encontrados sinais de perfuração.";
                break;
            }
        }
        GameObject LaudoClone = Instantiate(Laudo) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiatePolicial(){
        if(MainMenu.NewGame == false){
            PolicialEvidence.descriptionUpdate = policialUpdateSalvar;
        }
        GameObject PolicialClone = Instantiate(Policial) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateBilheteCulposo(){
        GameObject BilheteCulposoClone = Instantiate(BilheteCulposo) as GameObject;  
        switch(SceneManager.GetActiveScene().buildIndex){
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
    public void InstantiateFacaNormal(){
        GameObject FacaNormalClone = Instantiate(FacaNormal) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                FacaNormalClone.transform.position = new Vector3(0, -8,-5);
                break;
            case 2:
                FacaNormalClone.transform.position = new Vector3(0, -8,-5);
                break;
            case 3:
                FacaNormalClone.transform.position = new Vector3(-4.64f, -1.99f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "FacaNormal(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateRevolver(){
        GameObject RevolverClone = Instantiate(Revolver) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                RevolverClone.transform.position = new Vector3(0, -8,-5);
                break;
            case 2:
                RevolverClone.transform.position = new Vector3(0, -8,-5);
                break;
            case 3:
                RevolverClone.transform.position = new Vector3(0.9f, -2.34f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "Revolver(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateFacaNormalSemSangue(){
        GameObject FacaNormalSemSangueClone = Instantiate(FacaNormalSemSangue) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                FacaNormalSemSangueClone.transform.position = new Vector3(-8, -10,-5);
                break;
            case 2:
                FacaNormalSemSangueClone.transform.position = new Vector3(-8, -10,-5);
                break;
            case 3:
                FacaNormalSemSangueClone.transform.position = new Vector3(-1.3f, -3.6f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "FacaSerradaSemSangue(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateFacaCozinha(){
        GameObject FacaCozinhaClone = Instantiate(FacaCozinha) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                FacaCozinhaClone.transform.position = new Vector3(-13.39f,9.82f,-5);
                break;
            case 2:
                FacaCozinhaClone.transform.position = new Vector3(-13.39f,9.82f,-5);
                break;
            case 3:
                FacaCozinhaClone.transform.position = new Vector3(-24.57f,-18.92f,-5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "FacaCozinha(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCano(){
        GameObject CanoContundenteClone = Instantiate(CanoContundente) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                CanoContundenteClone.transform.position = new Vector3(-13.39f,9.82f,-5);
                break;
            case 2:
                CanoContundenteClone.transform.position = new Vector3(12.56f,-18.26f,-5);
                break;
            case 3:
                CanoContundenteClone.transform.position = new Vector3(-13.3f,17.47f,-5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CanoNormalContundente(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCanoSangue(){
        GameObject CanoContundenteSangueClone = Instantiate(CanoContundenteSangue) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                CanoContundenteSangueClone.transform.position = new Vector3(-13.39f,9.82f,-5);
                break;
            case 2:
                CanoContundenteSangueClone.transform.position = new Vector3(12.56f,-18.26f,-5);
                break;
            case 3:
                CanoContundenteSangueClone.transform.position = new Vector3(-13.3f,17.47f,-5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CanoSangueContundente(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateSufocamento(){
        GameObject SufocamentoClone = Instantiate(Sufocamento) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                SufocamentoClone.transform.position = new Vector3(40f,40f,-5);
                break;
            case 2:
                SufocamentoClone.transform.position = new Vector3(40f,40f,-5);
                break;
            case 3:
                SufocamentoClone.transform.position = new Vector3(40f,40f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "Sufocamento(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePano(){
        if(PanoSangue){
            PanoEvidence.descriptionUpdate = "Um pedaço de pano. Pano está sujo de sangue da vítima.";
        }
        GameObject PanoClone = Instantiate(Pano) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                PanoClone.transform.position = new Vector3(-13.39f,9.82f,-5);
                break;
            case 2:
                PanoClone.transform.position = new Vector3(-2.43f,-2.82f,-5);
                break;
            case 3:
                PanoClone.transform.position = new Vector3(-4.67f,7.19f,-5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Pano(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePanoSangue(){
        PanoEvidence.descriptionUpdate = "Um pedaço de pano. Pano está sujo de sangue da vítima.";
        GameObject PanoClone = Instantiate(Pano) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                PanoClone.transform.position = new Vector3(-13.39f,9.82f,-5);
                break;
            case 2:
                PanoClone.transform.position = new Vector3(-2.43f,-2.82f,-5);
                break;
            case 3:
                PanoClone.transform.position = new Vector3(-4.67f,7.19f,-5);
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "Pano(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePortaSaida(){
        GameObject PortaDeSaidaClone = Instantiate(PortaDeSaida) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                PortaDeSaidaClone.transform.position = new Vector3(9.836f,-16.8f,-5);
                break;
            case 2:
                break;
            case 3:
                PortaDeSaidaClone.transform.position = new Vector3(9.836f,-16.8f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "Porta de saida(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiatePunhos(){
        GameObject PunhosClone = Instantiate(Punhos) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                PunhosClone.transform.position = new Vector3(40f,40f,-5);
                break;
            case 2:
                PunhosClone.transform.position = new Vector3(40f,40f,-5);
                break;
            case 3:
                PunhosClone.transform.position = new Vector3(40f,40f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "Punhos(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateConvite(){
        GameObject ConviteClone = Instantiate(Convite) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                ConviteClone.transform.position = new Vector3(41f,41f,-5);
                break;
            case 2:
                ConviteClone.transform.position = new Vector3(41f,41f,-5);
                break;
            case 3:
                ConviteClone.transform.position = new Vector3(41f,41f,-5);
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "Convite(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto1(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                switch(ScenesManager.ActualScene){
                    case 2:
                        CorpoMorto1Evidence.description= "Corpo encontrado na sala com um corte nas costas.";
                        CorpoMorto1Evidence.descriptionUpdate= "Corpo encontrado na sala com um corte nas costas. Sujeito morava sozinho.";
                        break;
                    case 3:
                        CorpoMorto1Evidence.description= "Corpo encontrado na varanda com um corte nas costas.";
                        CorpoMorto1Evidence.descriptionUpdate= "Corpo encontrado na varanda com um corte nas costas. Sujeito morava sozinho.";
                        break;
                    }
                break;
            case 2:
                CorpoMorto1Evidence.description= "Corpo encontrado na sala com um corte nas costas.";
                CorpoMorto1Evidence.descriptionUpdate= "Corpo encontrado na sala com um corte nas costas. Sujeito morava sozinho.";
                break;
            case 3:
                CorpoMorto1Evidence.description= "Corpo encontrado na varanda com um corte nas costas.";
                CorpoMorto1Evidence.descriptionUpdate= "Corpo encontrado na varanda com um corte nas costas. Sujeito morava sozinho.";
                break;
        }
        GameObject CorpoMorto1Clone = Instantiate(CorpoMorto1) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                CorpoMorto1Clone.transform.position = new Vector3(-7f,-4.5f,-5);
                PosicaoCorpoMorto = CorpoMorto1Clone.transform.position;
                break;
            case 2:
                CorpoMorto1Clone.transform.position = new Vector3(-7f,-4.5f,-5);
                PosicaoCorpoMorto = CorpoMorto1Clone.transform.position;
                break;
            case 3:
                CorpoMorto1Clone.transform.position = new Vector3(3.28f,-30.21f,-5);
                PosicaoCorpoMorto = CorpoMorto1Clone.transform.position;
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto1(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto2(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                switch(ScenesManager.ActualScene){
                    case 2:
                        CorpoMorto2Evidence.description= "Corpo encontrado no quarto com hematomas pelo corpo.";
                        CorpoMorto2Evidence.descriptionUpdate= "Corpo encontrado no quarto com hematomas pelo corpo. Sujeito morava sozinho.";
                        break;
                    case 3:
                        CorpoMorto2Evidence.description= "Corpo encontrado no banheiro com hematomas pelo corpo.";
                        CorpoMorto2Evidence.descriptionUpdate= "Corpo encontrado no banheiro com hematomas pelo corpo. Sujeito morava sozinho.";
                        break;
                    }
                break;
            case 2:
                CorpoMorto2Evidence.description= "Corpo encontrado no quarto com hematomas pelo corpo.";
                CorpoMorto2Evidence.descriptionUpdate= "Corpo encontrado no quarto com hematomas pelo corpo. Sujeito morava sozinho.";
                break;
            case 3:
                CorpoMorto2Evidence.description= "Corpo encontrado no banheiro com hematomas pelo corpo.";
                CorpoMorto2Evidence.descriptionUpdate= "Corpo encontrado no banheiro com hematomas pelo corpo. Sujeito morava sozinho.";
                break;
        }
        GameObject CorpoMorto2Clone = Instantiate(CorpoMorto2) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                CorpoMorto2Clone.transform.position = new Vector3(4.32f,0f,-5);
                PosicaoCorpoMorto = CorpoMorto2Clone.transform.position;
                break;
            case 2:
                CorpoMorto2Clone.transform.position = new Vector3(4.32f,0f,-5);
                PosicaoCorpoMorto = CorpoMorto2Clone.transform.position;
                break;
            case 3:
                CorpoMorto2Clone.transform.position = new Vector3(-3.39f,18.99f,-5);
                PosicaoCorpoMorto = CorpoMorto2Clone.transform.position;
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto2(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto3(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                switch(ScenesManager.ActualScene){
                    case 2:
                        CorpoMorto3Evidence.description= "Corpo encontrado na sala com uma perfuração.";
                        CorpoMorto3Evidence.descriptionUpdate= "Corpo encontrado na sala com uma perfuração. Sujeito morava sozinho.";
                        break;
                    case 3:
                        CorpoMorto3Evidence.description= "Corpo encontrado na varanda com uma perfuração.";
                        CorpoMorto3Evidence.descriptionUpdate= "Corpo encontrado na varanda com uma perfuração. Sujeito morava sozinho.";
                        break;
                    }
                break;
            case 2:
                CorpoMorto3Evidence.description= "Corpo encontrado na sala com uma perfuração.";
                CorpoMorto3Evidence.descriptionUpdate= "Corpo encontrado na sala uma perfuração. Sujeito morava sozinho.";
                break;
            case 3:
                CorpoMorto3Evidence.description= "Corpo encontrado na varanda uma perfuração.";
                CorpoMorto3Evidence.descriptionUpdate= "Corpo encontrado na varanda uma perfuração. Sujeito morava sozinho.";
                break;
        }
        GameObject CorpoMorto3Clone = Instantiate(CorpoMorto3) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                CorpoMorto3Clone.transform.position = new Vector3(-7f,-4.5f,-5);
                PosicaoCorpoMorto = CorpoMorto3Clone.transform.position;
                break;
            case 2:
                CorpoMorto3Clone.transform.position = new Vector3(-7f,-4.5f,-5);
                PosicaoCorpoMorto = CorpoMorto3Clone.transform.position;
                break;
            case 3:
                CorpoMorto3Clone.transform.position = new Vector3(3.28f,-30.21f,-5);
                PosicaoCorpoMorto = CorpoMorto3Clone.transform.position;                
                break;
        }
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto3(Clone)";
        NumeroDeObjetos++;
    }
    public void InstantiateCorpoMorto4(){
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                switch(ScenesManager.ActualScene){
                    case 2:
                        CorpoMorto4Evidence.description= "Corpo encontrado no quarto.";
                        CorpoMorto4Evidence.descriptionUpdate= "Corpo encontrado no quarto. Sujeito morava sozinho.";
                        break;
                    case 3:
                        CorpoMorto4Evidence.description= "Corpo encontrado no banheiro.";
                        CorpoMorto4Evidence.descriptionUpdate= "Corpo encontrado no banheiro. Sujeito morava sozinho.";
                        break;
                    }
                break;
            case 2:
                CorpoMorto4Evidence.description= "Corpo encontrado no quarto.";
                CorpoMorto4Evidence.descriptionUpdate= "Corpo encontrado no quarto. Sujeito morava sozinho.";
                break;
            case 3:
                CorpoMorto4Evidence.description= "Corpo encontrado no banheiro.";
                CorpoMorto4Evidence.descriptionUpdate= "Corpo encontrado no banheiro. Sujeito morava sozinho.";
                break;
        }
        GameObject CorpoMorto4Clone = Instantiate(CorpoMorto4) as GameObject;
        switch(SceneManager.GetActiveScene().buildIndex){
            case 0:
                break;
            case 1:
                CorpoMorto4Clone.transform.position = new Vector3(4.32f,0f,-5);
                PosicaoCorpoMorto = CorpoMorto4Clone.transform.position;
                break;
            case 2:
                CorpoMorto4Clone.transform.position = new Vector3(4.32f,0f,-5);
                PosicaoCorpoMorto = CorpoMorto4Clone.transform.position;
                break;
            case 3:
                CorpoMorto4Clone.transform.position = new Vector3(-3.39f,18.99f,-5);
                PosicaoCorpoMorto = CorpoMorto4Clone.transform.position;
                break;
        }        
        NomeDosObjetos[NumeroDeObjetos] = "CorpoMorto4(Clone)";
        NumeroDeObjetos++;
    }
    void Update()
    {
        
    }
}
