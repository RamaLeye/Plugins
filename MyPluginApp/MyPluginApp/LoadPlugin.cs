using PluginSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;


namespace MyPluginApp
{
    public class LoadPlugin
    {
        private static List<IPlugin> AllPlugins { get; set; }

        private const string PluginFolder = @"plugins\";

        public List<IPlugin> getAllPlugins()
        {
            return AllPlugins;
        }

        public void LoadAllPlugins()
        {
         
            AllPlugins = new List<IPlugin>();

            //on récupere tous les .dll avec des classes qui implémente IPlugin et on les mets dans le dossier Plugin
            if (Directory.Exists(@".\"))
            {
                string[] files = Directory.GetFiles(@".\", "*.dll");
                foreach (var file in files)
                {

                    Type[] typeLoadedFromProject = Assembly.LoadFrom(Directory.GetCurrentDirectory() + file).GetTypes();
                    foreach (Type type in typeLoadedFromProject)
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                        {

                            File.Copy(file, @".\" + PluginFolder + Path.GetFileName(file), true);
                        }

                    }
                }
            }

            // on charge tous les plugins du dossier plugin
            string[] filesPlugins = Directory.GetFiles(@".\" + PluginFolder);
            foreach (var file in filesPlugins)
            {

                Type[] typeLoadedFromPlugins = Assembly.LoadFrom(@".\" + PluginFolder + Path.GetFileName(file)).GetTypes();
                foreach (Type type in typeLoadedFromPlugins)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        Assembly.LoadFrom(@".\" + PluginFolder + Path.GetFileName(file));

                    }

                }
            }


            Type pluginType = typeof(IPlugin);


            //requete pour récuprer les types qui implémente IPlugin et qui sont des classes
            Type[] typesLoaded = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .Where(plugin => pluginType.IsAssignableFrom(plugin) && plugin.IsClass)
                .ToArray();


            //on crée l'instance et on ajoute à la liste Plugin
            foreach (Type typeLoaded in typesLoaded)
            {             
                AllPlugins.Add((IPlugin)Activator.CreateInstance(typeLoaded));
            }



        }


    }
}
