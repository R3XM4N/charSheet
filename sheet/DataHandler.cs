using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sheet
{
    internal class DataHandler
    {
        public static Character loadCharacter(string path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Character));
            System.IO.FileStream fileStream = new System.IO.FileStream(path, System.IO.FileMode.Open);
            Character c = (Character)serializer.Deserialize(fileStream);
            fileStream.Close();
            return c;
        }

        public static List<Character> loadCharacterList(string directory) {
            List<Character> characterList = new List<Character>();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Character));
            string[] files = System.IO.Directory.GetFiles(directory, "*.xml");
            foreach (string file in files)
            {
                System.IO.FileStream fileStream = new System.IO.FileStream(file, System.IO.FileMode.Open);
                Character c = (Character)serializer.Deserialize(fileStream);
                characterList.Add(c);
                fileStream.Close();
            }
            return characterList;
        }

        public static void saveCharacter(Character c, string folder_path)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Character));
            System.IO.FileStream fileStream = new System.IO.FileStream(folder_path + "\\" + c.cName.Replace(' ', '_') + ".xml", System.IO.FileMode.Create);
            serializer.Serialize(fileStream, c);
            fileStream.Close();
        }

        public static void saveCharacter(Character c, string folder_path, string file_name)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Character));
            System.IO.FileStream fileStream = new System.IO.FileStream(folder_path + "\\" + file_name.Replace(' ', '_') + ".xml", System.IO.FileMode.Create);
            serializer.Serialize(fileStream, c);
            fileStream.Close();
        }

        public static void deleteCharacter(string hero_name)
        {
            System.IO.File.Delete(Properties.Settings.Default.path + "\\" + hero_name.Replace(" ","_") + ".xml");
        }

        public static List<Character> getSortedByLevel(List<Character> characterList)
        {
            return characterList.OrderByDescending(o => o.level).ToList();
        }

        public static List<Character> getSortedByName(List<Character> characterList)
        {
            return characterList.OrderBy(o => o.cName).ToList();
        }

        public static List<Character> getSortedByRace(List<Character> characterList)
        {
            return characterList.OrderBy(o => o.race).ToList();
        }

        public static List<Character> getSortedByClass(List<Character> characterList)
        {
            return characterList.OrderBy(o => o._class).ToList();
        }
    }
}
