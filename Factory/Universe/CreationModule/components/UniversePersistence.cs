using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.Universe.CreationModule.components
{
    public abstract class UniversePersistence<TSystem>
        where TSystem : class, new()
    {
        /// <summary>
        /// Carrega definições de um arquivo JSON.
        /// </summary>
        /// <param name="filePath">O caminho completo para o arquivo JSON.</param>
        /// <returns>Uma nova instância de TSystem preenchida.</returns>
        public static TSystem LoadFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo não encontrado: {filePath}");
            }

            string jsonString = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            try
            {
                // Desserializa para o tipo concreto que está chamando este método
                var loadedSystem = JsonSerializer.Deserialize<TSystem>(jsonString, options);
                Console.WriteLine($"Dados carregados com sucesso do arquivo: {filePath}");
                return loadedSystem;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro de desserialização JSON ao carregar dados: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao carregar dados do arquivo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Salva as definições atuais de uma instância em um arquivo JSON.
        /// </summary>
        /// <param name="data">A instância de TSystem contendo os dados a serem salvos.</param>
        /// <param name="filePath">O caminho completo para o qual o arquivo JSON será salvo.</param>
        public static void SaveToJsonFile(TSystem data, string filePath)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "A instância a ser salva não pode ser nula.");
            }
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("O caminho do arquivo não pode ser nulo ou vazio.", nameof(filePath));
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Dados salvos com sucesso em: {filePath}");
        }
    }
}
