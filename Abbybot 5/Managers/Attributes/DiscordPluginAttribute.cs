using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbybot_5.Managers.Attributes
{
	[AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
	public class DiscordPluginAttribute : Attribute
	{
		public DiscordPluginAttribute () {
			
		}
	}
}
