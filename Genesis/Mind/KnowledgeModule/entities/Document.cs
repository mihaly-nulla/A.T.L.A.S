using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Genesis.Mind.KnowledgeModule.entities
{
    public class Document
    {
        [JsonProperty("ID")]
        public string ID { get; private set; }
        [JsonProperty("Title")]
        public string Title { get; private set; }

        [JsonProperty("Description")]
        public string Description { get; private set; }

        [JsonProperty("Abstract")]
        public string Abstract { get; private set; }
        [JsonProperty("FilePath")]
        public string FilePath { get; private set; }

        [JsonProperty("Tags")]
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