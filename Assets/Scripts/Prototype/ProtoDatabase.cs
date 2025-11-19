using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoDatabase : MonoBehaviour
{
    [SerializeField] private ProtoHistory history = default;
    [SerializeField] private ProtoUserSearch userSearch = default;
    [SerializeField] private ProtoUserProfile userProfile = default;
    [SerializeField] private ProtoTrackWindow trackWindow = default;
    [SerializeField] private ProtoMailbox mailbox = default;

    [Header("Users")]
    [SerializeField] private UserData[] users = default;

    [Header("Tracks")]
    [SerializeField] private TrackData[] tracks = default;

    [Header("Emails")]
    [SerializeField] private EmailData[] emails = default;

    public static readonly List<string> ALL_USERS = new List<string>
    {
        //Testing
        "RadioKilledTheVideoStar", 
        
        // Plot Important
        "Admin", "BleakMusic", "The_Word_Underscore", "NocturneIdol",

        // Just Commenters
        "ChalkRock", "Folkie", "NotPop", "Tuotter", 

        // References
        "ToddInTheShadows", "TobyFox", 

        // Filler
        "2cuteHuman", "2freepe", "2hotFanfare", "4meParty", "AboutLight", "Abservep", "Acronry", "ActiveCy", "ActiveSoft", "AdagioFred", "Adagiolo", "Adagiona", "AdagioNight", "Adagiono", "Adagions", "Adagions1", "Adagionsys", "Adagious", "AdditionsMusicians", "Adgised", "Adjetri", "AdviceRhythm", "AgentChat", "AholicAria", "Ailaneado", "Akrotie", "Alatinit", "AlbumBand", "Allegropost", "Allign", "AlliSuite", "AloneHymn", "Alveous", "Amentico", "AnarchyCapella", "AnarchySanta", "AndanteLing", "Andanterbli", "AndanteVulture", "AngelicMan", "Angelink", "Anquino", "Anuladora", "Anysoftsm", "Aprovec", "Aquasiati", "AriaFeline", "Ariafl", "AriaGreat", "Arialp", "ArsenalNetwork", "Asimparro", "AsJazz", "AstaTempo", "Astraiane", "Atirete", "Atmosed", "Audions", "Audiosk", "AudioSoft", "Austraf", "AuthorOverture", "Autyuumi", "Avhanumsi", "Avtekto", "AwayPause", "Awkwarr", "Ayakaich", "Aynldspic", "Azophar", "Azovinsk", "AzovNovo", "Azuress", "BabixzNote", "Bagatellenter", "BagoNocturne", "Bagutskii", "Bailava", "BalladSnow", "BandChiari", "BandDark", "Banderca", "Banderpo", "Bandicused", "BandJoy", "BandMom", "BandMusic", "BandMusicians", "BandPurple", "BandRely", "BandSimple", "BandZee", "BarComments", "BarDubya", "Bbcmeno", "BeatDoom", "Beater", "Beatique", "BeatStories", "BeatWeb", "BeeSooth", "Belcanal", "Belcanet", "Belcango", "Belcantsv", "BerestL", "BestOstinato", "Betelli", "Betface", "Bhishoo", "Bikotsu", "Bisituk", "BizarreLegato", "BlackRock", "BleakStaff", "BlikiScan", "BlogTranquil", "BlondieCantata", "Bluesch", "BluesGotta", "Bluessi", "Bmanne", "Bmibank", "Bmibass", "BoaMadd", "BoboMaxi", "Boeckle", "Bologoe", "BomberFloat", "BomberRip", "Book", "BooshGlissando", "BooshThega", "BoostEnjoy", "Botterscutch", "BoxRiff", "BoxSpy", "BradelRee", "BrainyMew", "BreezeFugue", "BrilliantRap", "Brodyzh", "BuddieOctave", "Bullfines", "BunnyBlonde", "Butikinsa", "BWithLullaby", "ByteFugue", "ByteOpera", "Byuuryou", "CadenceHinch", "Cadencell", "Cadencervet", "Calmaner", "Calmgr", "Cantant", "CantataCrisp", "Cantatati", "Canyonshift", "CanyonsVelvet", "CapellaHello", "Capriccor", "Caressbo", "Caressis", "Caressor", "Caresstr", "Carolim", "Carolit", "Carolly", "CarolMass", "Carolment", "Caroltati", "Cetatea", "Chaconnens", "Chaconnetq", "Chaconnetr", "Champiorify", "ChattyPapa", "Chebskii", "Cheeria", "ChellChronicle", "Chimeri", "ChiQuiescent", "Choneti", "Chorused", "ChorusRaga", "ChorusRequiem", "ChosenAria", "ChronosPunk", "ChronoWave", "ChunkyDictator", "ChunkyTwit", "Cimento", "ClawCantata", "Clefer", "Cleffe", "ClefLedger", "Clefroit", "ClefTinnys", "Cleful", "Cloudfi", "CloudWitty", "Cocedad", "CodaIon", "Codand", "CodaNight", "Codanmi", "Codatr", "Comfornetu", "CommentTricked", "CommuniqueBeat", "Conceree", "ConcertoFrog", "Concertsant", "Concertse", "Contrica", "Cookieda", "Coolen", "Coolerri", "CoopsCert", "Cornyan", "CornyCrown", "CountryJaden", "Countrymemb", "Countryst", "Countrywise", "Cozyme", "Crazyme", "CrescendoBuzz", "Crescendougge", "Crescenti", "Crystalog", "Ctripol", "Cushyders", "CusickMusic", "CutieMusic", "CutieUpdates", "CyberLied", "CyberPop", "CyberReady", "CyberTastic", "Cyvizes", "CzarBreaking", "CzarCzar", "DancerStaccato", "DanskDance", "Datisca", "DavTrevor", "Debaifu", "Debaire", "Decimen", "DelicateAir", "Demonesne", "DiddyRavager", "Dioxacons", "DirgeChosen", "DirgeFortune", "Dirgenova", "Discomm", "Discorpbi", "Discorpoi", "Djer", "Doepkin", "Doodleti", "Doubleyc", "Dreamtr", "DressyOctave", "Drowseda", "Drowsent", "DuetDelight", "Duetry", "Duetsq", "Duettair", "Duetti", "Duetwo", "Dulcetch", "DulcetPaper", "Duumvir", "Dynachi", "EaseChee", "EatsyouBand", "Echoldon", "Ecklanake", "Ecstacy", "Edaasu", "EdgyDays", "EdgyTreasure", "Eisslik", "Eiyousi", "Eklinte", "Endaman", "Enisarov", "Erciyah", "ErMusic", "EtudeDipity", "Etudekarl", "Etudens", "EtudeTales", "Etudevo", "Eunucel", "EverHymn", "ExclusiveGlitz", "Experthn", "EyesStone", "Fanfarm", "FanOverture", "FarerQuiescent", "FateBandit", "Featheap", "FeatherWizard", "Fensukosa", "Ferrosa", "Fideexc", "Filontose", "FinestBeach", "FleaAware", "Flegib", "Floaton", "Flow2cute", "Flowhast", "Folkin", "Folkme", "Folkrane", "Followin", "Followthin", "ForKaptain", "Fraserho", "FreelanceDance", "FreexBeat", "FreezingJuz", "FugueKool", "Furmistar", "Fusessis", "FuzzyConcerto", "FuzzyPolka", "Gacherr", "Gaedesion", "GambitMelody", "Gasshuush", "GazerComfort", "GeneralCoda", "Geniussi", "Gertsin", "Gineiga", "Gjammore", "Glamouria", "GlissandoAlli", "Gloryonot", "GlossyMura", "GodDisco", "Godzillaki", "Gomelsk", "GomiiOs", "Gospelma", "GottaRaga", "Grandworm", "GreatAndante", "Greatchie", "GreeGlissando", "GreenTechno", "GreyFolk", "Grimati", "Grundynali", "Gumlityre", "Gurgut", "Gutaisan", "Guxinayoe", "GuyChaconne", "Hackley", "HannahTough", "HanSymphony", "Hapsalim", "Harmoniths", "Harmonymy", "HarmonyRap", "Harmonyta", "Harphe", "Harpla", "HarpMarcato", "Harpores", "Harpotel", "Harpreda", "Harpri", "Hartil", "HawkRock", "HeadlineLoop", "Helloom", "Herbengen", "Heroth", "Hhgrenter", "Hickona", "Hideakimi", "Hifableas", "Hikmalame", "Hinduer", "Hiroterg", "HiScherzo", "Hisyone", "Hofment", "HoodInvent", "Hoopau", "HopeEar", "Hopere", "Hoshcha", "HotRest", "HottSunset", "HulkPizzicato", "HumanBreath", "Humermx", "HumMind", "Hunzite", "HushClassy", "Hushwi", "Hybrillia", "HymnCrash", "Hymneson", "Hymnesul", "Hymnissu", "Hymnit", "HymnStart", "IamaLoven", "Iasary", "Iasenig", "IceDrama", "Ideal2free", "Idealth", "Idolotang", "Iduaryon", "Ierusiwa", "Ikuraniwa", "IlMusic", "Implipl", "InformerDuet", "InloveOctave", "Insiderhear", "Instantrite", "Insulan", "Intermezzoment", "IntincrYou", "InventAnn", "Irioso", "Irosoft", "Islandesto", "IsLil", "Izborsk", "Jabonar", "JaqBand", "Jautatert", "Jazzeric", "JazzRaz", "Jessiko", "JimPolka", "JinBelcanto", "Jiryoku", "Jordati", "Joshines", "Josueca", "Junjyu", "Juzgaar", "Kankaruna", "Kankits", "KazanieLu", "Keftack", "Keinibo", "Kerunen", "Keyet", "Keyor", "KeyWard", "KhadEtude", "KhadPurfect", "KholminPo", "Kiazhit", "KiddoIntcat", "KinoHarp", "KitBreath", "Kittetu", "KittyOstinato", "Kituka", "Kixon", "KlugRepose", "KnightChorus", "KoshKar", "Krankenwagen", "Krichev", "Kuchegosh", "Kunilev", "Kwiqque", "Kysylyn", "Ladogard", "LadyPop", "Lapsajava", "LaughSonata", "LawKey", "LegatoCozy", "Legatomg", "LegatoPira", "LegatoTrippin", "LegendCampy", "LegendOratorio", "Leidora", "Lejaracon", "Lengurr", "LeonBelcanto", "LetterOverture", "Lewart", "LiedChaconne", "LiedCookie", "LiedJoy", "LiedPanet", "Liedvalc", "Ligarin", "LightHaro", "LikeChilled", "LilRosa", "LimeLou", "Linkkiss", "LolDream", "Loopemed", "Loopia", "Loopre", "Loquali", "Lto", "Lucybe", "LudaHeart", "LuiBand", "Lullabyte", "Lullaim", "Lullatr", "Lullia", "LullVital", "LunaticLied", "Lyrichoon", "Machitush", "MaddReprise", "MaddSimon", "Madrigaleedg", "Madrigaliaso", "MadrigalSerene", "Madrigaltheh", "MadrigalTicko", "MafiaJournal", "MagazineDrowse", "Magicores", "Maharie", "MansMusic", "ManStaff", "Marcaroup", "Marcatch", "Marcatoma", "MarcherOrchestra", "MarcsZampogna", "MarkStill", "MassMon", "Matagaien", "Matrebo", "Mcraeli", "Measult", "MeasureBase", "MeasureJung", "MeasureMurphy", "Measureneti", "Measureya", "Mechang", "Melodyna", "Melodyne", "MelodyRecipe", "MelodyTeenie", "MelodyThin", "Memcorpla", "Memelik", "MewHunter", "MewTechno", "MineResonate", "Minnesingeos", "Minnesingerde", "MinnesingerHot", "MinnesingerKid", "Minnesingerry", "Minuettics", "Minuetto", "MissingMelody", "MjInca", "MohawkLuke", "Mokleskii", "Morikar", "Moshimo", "Most", "Motarse", "Moteki", "MotetGroup", "Motetup", "Motifie", "MotifXbox", "MountainYugi", "Movieli", "Mozella", "Mrmsgap", "MsSymphony", "Mtsenskii", "MuchTips", "Muflabrid", "MunarodRi", "Munaruk", "Muradro", "MurmurSpoiled", "MurphyInterval", "Muryorifu", "Musical", "MusicFluent", "MusicFox", "MusicGazer", "MusiciansBand", "Musicle", "Musiconex", "Musicrote", "MusicSter", "MusicTao", "Mutiugav", "Myalgency", "Myweant", "Mzimark", "NackMusic", "Nameronas", "Nanni", "Napeadu", "NapTrite", "Nateye", "Natsubu", "Nearlysian", "NeatShark", "Neopoor", "Nephewebli", "Netwood", "NewscastBar", "Nightma", "Nikolen", "NinjaSaki", "Nobersh", "Noctunomi", "Noctursera", "NocturnalGirl", "Noctis", "Noctambulation", "Nodashi", "Noisela", "Nosovskii", "Nosovyi", "Notech", "NoteCzar", "Notein", "Notele", "Notera", "Noters", "NoteSerenity", "Noteviva", "NozyFanfare", "NozyHarmony", "NumeroMelody", "Nutrado", "Nyxnax", "Obceceria", "Obolertma", "ObskiiGor", "Ochakhail", "OctaveBlues", "Octavedd", "OctaveHuman", "Octaverpor", "OctaveStripper", "OffalOfficials", "OfficialAut", "OfficialBob", "OfficialBomber", "OfficialCoops", "OfficialGrundy", "OfficialReader", "OfficialRoses", "OfficialSis", "OfficialStah", "Okaeshi", "Okayamia", "Okinoea", "Olgovit", "OlympicPolka", "Oncolog", "OneScherzo", "OnutovaS", "Onutovsk", "Oodleen", "Operact", "Operari", "Operavice", "Oratorioni", "Oratorks", "Oratorth", "OrchestraBand", "OrchidOrchestra", "Orisonma", "Orisonwi", "Orsenet", "OsmoMusic", "Ososano", "Osramwa", "Ostersk", "Ostinard", "Ostinatogr", "Ostinatoriu", "Ostinatory", "OstinatoSolo", "Ostrovit", "Oughtek", "Overtureat", "OvertureBal", "Overturech", "Overtureta", "Ovruch", "Owenspitt", "Owerusim", "Paozero", "PapaInterval", "ParisStaff", "Passacagliana", "PauseNess", "Pauservis", "Peaceru", "PeaceShush", "Percom", "Permesa", "Personase", "Pexages", "Pigrego", "Pitchei", "Pitchemag", "Pitcher", "PitcherSwing", "Pitchmaqu", "PitchMessages", "Pitchoric", "PizzicatoBen", "PizzicatoNeat", "Pizzicatonn", "Pizzicatoty", "PlaceBizarre", "Placidayco", "Pnbcomyx", "Polkage", "Ponywa", "Popek", "Poperea", "Popietyle", "PopLaugh", "Popnd", "Poptime", "PopularMegs", "Poraginsk", "Porindous", "Porkhanic", "Porkhov", "Ppoiini", "Precili", "ProdigyLoop", "ProdigyRap", "Pudentenc", "Punkborr", "PunkBWith", "PunkForlife", "Punkrout", "PureComfy", "Queycoon", "QuickBoosh", "Quicket", "Quiescental", "Quiescenter", "Quiescentzetl", "Quietergy", "Quietta", "Quiettics", "Quoizen", "Qwentum", "Ragate", "RagaTrimble", "Raimuro", "RapCommunique", "Raper", "RapGravity", "Raphome", "RapMarcato", "Raprege", "Ratific", "Ratin", "RavagerTechno", "Raygg", "RaySoul", "Razdoutov", "RedTempo", "ReggaeAbout", "ReggaeKid", "Relaxia", "ReporterTruck", "ReportsJava", "Repriseft", "Reprisema", "RepriseMdogg", "Reprisens", "Repriserver", "Requiemak", "RequiemBear", "RequiemShabby", "RequiemSound", "RequiemZero", "Requine", "Resseed", "RestDictator", "Restpe", "Rhythmar", "Rhythmar", "RhythmCrazy", "Rhythmerla", "Rhythmerri", "RhythmEternal", "RhythmYoga", "RiffBurnt", "Riffet", "RiffGal", "Riffle", "RiffSoccer", "Ripso", "Rittorain", "RockBand", "RockCadence", "RomanceWhisper", "RondoDiddy", "Rondogsaw", "Rondomela", "Rondori", "RondoTopics", "RondoVirelai", "Roosca", "RosaTechno", "RoseAgent", "RoxGino", "Rozandi", "Rubicri", "RuMusic", "Runbeam", "Rurouhiro", "Ryakudoga", "Ryounry", "Ryousok", "Rzevsk", "SaiyanJazz", "Salsanaro", "Salsarick", "Sandmoza", "Sansin", "Saprama", "Saratinic", "SaviorSalsa", "Scalewi", "scarylisa", "DrBear", "Baltholly", "Smish2Smush", "zyxxyz", "user72838", "user61753", "user18845", "user21283", "user55810", "user33638", "user29606", "user98861", "user83752", "user94638", "user55837", "user72411", "user95161", "user28470", "user17823", "user46954", "user29059", "user16681", "Schersolo", "Scherzog", "ScorpionDirge", "Seguijoye", "Seogastal", "Serenade", "SerenadeLuc", "Serenadent", "Serenadex", "SereneFour", "Serenery", "Serenite", "Serenityonma", "SerenityXo", "Sesquesse", "ShabbyBizarre", "ShabbyFreak", "ShadesAndante", "ShadesOverture", "Shagkem74", "Shayne", "Shestensk", "ShoesRae", "Sicherka", "Sigitasi", "SilenceVelvet", "SilkForever", "Sinelan", "Sistererig", "Sixbear", "Sk8rAlly", "Sk8rCloud", "Skaterli", "SkaterSno", "SkierGospel", "SkierPunk", "SkunkyBand", "Skunkylind", "SkyHymn", "SlowNephew", "SlowSlow", "SlumberJr", "Slypela", "Smolmozd", "Smoother", "Smoothheap", "Smoothinst", "SmoothSimply", "Smugli", "SmugMelody", "Snareac", "Snonext", "Softiral", "SokyMusic", "Soldavahr", "Solkhchek", "Solkhne", "Solocker", "SoloJame", "SoloLuc", "Solonc", "Soloon", "SomberSonata", "SoMusic", "Sonatabora", "SonataFriend", "Sonatalker", "Sonatalm", "Sonatati", "SongMusic", "Sonstem", "SoothBlab", "SoothHonda", "Soulab", "Soulli", "SoulPat", "SoulReader", "Soulum", "SoulVibrato", "SoundSparkling", "SourcesSoul", "Soutag", "Spinty", "SpokesmanDesman", "SpokesmanNewsman", "SportsVelvet", "SpotRondo", "SpyBlog", "Srishopen", "SrutMusic", "Staccaba", "Staccatogara", "Staccatone", "Staccatonews", "Staccatoobal", "StaccatoSonata", "Staffin", "Staffiner", "StaffMax", "StahShades", "Starazh", "Starmind", "StatDiplomat", "Steinat", "StillLegend", "Stolchen", "Stringon", "StrongString", "Suceamt", "Sudaris", "Sueyoku", "Sugrud", "Suiteam", "Suiteau", "Suitech", "SummaryBad", "SummaryInca", "SumoCountry", "Sundagik", "SunSk8r", "SupremeAria", "Surreamebr", "Swingersi", "SwingInvent", "Swingon", "Swingre", "Swingrovi", "SwingSpark", "SwingZeether", "Symphilism", "Symphonext", "Symphonyboud", "SynchroPlacid", "SynchroRest", "Syzransk", "TabRock", "TacticChord", "TacticCover", "Talear", "Tanorda", "Taoki", "TasticAria", "Taurima", "Teamse", "TeamSerenity", "TechnoString", "Technova", "Technovand", "TeenSwing", "TeenzBliss", "Tejasperl", "TempoBe", "Tempoetat", "Tempooh", "Tepactu", "Tepaltype", "Thehibing", "ThereMass", "ThinCloud", "ThinInterval", "Threnodyna", "Threnodyne", "ThrenodySkater", "Tinahon", "TinnysNinja", "Tipogia", "Tobolpe", "Tofflux", "TongsSongs", "TopSuite", "Torunnais", "Tosspoint", "Townes", "TownMass", "Tranquil2hot", "TrickedPassion", "TrippinForb", "Troiker", "Troikincu", "Troubadource", "TroubadourWise", "Troubadousymp", "Trubergor", "TrueChord", "Tsubode", "Tuneil", "TuneKeeper", "TunesMusic", "Tuness", "Tunett", "TwilightFire", "TwinkleOfficial", "Ubered", "Udeginn", "Ugleche", "Uitland", "Ukekar", "Ulvaccsco", "UMusic", "UnlimitedBand", "UnlimitedBlues", "Unlimitedia", "UnowSound", "Unwindab", "Unwindicia", "Unwindma", "UpdateBolt", "Upperiant", "Upsellogy", "Uraramesi", "UrLied", "UstPuita", "Uswitrypa", "Uteriati", "Utopyruff", "Uyounyuu", "Valavl", "VamCool", "Vcricalth", "Vellica", "Velvette", "Vemedixen", "VenueMusic", "VeteranCetic", "Viashnii", "Viatskii", "VibratePeace", "Vibrativ", "Vibratogeco", "VibratoPop", "Viipuriso", "VikingsGenius", "Virelaica", "Virelaign", "Virelaim", "Virelaire", "Vireletry", "Virtuoleri", "VirtuosoGo", "Virtuosori", "Vivacelf", "VivacePop", "Vivaceta", "Vivaceum", "VivaceZerp", "Vivalari", "Vladilov", "Vomerne", "Vospogo", "Vospogoro", "Vshchaia", "VultureAria", "WakaRhapsody", "WarmSpider", "WaveSky", "Wcubesq", "WeeklongSong", "WelBliss", "Welll", "Wethenagl", "WillowsScale", "WireDrowse", "Wirefi", "WireMusic", "Witchin", "WithpainNum", "Wittyin", "Wittyne", "WizardDirge", "Wolfienter", "Wondenb", "WonderNumero", "WordsSleep", "Worldre", "Wzynr", "WzyRiff", "XglossyChan", "XpOratorio", "YauOpera", "YellowBand", "Yensater", "Yosirui", "Yuataku", "YugiRhythm", "Yugirl", "ZampognaSuite", "Zapct", "ZbyraiBer", "ZeeTempo", "Zened", "Zenniach", "Zennyi", "ZenStacey", "ZephyrTactic", "Zhidchev", "Ziseamiar", "Zorrabi", "ZveniaR"
    };

    private void Awake()
    {
        ALL_USERS.Sort();
    }

    private void Start()
    {
        AddEmail(0);
    }

    public void OpenUser(in string username)
    {
        userProfile.Show();
        trackWindow.Hide();
        Optional<UserData> user = FindUser(username);

        if (user.Enabled)
        {
            userProfile.LoadUser(user.Value);
        }
        else
        {
            userProfile.RandomUser(username);
        }

        history.AddUser(username);
    }

    public void OpenTrack(in string username, in string trackName)
    {
        trackWindow.Show();
        Optional<TrackData> track = FindTrack(username, trackName);

        if (track.Enabled)
        {
            trackWindow.LoadTrack(track);
        }
        else
        {
            trackWindow.RandomTrack(username, trackName);
        }

        history.AddTrack(username, trackName);
    }

    public void AddEmail(in int emailIndex)
    {
        mailbox.AddEmail(emails[emailIndex], emailIndex);
    }

    public void OpenEmail(in int emailIndex)
    {
        mailbox.LoadEmail(emails[emailIndex]);
    }

    public void LoadHistory(in ProtoHistory.GameState backState)
    {
        if (backState.window == ProtoHistory.Window.UserSearch)
        {
            userProfile.Hide();
            trackWindow.Hide();
            userSearch.Search(backState.search);
        }
        else if (backState.window == ProtoHistory.Window.User)
        {
            userProfile.Show();
            trackWindow.Hide();
            Optional<UserData> user = FindUser(backState.username);

            if (user.Enabled) userProfile.LoadUser(user.Value);
            else userProfile.RandomUser(backState.username);
        }
        else if (backState.window == ProtoHistory.Window.Track)
        {
            trackWindow.Show();
            Optional<TrackData> track = FindTrack(backState.username, backState.trackName);

            if (track.Enabled) trackWindow.LoadTrack(track);
            else trackWindow.RandomTrack(backState.username, backState.trackName);
        }
    }

    private Optional<UserData> FindUser(in string username)
    {
        foreach (UserData user in users)
        {
            if (user.Username.Equals(username, System.StringComparison.CurrentCultureIgnoreCase))
            {
                return new Optional<UserData>(user);
            }
        }
        return new Optional<UserData>();
    }

    private Optional<TrackData> FindTrack(in string username, in string trackName)
    {
        bool matchUsername = false;
        bool matchTrackName = false;
        foreach (TrackData track in tracks)
        {
            matchUsername = track.Username.Equals(username, System.StringComparison.CurrentCultureIgnoreCase);
            matchTrackName = track.TrackName.Equals(trackName, System.StringComparison.CurrentCultureIgnoreCase);

            if (matchUsername & matchTrackName)
            {
                return new Optional<TrackData>(track);
            }
        }
        return new Optional<TrackData>();
    }
}
