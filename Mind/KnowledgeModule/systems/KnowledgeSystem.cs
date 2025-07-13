using A.T.L.A.S.Mind.KnowledgeModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A.T.L.A.S.Mind.KnowledgeModule.systems
{
    public class KnowledgeSystem
    {
        //public string NpcId { get; private set; }
        private List<Knowledge> knowledgeBase;

        public KnowledgeSystem()
        {
            knowledgeBase = new List<Knowledge>();
        }

        public void AddKnowledge(Knowledge newKnowledge)
        {
            if (newKnowledge != null && !knowledgeBase.Any(k => k.ConceptId == newKnowledge.ConceptId)) //verifica se j� existe um conhecimento com o mesmo ConceptId
            {
                knowledgeBase.Add(newKnowledge);
            }
        }

        public Knowledge GetKnowledgeByConceptId(string conceptId)
        {
            if (string.IsNullOrWhiteSpace(conceptId))
            {
                return null; // Retorna null se o conceptId for inv�lido
            }
            return knowledgeBase.FirstOrDefault(k => k.ConceptId == conceptId);
        }

        public IEnumerable<Knowledge> GetAllKnowledge()
        {
            return new List<Knowledge>(knowledgeBase); // Retorna uma cópia para proteger a coleção interna
        }
    }
}