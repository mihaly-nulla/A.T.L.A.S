﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A.T.L.A.S.Heart.AffectionModule.entities
{
    public class Relationship
    {
        [JsonPropertyName("target_npc_id")]
        public string TargetNpcId { get; set; }

        [JsonPropertyName("affection_score")]
        public int AffectionScore { get; set; }

        [JsonPropertyName("trust_score")]
        public int TrustScore { get; set; }

        [JsonPropertyName("friendship_level")]
        public string FriendshipLevel { get; set; }

        [JsonPropertyName("traits")]
        public List<string> Traits { get; set; }

        public Relationship()
        {
            this.TargetNpcId = string.Empty;
            this.FriendshipLevel = string.Empty;
            this.Traits = new List<string>();
        }

        public Relationship(string targetNpcId, int affectionScore, int trustScore, string friendshipLevel, List<string> traits)
        {
            if (string.IsNullOrWhiteSpace(targetNpcId))
                throw new System.ArgumentException("TargetNpcId cannot be null or empty.", nameof(targetNpcId));

            this.TargetNpcId = targetNpcId;
            this.AffectionScore = affectionScore;
            this.TrustScore = trustScore;
            this.FriendshipLevel = friendshipLevel;
            this.Traits = traits ?? new List<string>();
        }

        public void UpdateAffection(int newAffection)
        {
            if (newAffection < 0)
                throw new ArgumentOutOfRangeException(nameof(newAffection), "Affection score cannot be negative.");
            this.AffectionScore = newAffection;
        }

        public void UpdateTrust(int newTrust)
        {
            if (newTrust < 0)
                throw new ArgumentOutOfRangeException(nameof(newTrust), "Trust score cannot be negative.");
            this.TrustScore = newTrust;
        }

        public void UpdateFriendshipLevel(string newFriendshipLevel)
        {
            if (string.IsNullOrWhiteSpace(newFriendshipLevel))
                throw new ArgumentException("Friendship level cannot be null or empty.", nameof(newFriendshipLevel));
            this.FriendshipLevel = newFriendshipLevel;
        }

        public void AddTrait(string trait)
        {
            if (string.IsNullOrWhiteSpace(trait))
                throw new ArgumentException("Trait cannot be null or empty.", nameof(trait));
            if (!this.Traits.Contains(trait))
            {
                this.Traits.Add(trait);
            }
        }

        public void RemoveTrait(string trait)
        {
            if (string.IsNullOrWhiteSpace(trait))
                throw new ArgumentException("Trait cannot be null or empty.", nameof(trait));
            if (this.Traits.Contains(trait))
            {
                this.Traits.Remove(trait);
            }
        }

        public void ClearTraits()
        {
            this.Traits.Clear();
        }

        public void ResetRelationship()
        {
            this.AffectionScore = 0;
            this.TrustScore = 0;
            this.FriendshipLevel = "None";
            this.Traits.Clear();
        }

        public void OverrideTraits(List<string> newTraits)
        {
            if (newTraits == null)
                throw new ArgumentNullException(nameof(newTraits), "New traits cannot be null.");
            this.Traits = new List<string>(newTraits);
        }
    }
}
