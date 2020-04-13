using PluginSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPluginApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadPlugin loader = new LoadPlugin();
            Console.WriteLine("MyPluginApp has started ");
            try
            {
                
                loader.LoadAllPlugins();

                List <IPlugin> plugins = loader.getAllPlugins();

                // affichage de tous les plugins existant et de leurs définitions 
                if(plugins.Count > 0)
                {
                    foreach (var plugin in plugins)
                    {
                        Console.WriteLine(plugin.getName() + " : " + plugin.getDefinition());
                    }
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Plugins couldn't be loaded: {0}", e.Message));
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
             while (true)
             {
                 try
                 {
                     //Let the user fill in an plugin name
                     Console.Write("> ");
                     string line = Console.ReadLine();
                     string saisie = line.Split(new char[] { ' ' }).FirstOrDefault();
                     if (line == "exit")
                     {
                         Environment.Exit(0);
                     }

                     //on recupere la saisie et si le plugin existe on exécute
                     IPlugin plugin = loader.getAllPlugins().Where(p => p.getName() == saisie).FirstOrDefault();
                     if (plugin != null)
                     {                                         
                         plugin.Execute();
                     }
                     else
                     {
                         Console.WriteLine(string.Format("No plugin found with name '{0}'", saisie));
                     }
                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(string.Format(" exception: {0}", e.Message));
                 }
             }
        }
    }
}
