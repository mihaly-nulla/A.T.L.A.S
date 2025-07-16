using A.T.L.A.S.Factory.Tools;
using A.T.L.A.S.Factory.World.CreationModule.DTOs;
using A.T.L.A.S.Factory.World.CreationModule.entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.World.CreationModule.systems
{
    public class RaceManagerSystem
    {
        private const string RACE_SAVE_DIRECTORY_NAME = "database/universe/races"; // Pasta dentro da raiz do projeto
        private const string RACES_FILE_NAME = "world_races.json";

        private readonly string _racesFilePath;

        public UniverseRaces RaceDatabase { get; private set; }

        public RaceManagerSystem()
        {
            string loreFolderPath = DirectoryBuilderComponent.BuildCustomPath(RACE_SAVE_DIRECTORY_NAME);
            this._racesFilePath = Path.Combine(loreFolderPath, RACES_FILE_NAME);

            // Garante que o diretório de salvamento exista
            if (!Directory.Exists(loreFolderPath))
            {
                Directory.CreateDirectory(loreFolderPath);
                Debug.WriteLine($"Diretório de lore criado: {loreFolderPath}");
            }
            Debug.WriteLine($"Caminho do arquivo de raças: {_racesFilePath}");

            this.RaceDatabase = new UniverseRaces(); // Inicializa o banco de dados de raças vazio
        }

        /// <summary>
        /// Carrega todas as definições de raça do arquivo JSON.
        /// </summary>
        public void LoadAllRaces()
        {
            try
            {
                RaceDatabase = UniverseRaces.LoadFromJsonFile(this._racesFilePath);
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
                UniverseRaces.SaveToJsonFile(this.RaceDatabase, this._racesFilePath);
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

            this.RaceDatabase = worldRaces;
        }

        public void AddRace(Race newRace)
        {
            if (this.RaceDatabase != null && !this.RaceDatabase.UniverseRacesDatabase.ContainsKey(newRace.RaceID))
            {
                RaceDatabase.UniverseRacesDatabase.Add(newRace.RaceID, newRace);
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
            if (this.RaceDatabase != null && this.RaceDatabase.UniverseRacesDatabase.Remove(raceId))
            {
                Debug.WriteLine($"Raça '{raceId}' removida do banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Raça '{raceId}' não encontrada ou RaceDatabase é nulo.");
            }
        }
    }
}
