using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DXWebApplication1.Models.Examination;

namespace DXWebApplication1.Controllers
{
    public class ExamintionPlanController : ApiController
    {
        //    // GET api/<controller>
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        // GET api/<controller>/26450/FECA9BD1-CDBD-E911-80D0-20CF301DFD89
        //[HttpGet("{patientId},{ccId}")]
        public PlanRequest Get(int patid, string servid)
        {
            return new PlanRequest { IdPat = patid, Servid = servid};
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

}