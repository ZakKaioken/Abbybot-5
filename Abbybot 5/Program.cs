using System;

namespace Abbybot_5
{
	internal class Program
	{
		static Abbybot abbybot = new Abbybot( );

		static async Task Main( string[ ] args )
		{
			await abbybot.Spawn( );
		}
	}
}