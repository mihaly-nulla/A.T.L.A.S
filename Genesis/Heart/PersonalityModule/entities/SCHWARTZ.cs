using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Heart.PersonalityModule.entities
{
    public class SCHWARTZ
    {
        public int SelfDirection { get; set; }

        public int Stimulation { get; set; }

        public int Hedonism { get; set; }

        public int Achievement { get; set; }

        public int Power { get; set; }

        public int Security { get; set; }

        public int Conformity { get; set; }

        public int Tradition { get; set; }

        public int Benevolence { get; set; }

        public int Universalism { get; set; }

        public SCHWARTZ() { }

        public SCHWARTZ(
                        int selfDirection,
                        int stimulation,
                        int hedonism,
                        int achievement,
                        int power,
                        int security,
                        int conformity,
                        int tradition,
                        int benevolence,
                        int universalism
                     )
        {
            SelfDirection = selfDirection;
            Stimulation = stimulation;
            Hedonism = hedonism;
            Achievement = achievement;
            Power = power;
            Security = security;
            Conformity = conformity;
            Tradition = tradition;
            Benevolence = benevolence;
            Universalism = universalism;
        }

        public void SetSelfDirection(int value)
        {
            SelfDirection = value;
        }

        public void SetStimulation(int value)
        {
            Stimulation = value;
        }

        public void SetHedonism(int value)
        {
            Hedonism = value;
        }

        public void SetAchievement(int value)
        {
            Achievement = value;
        }

        public void SetPower(int value)
        {
            Power = value;
        }

        public void SetSecurity(int value)
        {
            Security = value;
        }

        public void SetConformity(int value)
        {
            Conformity = value;
        }

        public void SetTradition(int value)
        {
            Tradition = value;
        }

        public void SetBenevolence(int value)
        {
            Benevolence = value;
        }

        public void SetUniversalism(int value)
        {
            Universalism = value;
        }
    }
}
