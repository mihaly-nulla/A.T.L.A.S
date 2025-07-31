using Genesis.Factory.NPCs.CreationModule.entities;
using Newtonsoft.DTO.Characters.Affection;
using Newtonsoft.DTO.Characters.Identity;
using Newtonsoft.DTO.Characters.Personality;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newtonsoft.DTO.Characters
{
    public class NPCMapper : IMapper<Brain, NPC>
    {
        public Brain FromDTO(NPC destination)
        {
            return new Brain
            {
                NPCId = destination.NPCId,
                NpcIdentity = new IdentityMapper().FromDTO(destination.NpcIdentity),
                NpcPersonality = new PersonalityMapper().FromDTO(destination.NpcPersonality),
                NpcAffections = new AffectionMapper().FromDTO(destination.NpcAffections)
            };
        }

        public NPC ToDTO(Brain source)
        {
            return new NPC
            {
                NPCId = source.NPCId,
                NpcIdentity = new IdentityMapper().ToDTO(source.NpcIdentity),
                NpcPersonality = new PersonalityMapper().ToDTO(source.NpcPersonality),
                NpcAffections = new AffectionMapper().ToDTO(source.NpcAffections)
            };
        }
    }
}
