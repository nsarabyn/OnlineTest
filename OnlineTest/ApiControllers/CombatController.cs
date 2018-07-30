using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineTest.ApiControllers
{
    public class CombatController : ApiController
	{
		string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\OnlineTest";
		// GET: api/Combat
		public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Combat/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Combat
        public void Post([FromBody]string value)
        {
		}
		// POST: api/Combat
		[Route("api/Combat/start")]
		public Combat PostStart()
		{
			var player = Data.Players().Single(p=>p.Id == 1);
			var enemy = Data.Enemies().Single(p => p.Id == 7);

			var combat = new Combat
			{
				CombatId = 1,
				PlayerId = player.Id,
				Player = player,
				NPCs = Data.Enemies(),
				Round = 0,
				Init = Math.Max(player.Spd, Data.Enemies().Max(en => en.Spd)),
				Complete = false
			};


			UpdateLog(combat);
			return combat;
		}

	    [Route("api/Combat/attack/{id}")]
	    public Combat PostAttack(int id)
	    {
		    var combat = GetFromLog();
			var targEnemy = combat.NPCs.Single(npc => npc.Id == id);
			if (combat.Complete || targEnemy.Hp <= 0)
			{
				return combat;
			}
			combat.Round++;

			DoAttack(combat.Player, targEnemy, combat.Init);

			foreach (var npc in combat.NPCs)
			{
				if (npc.Hp > 0)
				{
					DoAttack(npc, combat.Player, combat.Init);
				}
			}

			if (combat.Player.Hp <= 0 || combat.NPCs.All(npc=> npc.Hp <= 0))
			{
				combat.Complete = true;
			}
			UpdateLog(combat);
			return combat;

		}

		private void DoAttack(Char attacker, Char defender, int init)
		{
			attacker.Init = attacker.Init - attacker.Spd;
			while (attacker.Init <= 0)
			{
				attacker.Init += init;
				defender.Hp -= attacker.Atk - (int)Math.Ceiling(attacker.Atk * (defender.Def / 100d));
			}
		}

	    // PUT: api/Combat/5
			public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Combat/5
        public void Delete(int id)
        {
        }

		private void UpdateLog(Combat combat)
		{
			var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(combat);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			File.WriteAllText(path + "\\CombatLog.txt", serialized);
		}

		private Combat GetFromLog()
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<Combat>(File.ReadAllText(path + "\\CombatLog.txt"));
		}
    }
}
