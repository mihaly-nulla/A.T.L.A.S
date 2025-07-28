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


        public UniverseRaces RaceDatabase { get; private set; }

        public RaceFactory()
        {

            RaceDatabase = new UniverseRaces();
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
                throw new InvalidOperationException("Nenhum database de races foi carregado.");
            }
            return RaceDatabase.GetResourceById(raceId);
        }
    }
}
