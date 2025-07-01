using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.PersonalityModule.components
{
    public class DialogStyle
    {
        [JsonPropertyName("tone")]
        public string Tone { get; private set; }

        [JsonPropertyName("formality")]
        public int Formality { get; private set; }

        [JsonPropertyName("vocabulary")]
        public string Vocabulary { get; private set; }

        [JsonPropertyName("vocabulary_reference")]
        public string VocabularyReference { get; private set; }

        public DialogStyle() 
        {
            this.Tone = "";
            this.Formality = 0;
            this.Vocabulary = "";
            this.VocabularyReference = "";
        }
    
        public DialogStyle(
                                string tone,
                                int formality,
                                string vocabulary,
                                string vocabularyReference
                             )
        {
            this.Tone = tone;
            this.Formality = formality;
            this.Vocabulary = vocabulary;
            this.VocabularyReference = vocabularyReference;
        }

        public void SetTone(string tone)
        {
            this.Tone = tone;
        }

        public void SetFormality(int formality)
        {
            this.Formality = formality;
        }

        public void SetVocabulary(string vocabulary)
        {
            this.Vocabulary = vocabulary;   
        }

        public void SetVocabularyReference(string vocabularyReference)
        {
            this.VocabularyReference = vocabularyReference;
        }
    }
}
