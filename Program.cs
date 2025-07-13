using System;
using System.Collections.Generic;
using System.Diagnostics;

using A.T.L.A.S.Heart.PersonalityModule.components;
using A.T.L.A.S.Heart.PersonalityModule.systems;
using A.T.L.A.S.Heart.PersonalityModule.entities;

using A.T.L.A.S.Mind.KnowledgeModule.entities;
using A.T.L.A.S.Mind.CommunicationModule.systems;

using A.T.L.A.S.Factory.CreationModule.entities;
using A.T.L.A.S.Factory.CreationModule.systems;

namespace A.T.L.A.S
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Debug.WriteLine("--- Iniciando Teste de Geração de Prompt de NPC ---");

            CreationSystem creator = new CreationSystem();
            CommunicationSystem communicator = new CommunicationSystem();

            // 1. Criar alguns Documentos
            Document docGenetica01 = new Document(
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

            Brain lucioNpcBrain = creator.CreateNPC("lucio", "Lucio", scientistInitialKnowledge, lucioPersonality);
            Brain rosaAlternate = creator.CreateNPC("rosa-alternate", "Rosa", scientistInitialKnowledge, alternateRosaPersonality);

            /*Debug.WriteLine("\n--- Gerando JSON do Prompt para NPC_Einstein ---");
            creator.GenerateAndSaveJson("rosa");
            creator.GenerateAndSaveJson("lucio");
            creator.GenerateAndSaveJson("rosa-alternate");*/


            //communicator.SendPromptToGEMINI("rosa-alternate");


            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Console.ReadLine();
        }
    }
}