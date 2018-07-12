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
				NPCId = enemy.Id,
				PlayerHp = player.Hp,
				NPCHp = enemy.Hp,
				PlayerInit = Math.Max(player.Spd, enemy.Spd),
				NPCInit = Math.Max(player.Spd, enemy.Spd),
				Round = 0,
				Init = Math.Max(player.Spd, enemy.Spd),
				Complete = false
			};


			UpdateLog(combat);
			return combat;
		}

	    [Route("api/Combat/attack")]
	    public Combat PostAttack()
	    {
		    var combat = GetFromLog();
			if (combat.Complete)
			{
				return combat;
			}
			combat.Round++;

		    var player = Data.Players().Single(p => p.Id == combat.PlayerId);
		    var enemy = Data.Enemies().Single(p => p.Id == combat.NPCId);

			combat.PlayerInit = combat.PlayerInit - player.Spd;
			combat.NPCInit = combat.NPCInit - enemy.Spd;

			while (combat.PlayerInit <= 0)
			{
				combat.PlayerInit += combat.Init;
				combat.NPCHp -= player.Atk;
			}
			while (combat.NPCInit <= 0)
			{
				combat.NPCInit += combat.Init;
				combat.PlayerHp -= enemy.Atk;
			}
			if(combat.PlayerHp <=0 || combat.NPCHp<=0)
			{
				combat.Complete = true;
			}
			UpdateLog(combat);
			return combat;

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
