using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Newtonsoft.Communication
{
    public static class Retriever
    {
        public static string ParseGEMINI(string jsonResponse)
        {
            var geminiResponse = JObject.Parse(jsonResponse);

            if (geminiResponse.TryGetValue("candidates", out JToken candidatesToken) &&
                candidatesToken is JArray candidatesArray && candidatesArray.Any())
            {
                JToken firstCandidate = candidatesArray.First();

                JToken textToken = firstCandidate?["content"]?["parts"]?.FirstOrDefault()?["text"];

                if (textToken != null)
                {
                    // Converte o valor do token para string
                    string aiResponseText = textToken.Value<string>();

                    Debug.WriteLine("\n--- Resposta Bruta da API do Gemini ---");
                    Debug.WriteLine(jsonResponse);
                    Debug.WriteLine("------------------------------------");
                    return aiResponseText;
                }

            }
            Debug.WriteLine("\n--- Resposta Bruta da API do Gemini ---");
            Debug.WriteLine(jsonResponse);
            Debug.WriteLine("------------------------------------");
            return "Erro: Resposta da IA não contém o formato esperado (texto).";
        }
    }
}
