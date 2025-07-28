using System;
using System.IO;

namespace Genesis.Factory.Universe.CreationModule.components
{
    public abstract class UniversePersistence<TSystem>
        where TSystem : class, new()
    {
        /// <summary>
        /// Carrega definições de um arquivo JSON.
        /// </summary>
        /// <param name="filePath">O caminho completo para o arquivo JSON.</param>
        /// <returns>Uma nova instância de TSystem preenchida.</returns>
        public static string LoadFromJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo não encontrado: {filePath}");
            }

            string jsonString = File.ReadAllText(filePath);

            try
            {
                Console.WriteLine($"Dados carregados com sucesso do arquivo: {filePath}");
                return jsonString;
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
        public static void SaveToJsonFile(string json, string filePath)
        {
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Dados salvos com sucesso em: {filePath}");
        }
    }
}
