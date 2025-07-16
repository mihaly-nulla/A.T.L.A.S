using A.T.L.A.S.Factory.NPCs.CreationModule.systems;
using A.T.L.A.S.Factory.World.CreationModule.entities;
using A.T.L.A.S.Factory.World.CreationModule.systems;
using A.T.L.A.S.Heart.AffectionModule.entities;
using A.T.L.A.S.Heart.AffectionModule.systems;
using A.T.L.A.S.Heart.PersonalityModule.entities;
using A.T.L.A.S.Heart.PersonalityModule.systems;
using A.T.L.A.S.Mind.CommunicationModule.systems;
using A.T.L.A.S.Mind.KnowledgeModule.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace A.T.L.A.S
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            Debug.WriteLine("--- Iniciando Teste de Geração de Prompt de NPC ---");

            CharacterManagerSystem characterFactory = new CharacterManagerSystem();
            CommunicationSystem communicator = new CommunicationSystem();
            
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
                creator.CreateNPC(
                    "rosa",
                    "Rosa",
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
           

            Brain lucioNpcBrain = creator.CreateNPC("lucio", "Lucio", scientistInitialKnowledge, lucioPersonality, new AffectionSystem(lucioRelationships, lucioSocialStanding));


            Debug.WriteLine("\n--- Gerando JSON do Prompt para NPC_Einstein ---");
            creator.GenerateAndSaveJson("rosa");
            creator.GenerateAndSaveJson("lucio");*/


            //communicator.SendPromptToGEMINI("rosa-alternate");

            //characterFactory.LoadNPC("rosa");
            //characterFactory.LoadNPC("lucio");

            RaceManagerSystem raceFactory = new RaceManagerSystem();

            /*Race HighElf = raceFactory.CreateRace("elf_h",
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

            raceFactory.AddRace(HighElf);
            raceFactory.AddRace(Orc);
            raceFactory.AddRace(Dwarf);

            raceFactory.SaveAllRaces();*/

            raceFactory.LoadAllRaces();

            Race HighElf = raceFactory.RaceDatabase.GetRaceById("elf_h");
            Race Orc = raceFactory.RaceDatabase.GetRaceById("orc");
            Race Dwarf = raceFactory.RaceDatabase.GetRaceById("dwarf");

            Debug.WriteLine("\n--- Exibindo Raças Carregadas ---");
            Debug.WriteLine($"Raça: {HighElf.RaceName}");
            Debug.WriteLine($"Raça: {Orc.RaceName}");
            Debug.WriteLine($"Raça: {Dwarf.RaceName}");

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Console.ReadLine();
        }
    }
}