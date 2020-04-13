using System;
using System.Collections.Generic;
using System.Text;

namespace PluginSystem
{
  public interface IPlugin
	{
		string Name { get; set; }
		string Definition { get; set; }

	
		void Execute();

		 string getName();
		 string getDefinition();


	}
}
