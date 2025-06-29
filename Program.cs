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
            Debug.WriteLine("--- Iniciando Teste de Gera��o de Prompt de NPC ---");

            CreationSystem creator = new CreationSystem();

            // 1. Criar alguns Documentos
            Document docFisica01 = new Document(
                "fisica_01",
                "Fundamentos de F�sica � Volume 1",
                "Livro base sobre cinem�tica e leis da f�sica. Cont�m informa��es essenciais sobre movimento, for�a e energia.",
                "Resumo de f�sica",
                "knowledge_base/fisica_vol1.pdf",
                new List<string> { "fisica", "cinematica", "dinamica" }
            );

            Document docFisica05 = new Document(
                "fisica_05",
                "Fundamentos de F�sica Qu�ntica � Volume 5",
                "Livro base sobre f�sica qu�ntica, abordando conceitos como dualidade onda-part�cula e mec�nica qu�ntica.",
                "Resumo de qu�ntica",
                "knowledge_base/fisica_vol5.pdf",
                new List<string> { "fisica", "qu�ntica" }
            );

            Document docOndulatoryColors = new Document(
                "ondulatory_colors",
                "Regras das cores em Ondulat�ria, no jogo",
                "Livro com a l�gica de como as cores interagem na f�sica ondulat�ria dentro das regras espec�ficas do jogo. Define a fus�o de cores prim�rias e secund�rias em ambientes de baixa luz.",
                "Resumo de ondulat�ria",
                "knowledge_base/game_documents/color_ondulatory.pdf",
                new List<string> { "jogo", "ondulatoria", "cores", "regras" }
            );


            // 2. Criar inst�ncias de Knowledge (conceitos com documentos)
            List<Knowledge> scientistInitialKnowledge = new List<Knowledge>
        {
            new Knowledge("physics_ondulatory", new List<Document> { docFisica01 }),
            new Knowledge("physics_quantum", new List<Document> { docFisica05 }),
            new Knowledge("game_ondulatory_rules-colors", new List<Document> { docOndulatoryColors })
        };

            /*List<Knowledge> adventurerInitialKnowledge = new List<Knowledge>
            {
                new Knowledge("survival_basics", new List<Document> { new Document("surv_01", "Guia de Sobreviv�ncia R�pida", "Manual com t�cnicas b�sicas de abrigo e alimenta��o.", "docs/survival.pdf", new List<string>{"survival"}) })
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
            // 4. Testar a recupera��o de conhecimento pelos Brains
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

            Console.WriteLine("\n--- Teste Conclu�do ---");*/
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            //Console.ReadLine();
        }
    }
}