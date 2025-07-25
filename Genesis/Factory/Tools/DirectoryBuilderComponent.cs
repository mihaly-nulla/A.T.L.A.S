using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Factory.Tools
{
    public static class DirectoryBuilderComponent
    {
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
    }
}
