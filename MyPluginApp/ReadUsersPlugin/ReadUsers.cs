using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PluginSystem;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReadUsersPlugin
{
    public class ReadUsers : IPlugin
    {
        string Name => "ReadUsers" ;
        string Definition => " Read users from JSON files.";

        private const string UserFolder = @"users\";

        private List<User> UserList ;


        string IPlugin.Definition { get => Definition; set => throw new NotImplementedException(); }
        string IPlugin.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute()
        {
            ReadUsersFiles();
            Console.WriteLine(" \n Extraction de " + getUserList().Count + " utilisateurs effectuée. ");
        }

        
        public void ReadUsersFiles()
        {
            Console.WriteLine("Executing ReadUsers");
            UserList = new List<User>();

            //on récupere uniquement les fichiers json
            string[] files = Directory.GetFiles(@".\" + UserFolder, "*.json");
            foreach (var file in files)
            {
                Console.WriteLine();
                 Console.WriteLine(" Reading from " + file);

                string json = File.ReadAllText(file);
                var temporaryUserList = JsonConvert.DeserializeObject<List<User>>(json);

                foreach (User user in temporaryUserList)
                {
                    UserList.Add(user);
                    Console.WriteLine(user.ToString());
                }

            }

        }
      
        public string getDefinition()
        {
            return Definition;
        }

        public string getName()
        {
            return Name;
        }

        public List<User> getUserList()
        {
            return UserList;
        }
    }
}
