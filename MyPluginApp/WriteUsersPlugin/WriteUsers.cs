using Newtonsoft.Json;
using PluginSystem;
using System;
using System.Collections.Generic;

namespace WriteUsersPlugin
{
    public class WriteUsers : IPlugin
    {
        string Name => "WriteUsers";
        string Definition => " Write users to JSON files.";

        List<User> UserList;

        string IPlugin.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IPlugin.Definition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Execute()
        {
            Console.WriteLine("executing writeUsers");

        }

        public string getDefinition()
        {
            return Definition;
        }

        public string getName()
        {
            return Name;
        }
    }
}
