using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abbybot_5.Extensions;
using Abbybot_5.Managers;
using Abbybot_5.Managers.Attributes;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace Abbybot_5
{
	internal class Abbybot
	{
		DiscordSocketClient discord;
		string discordApiPath = @"apikeys\discord.json";
		public async Task Spawn( )
		{
			discord = new( );
			DiscordPluginManager.LoadPlugins<DiscordPluginAttribute>(discord); //possibly evil wireless redstone
			if ( await discord.LoginIOAsync( discordApiPath ) ) //if we successfully log in
				await Start( );
			else
			{
				await IO.Save( discordApiPath, "" );
				Console.WriteLine( $"I didn't find api keys at {discordApiPath}. So i made an empty file for you" );
			}
		}
		public async Task Start() {
			await discord.StartAsync( );
			await Task.Delay(- 1);
			await discord.StopAsync( );
		}

	}

	class IO {
		public static async Task<T?> LoadAsync<T>( string path )
		{
			CreateMissingPath( path );
			try
			{
				var json = await File.ReadAllTextAsync( path );
				return JsonConvert.DeserializeObject<T>( json );
			}
			catch
			{
				return default;
			}
		}
		public static async Task Save<T>( string path, T? data )
		{
			var d = JsonConvert.SerializeObject( data );
			await File.WriteAllTextAsync(path,d);
		}

		static void CreateMissingPath( string path )
		{
			var directory = Path.GetFullPath( path ).Replace( Path.GetFileName( path ), "" );
			if ( !Directory.Exists( directory ) )
				Directory.CreateDirectory( directory );
		}
	}
}
