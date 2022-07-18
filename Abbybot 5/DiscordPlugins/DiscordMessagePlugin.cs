using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abbybot_5.Managers.Attributes;
using Discord.WebSocket;

namespace Abbybot_5.DiscordPlugins
{
	internal class DiscordMessagePlugin
	{
		[DiscordPlugin]
		public async Task Message (DiscordSocketClient discord) {
			discord.MessageReceived += async log => Console.WriteLine( $"{log.Author.Username}:({log.Content}): (clean: {log.CleanContent}) " );
		}
	}
}
