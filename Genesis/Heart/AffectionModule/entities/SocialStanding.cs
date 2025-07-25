using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
namespace Genesis.Heart.AffectionModule.entities
{
    public class SocialStanding
    {
        [JsonProperty("reputation_score")]
        public int ReputationScore { get; set; }

        [JsonProperty("reputation_type")]
        public string ReputationType { get; set; }

        [JsonProperty("known_by_npcs")]
        public List<string> KnownByNPCs { get; set; }

        [JsonProperty("unfavorable_npcs")]
        public List<string> UnfavorableNPCs { get; set; }

        public SocialStanding()
        {
            this.ReputationType = string.Empty;
            this.KnownByNPCs = new List<string>();
            this.UnfavorableNPCs = new List<string>();
        }

        public SocialStanding(int reputationScore, 
                                List<string> knownNPCs, 
                                List<string> unfavorableNPCs)
        {
            this.ReputationScore = reputationScore;
            this.ReputationType = CalculateReputationType(reputationScore);
            this.KnownByNPCs = knownNPCs;
            this.UnfavorableNPCs = unfavorableNPCs;
        }

        // Adiciona novo NPC conhecido
        public void AddNewKnownNpc(string npcId)
        {
            if (!this.KnownByNPCs.Contains(npcId)) this.KnownByNPCs.Add(npcId);
        }

        //Remove NPC conhecido
        public void RemoveKnownNpc(string npcId)
        {
            this.KnownByNPCs.Remove(npcId);
        }

        public void AddUnfavorableNpc(string npcId)
        {
            if (!this.UnfavorableNPCs.Contains(npcId)) this.UnfavorableNPCs.Add(npcId);
        }

        public void RemoveUnfavorableNpc(string npcId)
        {
            this.UnfavorableNPCs.Remove(npcId);
        }

        // Lógica para calcular o ReputationType (similar à discussão anterior)
        private string CalculateReputationType(int score)
        {
            if (score >= 80) return "Beloved"; // Amado
            if (score >= 60) return "Respected"; // Respeitado
            if (score >= 40) return "Recognized"; // Reconhecido
            if (score > -10 && score < 40) return "Neutral"; // Neutro
            if (score >= -40) return "Questionable"; // Questionável
            if (score >= -80) return "Dishonorable"; // Desonroso
            return "Infamous"; // Infame
        }
    }
}
