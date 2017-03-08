using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SwaggerDemo.Models;
using System.IO;
using System.Web.Http.Description;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// SwaggerDemo example class
    /// </summary>
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("api/order")]
        public Order[] Orders()
        {
            return new Order[]
            {
                new Order { id = 11, idCust = 1 },
                new Order { id = 12, idCust = 2 },
                new Order { id = 13, idCust = 3 }
            };
        }

        // /api/customer/1/orders/3
        [HttpGet]
        [Route("api/order/{id}")]
        public Order Orders(int id)
        {
            return new Order { id = id, idCust = 1 };
        }

        // /api/customer/1/orders
        [HttpPost]
        [Route("api/order")]
        public HttpResponseMessage Orders(Order order)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.OK;
            Uri location = null;
            if (order.id == 0)
            {
                httpStatusCode = HttpStatusCode.Created;
                Random rand = new Random();
                order.id = (int)rand.Next(5, 100);
                location = new Uri(Path.Combine(this.Request.RequestUri.AbsoluteUri, order.id.ToString()));
            }
            order.idCust = 1;
            HttpResponseMessage response = Request.CreateResponse(httpStatusCode, order);
            if (location != null)
                response.Headers.Location = location;
            return response;
        }

        [HttpGet]
        [Route("api/order/{id}/shipment")]
        public Shipment[] Shipments(int id)
        {
            return new Shipment[]
            {
                new Shipment { id = 111, idCust = 1, idOrder = id },
                new Shipment { id = 112, idCust = 2, idOrder = id },
                new Shipment { id = 113, idCust = 3, idOrder = id }
            };
        }

        // /api/customer/1/orders/3/shipments
        [HttpGet]
        [Route("api/order/{id}/shipment/{actionid}")]
        public Shipment Shipments(int id, int actionid)
        {
            return new Shipment { id = actionid, idOrder = id, idCust = 1 };
        }

        // /api/orders/3/shipments/1
        [HttpPost]
        [Route("api/order/{id}/shipment")]
        public HttpResponseMessage Shipments(int id, Shipment shipment)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.OK;
            Uri location = null;
            if (shipment.id == 0)
            {
                httpStatusCode = HttpStatusCode.Created;
                Random rand = new Random();
                shipment.id = (int)rand.Next(5, 100);
                location = new Uri(Path.Combine(this.Request.RequestUri.AbsoluteUri, shipment.id.ToString()));
            }
            shipment.idCust = 1;
            shipment.idOrder = id;
            HttpResponseMessage response = Request.CreateResponse(httpStatusCode, shipment);
            if (location != null)
                response.Headers.Location = location;
            return response;
        }
    }
}