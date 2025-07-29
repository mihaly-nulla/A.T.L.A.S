using Genesis.Factory.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Newtonsoft
{
    public class TestSaver : IFileStorage
    {
        private const string CHARACTER_SAVE_DIRECTORY_NAME = "database/characters";
        private const string RACE_SAVE_DIRECTORY_NAME = "database/universe/races";
        private const string ENVIRONMENT_SAVE_DIRECTORY_NAME = "database/universe/environments";

        private string CharactersFolderPath;
        private string RacesFolderPath;
        private string EnvironmentsFolderPath;

        public TestSaver()
        {
            this.CharactersFolderPath = BuildCustomPath(CHARACTER_SAVE_DIRECTORY_NAME);
            this.RacesFolderPath = BuildCustomPath(RACE_SAVE_DIRECTORY_NAME);
            this.EnvironmentsFolderPath = BuildCustomPath(ENVIRONMENT_SAVE_DIRECTORY_NAME);

            if (!Directory.Exists(this.CharactersFolderPath))
            {
                Directory.CreateDirectory(this.CharactersFolderPath);
                Debug.WriteLine($"Diretório de salvamento criado: {this.CharactersFolderPath}");
            } else if (!Directory.Exists(this.RacesFolderPath))
            {
                Directory.CreateDirectory(this.RacesFolderPath);
                Debug.WriteLine($"Diretório de salvamento criado: {this.RacesFolderPath}");
            } else if (!Directory.Exists(this.EnvironmentsFolderPath))
            {
                Directory.CreateDirectory(this.EnvironmentsFolderPath);
                Debug.WriteLine($"Diretório de salvamento criado: {this.EnvironmentsFolderPath}");
            }
            else
            {
                Debug.WriteLine($"Diretório de salvamento já existe: {this.CharactersFolderPath}");
            }
        }
        /// <summary>
        /// Tenta encontrar o diretório raiz da solução (procurando por um arquivo .sln)
        /// ou o diretório raiz do projeto (procurando por um arquivo .csproj) como fallback.
        /// </summary>
        /// <returns>O caminho completo para o diretório raiz.</returns>
        /// <exception cref="InvalidOperationException">Lançada se não conseguir encontrar um diretório raiz reconhecível.</exception>
        public static string GetSolutionOrProjectRootDirectory()
        {
            // Pega o diretório onde o assembly atual está rodando (geralmente bin/Debug/netX.X/)
            string currentAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Abordagem 1: Buscar pelo arquivo .sln (raiz da solução)
            DirectoryInfo directory = new DirectoryInfo(currentAssemblyPath);
            while (directory != null && !directory.GetFiles("*.sln").Any())
            {
                directory = directory.Parent;
            }

            if (directory != null)
            {
                Console.WriteLine($"Diretório raiz da SOLUÇÃO (.sln) encontrado: {directory.FullName}");
                return directory.FullName;
            }

            // Abordagem 2: Se não encontrou o .sln, busca pelo .csproj (raiz do projeto)
            directory = new DirectoryInfo(currentAssemblyPath); // Resetar para o diretório inicial
            while (directory != null && !directory.GetFiles("*.csproj").Any())
            {
                directory = directory.Parent;
            }

            if (directory != null)
            {
                Console.WriteLine($"Diretório raiz do PROJETO (.csproj) encontrado: {directory.FullName}");
                return directory.FullName;
            }

            // Fallback: Se nenhuma estratégia de busca de marcador funcionar, tente a heurística (menos robusto)
            // Isso só deve acontecer em cenários muito incomuns ou com estruturas de projeto não convencionais.
            Console.WriteLine("Aviso: Não foi possível encontrar '.sln' ou '.csproj'. Recorrendo à heurística de 3 níveis.");
            directory = new DirectoryInfo(currentAssemblyPath);
            for (int i = 0; i < 3 && directory.Parent != null; i++)
            {
                directory = directory.Parent;
            }
            if (directory != null)
            {
                Console.WriteLine($"Diretório raiz (heurística) calculado como: {directory.FullName}");
                return directory.FullName;
            }

            throw new InvalidOperationException("Não foi possível determinar o diretório raiz do projeto/solução.");
        }

        public static string BuildCustomPath(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
            {
                throw new ArgumentException("O caminho relativo não pode ser nulo ou vazio.", nameof(relativePath));
            }
            string rootDirectory = GetSolutionOrProjectRootDirectory();
            string fullPath = Path.Combine(rootDirectory, relativePath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));
            return fullPath;
        }

        public void Save(int type, string fileName, string content)
        {
            switch (type)
            {
                case 0: // Character
                    File.WriteAllText(Path.Combine(CharactersFolderPath, fileName + ".json"), content);
                    break;
                case 1: //Race
                    File.WriteAllText(Path.Combine(RacesFolderPath, fileName + ".json"), content);
                    break;
                case 2: // Environment
                    File.WriteAllText(Path.Combine(EnvironmentsFolderPath, fileName + ".json"), content);
                    break;
            }
        }

        public string Load(int type, string fileName)
        {
            switch (type)
            {
                case 0: // Character
                    string characterPath = Path.Combine(CharactersFolderPath, fileName + ".json");
                    return File.Exists(characterPath) ? File.ReadAllText(characterPath) : null;
                case 1:
                    string racePath = Path.Combine(RacesFolderPath, fileName + ".json");
                    return File.Exists(racePath) ? File.ReadAllText(racePath) : null;
                case 2:
                    string environmentPath = Path.Combine(EnvironmentsFolderPath, fileName + ".json");
                    return File.Exists(environmentPath) ? File.ReadAllText(environmentPath) : null;
            }

            return null; // Retorna null se o tipo não for reconhecido ou o arquivo não existir
        }
    }
}
