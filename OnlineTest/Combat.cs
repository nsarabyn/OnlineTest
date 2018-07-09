using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
	public class Combat
	{
		public int CombatId { get; set; }
		public int PlayerId { get; set; }
		public int NPCId { get; set; }
		public int PlayerHp { get; set; }
		public int NPCHp { get; set; }
		public int Round { get; set; }
	}
}