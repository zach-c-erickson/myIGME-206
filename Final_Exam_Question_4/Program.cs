using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;

namespace Final_Exam_Question_4
{

    // Class: Program
    // Author: Zachary Erickson
    // Purpose: Final Exam Question 4
    class Program
    {
        static void Main(string[] args)
        {
            PlayerSettings settings = new PlayerSettings();
            SettingsClass settingsFunctions = SettingsClass.GetInstance();

            settings = settingsFunctions.LoadPlayerSettings("C:/Users/Zachary/OneDrive/Desktop/settings.json");
            settingsFunctions.SavePlayerSettings("C:/Users/Zachary/OneDrive/Desktop/settings.json", settings);
        }
    }

    public interface IPlayerSettings
    {
        void SavePlayerSettings(string fileName, PlayerSettings settings);
        PlayerSettings LoadPlayerSettings(string fileName);
    }

    public class PlayerSettings
    {
        public string player_name;
        public int level;
        public int hp;
        public string[] inventory;
        public string license_key;
    }

    public class SettingsClass : IPlayerSettings
    {
        private static SettingsClass instance = new SettingsClass();

        private SettingsClass()
        {

        }

        public static SettingsClass GetInstance()
        {
            return instance;
        }

        public void SavePlayerSettings(string fileName, PlayerSettings settings)
        {
            string sSettings;

            // refer to 20 Questions if any problem
            sSettings = JsonConvert.SerializeObject(settings);

            // write sSettings to fileName
            StreamWriter writer = new StreamWriter(fileName, true);
            writer.Write(sSettings);
            writer.Close();
        }

        public PlayerSettings LoadPlayerSettings(string fileName)
        {
            string sSettings = null;

            // read fileName to sSettings
            StreamReader reader = new StreamReader(fileName, true);
            sSettings = reader.ReadToEnd();
            reader.Close();

            PlayerSettings settings;

            settings = JsonConvert.DeserializeObject<PlayerSettings>(sSettings);
            return settings;
        }
    }
}
