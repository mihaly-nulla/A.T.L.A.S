using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Genesis.Mind.KnowledgeModule.entities
{
    public class Document
    {
        public string ID { get; private set; }
        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Abstract { get; private set; }

        public string FilePath { get; private set; }

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