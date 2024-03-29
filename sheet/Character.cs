﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace sheet
{
    public class Character
    {
        [JsonProperty]
        private string VERSION = "dev-1.3.0";
        public int[] xpNeeded = new int[] { 0, 300, 900, 2700, 6500, 14000, 23000, 34000, 48000, 64000, 85000, 100000, 120000, 140000, 165000, 192000, 225000, 265000, 305000, 355000 };
        //Base
        public int proefficency = 0;
        public List<int>[] bonus = new List<int>[2] { new List<int> { }, new List<int> { } };
        public string cName { get; set; }
        public string race { get; set; }
        public string charClass { get; set; }
        public void SetBase(string characterName, string characterRace, string characterClass)
        {
            cName = characterName;
            race = characterRace;
            charClass = characterClass;
        }
        public int level { get; set; }
        public int exp = 0;
        public string hitDice="";
        public void AddXP(int ammmount)
        {
            exp += ammmount;
            try
            {
                if (exp < xpNeeded[0])
                {
                    level = 0;
                }
                else if (exp >= xpNeeded[xpNeeded.Length - 1])
                {
                    level = xpNeeded.Length - 1;
                }
                else
                {
                    for (int i = 0; i < xpNeeded.Length + 1; i++)
                    {
                        if (exp >= xpNeeded[i] && exp < xpNeeded[i + 1])
                        {
                            level = i;
                            break;
                        }
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            if (level < 5)
            {
                proefficency = 2;
            }
            else if (level < 9)
            {
                proefficency = 3;
            }
            else if (level < 13)
            {
                proefficency = 4;
            }
            else if (level < 17)
            {
                proefficency = 5;
            }
            else if (level > 16)
            {
                proefficency = 6;
            }
        }
        //Battle
        public int[] health { get; set; } = new int[3];//current/temp/max
        public int speed { get; set; }
        public int armorClass { get; set; }
        public int deathSaves { get; set; }
        //Rest
        public string image { get; set; }
        public void SetImage(Image image)
        {
            //this should work i think
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                this.image = Convert.ToBase64String(imageBytes);
            }
        }
        public Image GetImage()
        {
            byte[] imageBytes = Convert.FromBase64String(image);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        //The boring stuff
        public Characteristics characteristics;
        public struct Characteristics
        {
            public string age;
            public string height;
            public string weight;
            public string skin;
            public string eye;
            public string hair;

            public string alignment;
            public string ideals;
            public string background;
            public string backstory;
            public string bonds;
            public string allies;
            public string personalTraits;
            public string featuresTraits;
            public string profLanguages;
        }
        //Stats/throws/skills
        public Stats stats;
        public struct Stats
        {
            public int Strength { get; set; }
            public int Dexterity { get; set; }
            public int Constitution { get; set; }
            public int Intelligence { get; set; }
            public int Wisdom { get; set; }
            public int Charisma { get; set; }
            public void Set(int[] stats)
            {
                if (stats.Length == 6)
                {
                    Strength = stats[0];
                    Dexterity = stats[1];
                    Constitution = stats[2];
                    Intelligence = stats[3];
                    Wisdom = stats[4];
                    Charisma = stats[5];
                }
            }
            public int[] Get()
            {
                return new int[6]{
                    Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
                };
            }
            public int[] GetRollValues()
            {
                return new int[6]{
                    Strength / 2 - 10, Dexterity / 2 - 10, Constitution / 2 - 10, Intelligence / 2 - 10, Wisdom / 2 - 10, Charisma/ 2 - 10
                };
            }
        }
        public SavingThrows savingThrows;
        public struct SavingThrows
        {
            public int SavingStrength { get; set; }
            public int SavingDexterity { get; set; }
            public int SavingConstitution { get; set; }
            public int SavingIntelligence { get; set; }
            public int SavingWisdom { get; set; }
            public int SavingCharisma { get; set; }
            public void Set(int[] throws)
            {
                if (throws.Length == 6)
                {
                    SavingStrength = throws[0];
                    SavingDexterity = throws[1];
                    SavingConstitution = throws[2];
                    SavingIntelligence = throws[3];
                    SavingWisdom = throws[4];
                    SavingCharisma = throws[5];
                }
            }
            public int[] Get()
            {
                return new int[6]{
                SavingStrength, SavingDexterity, SavingConstitution, SavingIntelligence, SavingWisdom, SavingCharisma
                };
            }
        }
        public Skills skills;
        public struct Skills
        {
            public int Acrobatics { get; set; }
            public int AnimHand { get; set; }
            public int Arcana { get; set; }

            public int Athletics { get; set; }
            public int Deception { get; set; }
            public int History { get; set; }

            public int Insight { get; set; }
            public int Intimidation { get; set; }
            public int Investigation { get; set; }

            public int Medicine { get; set; }
            public int Nature { get; set; }
            public int Perceprtion { get; set; }

            public int Performance { get; set; }
            public int Persuasion { get; set; }
            public int Religion { get; set; }

            public int SoH { get; set; }
            public int Stealth { get; set; }
            public int Survival { get; set; }
            public void Set(int[] skills)
            {
                if (skills.Length == 18)
                {
                    Acrobatics = skills[0];
                    AnimHand = skills[1];
                    Arcana = skills[2];
                    Athletics = skills[3];
                    Deception = skills[4];
                    History = skills[5];
                    Insight = skills[6];
                    Intimidation = skills[7];
                    Investigation = skills[8];
                    Medicine = skills[9];
                    Nature = skills[10];
                    Perceprtion = skills[11];
                    Performance = skills[12];
                    Persuasion = skills[13];
                    Religion = skills[14];
                    SoH = skills[15];
                    Stealth = skills[16];
                    Survival = skills[17];
                }
            }
            public int[] Get()
            {
                return new int[18] {Acrobatics, AnimHand, Arcana, Athletics, Deception, History, Insight,
                Intimidation, Investigation, Medicine, Nature, Perceprtion, Performance,Persuasion, Religion, SoH, Stealth, Survival
                };
            }
        }
        //CC,SC,EC,GC,PC
        public int[] money = new int[5] { 0,0,0,0,0} ;
        public string[] inventory = new string[2];
        public string notes="";
        public void SaveAsFile(string location)
        {
            DataHandler.ToJsonFile(this, location);
        }
        public List<string>[] spells = new List<string>[10] { new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { }, new List<string>() { } };
        public List<string> attacks = new List<string>();
    }
}