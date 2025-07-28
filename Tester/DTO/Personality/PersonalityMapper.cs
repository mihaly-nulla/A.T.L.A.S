using Genesis.Heart.PersonalityModule.entities;
using Genesis.Heart.PersonalityModule.systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Personality
{
    public class PersonalityMapper : IMapper<PersonalitySystem, NPCPersonality>
    {
        public PersonalitySystem FromDTO(NPCPersonality destination)
        {
            return new PersonalitySystem
            {
                oceanPersonality = new OCEAN
                {
                    Openness = destination.ocean.Openness,
                    Conscientiousness = destination.ocean.Conscientiousness,
                    Extraversion = destination.ocean.Extraversion,
                    Agreeableness = destination.ocean.Agreeableness,
                    Neuroticism = destination.ocean.Neuroticism
                },
                schwartzPersonality = new SCHWARTZ
                {
                    Power = destination.schwartz.Power,
                    Achievement = destination.schwartz.Achievement,
                    Hedonism = destination.schwartz.Hedonism,
                    Stimulation = destination.schwartz.Stimulation,
                    SelfDirection = destination.schwartz.SelfDirection,
                    Universalism = destination.schwartz.Universalism,
                    Benevolence = destination.schwartz.Benevolence,
                    Tradition = destination.schwartz.Tradition,
                    Conformity = destination.schwartz.Conformity,
                    Security = destination.schwartz.Security
                },
                personalityStyle = new DialogueStyle
                {
                    Tone = destination.dialogueStyle.Tone,
                    Formality = destination.dialogueStyle.Formality,
                    Vocabulary = destination.dialogueStyle.Vocabulary,
                    VocabularyReference = destination.dialogueStyle.VocabularyReference
                }
            };
        }

        public NPCPersonality ToDTO(PersonalitySystem source)
        {
            return new NPCPersonality
            {
                ocean = new NPCOcean
                {
                    Openness = source.oceanPersonality.Openness,
                    Conscientiousness = source.oceanPersonality.Conscientiousness,
                    Extraversion = source.oceanPersonality.Extraversion,
                    Agreeableness = source.oceanPersonality.Agreeableness,
                    Neuroticism = source.oceanPersonality.Neuroticism
                },
                schwartz = new NPCSchwartz
                {
                    Power = source.schwartzPersonality.Power,
                    Achievement = source.schwartzPersonality.Achievement,
                    Hedonism = source.schwartzPersonality.Hedonism,
                    Stimulation = source.schwartzPersonality.Stimulation,
                    SelfDirection = source.schwartzPersonality.SelfDirection,
                    Universalism = source.schwartzPersonality.Universalism,
                    Benevolence = source.schwartzPersonality.Benevolence,
                    Tradition = source.schwartzPersonality.Tradition,
                    Conformity = source.schwartzPersonality.Conformity,
                    Security = source.schwartzPersonality.Security
                },
                dialogueStyle = new NPCDialogue
                {
                    Tone = source.personalityStyle.Tone,
                    Formality = source.personalityStyle.Formality,
                    Vocabulary = source.personalityStyle.Vocabulary,
                    VocabularyReference = source.personalityStyle.VocabularyReference
                }
            };
        }
    }
}
