using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore;
using FrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ValuesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<ManageEvent> Get()
        {
            IRepository<ManageEvent> eventRepository = unitOfWork.Get<ManageEvent>();
            IRepository<Country> coutryRepository = unitOfWork.Get<Country>();

            var countries = coutryRepository.Query.Where(s => s.ID == 1).Select(s=>s.States).ToList();

            //eventRepository.One(s => s.Name == "event");
            //ManageEvent manageEvent = new ManageEvent();
            //manageEvent.Name = "new event";
            //manageEvent.Address = "update event";
            //manageEvent.City = "new event";
            //manageEvent.DasboardImage = "new event";
            //manageEvent.EventEndDate = DateTime.Now;
            //manageEvent.EventStartDate = DateTime.Now;
            //manageEvent.EventManagerEmail = "new event";
            //manageEvent.EventManagerName = "new event";
            //manageEvent.LandingPageImage = "new event";
            //manageEvent.Logo = "new event";
            //eventRepository.Save(manageEvent);
            //unitOfWork.Commit();
            var eve = eventRepository.Query.ToList();

            return eve;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
