using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.PersonalityModule.components
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
            Tone = "";
            Formality = 0;
            Vocabulary = "";
            VocabularyReference = "";
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
