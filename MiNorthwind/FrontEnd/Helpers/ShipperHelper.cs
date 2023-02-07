using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontEnd.Helpers
{
    public class ShipperHelper
    {
        private ServiceRepository serviceRepository;

        public ShipperHelper()
        {
            serviceRepository= new ServiceRepository();
        }

        public List<ShipperViewModel> GetAll()
        {
            HttpResponseMessage response = serviceRepository.GetResponse("api/Shipper");
            var content = response.Content.ReadAsStringAsync().Result;

            List <ShipperViewModel> lista = JsonConvert.DeserializeObject<List<ShipperViewModel>>(content);
            return lista;
        }

        public ShipperViewModel Get(int id) {
            HttpResponseMessage response = serviceRepository.GetResponse("api/Shipper/"+id.ToString());
            var content = response.Content.ReadAsStringAsync().Result;

            ShipperViewModel shipper = JsonConvert.DeserializeObject<ShipperViewModel>(content);
            return shipper;
        }
    }
}
