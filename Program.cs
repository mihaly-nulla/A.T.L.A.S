using A.T.L.A.S.CreationModule.entities; // Brain (o NPC em si)
using A.T.L.A.S.CreationModule.systems; // CreationSystem
using A.T.L.A.S.KnowledgeModule.entities; // Knowledge, Document
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace A.T.L.A.S
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Debug.WriteLine("--- Iniciando Teste de Geração de Prompt de NPC ---");

            CreationSystem creator = new CreationSystem();

            // 1. Criar alguns Documentos
            Document docFisica01 = new Document(
                "fisica_01",
                "Fundamentos de Física — Volume 1",
                "Livro base sobre cinemática e leis da física. Contém informações essenciais sobre movimento, força e energia.",
                "Resumo de física",
                "knowledge_base/fisica_vol1.pdf",
                new List<string> { "fisica", "cinematica", "dinamica" }
            );

            Document docFisica05 = new Document(
                "fisica_05",
                "Fundamentos de Física Quântica — Volume 5",
                "Livro base sobre física quântica, abordando conceitos como dualidade onda-partícula e mecânica quântica.",
                "Resumo de quântica",
                "knowledge_base/fisica_vol5.pdf",
                new List<string> { "fisica", "quântica" }
            );

            Document docOndulatoryColors = new Document(
                "ondulatory_colors",
                "Regras das cores em Ondulatória, no jogo",
                "Livro com a lógica de como as cores interagem na física ondulatória dentro das regras específicas do jogo. Define a fusão de cores primárias e secundárias em ambientes de baixa luz.",
                "Resumo de ondulatória",
                "knowledge_base/game_documents/color_ondulatory.pdf",
                new List<string> { "jogo", "ondulatoria", "cores", "regras" }
            );


            // 2. Criar instâncias de Knowledge (conceitos com documentos)
            List<Knowledge> scientistInitialKnowledge = new List<Knowledge>
        {
            new Knowledge("physics_ondulatory", new List<Document> { docFisica01 }),
            new Knowledge("physics_quantum", new List<Document> { docFisica05 }),
            new Knowledge("game_ondulatory_rules-colors", new List<Document> { docOndulatoryColors })
        };

            /*List<Knowledge> adventurerInitialKnowledge = new List<Knowledge>
            {
                new Knowledge("survival_basics", new List<Document> { new Document("surv_01", "Guia de Sobrevivência Rápida", "Manual com técnicas básicas de abrigo e alimentação.", "docs/survival.pdf", new List<string>{"survival"}) })
            };*/

            // 3. Criar NPCs (Brains) usando o CreationSystem
            Debug.WriteLine("\n--- Criando NPCs ---");
            Brain scientistNpcBrain = creator.CreateNPC("NPC_Einstein", "Albert Einstein", scientistInitialKnowledge);
            //Brain adventurerNpcBrain = creator.CreateNPC("NPC_IndianaJones", adventurerInitialKnowledge);

            Debug.WriteLine("\n--- Testando Brains ---");
            Debug.WriteLine(scientistNpcBrain.npcKnowledge.GetKnowledgeByConceptId("physics_quantum").ConceptId);

            Debug.WriteLine("\n--- Gerando JSON do Prompt para NPC_Einstein ---");
            string scientistPromptJson = creator.GeneratePromptJsonForNpc("NPC_Einstein");
            Debug.WriteLine(scientistPromptJson);
            // 4. Testar a recuperação de conhecimento pelos Brains
            /*Console.WriteLine("\n--- Testando Brains ---");
            Console.WriteLine(scientistNpcBrain.GetKnowledgeDescription("physics_ondulatory"));
            Console.WriteLine(adventurerNpcBrain.GetKnowledgeDescription("survival_basics"));
            Console.WriteLine(scientistNpcBrain.GetKnowledgeDescription("unknown_concept"));

            // 5. Gerar o JSON do prompt para os NPCs
            Console.WriteLine("\n--- Gerando JSON do Prompt para NPC_Einstein ---");
            string scientistPromptJson = creator.GeneratePromptJsonForNpc("NPC_Einstein");
            Console.WriteLine(scientistPromptJson);

            Console.WriteLine("\n--- Gerando JSON do Prompt para NPC_IndianaJones ---");
            string adventurerPromptJson = creator.GeneratePromptJsonForNpc("NPC_IndianaJones");
            Console.WriteLine(adventurerPromptJson);

            Console.WriteLine("\n--- Teste Concluído ---");*/
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Console.ReadLine();
        }
    }
}