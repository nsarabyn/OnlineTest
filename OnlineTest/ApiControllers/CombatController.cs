using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineTest.ApiControllers
{
    public class CombatController : ApiController
    {
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
		[Route("api/Combat/start/{pId}")]
		public void PostStart(int pId)
		{
			var player = Data.Players().Single(p=>p.Id == pId);
			var enemy = Data.Enemies().Single(p => p.Id == 7);

			var combat = new Combat
			{
				PlayerId = pId,
				NPCId = enemy.Id,
				PlayerHp = player.Hp,
				NPCHp = enemy.Hp,
				Round = 0
			};

			var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(combat);

			System.IO.File.WriteAllText("CombatLog.txt", serialized);

		}

		// PUT: api/Combat/5
		public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Combat/5
        public void Delete(int id)
        {
        }
    }
}
