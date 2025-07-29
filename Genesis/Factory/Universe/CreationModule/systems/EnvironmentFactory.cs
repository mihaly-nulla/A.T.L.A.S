using Genesis.Factory.Universe.CreationModule.components.location;
using Genesis.Factory.Universe.CreationModule.entities.region;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Genesis.Factory.Universe.CreationModule.systems
{
    public class EnvironmentFactory
    {

        public UniverseEnvironments EnvironmentDatabase { get; private set; }

        public EnvironmentFactory()
        {

            EnvironmentDatabase = new UniverseEnvironments(); // Inicializa o banco de dados de environments vazio

        }

        public void SetEnvironmentDatabase(UniverseEnvironments worldEnvironments)
        {
            if (worldEnvironments == null)
            {
                throw new ArgumentNullException(nameof(worldEnvironments), "O banco de dados de raças não pode ser nulo.");
            }

            EnvironmentDatabase = worldEnvironments;
        }

        public void AddEnvironment(WorldEnvironment newEnvironment)
        {
            if (EnvironmentDatabase != null && !EnvironmentDatabase.UniverseResourcesDatabase.ContainsKey(newEnvironment.EnvironmentID))
            {
                EnvironmentDatabase.UniverseResourcesDatabase.Add(newEnvironment.EnvironmentID, newEnvironment);
                Debug.WriteLine($"Environment '{newEnvironment.EnvironmentID}' adicionada ao banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Environment '{newEnvironment.EnvironmentID}' já existe ou RaceDatabase é nulo.");
            }
        }

        public WorldEnvironment CreateEnvironment(string environmentID,
                               string environmentName,
                               string environmentType,
                               string environmentDescription,
                               List<string> environmentCharacteristics,
                               string environmentHistoricalContext,
                               Dictionary<string, Location> relevantLocations)
        {
            var worldEnvironment = new WorldEnvironment(
                                            environmentID,
                                            environmentName,
                                            environmentType,
                                            environmentDescription,
                                            environmentCharacteristics,
                                            environmentHistoricalContext,
                                            relevantLocations
                                        );
            AddEnvironment(worldEnvironment);

            return worldEnvironment;
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
            if (EnvironmentDatabase != null && EnvironmentDatabase.UniverseResourcesDatabase.Remove(environmentId))
            {
                Debug.WriteLine($"Raça '{environmentId}' removida do banco de dados.");
            }
            else
            {
                Debug.WriteLine($"Aviso: Raça '{environmentId}' não encontrada ou RaceDatabase é nulo.");
            }
        }

        /// <summary>
        /// Obtém uma definição de WorldEnvironment específica do banco de dados de environments carregado em memória.
        /// </summary>
        /// <param name="environmentId">O ID da raça a ser recuperada.</param>
        /// <returns>O objeto WorldEnvironment correspondente, ou null se não for encontrada.</returns>
        public WorldEnvironment GetEnvironmentById(string raceId) // Nome mais claro: GetRaceById (RaceFactory)
        {
            if (EnvironmentDatabase.CheckIfEmpty())
            {
                throw new InvalidOperationException("Nenhum database de environments foi carregado.");
            }
            return EnvironmentDatabase.GetResourceById(raceId);
        }
    }
}
