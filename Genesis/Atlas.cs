using Genesis.Factory.NPCs.CreationModule.systems;
using Genesis.Factory.Tools;
using Genesis.Factory.Universe.CreationModule.systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis
{
    public class Atlas
    {
        private static Atlas _instance;
        private static readonly object _lock = new object();

        private IFileStorage _storage;

        private RaceFactory RaceManager;
        private EnvironmentFactory EnvironmentManager;
        private CharacterFactory CharacterManager;

        /// <summary>
        /// Propriedade estática pública para acessar a única instância da classe Atlas.
        /// Cria a instância na primeira vez que é chamada.
        /// </summary>
        public static Atlas Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Atlas();
                }
                return _instance;
            }
        }

        private Atlas()
        {
            RaceManager = new RaceFactory();
            EnvironmentManager = new EnvironmentFactory();
            CharacterManager = new CharacterFactory();

            Console.WriteLine("ATLAS inicializado com sucesso.");
        }

        public RaceFactory GetRaceManager()
        {
            return RaceManager;
        }

        public EnvironmentFactory GetEnvironmentManager()
        {
            return EnvironmentManager;
        }

        public CharacterFactory GetCharacterManager()
        {
            return CharacterManager;

        }

        public void SetFileStorageSystem(IFileStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(storage), "O armazenamento de arquivos não pode ser nulo.");
            }
            this._storage = storage;
        }

        public void SaveSystemData(int type, string fileID, string content)
        {
            if (_storage == null)
            {
                throw new InvalidOperationException("O sistema de armazenamento de arquivos não foi configurado.");
            }

            _storage.Save(type, fileID, content);
        }

        public string LoadSystemData(int type, string fileName)
        {
            if (_storage == null)
            {
                throw new InvalidOperationException("O sistema de armazenamento de arquivos não foi configurado.");
            }
            return _storage.Load(type, fileName);
        }
    }
}
