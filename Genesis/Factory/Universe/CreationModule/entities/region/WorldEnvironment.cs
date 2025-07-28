using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Factory.Universe.CreationModule.entities.region
{
    public class WorldEnvironment
    {

        public string EnvironmentID { get; set; }

        public string EnvironmentName { get; set; }

        public string EnvironmentType { get; set; }

        public string EnvironmentDescription { get; set; }

        public List<string> EnvironmentCharacteristics { get; set; }

        public string EnvironmentHistoricalContext { get; set; }

        public Dictionary<string, Location> EnvironmentMajorLocations { get; set; }

        public WorldEnvironment()
        {
            EnvironmentID = string.Empty;
            EnvironmentName = string.Empty;
            EnvironmentType = string.Empty;
            EnvironmentDescription = string.Empty;
            EnvironmentCharacteristics = new List<string>();
            EnvironmentHistoricalContext = string.Empty;
            EnvironmentMajorLocations = new Dictionary<string, Location>();
        }

        public WorldEnvironment(string environmentID,
                        string environmentName,
                        string environmentType,
                        string environmentDescription,
                        List<string> environmentCharacteristics,
                        string environmentHistoricalContext)
        {
            EnvironmentID = environmentID;
            EnvironmentName = environmentName;
            EnvironmentType = environmentType;
            EnvironmentDescription = environmentDescription;
            EnvironmentCharacteristics = environmentCharacteristics;
            EnvironmentHistoricalContext = environmentHistoricalContext;
        }

        public WorldEnvironment(string environmentID,
                                string environmentName,
                                string environmentType,
                                string environmentDescription,
                                List<string> environmentCharacteristics,
                                string environmentHistoricalContext,
                                Dictionary<string, Location> majorLocations)
        {
            EnvironmentID = environmentID;
            EnvironmentName = environmentName;
            EnvironmentType = environmentType;
            EnvironmentDescription = environmentDescription;
            EnvironmentCharacteristics = environmentCharacteristics;
            EnvironmentHistoricalContext = environmentHistoricalContext;
            EnvironmentMajorLocations = majorLocations;
        }

        public void SetEnvironmentMajorLocations(Dictionary<string, Location> majorLocations)
        {
            if (majorLocations == null)
            {
                throw new ArgumentNullException(nameof(majorLocations), "O dicionário de locais principais não pode ser nulo.");
            }
            EnvironmentMajorLocations = majorLocations;

        }

        public void AddMajorLocation(Location newLocation)
        {
            if (newLocation == null)
            {
                throw new ArgumentNullException(nameof(newLocation), "O local não pode ser nulo.");
            }
            if (!EnvironmentMajorLocations.ContainsKey(newLocation.LocationID))
            {
                EnvironmentMajorLocations.Add(newLocation.LocationID, newLocation);
            }
            else
            {
                throw new InvalidOperationException($"O local com ID '{newLocation.LocationID}' já existe no ambiente.");
            }
        }
    }
}
