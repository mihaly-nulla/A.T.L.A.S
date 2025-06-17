using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeModule.entities
{
    public class Document
    {
        private string ID;
        private string title;
        private string description;
        private string filePath;
        private List<string> tags;

        public Document(string ID, string title,
                        string description, string filePath,
                        List<string> tags
        )
        {
            this.ID = ID;
            this.title = title;
            this.description = description;
            this.filePath = filePath;
            this.tags = tags;
        }
    }
}