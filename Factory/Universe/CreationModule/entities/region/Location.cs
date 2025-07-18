using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Factory.Universe.CreationModule.entities.region
{
    public class Location
    {
        [JsonPropertyName("location_id")]
        public string LocationID { get; set; }

        [JsonPropertyName("name")]
        public string LocationName { get; set; }

        [JsonPropertyName("type")]
        public string LocationType { get; set; }

        [JsonPropertyName("description_summary")]
        public string LocationDescription { get; set; }

        [JsonPropertyName("key_features")]
        public List<string> LocationKeyFeatures { get; set; }

        public Location()
        {
            this.LocationID = string.Empty;
            this.LocationName = string.Empty;
            this.LocationType = string.Empty;
            this.LocationDescription = string.Empty;
            this.LocationKeyFeatures = new List<string>();
        }

        public Location(string locationID, 
                        string locationName, 
                        string locationType, 
                        string locationDescription, 
                        List<string> locationKeyFeatures)
        {
            this.LocationID = locationID;
            this.LocationName = locationName;
            this.LocationType = locationType;
            this.LocationDescription = locationDescription;
            this.LocationKeyFeatures = locationKeyFeatures ?? new List<string>();
        }
    }
}
