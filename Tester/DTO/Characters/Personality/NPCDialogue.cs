using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Characters.Personality
{
    public class NPCDialogue
    {
        [JsonProperty("tone")]
        public string Tone { get; set; }

        [JsonProperty("formality")]
        public int Formality { get; set; }

        [JsonProperty("vocabulary")]
        public string Vocabulary { get; set; }

        [JsonProperty("vocabulary_reference")]
        public string VocabularyReference { get; set; }
    }
}
