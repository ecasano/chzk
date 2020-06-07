using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApiChzk1.Models;
using WebApiChzk1.Transfer;


namespace WebApiChzk1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DeliveryServiceController : ApiController
    {

        private chzkEntities db = new chzkEntities();

        // GET: api/Entregas //
        [HttpGet]
        [Route("api/entregas")]
        public IEnumerable<DeliveryServicedt> GetEntregas()
        {
            return DeliveryService.Entregas();
        }


        // GET: api/EntregasPorTienda
        [HttpGet]
        [Route("api/entregasportienda")]
        public IEnumerable<Storedt> GetEntregasPorTienda(string tienda, string)
        {
            return DeliveryService.EntregasPorTienda(tienda);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryServiceExists(int id)
        {
            return db.DeliveryService.Count(e => e.deliveryServiceId == id) > 0;
        }



    }
}
