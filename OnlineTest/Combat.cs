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
		public Player Player { get; set; }
		//public int NPCId { get; set; }
		public List<NPC> NPCs { get; set; }
		public int Round { get; set; }
		public int Init { get; set; }
		public bool Complete { get; set; }
	}
}