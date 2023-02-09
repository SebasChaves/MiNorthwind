using BackEnd.Models;
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


        #region Convertir
        private ShipperModel Convertir(Shipper shipper)
        {
            return new ShipperModel
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }

        private Shipper Convertir(ShipperModel shipper)
        {
            return new Shipper
            {
                ShipperId = shipper.ShipperId,
                CompanyName = shipper.CompanyName,
                Phone = shipper.Phone
            };
        }
        #endregion

        // GET: api/<ShipperController>
        [HttpGet]
        public JsonResult GetAll()
        {
            IEnumerable<Shipper> shippers= shipperDAL.GetAll();
            List<ShipperModel> shipperModel = new List<ShipperModel>();

            foreach(Shipper shipper in shippers) { 
                shipperModel.Add(Convertir(shipper)); 
            }

            return new JsonResult(shipperModel);    
        }

        // GET api/<ShipperController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Shipper shipper = shipperDAL.Get(id);
            return new JsonResult(Convertir(shipper));
        }
        /* public JsonResult Get(int id)
         {
             Shipper shipper = shipperDAL.Get(id);
             return new JsonResult(shipper);
         }*/

        // POST api/<ShipperController>
        [HttpPost]
        public JsonResult Post([FromBody] ShipperModel value)
        {
            shipperDAL.Add(Convertir(value));
            return new JsonResult(value);
        }
        /*public JsonResult Post([FromBody] Shipper value)
        {
            shipperDAL.Add(value);
            return new JsonResult(value);
        }*/


        // PUT api/<ShipperController>/5
        [HttpPut]
        public JsonResult Put([FromBody]ShipperModel shipper)
        {
            shipperDAL.Update(Convertir(shipper));
            return new JsonResult(Convertir(shipper)); 
        }

        // DELETE api/<ShipperController>/5
        [HttpDelete("{value}")]
        public JsonResult Delete(int value)
        {
           // Shipper shippershipper = shipperDAL.Get(value);  
            bool complete = shipperDAL.Remove(shipperDAL.Get(value));
            return new JsonResult(complete);
        }
    }
}
