using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sheet
{
    public class Character
    {
        public Stats stats;
        public Skills skills;
        public Sthrows savingThrows;
        public List<AnS> attacksAndSpells;


        public string cName;
        public string race;
        public string _class;

        

        public int level;

        public Character() { }

    }

    //used these for convenience
    public class CharDescription
    {
        public string height;
        public string weigth;
        public string age;
        public string alignment;
        public string persTraits;
        public string ideals;
        public string bonds;
        public string flaws;
        public string featuresAndTraits;
        public string profAndLanguages;

    }
    public class Stats
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

    public class AnS
    {
        public string aName;
        public string aBonus;
        public string damageAndType;
    }
    //not sure how will you want from the other stuff
    public class OtherP1
    {
        public string armorClass;
        public string iniative;
        public string speed;
        public int hP;
        public int tempHP;
    }
}
