using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Genesis.Mind.KnowledgeModule.entities
{
    public class Knowledge
    {
        [JsonProperty("concept_id")]
        public string ConceptId { get; private set; }

        [JsonProperty("Documents")]
        public List<Document> Documents { get; private set; } = new List<Document>();

        public Knowledge() : this("", null) { }

        public Knowledge(string conceptId, List<Document> documents = null)
        {
            if (string.IsNullOrWhiteSpace(conceptId))
                throw new ArgumentException("ConceptId cannot be null or empty.", nameof(conceptId));

            ConceptId = conceptId;
            Documents = documents ?? new List<Document>();
        }
    }
}