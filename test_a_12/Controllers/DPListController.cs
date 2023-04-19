using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_a_12.Models;

namespace test_a_12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DPListController : ControllerBase
    {
        // GET: api/DPList
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> dpList = new List<string>();
            dpList.Add("DP1");
            dpList.Add("DP2");
            dpList.Add("DP3");
            return dpList;
        }

        // GET: api/DPList/5
        [HttpGet("{id}")]
        public DPList Get(int id)
        {
            DPList dplist = new DPList();
            if (id == 1)
            {
                dplist.DPName = "DP1";
            }
            else if (id == 2)
            {
                dplist.DPName = "DP2";
            }
            else if (id == 3)
            {
                dplist.DPName = "DP3";
            }
            return dplist;
        }

        // POST: api/DPList
        [HttpPost]
        public void Post([FromBody] DPList dplist)
        {
            //TODO: Implement Create
        }

        // PUT: api/DPList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DPList dplist)
        {
            //TODO: Implement Update
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO: Implement Delete
        }
    }
}