using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MemoryModule.components
{
    public class SemanticMemory
    {
        private string conceptId;
        private List<string> relatedConcepts;
        private DateTime discoveryDate;

        public SemanticMemory(string conceptId, 
                                List<string> relatedConcepts,
                                DateTime discoveryDate)
        {
            this.conceptId = conceptId;
            this.relatedConcepts = relatedConcepts;
            this.discoveryDate = discoveryDate;
        }

        public void AddRelatedConcept(string relatedConcept)
        {
            if (!relatedConcepts.Contains(relatedConcept))
            {
                relatedConcepts.Add(relatedConcept);
            }
        }

        public List<string> GetRelatedConcepts()
        {
            return relatedConcepts;
        }

        public string GetConceptId()
        {
            return conceptId;
        }
    }
}