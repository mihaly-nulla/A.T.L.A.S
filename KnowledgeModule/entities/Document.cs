using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.KnowledgeModule.entities
{
    public class Document
    {
        [JsonPropertyName("ID")]
        public string ID { get; private set; }
        [JsonPropertyName("Title")]
        public string Title { get; private set; }

        [JsonPropertyName("Description")]
        public string Description { get; private set; }

        [JsonPropertyName("Abstract")]
        public string Abstract { get; private set; }
        [JsonPropertyName("FilePath")]
        public string FilePath { get; private set; }

        [JsonPropertyName("Tags")]
        public List<string> Tags { get; private set; } = new List<string>();

        public Document(string ID, string title,
                        string description, string text_abstract,
                        string filePath, List<string> tags
        )
        {
            this.ID = ID;
            Title = title;
            Description = description;
            Abstract = text_abstract;
            FilePath = filePath;
            Tags = tags;
        }
    }
}