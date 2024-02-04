using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sheet
{
    public class Character
    {
        //BASE

        public string cName;
        public int exp;
        public int level;
        public string race;
        public string _class;

        //PAGE 1 CHARACTERISTICS

        public Apearance apearance;
        public Personality personality;

        //PAGE 2 STATS

        public mainStats mainStats;
        public Skills skills;
        public Sthrows savingThrows;

        public List<int> proficiencies; //each one will have numbah assigned

        //PAGE 3 INVENTORY

        public Inventory inventory;

        //PAGE 4 



        //PAGE 5 



        //ELSE

        public string notes;

        public Character() { }

        public List<int> statsListed()
        {
            return new List<int> { mainStats.Str,mainStats.Dex,mainStats.Const,mainStats.Int,mainStats.Wis,mainStats.Char,skills.Acrobatics,skills.AnimHand, skills.Arcana,
            skills.Athletics,skills.Deception,skills.History,skills.Insight,skills.Intimidation,skills.Investigation,skills.Medicine,skills.Nature,skills.Nature,
            skills.Perceprtion,skills.Performance,skills.Persuasion,skills.Religion,skills.SoH,skills.Stealth,skills.Survival};
        }

    }

    //PAGE 1 Characteristics
    public class Apearance
    {
        public string background;
        public string age;
        public string height;
        public string weight;
        public string skin;
        public string eye;
        public string hair;
        public string alignment;
    }

    public class Personality
    {
        public string ideals;
        public string bonds;
        public string personalTraits;
        public string featuresTraits;
        public string profLanguages;
        public string backstory;
        public string allies;

        //put other here
    }

    //PAGE 2 Stats

    public class mainStats
    {
        public int Str;
        public int Dex;
        public int Const;
        public int Int;
        public int Wis;
        public int Char;
    }

    public class Skills
    {
        public int Acrobatics;
        public int AnimHand;
        public int Arcana;

        public int Athletics;
        public int Deception;
        public int History;

        public int Insight;
        public int Intimidation;
        public int Investigation;

        public int Medicine;
        public int Nature;
        public int Perceprtion;

        public int Performance;
        public int Persuasion;
        public int Religion;

        public int SoH;
        public int Stealth;
        public int Survival;
    }
    public class Sthrows
    {
        public int Strenghth;
        public int Dexterity;
        public int Constitution;
        public int Inteligence;
        public int Wisdom;
        public int Charisma;
    }

    //PAGE 3

    public class Inventory
    {
        public string equipment;
        public string treasure;
    }

    //PAGE 4 
    public class SpellBook
    {
        //cantrips

        //spells
    }


    //PAGE 5 

}
