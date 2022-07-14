using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace LetsSpeak
{

    public static class DatabaseInit
    {
        public static void Initialize(Dictionary<string, string> englishDictionary, string dictionaryDb)
        {
            if (!File.Exists(dictionaryDb))
                DatabaseSave.Save(englishDictionary, dictionaryDb);

            DatabaseLoad.Load(dictionaryDb);
        }
    }
    public static class DatabaseLoad
    {
        public static void Load(string dictioDb)
        {
            var dictCont = File.ReadAllText(dictioDb);
            Database.Dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(dictCont);
        }
    }

    public static class Database
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string _DictioDb = Path.Combine(_rootDirectory, "dictio.json");

        public static Dictionary<string, string> Dict = new Dictionary<string, string>();

        static Database()
        {
            DatabaseInit.Initialize(Dict, _DictioDb);
        }
    }

    public static class DatabaseSave
    {
        public static void Save(Dictionary<string, string> dictionary, string dictionaryDb)
        {
            Console.WriteLine("Saving...");

            var conteudo = JsonConvert.SerializeObject(dictionary);

            File.WriteAllText(dictionaryDb, conteudo);

        }
    }
}
