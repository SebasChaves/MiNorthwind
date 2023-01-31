using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {

        private IShippers shipperDAL;
        public ShipperController() {
            shipperDAL = new ShippersDALImpl(new Entities.NorthWindContext());
        }


        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult GetAll()
        {
            IEnumerable<Shipper> shippers= shipperDAL.GetAll();
            return new JsonResult(shippers);
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);
            return new JsonResult(shipper);
        }

        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] Shipper value)
        {
            shipperDAL.Add(value);
            return new JsonResult(value);
        }

        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody]Shipper shipper)
        {
            shipperDAL.Update(shipper);
            return new JsonResult(shipper); 
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int value)
        {
            Shipper shippershipper = new Shipper { ShipperId= value };  
            shipperDAL.Remove(shippershipper);
            return new JsonResult(value);
        }
    }
}
