using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abbybot_5.Managers.Attributes;
using Discord.WebSocket;

namespace Abbybot_5.DiscordPlugins
{
	internal class DiscordLogPlugin
	{
		[DiscordPlugin]
		public async Task Log (DiscordSocketClient discord) {
			discord.Log += async log => Console.WriteLine( log );
		}
	}
}
