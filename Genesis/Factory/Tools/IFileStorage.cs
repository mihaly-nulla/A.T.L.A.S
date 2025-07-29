using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Factory.Tools
{
    public interface IFileStorage
    {
        /// <summary>
        /// Salva um conteúdo de texto em um arquivo.
        /// </summary>
        /// <param name="fileName">O nome do arquivo (ex: "npc_01.json").</param>
        /// <param name="content">O conteúdo a ser salvo.</param>
        void Save(int type, string fileName, string content);

        /// <summary>
        /// Carrega o conteúdo de texto de um arquivo.
        /// </summary>
        /// <param name="fileName">O nome do arquivo a ser lido.</param>
        /// <returns>O conteúdo do arquivo, ou null se não existir.</returns>
        string Load(int type, string fileName);

    }
}
