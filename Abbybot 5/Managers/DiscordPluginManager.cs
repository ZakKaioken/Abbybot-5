using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Abbybot_5.Managers
{
	internal class DiscordPluginManager
	{
		internal static void LoadPlugins<T>( DiscordSocketClient discord ) {
			IEnumerable<MethodInfo> funcs = AppDomain.CurrentDomain.GetAssemblies( )
				.SelectMany( s => s.GetTypes( ) ) 
				.SelectMany( m=>m.GetMethods())
				.Where( m => m.GetCustomAttributes( typeof(T), false ).Length > 0 )
				.ToArray( );
			foreach ( var m in funcs )
			{
				Object? o = Activator.CreateInstance( m.ReflectedType );
				m.Invoke( o, new object[ ] { discord } );
			}

		}

	}
}
