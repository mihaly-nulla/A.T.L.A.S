using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace Genesis.Factory.Universe.CreationModule.entities.region
{
    public class Location
    {
        [JsonProperty("location_id")]
        public string LocationID { get; set; }

        [JsonProperty("name")]
        public string LocationName { get; set; }

        [JsonProperty("type")]
        public string LocationType { get; set; }

        [JsonProperty("description_summary")]
        public string LocationDescription { get; set; }

        [JsonProperty("key_features")]
        public List<string> LocationKeyFeatures { get; set; }

        public Location()
        {
            LocationID = string.Empty;
            LocationName = string.Empty;
            LocationType = string.Empty;
            LocationDescription = string.Empty;
            LocationKeyFeatures = new List<string>();
        }

        public Location(string locationID, 
                        string locationName, 
                        string locationType, 
                        string locationDescription, 
                        List<string> locationKeyFeatures)
        {
            LocationID = locationID;
            LocationName = locationName;
            LocationType = locationType;
            LocationDescription = locationDescription;
            LocationKeyFeatures = locationKeyFeatures ?? new List<string>();
        }
    }
}
