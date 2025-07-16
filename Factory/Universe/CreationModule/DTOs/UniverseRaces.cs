using A.T.L.A.S.Factory.World.CreationModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.World.CreationModule.DTOs
{
    public class UniverseRaces
    {
        [JsonPropertyName("world_races")]
        public Dictionary<string, Race> UniverseRacesDatabase { get; set; }

        public UniverseRaces()
        {
            UniverseRacesDatabase = new Dictionary<string, Race>();
        }

        public UniverseRaces(Dictionary<string, Race> worldRaces)
        {
            UniverseRacesDatabase = worldRaces ?? new Dictionary<string, Race>();
        }

        /// <summary>
        /// Obtém uma definição de raça pelo seu ID (funciona em uma instância já carregada).
        /// </summary>
        public Race GetRaceById(string raceId)
        {
            if (UniverseRacesDatabase.ContainsKey(raceId))
            {
                return UniverseRacesDatabase[raceId];
            }
            return null;
        }

        /// <summary>
        /// Carrega as definições de raça de um arquivo JSON.
        /// </summary>
        /// <param name="filePath">O caminho completo para o arquivo JSON das raças.</param>
        /// <returns>Uma nova instância de RaceCreationSystem preenchida com as raças.</returns>
        public static UniverseRaces LoadFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo de raças não encontrado: {filePath}");
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
                var loadedSystem = JsonSerializer.Deserialize<UniverseRaces>(jsonString, options);
                Console.WriteLine($"Raças carregadas com sucesso do arquivo: {filePath}");
                return loadedSystem;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Erro de desserialização JSON ao carregar raças: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao carregar raças do arquivo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Salva as definições de raça atuais de uma instância RaceCreationSystem em um arquivo JSON.
        /// </summary>
        /// <param name="raceData">A instância de RaceCreationSystem contendo os dados a serem salvos.</param>
        /// <param name="filePath">O caminho completo para o qual o arquivo JSON das raças será salvo.</param>
        public static void SaveToJsonFile(UniverseRaces raceData, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            string jsonString = JsonSerializer.Serialize(raceData, options);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Raças salvas com sucesso em: {filePath}");
        }
    }
}
