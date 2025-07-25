using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.Universe.CreationModule.entities.region
{
    public class WorldEnvironment
    {
        [JsonPropertyName("environment_id")]
        public string EnvironmentID { get; set; }

        [JsonPropertyName("name")]
        public string EnvironmentName { get; set; }

        [JsonPropertyName("type")]
        public string EnvironmentType { get; set; }

        [JsonPropertyName("general_description")]
        public string EnvironmentDescription { get; set; }

        [JsonPropertyName("key_characteristics")]
        public List<string> EnvironmentCharacteristics { get; set; }

        [JsonPropertyName("historical_context_summary")]
        public string EnvironmentHistoricalContext { get; set; }

        [JsonPropertyName("major_locations_overview")]
        public Dictionary<string, Location> EnvironmentMajorLocations { get; set; }

        public WorldEnvironment()
        {
            this.EnvironmentID = string.Empty;
            this.EnvironmentName = string.Empty;
            this.EnvironmentType = string.Empty;
            this.EnvironmentDescription = string.Empty;
            this.EnvironmentCharacteristics = new List<string>();
            this.EnvironmentHistoricalContext = string.Empty;
            this.EnvironmentMajorLocations = new Dictionary<string, Location>();
        }

        public WorldEnvironment(string environmentID,
                        string environmentName,
                        string environmentType,
                        string environmentDescription,
                        List<string> environmentCharacteristics,
                        string environmentHistoricalContext)
        {
            this.EnvironmentID = environmentID;
            this.EnvironmentName = environmentName;
            this.EnvironmentType = environmentType;
            this.EnvironmentDescription = environmentDescription;
            this.EnvironmentCharacteristics = environmentCharacteristics;
            this.EnvironmentHistoricalContext = environmentHistoricalContext;
        }

        public WorldEnvironment(string environmentID,
                                string environmentName,
                                string environmentType,
                                string environmentDescription,
                                List<string> environmentCharacteristics,
                                string environmentHistoricalContext,
                                Dictionary<string, Location> majorLocations)
        {
            this.EnvironmentID = environmentID;
            this.EnvironmentName = environmentName;
            this.EnvironmentType = environmentType;
            this.EnvironmentDescription = environmentDescription;
            this.EnvironmentCharacteristics = environmentCharacteristics;
            this.EnvironmentHistoricalContext = environmentHistoricalContext;
            this.EnvironmentMajorLocations = majorLocations;
        }

        public void SetEnvironmentMajorLocations(Dictionary<string, Location> majorLocations)
        {
            if (majorLocations == null)
            {
                throw new ArgumentNullException(nameof(majorLocations), "O dicionário de locais principais não pode ser nulo.");
            }
            this.EnvironmentMajorLocations = majorLocations;

        }

        public void AddMajorLocation(Location newLocation)
        {
            if (newLocation == null)
            {
                throw new ArgumentNullException(nameof(newLocation), "O local não pode ser nulo.");
            }
            if (!this.EnvironmentMajorLocations.ContainsKey(newLocation.LocationID))
            {
                this.EnvironmentMajorLocations.Add(newLocation.LocationID, newLocation);
            }
            else
            {
                throw new InvalidOperationException($"O local com ID '{newLocation.LocationID}' já existe no ambiente.");
            }
        }
    }
}
