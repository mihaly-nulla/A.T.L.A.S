using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeModule.entities;

namespace KnowledgeModule.systems
{
    public class KnowledgeSystem
    {
        private List<Knowledge> knowledgeBase;

        public KnowledgeSystem()
        {
            this.knowledgeBase = new List<Knowledge>();
        }

        public void AddKnowledge(Knowledge newKnowledge)
        {
            if (knowledge != null && !knowledgeBase.Any(k => k.ConceptId == knowledge.ConceptId)) //verifica se já existe um conhecimento com o mesmo ConceptId
            {
                knowledgeBase.Add(knowledge);
            }
        }

        public Knowledge GetKnowledgeByConceptId(string conceptId)
        {
            if (string.IsNullOrWhiteSpace(conceptId))
            {
                return null; // Retorna null se o conceptId for inválido
            }
            return knowledgeBase.FirstOrDefault(k => k.ConceptId == conceptId);
        }
    }
}