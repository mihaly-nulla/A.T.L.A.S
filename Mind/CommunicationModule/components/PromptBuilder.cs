using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.T.L.A.S.Mind.CommunicationModule.components
{
    public static class PromptBuilder
    {
        /// <summary>
        /// Constrói o prompt completo para a IA generativa, incluindo o JSON do perfil do NPC e a entrada do usuário.
        /// </summary>
        /// <param name="npcProfileJson">A string JSON completa do perfil do NPC (gerada pelo GeneratePromptJsonForNpc).</param>
        /// <param name="playerInput">A entrada mais recente do jogador ou o contexto da conversa.</param>
        /// <param name="contextualInformation">Informações adicionais relevantes para o prompt (e.g., objetivo atual, localização, status de quest).</param>
        /// <returns>A string completa do prompt para enviar à IA.</returns>
        public static string BuildAiPrompt(
                                                string npcProfileJson, 
                                                string playerInput, 
                                                Dictionary<string, string> relevantNpcData,
                                                string relevantRaceData,
                                                string relevantEnvironmentData)
        {
            StringBuilder prompt = new StringBuilder();



            // --- 1. Instruções para a IA (O "Persona" e a Tarefa) ---
            prompt.AppendLine("You are an autonomous Non-Player Character (NPC) in a simulation. Your goal is to respond authentically, leveraging your internal profile, knowledge, and memory.");
            prompt.AppendLine("Your character is specified by the provided NPC Profile.");
            prompt.AppendLine("You possess a unique personality. Your responses should reflect your character's traits.");

            prompt.AppendLine("Your core personality is primarily defined by your OCEAN and SCHWARTZ values. These models represent the fundamental aspects of your character and should be the guiding force behind your thoughts and actions.");
            prompt.AppendLine("Your 'dialog_style' further refines how this core personality is expressed, influencing your tone, formality, and vocabulary.");

            prompt.AppendLine("Avoid stating you are an AI or a computer program.");
            prompt.AppendLine("Focus on providing helpful information based on your knowledge, and ask clarifying questions if needed.");

            prompt.AppendLine("If the player asks about something outside your knowledge, gracefully admit you don't know or offer to find out if that's a capability.");
            prompt.AppendLine("Your response must be in Brazilian Portuguese. Use common Brazilian Portuguese expressions and grammatical structures. Maintain the tone and vocabulary style specified.");
            
            prompt.AppendLine("Do not use emojis in your response.");
            prompt.AppendLine($"Keep your response concise, to a maximum of approximately 100 words. Prioritize the most critical information.");

            prompt.AppendLine("\n--- NPC Profile (JSON) ---");
            prompt.AppendLine("```json");
            prompt.AppendLine(npcProfileJson);
            prompt.AppendLine("```");

            if (relevantNpcData != null && relevantNpcData.Any())
            {
                prompt.AppendLine("\n--- Profiles of Related NPCs ---");
                foreach (var entry in relevantNpcData)
                {
                    prompt.AppendLine(entry.Value);
                }
            }

            if (!string.IsNullOrWhiteSpace(relevantRaceData))
            {
                prompt.AppendLine("\n--- Your Race Data ---");
                
                prompt.AppendLine(relevantRaceData);
            }

            if (!string.IsNullOrWhiteSpace(relevantEnvironmentData))
            {
                prompt.AppendLine("\n--- Your Place of Origin Data ---");

                prompt.AppendLine(relevantEnvironmentData);
            }

            // --- 3. Entrada do Jogador ---
            prompt.AppendLine("\n--- Input Prompt ---");
            prompt.AppendLine(playerInput);

            // --- 4. Instruções Finais para o Formato de Saída ---
            prompt.AppendLine("\n--- NPC Response ---");
            prompt.AppendLine("Respond as the NPC. Start directly with the NPC's speech. Do not add any introductory phrases like 'As the NPC, I would say...'");

            return prompt.ToString();
        }
    }
}
