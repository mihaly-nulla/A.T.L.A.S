using Genesis.Heart.IdentityModule.systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.NPC.Identity
{
    public class IdentityMapper : IMapper<IdentitySystem, NPCIdentity>
    {
        public IdentitySystem FromDTO(NPCIdentity destination)
        {
            return new IdentitySystem
            {
                NpcName = destination.NpcName,
                RaceID = destination.NpcRaceId,
                EnvironmentID = destination.NpcOriginEnvironmentId,
                Gender = destination.NpcGender,
                Age = destination.NpcAge,
                BiographyFull = destination.Biography,
                Role = destination.Role,
                PhysicalDescription = destination.PhysicalDescription,
                CoreBeliefs = destination.CoreBeliefs ?? new List<string>(),
                Likes = destination.Likes ?? new List<string>(),
                Dislikes = destination.Dislikes ?? new List<string>()
            };
        }

        public NPCIdentity ToDTO(IdentitySystem source)
        {
            return new NPCIdentity
            {
                NpcName = source.NpcName,
                NpcRaceId = source.RaceID,
                NpcOriginEnvironmentId = source.EnvironmentID,
                NpcGender = source.Gender,
                NpcAge = source.Age,
                Biography = source.BiographyFull,
                Role = source.Role,
                PhysicalDescription = source.PhysicalDescription,
                CoreBeliefs = source.CoreBeliefs,
                Likes = source.Likes,
                Dislikes = source.Dislikes
            };
        }
    }
}
