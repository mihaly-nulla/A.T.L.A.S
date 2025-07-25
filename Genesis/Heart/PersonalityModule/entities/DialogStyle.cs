using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Genesis.Heart.PersonalityModule.entities
{
    public class DialogStyle
    {
        [JsonProperty("tone")]
        public string Tone { get; set; }

        [JsonProperty("formality")]
        public int Formality { get; set; }

        [JsonProperty("vocabulary")]
        public string Vocabulary { get; set; }

        [JsonProperty("vocabulary_reference")]
        public string VocabularyReference { get; set; }

        public DialogStyle() 
        {
            this.Tone = string.Empty;
            this.Vocabulary = string.Empty;
            this.VocabularyReference = string.Empty;
        }
    
        public DialogStyle(
                                string tone,
                                int formality,
                                string vocabulary,
                                string vocabularyReference
                             )
        {
            Tone = tone;
            Formality = formality;
            Vocabulary = vocabulary;
            VocabularyReference = vocabularyReference;
        }

        public void SetTone(string tone)
        {
            Tone = tone;
        }

        public void SetFormality(int formality)
        {
            Formality = formality;
        }

        public void SetVocabulary(string vocabulary)
        {
            Vocabulary = vocabulary;   
        }

        public void SetVocabularyReference(string vocabularyReference)
        {
            VocabularyReference = vocabularyReference;
        }
    }
}
