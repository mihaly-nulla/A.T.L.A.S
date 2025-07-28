using Genesis.Factory.Tools;
using Genesis.Factory.Tools.SerializationInterface;
using Genesis.Factory.Universe.CreationModule.DTOs.race;
using Genesis.Factory.Universe.CreationModule.entities.race;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO - Verificar possibilidade de aplicar um Factory Method
namespace Genesis.Factory.Universe.CreationModule.systems
{
    public class RaceFactory
    {
        private const string RACE_SAVE_DIRECTORY_NAME = "database/universe/races"; // Pasta dentro da raiz do projeto
        private const string RACES_FILE_NAME = "races.json";

        private readonly string _racesFilePath;

        public UniverseRaces RaceDatabase { get; private set; }

        private ISerializer _serializer;

        public RaceFactory(ISerializer serializer)
        {
            string loreFolderPath = DirectoryBuilderComponent.BuildCustomPath(RACE_SAVE_DIRECTORY_NAME);
            _racesFilePath = Path.Combine(loreFolderPath, RACES_FILE_NAME);

            // Garante que o diretório de salvamento exista
            if (!Directory.Exists(loreFolderPath))
            {
                Directory.CreateDirectory(loreFolderPath);
                Debug.WriteLine($"Diretório de lore criado: {loreFolderPath}");
            }
            Debug.WriteLine($"Caminho do arquivo de raças: {_racesFilePath}");

            RaceDatabase = new UniverseRaces(); // Inicializa o banco de dados de raças vazio
            this._serializer = serializer ?? throw new ArgumentNullException(nameof(serializer), "O serializador não pode ser nulo.");
        }

        public RaceFactory(string path, ISerializer serializer)
        {
            string fullPath = Path.Combine(path, RACE_SAVE_DIRECTORY_NAME.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

            _racesFilePath = fullPath;
            this._serializer = serializer ?? throw new ArgumentNullException(nameof(serializer), "O serializador não pode ser nulo.");
        }

        /// <summary>
        /// Carrega todas as definições de raça do arquivo JSON.
        /// </summary>
        public void LoadAllRaces()
        {
            try
            {
                RaceDatabase = this._serializer.Deserialize<UniverseRaces>(UniverseRaces.LoadFromJsonFile(_racesFilePath));
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine($"Arquivo de raças '{_racesFilePath}' não encontrado. Iniciando com banco de dados de raças vazio.");
                RaceDatabase = new UniverseRaces(); // Cria um novo sistema vazio se o arquivo não existir
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao carregar raças: {ex.Message}");
                RaceDatabase = new UniverseRaces(); // Garante que a instância não seja nula
            }
        }

        /// <summary>
        /// Salva todas as definições de raça atuais em um arquivo JSON.
        /// </summary>
        public void SaveAllRaces()
        {
            if (RaceDatabase != null)
            {
                UniverseRaces.SaveToJsonFile(_serializer.Serialize(RaceDatabase), _racesFilePath);
            }
            else
            {
                Debug.WriteLine("Aviso: Tentativa de salvar raças, mas RaceDatabase é nulo.");
            }
        }

        public void SetRacesDatabase(UniverseRaces worldRaces)
        {
            if (worldRaces == null)
            {
                throw new ArgumentNullException(nameof(worldRaces), "O banco de dados de raças não pode ser nulo.");
            }

            RaceDatabase = worldRaces;
        }

        public void AddRace(Race newRace)
        {
            if (RaceDatabase != null && !RaceDatabase.UniverseResourcesDatabase.ContainsKey(newRace.RaceID))
            {
                RaceDatabase.UniverseResourcesDatabase.Add(newRace.RaceID, newRace);
                Debug.WriteLine($"Raça '{newRace.RaceName}' adicionada ao banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Raça '{newRace.RaceName}' já existe ou RaceDatabase é nulo.");
            }
        }

        public Race CreateRace(string raceID,
                               string raceName,
                               RaceDescription raceInformation,
                               string raceAppearenceDescription,
                               string raceLore)
        {
            return new Race(raceID,
                                  raceName,
                                  raceInformation,
                                  raceAppearenceDescription,
                                  raceLore
                                  );
        }

        public RaceDescription CreateRaceDescription(string racialGeneralOverview,
                                          string racialCulturalValues,
                                          string racialSocialBehavior,
                                          string racialAbilities)
        {
            return new RaceDescription(racialGeneralOverview,
                                       racialCulturalValues,
                                       racialSocialBehavior,
                                       racialAbilities);
        }

        public void RemoveRace(string raceId)
        {
            if (RaceDatabase != null && RaceDatabase.UniverseResourcesDatabase.Remove(raceId))
            {
                Debug.WriteLine($"Raça '{raceId}' removida do banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Raça '{raceId}' não encontrada ou RaceDatabase é nulo.");
            }
        }

        /// <summary>
        /// Obtém uma definição de raça específica do banco de dados de raças carregado em memória.
        /// </summary>
        /// <param name="raceId">O ID da raça a ser recuperada.</param>
        /// <returns>O objeto Race correspondente, ou null se não for encontrada.</returns>
        public Race GetRaceById(string raceId) // Nome mais claro: GetRaceById (RaceFactory)
        {
            
            if(RaceDatabase.CheckIfEmpty())
            {
                LoadAllRaces();
            }
            return RaceDatabase.GetResourceById(raceId);
        }
    }
}
