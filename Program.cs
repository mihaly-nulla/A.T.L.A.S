using A.T.L.A.S.Factory.NPCs.CreationModule.systems;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.race;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.region;
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

            CharacterFactory characterFactory = new CharacterFactory();
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

            RaceFactory raceFactory = new RaceFactory();
            EnvironmentFactory environmentFactory = new EnvironmentFactory();

            /*Location CoffeShop = new Location(
                "coffe_shop",
                "Cafeteria do Bairro",
                "Coffe Shop",
                "Uma pequena e aconchegante cafeteria localizada no cora��o do bairro, conhecida por seu caf� fresco e ambiente acolhedor. A cafeteria � um local de encontro popular entre os moradores locais, oferecendo uma variedade de caf�s, ch�s e doces caseiros. O ambiente � decorado com m�veis de madeira r�stica e quadros de artistas locais nas paredes. H� mesas internas e externas, permitindo que os clientes desfrutem de suas bebidas enquanto observam a vida do bairro passar.",
                new List<string> { "cafe", "encontro", "social" }
            );

            Location GrandSquare = new Location(
                "grand_square",
                "Central Square",
                "Common Plaza",
                "Uma vasta pra�a central cercada por edif�cios hist�ricos e monumentos. � um ponto de encontro popular para eventos comunit�rios, feiras e celebra��es. A pra�a � adornada com jardins bem cuidados, fontes e bancos, proporcionando um espa�o agrad�vel para relaxar e socializar. Frequentemente, artistas de rua se apresentam aqui, adicionando vida e cor ao ambiente.",
                new List<string> { "encontro", "evento", "social" }
            );

            Location Library = new Location(
                "library",
                "Biblioteca Municipal",
                "Public Library",
                "Uma biblioteca p�blica bem equipada, oferecendo uma vasta cole��o de livros, peri�dicos e recursos digitais. � um local tranquilo, ideal para estudo e pesquisa. A biblioteca tamb�m organiza eventos culturais, palestras e clubes de leitura, promovendo a educa��o e o envolvimento comunit�rio. O ambiente � calmo e acolhedor, com �reas de leitura confort�veis e acesso � internet.",
                new List<string> { "educacao", "cultura", "social" }
            );

            Location Wallmart = new Location(
                "wallmart",
                "Supermercado Wallmart",
                "Supermarket",
                "Um grande supermercado que oferece uma ampla variedade de produtos, desde alimentos frescos at� eletr�nicos e roupas. � um local conveniente para compras di�rias, com pre�os competitivos e promo��es frequentes. O supermercado � bem iluminado e organizado, facilitando a navega��o pelos corredores. H� tamb�m uma se��o de produtos locais e org�nicos, promovendo a sustentabilidade.",
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
                "Uma rua tranquila e arborizada, conhecida por suas casas coloridas e jardins bem cuidados. � um local residencial popular, com uma comunidade amig�vel e ativa. A rua � cercada por �rvores de ac�cia, que florescem em cores vibrantes durante a primavera. H� cal�adas largas para caminhadas e ciclovias, tornando-a ideal para passeios a p� ou de bicicleta.",
                new List<string> { "rua", "residencial", "tranquilo" },
                "A Rua Ac�cia � o cora��o de uma comunidade coesa, onde os moradores se conhecem e participam ativamente da vida local. H� um forte senso de vizinhan�a e pertencimento. � comum ver crian�as brincando nas cal�adas largas e nos pequenos jardins da frente, sob o olhar atento dos adultos. Os moradores organizam eventos regulares, como festas de rua no ver�o, bazares comunit�rios na pra�a pr�xima e mutir�es para manuten��o dos jardins p�blicos e das ciclovias. Existe uma rede informal de apoio, onde vizinhos ajudam uns aos outros com pequenos favores, como cuidar de animais de estima��o ou buscar correspond�ncias durante viagens. A seguran�a � percebida como alta, em parte devido � vigil�ncia comunit�ria e � baixa rotatividade de moradores. Conversas casuais nos passeios com animais de estima��o ou durante o regar dos jardins s�o a norma.",
                "O contexto pol�tico da Rua Ac�cia � fortemente influenciado pela sua natureza comunit�ria. Os moradores s�o proativos nas quest�es locais e geralmente votam em representantes que defendam os interesses do bairro, como melhorias na infraestrutura urbana (ilumina��o, poda de �rvores), seguran�a p�blica e manuten��o de �reas verdes. H� uma Associa��o de Moradores bem estabelecida e atuante, que serve como principal canal de comunica��o com a prefeitura e os �rg�os de seguran�a. Essa associa��o se re�ne mensalmente para discutir problemas, propor solu��es e organizar a��es coletivas. Pequenas disputas pol�ticas internas podem surgir em rela��o a detalhes como a cor dos postes de luz ou o tipo de planta a ser cultivada nas �reas comuns, mas raramente escalam para grandes conflitos. A participa��o c�vica � alta, e os moradores n�o hesitam em contactar seus representantes eleitos para expressar preocupa��es ou solicitar melhorias. A rua mant�m um bom relacionamento com a pol�cia de bairro, que realiza patrulhamento frequente, sendo vista mais como um servi�o de apoio � comunidade do que como uma for�a de controle.",
                AcasiaLocations
            );

            WorldEnvironment RuaSolis = new WorldEnvironment(
                "rua_solis",
                "Rua Solis",
                "Street",
                "A Rua Solis � uma art�ria vibrante e movimentada da cidade, pulsando com a energia do com�rcio e do fluxo constante de pessoas e ve�culos. Suas cal�adas s�o largas, mas frequentemente cheias, ladeadas por uma diversidade de estabelecimentos que v�o desde pequenas lojas de conveni�ncia at� grandes redes varejistas. No cora��o da Rua Solis, encontra-se a Biblioteca Municipal \"Saber Aberto\", um o�sis de tranquilidade e conhecimento, contrastando com a agita��o externa. A poucos quarteir�es de dist�ncia, ergue-se o imponente Walmart, que atrai um p�blico vasto e diversificado, gerando um tr�fego consider�vel. Apesar do barulho constante e do ritmo acelerado, a Rua Solis � um ponto de encontro e de passagem essencial para muitos moradores, oferecendo uma gama completa de servi�os e produtos. O transporte p�blico � intenso, com pontos de �nibus movimentados e t�xis circulando.",
                new List<string> { "rua", "comercial", "movimentado" },
                "O contexto social da Rua Solis � marcado pela diversidade e transitoriedade. � um caldeir�o de diferentes grupos sociais e econ�micos que convergem por motivos variados: compras no Walmart, estudo ou acesso a servi�os na biblioteca, trabalho nas lojas ou simples deslocamento. As intera��es s�o mais ef�meras e transacionais do que na Rua Ac�cia; as pessoas se cruzam, mas raramente formam la�os profundos. Na Biblioteca Municipal, o ambiente social � mais focado e silencioso, com estudantes, pesquisadores e leitores buscando concentra��o, embora os arredores da biblioteca possam ser pontos de encontro informais. O Walmart � um microcosmo da sociedade, onde consumidores apressados se misturam, e a din�mica social � ditada pela busca por produtos e pela efici�ncia das compras. H� um senso de anonimato predominante; as pessoas s�o mais observadoras do que participantes ativas em um coletivo. Os eventos sociais s�o raros e, quando ocorrem, s�o geralmente promo��es comerciais ou feiras organizadas pela prefeitura, n�o por iniciativa da comunidade local.",
                "Politicamente, a Rua Solis � um ponto de interesse devido ao seu fluxo de tr�fego e import�ncia comercial. As quest�es pol�ticas aqui giram em torno de:\r\n\r\nInfraestrutura: Demanda constante por melhorias no tr�nsito (sem�foros, faixas de pedestres), pavimenta��o e estacionamento.\r\n\r\nSeguran�a P�blica: Devido ao grande movimento de pessoas e estabelecimentos comerciais, h� uma preocupa��o maior com seguran�a, levando a mais patrulhamento policial e talvez c�meras de vigil�ncia.\r\n\r\nRegulamenta��o Comercial: Debates sobre hor�rios de funcionamento, impostos para comerciantes e permiss�es para vendedores ambulantes s�o frequentes.\r\n\r\nInteresses Comerciais vs. Moradores: Conflitos podem surgir entre os interesses dos grandes estabelecimentos comerciais (que querem mais tr�fego) e os poucos moradores residenciais da rua (que buscam menos barulho e congestionamento).\r\n\r\nAtivismo de Base: Raramente h� um ativismo pol�tico local forte vindo dos moradores da rua, mas associa��es comerciais ou grupos de consumidores podem ter voz nas decis�es que afetam a Rua Solis. As decis�es pol�ticas tendem a vir de �rg�os municipais, visando o benef�cio econ�mico da regi�o.",
                SolisLocations
            );

            environmentFactory.AddEnvironment(RuaAcasia);
            environmentFactory.AddEnvironment(RuaSolis);

            environmentFactory.SaveAllEnvironments();*/

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

            environmentFactory.LoadAllEnvironments();

            Race HighElf = raceFactory.RaceDatabase.GetResourceById("elf_h");
            Race Orc = raceFactory.RaceDatabase.GetResourceById("orc");
            Race Dwarf = raceFactory.RaceDatabase.GetResourceById("dwarf");

            WorldEnvironment RuaAcasia = environmentFactory.EnvironmentDatabase.GetResourceById("rua_acasia");
            WorldEnvironment RuaSolis = environmentFactory.EnvironmentDatabase.GetResourceById("rua_solis");

            Debug.WriteLine("\n--- Exibindo Ra�as Carregadas ---");
            Debug.WriteLine($"Ra�a: {HighElf.RaceName}");
            Debug.WriteLine($"Ra�a: {Orc.RaceName}");
            Debug.WriteLine($"Ra�a: {Dwarf.RaceName}");

            Debug.WriteLine("\n--- Exibindo Environments Carregadoss ---");
            Debug.WriteLine($"Environment: {RuaAcasia.EnvironmentName}");
            Debug.WriteLine($"Environment Location: {RuaAcasia.EnvironmentName} - {RuaAcasia.EnvironmentMajorLocations["coffe_shop"].LocationName}");
            Debug.WriteLine($"Environment Location: {RuaAcasia.EnvironmentName} - {RuaAcasia.EnvironmentMajorLocations["grand_square"].LocationName}");

            Debug.WriteLine($"Environment: {RuaSolis.EnvironmentName}");
            Debug.WriteLine($"Environment Location: {RuaSolis.EnvironmentName} - {RuaSolis.EnvironmentMajorLocations["library"].LocationName}");
            Debug.WriteLine($"Environment Location: {RuaSolis.EnvironmentName} - {RuaSolis.EnvironmentMajorLocations["wallmart"].LocationName}");

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Console.ReadLine();
        }
    }
}