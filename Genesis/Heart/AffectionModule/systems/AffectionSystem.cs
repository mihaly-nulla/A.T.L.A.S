using Genesis.Heart.AffectionModule.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Heart.AffectionModule.systems
{
    public class AffectionSystem
    {
        public List<Relationship> Relationships { get; set; }

        public SocialStanding SocialPerception { get; set; }

        public AffectionSystem()
        {
            this.Relationships = new List<Relationship>();
            this.SocialPerception = new SocialStanding();
        }

        public AffectionSystem(List<Relationship> relationships, SocialStanding socialStanding)
        {
            this.Relationships = relationships ?? new List<Relationship>();
            this.SocialPerception = socialStanding ?? new SocialStanding();
        }

        public void AddRelationship(Relationship relationship)
        {
            if (relationship != null && !this.Relationships.Any(r => r.TargetNpcId == relationship.TargetNpcId))
            {
                this.Relationships.Add(relationship);
            }
        }

        /// <summary>
        /// Atualiza um relacionamento com outro NPC.
        /// </summary>
        public void UpdateRelationship(string targetNpcId, int newAffection, int newTrust, string newFriendshipLevel, List<string> newTraits)
        {
            var existingRelationship = this.Relationships.FirstOrDefault(r => r.TargetNpcId == targetNpcId);
            if (existingRelationship != null)
            {
                existingRelationship.UpdateAffection(newAffection);
                existingRelationship.UpdateTrust(newTrust);
                existingRelationship.UpdateFriendshipLevel(newFriendshipLevel);
                existingRelationship.OverrideTraits(newTraits);
            }
        }

        public Relationship GetRelationship(string targetNpcId)
        {
            return this.Relationships.FirstOrDefault(r => r.TargetNpcId == targetNpcId);
        }
    }
}
