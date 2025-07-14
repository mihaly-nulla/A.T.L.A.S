using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.PersonalityModule.entities
{
    public class DialogStyle
    {
        [JsonPropertyName("tone")]
        public string Tone { get; set; }

        [JsonPropertyName("formality")]
        public int Formality { get; set; }

        [JsonPropertyName("vocabulary")]
        public string Vocabulary { get; set; }

        [JsonPropertyName("vocabulary_reference")]
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
