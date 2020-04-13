using PluginSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoticePlugin
{
    class Notice : IPlugin

    {

        string Name => "Notice";
        string Definition => " Test de plugin ";



        string IPlugin.Name { get => Name; set => throw new NotImplementedException(); }
    
        string IPlugin.Definition { get => Definition; set => throw new NotImplementedException(); }

        public void Execute()
        {
            Console.WriteLine("executing Notice");


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
