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
            
            Debug.WriteLine("--- Iniciando Teste de Gera��o de Prompt de NPC ---");

            CharacterManagerSystem characterFactory = new CharacterManagerSystem();
            CommunicationSystem communicator = new CommunicationSystem();
            
            // 1. Criar alguns Documentos
            /*Document docGenetica01 = new Document(
                "genetics_dna",
                "Fundamentos de Gen�tica � Volume 1",
                "Livro base sobre cinem�tica e leis da f�sica. Cont�m informa��es essenciais sobre movimento, for�a e energia.",
                "The DNA, or deoxyribonucleic acid, is a fundamental nucleic acid that serves as the hereditary material in all known organisms, including viruses. Its structure is a double helix composed of two long polymer chains of nucleotides, which are held together by hydrogen bonds. This intricate molecular architecture allows DNA to store biological information in a sequence of bases (adenine, guanine, cytosine, and thymine). This information is duplicated through a process called replication and can be transcribed into RNA and translated into proteins, forming the central dogma of molecular biology. The precise sequence of nucleotides dictates the genetic code, providing the blueprint for cellular function, organism development, and reproduction.",
                "knowledge_base/fisica_vol1.pdf",
                new List<string> { "fisica", "cinematica", "dinamica" }
            );

            Document docGenetica02 = new Document(
                "genetics_genes",
                "Fundamentos de Gen�tica � Volume 5",
                "Genes sao como receitas em um grande livro de culinaria. Cada um tem o codigo para fazer algo incr\u00edvel no seu corpo!",
                "A gene is defined as a basic physical and functional unit of heredity. It is a specific sequence of nucleotides in DNA or RNA that contains instructions for constructing a specific product, typically a protein or a functional RNA molecule. Genes are organized on chromosomes and their location is referred to as a locus. While some genes encode for the synthesis of proteins, others encode for functional RNA molecules that are not translated into proteins. The expression of a gene is a complex process involving transcription and translation, and it is regulated by various cellular mechanisms to ensure that the right products are made at the right time and in the right amounts.",
                "knowledge_base/fisica_vol5.pdf",
                new List<string> { "fisica", "qu�ntica" }
            );

            Document docGenetica03 = new Document(
                "genetics_mitosis",
                "Regras das cores em Ondulat�ria, no jogo",
                "Livro com a l�gica de como as cores interagem na f�sica ondulat�ria dentro das regras espec�ficas do jogo. Define a fus�o de cores prim�rias e secund�rias em ambientes de baixa luz.",
                "Mitosis is a critical phase of the cell cycle where a single eukaryotic cell divides into two genetically identical daughter cells. This process is divided into several distinct stages: prophase, metaphase, anaphase, and telophase, followed by cytokinesis. During mitosis, the cell's duplicated chromosomes are separated into two new nuclei, ensuring that each daughter cell receives a complete and identical set of chromosomes from the parent cell. This meticulous division is essential for asexual reproduction in single-celled organisms and for growth, tissue repair, and replacement in multicellular organisms. Any errors during this process can lead to chromosomal abnormalities, which are associated with various diseases.",
                "knowledge_base/game_documents/color_ondulatory.pdf",
                new List<string> { "jogo", "ondulatoria", "cores", "regras" }
            );

            Document docGenetica04 = new Document(
                "genetics_heredity",
                "Regras das cores em Ondulat�ria, no jogo",
                "Livro com a l�gica de como as cores interagem na f�sica ondulat�ria dentro das regras espec�ficas do jogo. Define a fus�o de cores prim�rias e secund�rias em ambientes de baixa luz.",
                "Heredity is the biological process by which genetic information and traits are transmitted from parents to their offspring. This transmission occurs through the process of sexual or asexual reproduction, where genes from the parents are passed down to the next generation. The study of heredity, or genetics, involves understanding the mechanisms of gene expression, inheritance patterns (such as Mendelian inheritance), and genetic variation. Heredity is responsible for the similarities between parents and offspring, while genetic variation, influenced by factors like mutations and recombination, explains the differences. The principles of heredity are fundamental to understanding evolutionary biology and the diversity of life on Earth.",
                "knowledge_base/game_documents/color_ondulatory.pdf",
                new List<string> { "jogo", "ondulatoria", "cores", "regras" }
            );


            // 2. Criar inst�ncias de Knowledge (conceitos com documentos)
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
                80, // Mais formal/distante, embora com humor pr�prio
                "technical, cynical, analytical", // Vocabul�rio t�cnico e anal�tico
                "Dr. Gregory House" // A refer�ncia expl�cita ao House
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
                                       "Uma ra�a antiga e m�stica, profundamente conectada com as florestas e a natureza. Elfos s�o seres de not�vel longevidade e agilidade, possuindo uma liga��o intr�nseca e poderosa com a magia. Distinguem-se por sua beleza et�rea e uma sabedoria que transcende gera��es, acumulada ao longo de suas vastas exist�ncias.",
                                       "A cultura �lfica valoriza acima de tudo a harmonia com o ambiente natural, a arte, a m�sica e a busca incessante pelo conhecimento. Eles respeitam profundamente a ancestralidade e transmitem saberes atrav�s de tradi��es orais e rituais antigos. A paci�ncia e a contempla��o s�o virtudes altamente estimadas.",
                                       "Elfos tendem a ser reservados e cautelosos com estranhos, especialmente com ra�as mais jovens e impulsivas. Preferem viver em comunidades isoladas e harmoniosas, muitas vezes ocultas nas florestas mais antigas. Quando se abrem, demonstram lealdade profunda e um senso de comunidade inabal�vel. Raramente buscam confrontos diretos, preferindo a diplomacia ou a evas�o.",
                                       "S�o ex�mios em magia, com aptid�o natural para encantamentos, cura e controle elemental. Possuem habilidades superiores em arquearia e ca�a, movendo-se com sil�ncio e precis�o inigual�veis. Sua conex�o com a fauna e flora lhes confere um dom para a domestica��o de animais e a manipula��o de plantas."
                                   ),
                                   "Elfos possuem orelhas pontudas, pele clara e olhos brilhantes que refletem a luz de maneira �nica. Sua estatura � geralmente mais alta do que a m�dia humana, e seus movimentos s�o graciosos e fluidos. Vestem-se com roupas leves e naturais, muitas vezes adornadas com elementos da floresta",
                                   "Elfos s�o conhecidos por sua habilidade em magia, especialmente em encantamentos e cura. Eles tamb�m s�o ex�mios arqueiros e ca�adores, com uma conex�o especial com a fauna e flora ao seu redor. Sua cultura valoriza a harmonia com a natureza e o conhecimento"
            );

            Race Orc = raceFactory.CreateRace("orc",
                                   "Orc",
                                   raceFactory.CreateRaceDescription(
                                       "Uma ra�a robusta e pragm�tica, forjada em terras �ridas e conflitos constantes. Orcs s�o conhecidos por sua for�a f�sica formid�vel, resili�ncia e uma cultura tribal que valoriza a honra em combate e a for�a da comunidade. Embora frequentemente mal compreendidos, possuem uma lealdade feroz aos seus cl�s.",
                                       "A cultura orcish prioriza a for�a, a honra, a lealdade ao cl� e a sobreviv�ncia em ambientes hostis. Eles respeitam a hierarquia baseada na for�a e na sabedoria dos l�deres de cl�. A arte da guerra e a forja de armas s�o consideradas formas elevadas de express�o cultural e sobreviv�ncia.",
                                       "Orcs s�o geralmente diretos e, por vezes, agressivos em sua comunica��o. Tendem a ser desconfiados de forasteiros e ra�as n�o-orcish, mas formam la�os inquebr�veis com aqueles que provam seu valor ou pertencem ao seu cl�. A hospitalidade � rara, mas a alian�a forjada em batalha � sagrada. Preferem a a��o � diplomacia excessiva.",
                                       "S�o ex�mios guerreiros, proficientes no uso de armas pesadas e t�ticas de combate corpo a corpo. Possuem grande resist�ncia � dor e � fadiga. Habilidades em forja, ca�a de grandes feras e constru��o de fortifica��es s�o comuns. Alguns possuem uma conex�o rudimentar com magias xam�nicas."
                                   ),
                                   "Orcs possuem pele esverdeada ou acinzentada e mand�bulas proeminentes com presas inferiores que se projetam. Sua estatura � geralmente robusta e musculosa, com ombros largos e uma postura imponente. Os olhos s�o frequentemente pequenos e vermelhos ou amarelos. Vestem armaduras pesadas e peles de animais, adornadas com cicatrizes de batalha e trof�us.",
                                   "Os Orcs surgiram das profundezas da terra em eras de grande conflito, forjando suas tribos em meio a vulc�es e desertos. Sua hist�ria � marcada por migra��es em massa, batalhas territoriais e a busca incessante por um lugar onde possam prosperar. Conhecidos por seu poderio militar, constru�ram imp�rios tribais que desafiaram as maiores civiliza��es, apesar de sua fama de selvagens."
            );

            Race Dwarf = raceFactory.CreateRace("dwarf",
                                   "Dwarf",
                                   raceFactory.CreateRaceDescription(
                                       "Uma ra�a robusta e resiliente, nascida das montanhas e com uma conex�o inabal�vel com a pedra e o metal. An�es s�o mestres artes�os, mineiros e guerreiros, conhecidos por sua teimosia, honestidade e apre�o por tradi��es milenares. Possuem uma longa vida e uma grande paix�o por seus cl�s e sua ancestralidade.",
                                       "A cultura an� valoriza a honra, o trabalho �rduo, a lealdade ao cl�, a per�cia artesanal e a riqueza material (especialmente metais preciosos e gemas). Respeitam a palavra dada, a honestidade e a sabedoria dos anci�os. A tradi��o e a hist�ria de seu povo s�o reverenciadas acima de tudo.",
                                       "An�es podem ser rudes e desconfiados de forasteiros no in�cio, mas uma vez que sua confian�a � ganha, s�o leais amigos e aliados. Preferem a companhia de seu pr�prio povo em fortalezas subterr�neas e t�m pouca paci�ncia para frivolidades ou mentiras. Sua comunica��o � direta e sem rodeios, por vezes parecendo brusca.",
                                       "S�o incompar�veis em minera��o, metalurgia e forja, capazes de criar armas e armaduras de qualidade lend�ria. Possuem grande resist�ncia f�sica, especialmente contra venenos e magia. S�o guerreiros formid�veis em espa�os fechados e mestres na constru��o de t�neis e fortalezas. Muitos t�m aptid�o para engenharia mec�nica e t�tica de cerco."
                                   ),
                                   "An�es possuem uma estatura compacta e atarracada, mas s�o incrivelmente fortes e musculosos. Sua pele � geralmente morena ou bronzeada, e seus cabelos e barbas (que s�o muito valorizados, especialmente pelos machos) variam de castanho a ruivo, por vezes pretos ou grisalhos. Seus olhos s�o frequentemente pequenos, mas penetrantes, em tons de azul, cinza ou marrom. Vestem roupas pr�ticas e resistentes, muitas vezes com armaduras de metal e ferramentas presas ao corpo.",
                                   "Os An�es t�m sua origem nas profundezas das montanhas mais antigas, onde constru�ram vastas cidades subterr�neas adornadas com sua arte e engenharia. Sua hist�ria � uma saga de grandes minera��es, descoberta de tesouros lend�rios e guerras �picas contra criaturas das profundezas. Guardi�es de segredos antigos e protetores de reinos sob a terra, eles mant�m uma mem�ria coletiva de seus ancestrais que guia cada aspecto de sua exist�ncia."
            );

            raceFactory.AddRace(HighElf);
            raceFactory.AddRace(Orc);
            raceFactory.AddRace(Dwarf);

            raceFactory.SaveAllRaces();*/

            raceFactory.LoadAllRaces();

            Race HighElf = raceFactory.RaceDatabase.GetRaceById("elf_h");
            Race Orc = raceFactory.RaceDatabase.GetRaceById("orc");
            Race Dwarf = raceFactory.RaceDatabase.GetRaceById("dwarf");

            Debug.WriteLine("\n--- Exibindo Ra�as Carregadas ---");
            Debug.WriteLine($"Ra�a: {HighElf.RaceName}");
            Debug.WriteLine($"Ra�a: {Orc.RaceName}");
            Debug.WriteLine($"Ra�a: {Dwarf.RaceName}");

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Console.ReadLine();
        }
    }
}