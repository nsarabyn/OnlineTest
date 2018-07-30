using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
	public class Data
	{
		public static List<Player> Players()
		{
			return new List<Player>
			{
				new Player{
					Id = 1,
					Hp = 100,
					Atk = 10,
					Def = 10,
					Spd = 10
				}
			};
		}
		public static List<NPC> Enemies()
		{
			return new List<NPC>
			{
				new NPC{
					Id = 7,
					Hp = 25,
					Atk = 10,
					Def = 10,
					Spd = 9
				},

				new NPC{
					Id = 8,
					Hp = 25,
					Atk = 10,
					Def = 10,
					Spd = 9
				}
			};
		}
	}
}