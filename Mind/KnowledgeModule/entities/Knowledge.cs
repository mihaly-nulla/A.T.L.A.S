using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Mind.KnowledgeModule.entities
{
    public class Knowledge
    {
        [JsonPropertyName("concept_id")]
        public string ConceptId { get; private set; }

        [JsonPropertyName("Documents")]
        public List<Document> Documents { get; private set; } = new List<Document>();

        public Knowledge(string conceptId, List<Document> documents = null)
        {
            if (string.IsNullOrWhiteSpace(conceptId))
                throw new ArgumentException("ConceptId cannot be null or empty.", nameof(conceptId));

            ConceptId = conceptId;
            Documents = documents ?? new List<Document>();
        }
    }
}