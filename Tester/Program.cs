using Genesis.Factory.NPCs.CreationModule.entities;
using Genesis.Factory.NPCs.CreationModule.systems;
using Genesis.Factory.Universe.CreationModule.entities.race;
using Genesis.Factory.Universe.CreationModule.entities.region;
using Genesis.Factory.Universe.CreationModule.systems;
using Genesis.Heart.AffectionModule.entities;
using Genesis.Heart.AffectionModule.systems;
using Genesis.Heart.IdentityModule.systems;
using Genesis.Heart.PersonalityModule.entities;
using Genesis.Heart.PersonalityModule.systems;
using Genesis.Mind.CommunicationModule.systems;
using Genesis.Mind.KnowledgeModule.entities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Genesis;
using System.Runtime.CompilerServices;
using Newtonsoft;
using Newtonsoft.DTO.NPC;
using Newtonsoft.DTO.NPC.Personality;
using Newtonsoft.DTO.NPC.Identity;
using Newtonsoft.DTO.NPC.Affection;
using Newtonsoft.DTO.World._Location;
using Newtonsoft.DTO.World;
using Newtonsoft.DTO.Races;

namespace A.T.L.A.S
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Atlas atlas = Atlas.Instance;

            var test_npc = atlas.GetCharacterManager().CreateNPC("test");

            test_npc.NpcPersonality.oceanPersonality = new OCEAN(100, 100, 100, 100, 100);

            test_npc.NpcPersonality.schwartzPersonality = new SCHWARTZ(100, 100, 100, 100, 100, 100, 100, 100, 100, 100);

            test_npc.NpcPersonality.personalityStyle = new DialogueStyle(
                "enthusiastic and inspiring",
                30,
                "accessible, full of analogies and metaphors",
                ""
            );

            test_npc.NpcIdentity.NpcName = "Test";
            test_npc.NpcIdentity.RaceID = "human";
            test_npc.NpcIdentity.EnvironmentID = "rua_acasia";
            test_npc.NpcIdentity.Gender = "Male";
            test_npc.NpcIdentity.Age = 30;
            test_npc.NpcIdentity.BiographyFull = "This is a test NPC created to demonstrate the functionality of the Atlas system. It serves as a placeholder for testing purposes.";   
            test_npc.NpcIdentity.Role = "Test Role";
            test_npc.NpcIdentity.PhysicalDescription = "A generic test NPC with no specific features.";
            test_npc.NpcIdentity.CoreBeliefs = new List<string>
            {
                "Knowledge is power.",
                "Curiosity drives innovation.",
                "Empathy is essential for understanding others."
            };
            test_npc.NpcIdentity.Likes = new List<string>
            {
                "Reading books",
                "Exploring new ideas",
                "Helping others"
            };

            test_npc.NpcIdentity.Dislikes = new List<string>
            {
                "Ignorance",
                "Close-mindedness",
                "Dishonesty"
            };

            test_npc.NpcAffections.AddRelationship(
                new Relationship(
                    "lucio",
                    80,
                    70,
                    "Friend",
                    new List<string> { "sarcastic", "blunt" }
                )
            );

            test_npc.NpcAffections.SocialPerception = new SocialStanding(
                90,
                new List<string> { "lucio" },
                new List<string> { "dracula" }
            );

            PersonalityMapper personalityMapper = new PersonalityMapper();
            IdentityMapper identityMapper = new IdentityMapper();
            AffectionMapper affectionMapper = new AffectionMapper();

            var testEnvironment = atlas.GetEnvironmentManager().CreateEnvironment
            (
                "test_environment",
                "Test Environment",
                "planet",
                "This is a test environment created to demonstrate the functionality of the Atlas system. It serves as a placeholder for testing purposes.",
                new List<string> { "test", "environment", "placeholder" },
                "This test environment is designed to showcase the capabilities of the Atlas system. It is not intended for actual gameplay but rather for testing and development purposes.",
                new Dictionary<string, Location>
                {
                    { "test_location", new Location("test_location", "Test Location", "Test Type", "This is a test location within the test environment.", new List<string> { "test", "location" }) }
                }
            );

            var testRace = atlas.GetRaceManager().CreateRace
            (
                "test_race",
                "Test Race",
                new RaceDescription
                (
                    "This is a test",
                    "This is a test",
                    "This is a test",
                    "This is a test"
                ),
                "This is a test appearance",
                "This is a test lore"
            );

            var testRace2 = atlas.GetRaceManager().CreateRace
            (
                "test_race_2",
                "Test Race2",
                new RaceDescription
                (
                    "This is a test2",
                    "This is a test2",
                    "This is a test2",
                    "This is a test2"
                ),
                "This is a test appearance2",
                "This is a test lore2"
            );
            var npcDTO = new NPC
            {
                NPCId = test_npc.GetNPCID(),
                NpcIdentity = identityMapper.ToDTO(test_npc.NpcIdentity),
                NpcPersonality = personalityMapper.ToDTO(test_npc.NpcPersonality),
                NpcAffections = affectionMapper.ToDTO(test_npc.NpcAffections)
            };

            

            UniverseMapper universeMapper = new UniverseMapper();
            UniverseRacesMapper racesMapper = new UniverseRacesMapper();

            var environmentDTO = universeMapper.ToDTO(atlas.GetEnvironmentManager().EnvironmentDatabase);

            var racesDTO = racesMapper.ToDTO(atlas.GetRaceManager().RaceDatabase);

            var settings = new JsonSerializerSettings
            {
                // Formata o JSON com quebras de linha e indentação para facilitar a leitura
                Formatting = Formatting.Indented,
                // Ignora propriedades com valor nulo para um JSON mais limpo
                NullValueHandling = NullValueHandling.Ignore
            };

            // 2. Serialize o objeto DTO para uma string JSON
            string npcJsonString = JsonConvert.SerializeObject(npcDTO, settings);

            string environmentJsonString = JsonConvert.SerializeObject(environmentDTO, settings);

            string racesJsonString = JsonConvert.SerializeObject(racesDTO, settings);

            Debug.WriteLine("Serialized NPC JSON:");
            Debug.WriteLine(npcJsonString);

            Debug.WriteLine("Serialized Universe JSON:");
            Debug.WriteLine(environmentJsonString);

            Debug.WriteLine("Serialized Universe Races JSON:");
            Debug.WriteLine(racesJsonString);

            NPC deserializedNpc = JsonConvert.DeserializeObject<NPC>(npcJsonString);

            atlas.GetCharacterManager().CreateNPC(
                                                    "test_deserialized",
                                                    identityMapper.FromDTO(deserializedNpc.NpcIdentity),
                                                    personalityMapper.FromDTO(deserializedNpc.NpcPersonality),
                                                    affectionMapper.FromDTO(deserializedNpc.NpcAffections)
                                                 );

            var created_npc = atlas.GetCharacterManager().GetNPCBrain("test_deserialized");

            Debug.WriteLine("Deserialized NPC:");

            Debug.WriteLine($"NPC ID: {created_npc.GetNPCID()}");

            Debug.WriteLine($"NPC Name: {created_npc.NpcIdentity.NpcName}");
            Debug.WriteLine($"NPC OCEAN: {created_npc.NpcPersonality.oceanPersonality.Openness}");
            Debug.WriteLine($"NPC Biography: {created_npc.NpcIdentity.BiographyFull}");

            TestSaver saver = new TestSaver();

            atlas.SetFileStorageSystem(saver);

            atlas.SaveSystemData(0, "test", npcJsonString);

            atlas.SaveSystemData(1, "a", racesJsonString);

            string loadedJson = atlas.LoadSystemData(0, "rosa");

            Debug.WriteLine($"Loaded NPC JSON:{loadedJson}");

            /*RaceFactory raceFactory = new RaceFactory();
            EnvironmentFactory environmentFactory = new EnvironmentFactory();
            CharacterFactory characterFactory = new CharacterFactory(new TestSerializer());
            CommunicationSystem communicator = new CommunicationSystem(characterFactory);*/

            /*Debug.WriteLine("--- Iniciando Teste de Geração de Prompt de NPC ---");

            CharacterFactory characterFactory = new CharacterFactory();
            CommunicationSystem communicator = new CommunicationSystem(characterFactory);*/

            // 1. Criar alguns Documentos
            /*Document docGenetica01 = new Document(
                "genetics_dna",
                "Fundamentos de Genética — Volume 1",
                "Livro base sobre cinemática e leis da física. Contém informações essenciais sobre movimento, força e energia.",
                "The DNA, or deoxyribonucleic acid, is a fundamental nucleic acid that serves as the hereditary material in all known organisms, including viruses. Its structure is a double helix composed of two long polymer chains of nucleotides, which are held together by hydrogen bonds. This intricate molecular architecture allows DNA to store biological information in a sequence of bases (adenine, guanine, cytosine, and thymine). This information is duplicated through a process called replication and can be transcribed into RNA and translated into proteins, forming the central dogma of molecular biology. The precise sequence of nucleotides dictates the genetic code, providing the blueprint for cellular function, organism development, and reproduction.",
                "knowledge_base/fisica_vol1.pdf",
                new List<string> { "fisica", "cinematica", "dinamica" }
            );

            Document docGenetica02 = new Document(
                "genetics_genes",
                "Fundamentos de Genética — Volume 5",
                "Genes sao como receitas em um grande livro de culinaria. Cada um tem o codigo para fazer algo incr\u00edvel no seu corpo!",
                "A gene is defined as a basic physical and functional unit of heredity. It is a specific sequence of nucleotides in DNA or RNA that contains instructions for constructing a specific product, typically a protein or a functional RNA molecule. Genes are organized on chromosomes and their location is referred to as a locus. While some genes encode for the synthesis of proteins, others encode for functional RNA molecules that are not translated into proteins. The expression of a gene is a complex process involving transcription and translation, and it is regulated by various cellular mechanisms to ensure that the right products are made at the right time and in the right amounts.",
                "knowledge_base/fisica_vol5.pdf",
                new List<string> { "fisica", "quântica" }
            );

            Document docGenetica03 = new Document(
                "genetics_mitosis",
                "Regras das cores em Ondulatória, no jogo",
                "Livro com a lógica de como as cores interagem na física ondulatória dentro das regras específicas do jogo. Define a fusão de cores primárias e secundárias em ambientes de baixa luz.",
                "Mitosis is a critical phase of the cell cycle where a single eukaryotic cell divides into two genetically identical daughter cells. This process is divided into several distinct stages: prophase, metaphase, anaphase, and telophase, followed by cytokinesis. During mitosis, the cell's duplicated chromosomes are separated into two new nuclei, ensuring that each daughter cell receives a complete and identical set of chromosomes from the parent cell. This meticulous division is essential for asexual reproduction in single-celled organisms and for growth, tissue repair, and replacement in multicellular organisms. Any errors during this process can lead to chromosomal abnormalities, which are associated with various diseases.",
                "knowledge_base/game_documents/color_ondulatory.pdf",
                new List<string> { "jogo", "ondulatoria", "cores", "regras" }
            );

            Document docGenetica04 = new Document(
                "genetics_heredity",
                "Regras das cores em Ondulatória, no jogo",
                "Livro com a lógica de como as cores interagem na física ondulatória dentro das regras específicas do jogo. Define a fusão de cores primárias e secundárias em ambientes de baixa luz.",
                "Heredity is the biological process by which genetic information and traits are transmitted from parents to their offspring. This transmission occurs through the process of sexual or asexual reproduction, where genes from the parents are passed down to the next generation. The study of heredity, or genetics, involves understanding the mechanisms of gene expression, inheritance patterns (such as Mendelian inheritance), and genetic variation. Heredity is responsible for the similarities between parents and offspring, while genetic variation, influenced by factors like mutations and recombination, explains the differences. The principles of heredity are fundamental to understanding evolutionary biology and the diversity of life on Earth.",
                "knowledge_base/game_documents/color_ondulatory.pdf",
                new List<string> { "jogo", "ondulatoria", "cores", "regras" }
            );


            // 2. Criar instâncias de Knowledge (conceitos com documentos)
            List<Knowledge> scientistInitialKnowledge = new List<Knowledge>
            {
                new Knowledge("cells", new List<Document> { docGenetica03, docGenetica04 }),
                new Knowledge("dna-rna", new List<Document> { docGenetica01, docGenetica02 })
            };

            var rosaRelationships = new List<Relationship>
            {
                new Relationship("lucio", 80, 70, "Friend", new List<string> { "sarcastic", "blunt" }),
                new Relationship("einstein", 90, 85, "Mentor", new List<string> { "genius", "innovative" })
            };

            var rosaSocialStanding = new SocialStanding(90, new List<string> { "lucio", "einstein" }, new List<string> { "dracula" });

            Debug.WriteLine("\n--- Criando NPCs ---");
            Brain rosaBrain =
                characterFactory.CreateNPC(
                    "rosa",
                    new IdentitySystem(
                                            "Rosa Lovegood",
                                            "human",
                                            "rua_acasia",
                                            false,
                                            35,
                                            "Rosa é uma professora de genética apaixonada e animada, conhecida por sua capacidade de tornar conceitos complexos acessíveis e envolventes. Sua abordagem amigável e divertida cativa os alunos.",
                                            "Rosa Lovegood descobriu seu amor pela ciência na infância, fascinada pelos mistérios da vida em nível microscópico. Formou-se com honras em genética e dedicou anos à pesquisa, mas encontrou sua verdadeira vocação no ensino. Acredita que o conhecimento deve ser compartilhado com entusiasmo e que a curiosidade é o maior motor da descoberta. Sua energia contagiante e seu bom humor são marcas registradas em sala de aula, inspirando muitos a seguir o caminho da ciência. Ela se esforça para criar um ambiente de aprendizado leve e acolhedor, sempre com um sorriso no rosto, embora possa ser surpreendentemente firme quando necessário.",
                                            "Teacher",
                                            "Mulher de estatura média, com cabelos castanhos ondulados e olhos expressivos. Seu sorriso é fácil e acolhedor, e ela gesticula bastante ao falar, transmitindo entusiasmo. Gosta de usar roupas coloridas e confortáveis que refletem sua personalidade vibrante.",
                                            new List<string> 
                                            {
                                                "O conhecimento é um tesouro a ser compartilhado.",
                                                "A curiosidade move o mundo.",
                                                "Errar faz parte do processo de aprendizado.",
                                                "Todos podem entender ciência se for bem explicada."
                                            },
                                            new List<string>
                                            {
                                                "Cha Preto com leite.",
                                                "Bolinho de cenoura."
                                            },
                                            new List<string>
                                            {
                                                "Perda de tempo"
                                            }
                                        ),
                    scientistInitialKnowledge,
                    new PersonalitySystem(
                                            new OCEAN(
                                                        90,
                                                        70,
                                                        85,
                                                        95,
                                                        20
                                                      ),
                                            new SCHWARTZ(
                                                            90,
                                                            90,
                                                            70,
                                                            60,
                                                            20,
                                                            50,
                                                            40,
                                                            30,
                                                            90,
                                                            80
                                                         ),
                                            new DialogStyle(
                                                                    "enthusiastic and inspiring", 
                                                                    30,
                                                                    "acessible, full of analogies and metaphors",
                                                                    ""
                                                                )
                                         ),
                    new AffectionSystem(
                                            rosaRelationships,
                                            rosaSocialStanding
                                       )
            );

            DialogStyle lucioDialogStyle = new DialogStyle(
                "sarcastic, blunt, dry humor", // Tom direto e seco
                80, // Mais formal/distante, embora com humor próprio
                "technical, cynical, analytical", // Vocabulário técnico e analítico
                "Dr. Gregory House" // A referência explícita ao House
            );

            PersonalitySystem lucioPersonality = new PersonalitySystem(
                new OCEAN(80, 85, 20, 15, 70), // Open, Consc, Extra, Agree, Neuro
                new SCHWARTZ(95, 60, 40, 90, 50, 40, 10, 10, 20, 30), // Self-Dir, Stim, Hedon, Achiev, Power, Secur, Conf, Trad, Benev, Univ
                lucioDialogStyle
            );

            PersonalitySystem alternateRosaPersonality = new PersonalitySystem(
                new OCEAN(80, 85, 20, 15, 70), // Open, Consc, Extra, Agree, Neuro
                new SCHWARTZ(95, 60, 40, 90, 50, 40, 10, 10, 20, 30), // Self-Dir, Stim, Hedon, Achiev, Power, Secur, Conf, Trad, Benev, Univ
                new DialogStyle(
                        "enthusiastic and inspiring",
                        30,
                        "acessible, full of analogies and metaphors",
                        ""
                    )
            );

            var lucioRelationships = new List<Relationship>
            {
                new Relationship("rosa", 80, 70, "Friend", new List<string> { "extrovert", "intelligent" })
            };

            var lucioSocialStanding = new SocialStanding(70, new List<string> { "rosa" }, new List<string>());
           

            Brain lucioNpcBrain = characterFactory.CreateNPC(
                "lucio", 
                new IdentitySystem(
                        "Lucio House",
                        "human",
                        "rua_acasia",
                        true,
                        55,
                        "Lucio é um médico especialista em genética, conhecido por seu humor sarcástico e sua abordagem direta. Ele é um pensador crítico e não tem paciência para tolices, mas é extremamente competente em sua área.",
                        "Lucio House é um renomado geneticista que se destacou por sua abordagem direta e cínica à medicina. Desde jovem, mostrou interesse pela biologia, mas sua verdadeira paixão pela genética surgiu durante a faculdade de medicina. Ele é conhecido por sua mente afiada e seu humor sarcástico, o que o torna tanto admirado quanto temido por seus colegas. Lucio acredita que a verdade deve ser dita, não importa quão dura seja, e isso o leva a ser muitas vezes visto como insensível. No entanto, sua competência e dedicação à ciência são inegáveis, e ele é respeitado por suas contribuições significativas ao campo da genética.",
                        "Geneticist",
                        "Homem de estatura média, com cabelos grisalhos desgrenhados e barba por fazer. Seus olhos azuis, frequentemente semicerrados, carregam um ar de sarcasmo e inteligência penetrante. Anda com uma leve mancada, apoiando-se em uma bengala, mas sua presença é inegável.",
                        new List<string>
                        {
                            "A verdade é absoluta, não importa o quão dolorosa ela seja.",
                            "Todos mentem, a ciência busca os fatos.",
                            "A estupidez é a maior praga da humanidade.",
                            "Resultados práticos superam boas intenções vazias."
                        },
                        new List<string>
                        {
                            "Cafe Preto."
                        },
                        new List<string>
                        {
                            "Contar mentiras"
                        }
                ), 
                scientistInitialKnowledge, 
                lucioPersonality, 
                new AffectionSystem(
                                        lucioRelationships, 
                                        lucioSocialStanding
                                    )
            );


            Debug.WriteLine("\n--- Gerando JSON do Prompt para NPC_Einstein ---");
            characterFactory.SaveCharacterAsJSON("rosa");
            characterFactory.SaveCharacterAsJSON("lucio");*/


            //communicator.SendPromptToGEMINI("rosa-alternate");

            //characterFactory.LoadNPC("rosa");
            //characterFactory.LoadNPC("lucio");

            /*Location CoffeShop = new Location(
                "coffe_shop",
                "Cafeteria do Bairro",
                "Coffe Shop",
                "Uma pequena e aconchegante cafeteria localizada no coração do bairro, conhecida por seu café fresco e ambiente acolhedor. A cafeteria é um local de encontro popular entre os moradores locais, oferecendo uma variedade de cafés, chás e doces caseiros. O ambiente é decorado com móveis de madeira rústica e quadros de artistas locais nas paredes. Há mesas internas e externas, permitindo que os clientes desfrutem de suas bebidas enquanto observam a vida do bairro passar.",
                new List<string> { "cafe", "encontro", "social" }
            );

            Location GrandSquare = new Location(
                "grand_square",
                "Central Square",
                "Common Plaza",
                "Uma vasta praça central cercada por edifícios históricos e monumentos. É um ponto de encontro popular para eventos comunitários, feiras e celebrações. A praça é adornada com jardins bem cuidados, fontes e bancos, proporcionando um espaço agradável para relaxar e socializar. Frequentemente, artistas de rua se apresentam aqui, adicionando vida e cor ao ambiente.",
                new List<string> { "encontro", "evento", "social" }
            );

            Location Library = new Location(
                "library",
                "Biblioteca Municipal",
                "Public Library",
                "Uma biblioteca pública bem equipada, oferecendo uma vasta coleção de livros, periódicos e recursos digitais. É um local tranquilo, ideal para estudo e pesquisa. A biblioteca também organiza eventos culturais, palestras e clubes de leitura, promovendo a educação e o envolvimento comunitário. O ambiente é calmo e acolhedor, com áreas de leitura confortáveis e acesso à internet.",
                new List<string> { "educacao", "cultura", "social" }
            );

            Location Wallmart = new Location(
                "wallmart",
                "Supermercado Wallmart",
                "Supermarket",
                "Um grande supermercado que oferece uma ampla variedade de produtos, desde alimentos frescos até eletrônicos e roupas. É um local conveniente para compras diárias, com preços competitivos e promoções frequentes. O supermercado é bem iluminado e organizado, facilitando a navegação pelos corredores. Há também uma seção de produtos locais e orgânicos, promovendo a sustentabilidade.",
                new List<string> { "compras", "conveniencia", "social" }
            );

            Dictionary<string, Location> AcasiaLocations = new Dictionary<string, Location>
            {
                { CoffeShop.LocationID, CoffeShop },
                { GrandSquare.LocationID, GrandSquare }
            };

            Dictionary<string, Location> SolisLocations = new Dictionary<string, Location>
            {
                { Library.LocationID, Library },
                { Wallmart.LocationID, Wallmart }
            };

            WorldEnvironment RuaAcasia = new WorldEnvironment(
                "rua_acasia",
                "Rua Acasia",
                "Street",
                "Uma rua tranquila e arborizada, conhecida por suas casas coloridas e jardins bem cuidados. É um local residencial popular, com uma comunidade amigável e ativa. A rua é cercada por árvores de acácia, que florescem em cores vibrantes durante a primavera. Há calçadas largas para caminhadas e ciclovias, tornando-a ideal para passeios a pé ou de bicicleta.",
                new List<string> { "rua", "residencial", "tranquilo" },
                "A Rua Acácia é o coração de uma comunidade coesa, onde os moradores se conhecem e participam ativamente da vida local. Há um forte senso de vizinhança e pertencimento. É comum ver crianças brincando nas calçadas largas e nos pequenos jardins da frente, sob o olhar atento dos adultos. Os moradores organizam eventos regulares, como festas de rua no verão, bazares comunitários na praça próxima e mutirões para manutenção dos jardins públicos e das ciclovias. Existe uma rede informal de apoio, onde vizinhos ajudam uns aos outros com pequenos favores, como cuidar de animais de estimação ou buscar correspondências durante viagens. A segurança é percebida como alta, em parte devido à vigilância comunitária e à baixa rotatividade de moradores. Conversas casuais nos passeios com animais de estimação ou durante o regar dos jardins são a norma.",
                AcasiaLocations
            );

            WorldEnvironment RuaSolis = new WorldEnvironment(
                "rua_solis",
                "Rua Solis",
                "Street",
                "A Rua Solis é uma artéria vibrante e movimentada da cidade, pulsando com a energia do comércio e do fluxo constante de pessoas e veículos. Suas calçadas são largas, mas frequentemente cheias, ladeadas por uma diversidade de estabelecimentos que vão desde pequenas lojas de conveniência até grandes redes varejistas. No coração da Rua Solis, encontra-se a Biblioteca Municipal \"Saber Aberto\", um oásis de tranquilidade e conhecimento, contrastando com a agitação externa. A poucos quarteirões de distância, ergue-se o imponente Walmart, que atrai um público vasto e diversificado, gerando um tráfego considerável. Apesar do barulho constante e do ritmo acelerado, a Rua Solis é um ponto de encontro e de passagem essencial para muitos moradores, oferecendo uma gama completa de serviços e produtos. O transporte público é intenso, com pontos de ônibus movimentados e táxis circulando.",
                new List<string> { "rua", "comercial", "movimentado" },
                "O contexto social da Rua Solis é marcado pela diversidade e transitoriedade. É um caldeirão de diferentes grupos sociais e econômicos que convergem por motivos variados: compras no Walmart, estudo ou acesso a serviços na biblioteca, trabalho nas lojas ou simples deslocamento. As interações são mais efêmeras e transacionais do que na Rua Acácia; as pessoas se cruzam, mas raramente formam laços profundos. Na Biblioteca Municipal, o ambiente social é mais focado e silencioso, com estudantes, pesquisadores e leitores buscando concentração, embora os arredores da biblioteca possam ser pontos de encontro informais. O Walmart é um microcosmo da sociedade, onde consumidores apressados se misturam, e a dinâmica social é ditada pela busca por produtos e pela eficiência das compras. Há um senso de anonimato predominante; as pessoas são mais observadoras do que participantes ativas em um coletivo. Os eventos sociais são raros e, quando ocorrem, são geralmente promoções comerciais ou feiras organizadas pela prefeitura, não por iniciativa da comunidade local.",
                SolisLocations
            );

            environmentFactory.AddEnvironment(RuaAcasia);
            environmentFactory.AddEnvironment(RuaSolis);

            environmentFactory.SaveAllEnvironments();

            Race HighElf = raceFactory.CreateRace("elf_h",
                                   "High Elf",
                                   raceFactory.CreateRaceDescription(
                                       "Uma raça antiga e mística, profundamente conectada com as florestas e a natureza. Elfos são seres de notável longevidade e agilidade, possuindo uma ligação intrínseca e poderosa com a magia. Distinguem-se por sua beleza etérea e uma sabedoria que transcende gerações, acumulada ao longo de suas vastas existências.",
                                       "A cultura élfica valoriza acima de tudo a harmonia com o ambiente natural, a arte, a música e a busca incessante pelo conhecimento. Eles respeitam profundamente a ancestralidade e transmitem saberes através de tradições orais e rituais antigos. A paciência e a contemplação são virtudes altamente estimadas.",
                                       "Elfos tendem a ser reservados e cautelosos com estranhos, especialmente com raças mais jovens e impulsivas. Preferem viver em comunidades isoladas e harmoniosas, muitas vezes ocultas nas florestas mais antigas. Quando se abrem, demonstram lealdade profunda e um senso de comunidade inabalável. Raramente buscam confrontos diretos, preferindo a diplomacia ou a evasão.",
                                       "São exímios em magia, com aptidão natural para encantamentos, cura e controle elemental. Possuem habilidades superiores em arquearia e caça, movendo-se com silêncio e precisão inigualáveis. Sua conexão com a fauna e flora lhes confere um dom para a domesticação de animais e a manipulação de plantas."
                                   ),
                                   "Elfos possuem orelhas pontudas, pele clara e olhos brilhantes que refletem a luz de maneira única. Sua estatura é geralmente mais alta do que a média humana, e seus movimentos são graciosos e fluidos. Vestem-se com roupas leves e naturais, muitas vezes adornadas com elementos da floresta",
                                   "Elfos são conhecidos por sua habilidade em magia, especialmente em encantamentos e cura. Eles também são exímios arqueiros e caçadores, com uma conexão especial com a fauna e flora ao seu redor. Sua cultura valoriza a harmonia com a natureza e o conhecimento"
            );

            Race Orc = raceFactory.CreateRace("orc",
                                   "Orc",
                                   raceFactory.CreateRaceDescription(
                                       "Uma raça robusta e pragmática, forjada em terras áridas e conflitos constantes. Orcs são conhecidos por sua força física formidável, resiliência e uma cultura tribal que valoriza a honra em combate e a força da comunidade. Embora frequentemente mal compreendidos, possuem uma lealdade feroz aos seus clãs.",
                                       "A cultura orcish prioriza a força, a honra, a lealdade ao clã e a sobrevivência em ambientes hostis. Eles respeitam a hierarquia baseada na força e na sabedoria dos líderes de clã. A arte da guerra e a forja de armas são consideradas formas elevadas de expressão cultural e sobrevivência.",
                                       "Orcs são geralmente diretos e, por vezes, agressivos em sua comunicação. Tendem a ser desconfiados de forasteiros e raças não-orcish, mas formam laços inquebráveis com aqueles que provam seu valor ou pertencem ao seu clã. A hospitalidade é rara, mas a aliança forjada em batalha é sagrada. Preferem a ação à diplomacia excessiva.",
                                       "São exímios guerreiros, proficientes no uso de armas pesadas e táticas de combate corpo a corpo. Possuem grande resistência à dor e à fadiga. Habilidades em forja, caça de grandes feras e construção de fortificações são comuns. Alguns possuem uma conexão rudimentar com magias xamânicas."
                                   ),
                                   "Orcs possuem pele esverdeada ou acinzentada e mandíbulas proeminentes com presas inferiores que se projetam. Sua estatura é geralmente robusta e musculosa, com ombros largos e uma postura imponente. Os olhos são frequentemente pequenos e vermelhos ou amarelos. Vestem armaduras pesadas e peles de animais, adornadas com cicatrizes de batalha e troféus.",
                                   "Os Orcs surgiram das profundezas da terra em eras de grande conflito, forjando suas tribos em meio a vulcões e desertos. Sua história é marcada por migrações em massa, batalhas territoriais e a busca incessante por um lugar onde possam prosperar. Conhecidos por seu poderio militar, construíram impérios tribais que desafiaram as maiores civilizações, apesar de sua fama de selvagens."
            );

            Race Dwarf = raceFactory.CreateRace("dwarf",
                                   "Dwarf",
                                   raceFactory.CreateRaceDescription(
                                       "Uma raça robusta e resiliente, nascida das montanhas e com uma conexão inabalável com a pedra e o metal. Anões são mestres artesãos, mineiros e guerreiros, conhecidos por sua teimosia, honestidade e apreço por tradições milenares. Possuem uma longa vida e uma grande paixão por seus clãs e sua ancestralidade.",
                                       "A cultura anã valoriza a honra, o trabalho árduo, a lealdade ao clã, a perícia artesanal e a riqueza material (especialmente metais preciosos e gemas). Respeitam a palavra dada, a honestidade e a sabedoria dos anciãos. A tradição e a história de seu povo são reverenciadas acima de tudo.",
                                       "Anões podem ser rudes e desconfiados de forasteiros no início, mas uma vez que sua confiança é ganha, são leais amigos e aliados. Preferem a companhia de seu próprio povo em fortalezas subterrâneas e têm pouca paciência para frivolidades ou mentiras. Sua comunicação é direta e sem rodeios, por vezes parecendo brusca.",
                                       "São incomparáveis em mineração, metalurgia e forja, capazes de criar armas e armaduras de qualidade lendária. Possuem grande resistência física, especialmente contra venenos e magia. São guerreiros formidáveis em espaços fechados e mestres na construção de túneis e fortalezas. Muitos têm aptidão para engenharia mecânica e tática de cerco."
                                   ),
                                   "Anões possuem uma estatura compacta e atarracada, mas são incrivelmente fortes e musculosos. Sua pele é geralmente morena ou bronzeada, e seus cabelos e barbas (que são muito valorizados, especialmente pelos machos) variam de castanho a ruivo, por vezes pretos ou grisalhos. Seus olhos são frequentemente pequenos, mas penetrantes, em tons de azul, cinza ou marrom. Vestem roupas práticas e resistentes, muitas vezes com armaduras de metal e ferramentas presas ao corpo.",
                                   "Os Anões têm sua origem nas profundezas das montanhas mais antigas, onde construíram vastas cidades subterrâneas adornadas com sua arte e engenharia. Sua história é uma saga de grandes minerações, descoberta de tesouros lendários e guerras épicas contra criaturas das profundezas. Guardiões de segredos antigos e protetores de reinos sob a terra, eles mantêm uma memória coletiva de seus ancestrais que guia cada aspecto de sua existência."
            );

            Race Human = raceFactory.CreateRace(
                "human",
                "Humano", 
                raceFactory.CreateRaceDescription(
                    "Uma raça versátil e adaptável, com uma capacidade inigualável de inovação e colonização. Humanos são conhecidos por sua resiliência, ambição e uma vasta diversidade cultural que os permite prosperar em quase todos os ambientes.", // general_overview
                    "A cultura humana valoriza a diversidade, o progresso tecnológico e social, a liberdade individual e a formação de grandes sociedades. Eles têm uma forte inclinação para a exploração, o comércio e a busca por conhecimento, muitas vezes superando limites com ousadia.", // cultural_values
                    "Humanos apresentam uma vasta gama de comportamentos sociais, desde a cooperação em grandes impérios até a rivalidade entre nações. São geralmente expressivos e curiosos sobre o desconhecido, capazes de formar laços profundos ou de trair por ganância. Sua comunicação é direta, mas também adaptável a nuances sociais.", // social_behavior
                    "Possuem uma notável adaptabilidade física e mental. São proficientes em uma vasta gama de habilidades, desde a engenharia e construção complexa até o comércio e a diplomacia. Sua capacidade de aprendizado rápido e de inovar em tecnologia os torna formidáveis em diversos campos, embora não possuam habilidades mágicas inatas ou força bruta excepcional de outras raças." // typical_abilities_and_skills
                ),
                "Humanos apresentam uma diversidade física notável, variando amplamente em altura, tom de pele, cor de cabelo e estrutura corporal. Suas feições são proporcionais e eles tendem a ser atléticos. Não possuem características físicas distintivas como orelhas pontudas, mas sua expressividade facial e corporal é muito desenvolvida. Vestem-se com uma grande variedade de estilos, refletindo suas culturas e tecnologias diversas.", // race_appearance_description
                "A história humana é marcada por ascensões e quedas de impérios, inovações tecnológicas revolucionárias e exploração incansável. Desde a forja das primeiras ferramentas até a construção de megacidades, os humanos moldaram o mundo de maneiras profundas, enfrentando desafios internos e externos com notável resiliência e, por vezes, grande brutalidade. Sua busca incessante por progresso os levou a colonizar novos territórios e a desvendar os segredos do universo." // race_lore
            );

            raceFactory.AddRace(Human);
            raceFactory.AddRace(HighElf);
            raceFactory.AddRace(Orc);
            raceFactory.AddRace(Dwarf);

            raceFactory.SaveAllRaces();*/

            /*characterFactory.LoadNPC("rosa");
            characterFactory.LoadNPC("lucio");*/

            //await communicator.SendPromptToGEMINI("lucio", "O que você acha da Rosa, sua amiga?", "AIzaSyCP8mQ3vaTcgs9sDl7p2xuFzwqlPyxQHe4");
            //Console.ReadLine();
        }
    }
}