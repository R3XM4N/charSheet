using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;

namespace sheet
{
    public class Character
    {
        //Base
        public int proefficency;
        public List<int>[] bonus = new List<int>[2];
        public string cName { get; private set; }
        public string race { get; private set; }
        public string charClass { get; private set; }
        public int level { get; private set; }
        public string exp { get; private set; }
        //Battle
        public int[] health { get; private set; } = new int[3];//max/current/temp
        public int speed { get; private set; }
        public int armorClass { get; private set; }
        public int deathSaves { get; private set; }
        //Rest
        public string image { get; private set; }
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
        public Characteristics characteristics { get; private set; }
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
        public Stats stats { get; private set; }
        //Stats/throws/skills
        public struct Stats
        {
            public int Strength { get; private set; }
            public int Dexterity { get; private set; }
            public int Constitution { get; private set; }
            public int Intelligence { get; private set; }
            public int Wisdom { get; private set; }
            public int Charisma { get; private set; }
            public void Set(int[] throws)
            {
                if (throws.Length == 6)
                {
                    Strength = throws[0];
                    Dexterity = throws[1];
                    Constitution = throws[2];
                    Intelligence = throws[3];
                    Wisdom = throws[4];
                    Charisma = throws[5];
                }
            }
            public int[] Get()
            {
                return new int[6]{
                    Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma
                };
            }
        }
        public SavingThrows savingThrows { get; private set; }
        public struct SavingThrows
        {
            public int SavingStrength { get; private set; }
            public int SavingDexterity{ get; private set; }
            public int SavingConstitution{ get; private set; }
            public int SavingIntelligence{ get; private set; }
            public int SavingWisdom{ get; private set; }
            public int SavingCharisma{ get; private set; }
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
        public Skills skills { get; private set; }
        public struct Skills
        {
            public int Acrobatics { get; private set; }
            public int AnimHand { get; private set; }
            public int Arcana { get; private set; }

            public int Athletics { get; private set; }
            public int Deception { get; private set; }
            public int History { get; private set; }

            public int Insight { get; private set; }
            public int Intimidation { get; private set; }
            public int Investigation { get; private set; }

            public int Medicine { get; private set; }
            public int Nature { get; private set; }
            public int Perceprtion { get; private set; }

            public int Performance { get; private set; }
            public int Persuasion { get; private set; }
            public int Religion { get; private set; }

            public int SoH { get; private set; }
            public int Stealth { get; private set; }
            public int Survival { get; private set; }
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
        public Money money { get; private set; }
        public struct Money
        {
            public double copperC;
            public double silverC;
            public double electrumC;
            public double goldC;
            public double platinumC;

            public void Set(double[] coins)
            {
                if (coins.Length == 5)
                {
                    copperC = coins[0];
                    silverC = coins[1];
                    electrumC = coins[2];
                    goldC = coins[3];
                    platinumC = coins[4];
                }
            }
            public double[] Get()
            {
                return new double[5]{
                    copperC, silverC, electrumC, goldC, platinumC
                };
            }
        }
    }
}
