using A.T.L.A.S.Factory.Tools;
using A.T.L.A.S.Factory.Universe.CreationModule.DTOs.location;
using A.T.L.A.S.Factory.Universe.CreationModule.DTOs.race;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.race;
using A.T.L.A.S.Factory.Universe.CreationModule.entities.region;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.World.CreationModule.systems
{
    public class EnvironmentFactory
    {
        private const string ENVIRONMENT_SAVE_DIRECTORY_NAME = "database/universe/environments";
        private const string ENVIRONMENTS_FILE_NAME = "environments.json";

        private readonly string _environmentsFilePath;

        public UniverseEnvironments EnvironmentDatabase { get; private set; }

        public EnvironmentFactory()
        {
            string loreFolderPath = DirectoryBuilderComponent.BuildCustomPath(ENVIRONMENT_SAVE_DIRECTORY_NAME);
            this._environmentsFilePath = Path.Combine(loreFolderPath, ENVIRONMENTS_FILE_NAME);

            // Garante que o diretório de salvamento exista
            if (!Directory.Exists(loreFolderPath))
            {
                Directory.CreateDirectory(loreFolderPath);
                Debug.WriteLine($"Diretório de lore criado: {loreFolderPath}");
            }
            Debug.WriteLine($"Caminho do arquivo de raças: {_environmentsFilePath}");

            this.EnvironmentDatabase = new UniverseEnvironments(); // Inicializa o banco de dados de environments vazio
        }

        /// <summary>
        /// Carrega todas as definições de raça do arquivo JSON.
        /// </summary>
        public void LoadAllEnvironments()
        {
            try
            {
                this.EnvironmentDatabase = UniverseEnvironments.LoadFromJsonFile(this._environmentsFilePath);
            }
            catch (FileNotFoundException)
            {
                Debug.WriteLine($"Arquivo de raças '{_environmentsFilePath}' não encontrado. Iniciando com banco de dados de raças vazio.");
                this.EnvironmentDatabase = new UniverseEnvironments(); // Cria um novo sistema vazio se o arquivo não existir
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao carregar raças: {ex.Message}");
                this.EnvironmentDatabase = new UniverseEnvironments(); // Garante que a instância não seja nula
            }
        }

        /// <summary>
        /// Salva todas as definições de raça atuais em um arquivo JSON.
        /// </summary>
        public void SaveAllEnvironments()
        {
            if (this.EnvironmentDatabase != null)
            {
                UniverseEnvironments.SaveToJsonFile(this.EnvironmentDatabase, this._environmentsFilePath);
            }
            else
            {
                Debug.WriteLine("Aviso: Tentativa de salvar raças, mas RaceDatabase é nulo.");
            }
        }

        public void SetEnvironmentDatabase(UniverseEnvironments worldEnvironments)
        {
            if (worldEnvironments == null)
            {
                throw new ArgumentNullException(nameof(worldEnvironments), "O banco de dados de raças não pode ser nulo.");
            }

            this.EnvironmentDatabase = worldEnvironments;
        }

        public void AddEnvironment(WorldEnvironment newEnvironment)
        {
            if (this.EnvironmentDatabase != null && !this.EnvironmentDatabase.UniverseResourcesDatabase.ContainsKey(newEnvironment.EnvironmentID))
            {
                this.EnvironmentDatabase.UniverseResourcesDatabase.Add(newEnvironment.EnvironmentID, newEnvironment);
                Debug.WriteLine($"Raça '{newEnvironment.EnvironmentID}' adicionada ao banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Raça '{newEnvironment.EnvironmentID}' já existe ou RaceDatabase é nulo.");
            }
        }

        public WorldEnvironment CreateEnvironment(string environmentID,
                               string environmentName,
                               string environmentType,
                               string environmentDescription,
                               List<string> environmentCharacteristics,
                               string environmentHistoricalContext,
                               string environmentSociopoliticalOverview,
                               string environmentTechLevel,
                               Dictionary<string, Location> relevantLocations)
        {
            return new WorldEnvironment(
                                            environmentID,
                                            environmentName,
                                            environmentType,
                                            environmentDescription,
                                            environmentCharacteristics,
                                            environmentHistoricalContext,
                                            environmentSociopoliticalOverview,
                                            relevantLocations
                                        );
        }

        public Location CreateEnvironmentLocation(string locationID,
                                          string locationName,
                                          string locationType,
                                          string locationDescription,
                                          List<string> locationKeyFeatures)
        {
            return new Location(
                                    locationID,
                                    locationName,
                                    locationType,
                                    locationDescription,
                                    locationKeyFeatures
                                );
        }

        public void RemoveEnvironment(string environmentId)
        {
            if (this.EnvironmentDatabase != null && this.EnvironmentDatabase.UniverseResourcesDatabase.Remove(environmentId))
            {
                Debug.WriteLine($"Raça '{environmentId}' removida do banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Raça '{environmentId}' não encontrada ou RaceDatabase é nulo.");
            }
        }
    }
}
