using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Abbybot_5.Extensions
{
	public static class DiscordSocketClientExtensions
	{
		public static async Task<bool> LoginIOAsync( this DiscordSocketClient discord, string tokenPath ) {
			var token = await IO.LoadAsync<string>( tokenPath );
			if ( token != null && token.Length > 0 )
			{
				await discord.LoginAsync( Discord.TokenType.Bot, token );
				return true;
			}
			else
				return false;
		}
	}
}
