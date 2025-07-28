using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Factory.Universe.CreationModule.entities.region
{
    public class Location
    {
        public string LocationID { get; set; }

        public string LocationName { get; set; }

        public string LocationType { get; set; }

        public string LocationDescription { get; set; }

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
