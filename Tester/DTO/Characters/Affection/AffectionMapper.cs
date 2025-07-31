using Genesis.Heart.AffectionModule.entities;
using Genesis.Heart.AffectionModule.systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Characters.Affection
{
    public class AffectionMapper : IMapper<AffectionSystem, NPCAffection>
    {
        public AffectionSystem FromDTO(NPCAffection destination)
        {
            /*AffectionSystem affections = new AffectionSystem();



            foreach (var relationship in destination.Relationships)
            {
                affections.AddRelationship(new Relationship
                    {
                        TargetNpcId = relationship.TargetNpcId,
                        AffectionScore = relationship.AffectionScore,
                        TrustScore = relationship.TrustScore,
                        FriendshipLevel = relationship.FriendshipLevel,
                        Traits = relationship.Traits ?? new List<string>()
                    }
                );
            }

            affections.SocialPerception = new SocialStanding
            {
                ReputationScore = destination.SocialPerception.ReputationScore,
                ReputationType = destination.SocialPerception.ReputationType,
                KnownByNPCs = destination.SocialPerception.KnownByNPCs,
                UnfavorableNPCs = destination.SocialPerception.UnfavorableNPCs
            };

            return affections;*/

            return new AffectionSystem
            {
                Relationships = destination.Relationships.ConvertAll(r => new Relationship
                {
                    TargetNpcId = r.TargetNpcId,
                    AffectionScore = r.AffectionScore,
                    TrustScore = r.TrustScore,
                    FriendshipLevel = r.FriendshipLevel,
                    Traits = r.Traits ?? new List<string>()
                }),
                SocialPerception = new SocialStanding
                {
                    ReputationScore = destination.SocialPerception.ReputationScore,
                    ReputationType = destination.SocialPerception.ReputationType,
                    KnownByNPCs = destination.SocialPerception.KnownByNPCs,
                    UnfavorableNPCs = destination.SocialPerception.UnfavorableNPCs
                }
            };
        }

        public NPCAffection ToDTO(AffectionSystem source)
        {
            return new NPCAffection
            {
                Relationships = source.Relationships.ConvertAll(r => new NPCRelationship
                {
                    TargetNpcId = r.TargetNpcId,
                    AffectionScore = r.AffectionScore,
                    TrustScore = r.TrustScore,
                    FriendshipLevel = r.FriendshipLevel,
                    Traits = r.Traits ?? new List<string>()
                }),
                SocialPerception = new NPCSocialStanding
                {
                    ReputationScore = source.SocialPerception.ReputationScore,
                    ReputationType = source.SocialPerception.ReputationType,
                    KnownByNPCs = source.SocialPerception.KnownByNPCs,
                    UnfavorableNPCs = source.SocialPerception.UnfavorableNPCs
                }
            };
        }
    }
}
