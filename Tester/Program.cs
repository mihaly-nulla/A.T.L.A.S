using Genesis.Factory.NPCs.CreationModule.entities;
using Genesis.Factory.NPCs.CreationModule.systems;
using Genesis.Factory.Universe.CreationModule.entities.race;
using Genesis.Factory.Universe.CreationModule.entities.region;
using Genesis.Factory.Universe.CreationModule.systems;
using Genesis.Heart.AffectionModule.entities;
using Genesis.Heart.AffectionModule.systems;
using Genesis.Heart.IdentityModule.systems;
using Genesis.Heart.PersonalityModule.entities;
using Genesis.Heart.PersonalityModule.systems;
using Genesis.Mind.KnowledgeModule.entities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Genesis;
using System.Runtime.CompilerServices;
using Newtonsoft;
using Newtonsoft.DTO.Characters;
using Newtonsoft.DTO.Characters.Personality;
using Newtonsoft.DTO.Characters.Identity;
using Newtonsoft.DTO.Characters.Affection;
using Newtonsoft.DTO.World._Location;
using Newtonsoft.DTO.World;
using Newtonsoft.DTO.Races;
using Newtonsoft.Serializer;
using Newtonsoft.Communication;

namespace A.T.L.A.S
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            Atlas atlas = Atlas.Instance;

            var test_npc = atlas.GetCharacterManager().CreateNPC("test");

            test_npc.NpcPersonality.oceanPersonality = new OCEAN(100, 100, 100, 100, 100);

            test_npc.NpcPersonality.schwartzPersonality = new SCHWARTZ(100, 100, 100, 100, 100, 100, 100, 100, 100, 100);

            test_npc.NpcPersonality.personalityStyle = new DialogueStyle(
                "enthusiastic and inspiring",
                30,
                "accessible, full of analogies and metaphors",
                ""
            );

            test_npc.NpcIdentity.NpcName = "Test";
            test_npc.NpcIdentity.RaceID = "human";
            test_npc.NpcIdentity.EnvironmentID = "rua_acasia";
            test_npc.NpcIdentity.Gender = "Male";
            test_npc.NpcIdentity.Age = 30;
            test_npc.NpcIdentity.BiographyFull = "This is a test NPC created to demonstrate the functionality of the Atlas system. It serves as a placeholder for testing purposes.";   
            test_npc.NpcIdentity.Role = "Test Role";
            test_npc.NpcIdentity.PhysicalDescription = "A generic test NPC with no specific features.";
            test_npc.NpcIdentity.CoreBeliefs = new List<string>
            {
                "Knowledge is power.",
                "Curiosity drives innovation.",
                "Empathy is essential for understanding others."
            };
            test_npc.NpcIdentity.Likes = new List<string>
            {
                "Reading books",
                "Exploring new ideas",
                "Helping others"
            };

            test_npc.NpcIdentity.Dislikes = new List<string>
            {
                "Ignorance",
                "Close-mindedness",
                "Dishonesty"
            };

            test_npc.NpcAffections.AddRelationship(
                new Relationship(
                    "lucio",
                    80,
                    70,
                    "Friend",
                    new List<string> { "sarcastic", "blunt" }
                )
            );

            test_npc.NpcAffections.SocialPerception = new SocialStanding(
                90,
                new List<string> { "lucio" },
                new List<string> { "dracula" }
            );

            PersonalityMapper personalityMapper = new PersonalityMapper();
            IdentityMapper identityMapper = new IdentityMapper();
            AffectionMapper affectionMapper = new AffectionMapper();

            var testEnvironment = atlas.GetEnvironmentManager().CreateEnvironment
            (
                "test_environment",
                "Test Environment",
                "planet",
                "This is a test environment created to demonstrate the functionality of the Atlas system. It serves as a placeholder for testing purposes.",
                new List<string> { "test", "environment", "placeholder" },
                "This test environment is designed to showcase the capabilities of the Atlas system. It is not intended for actual gameplay but rather for testing and development purposes.",
                new Dictionary<string, Location>
                {
                    { "test_location", new Location("test_location", "Test Location", "Test Type", "This is a test location within the test environment.", new List<string> { "test", "location" }) }
                }
            );

            var testRace = atlas.GetRaceManager().CreateRace
            (
                "test_race",
                "Test Race",
                new RaceDescription
                (
                    "This is a test",
                    "This is a test",
                    "This is a test",
                    "This is a test"
                ),
                "This is a test appearance",
                "This is a test lore"
            );

            var testRace2 = atlas.GetRaceManager().CreateRace
            (
                "test_race_2",
                "Test Race2",
                new RaceDescription
                (
                    "This is a test2",
                    "This is a test2",
                    "This is a test2",
                    "This is a test2"
                ),
                "This is a test appearance2",
                "This is a test lore2"
            );
            var npcDTO = new NPC
            {
                NPCId = test_npc.GetNPCID(),
                NpcIdentity = identityMapper.ToDTO(test_npc.NpcIdentity),
                NpcPersonality = personalityMapper.ToDTO(test_npc.NpcPersonality),
                NpcAffections = affectionMapper.ToDTO(test_npc.NpcAffections)
            };

            

            UniverseMapper universeMapper = new UniverseMapper();
            UniverseRacesMapper racesMapper = new UniverseRacesMapper();

            var environmentDTO = universeMapper.ToDTO(atlas.GetEnvironmentManager().EnvironmentDatabase);

            var racesDTO = racesMapper.ToDTO(atlas.GetRaceManager().RaceDatabase);

            var settings = new JsonSerializerSettings
            {
                // Formata o JSON com quebras de linha e indentação para facilitar a leitura
                Formatting = Formatting.Indented,
                // Ignora propriedades com valor nulo para um JSON mais limpo
                NullValueHandling = NullValueHandling.Ignore
            };

            // 2. Serialize o objeto DTO para uma string JSON
            string npcJsonString = JsonConvert.SerializeObject(npcDTO, settings);

            string environmentJsonString = JsonConvert.SerializeObject(environmentDTO, settings);

            string racesJsonString = JsonConvert.SerializeObject(racesDTO, settings);

            NPC deserializedNpc = JsonConvert.DeserializeObject<NPC>(npcJsonString);

            atlas.GetCharacterManager().CreateNPC(
                                                    "test_deserialized",
                                                    identityMapper.FromDTO(deserializedNpc.NpcIdentity),
                                                    personalityMapper.FromDTO(deserializedNpc.NpcPersonality),
                                                    affectionMapper.FromDTO(deserializedNpc.NpcAffections)
                                                 );

            var created_npc = atlas.GetCharacterManager().GetNPCBrain("test_deserialized");

            TestSaver saver = new TestSaver();
            NewtonsoftSerializer serializer = new NewtonsoftSerializer();
          

            atlas.SetFileStorageSystem(saver);
            atlas.SetDataSerializer(serializer);



            atlas.SaveSystemData(0, "test", npcJsonString);
        }
    }
}