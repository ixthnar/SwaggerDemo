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
    public class CustomerController : ApiController
    {
        // /api/customer/
        [HttpGet]
        [Route("api/customer")]
        public Customer[] Get(string paramRequired, string paramOptional = null)
        {
            return new Customer[] 
            {
                new Customer { id = 1 },
                new Customer { id = 2 },
                new Customer { id = 3 }
            };
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet]
        [Route("api/secret")]
        public string Secret()
        {
            return "very very secret";
        }

        // /api/customer/
        [HttpPost]
        [Route("api/customer")]
        public HttpResponseMessage Post(Customer customer)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.OK;
            Uri location = null;
            if (customer.id == 0)
            {
                httpStatusCode = HttpStatusCode.Created;
                Random rand = new Random();
                customer.id = (int)rand.Next(5, 100);
                location = new Uri(Path.Combine(this.Request.RequestUri.AbsoluteUri, customer.id.ToString()));
            }
            HttpResponseMessage response = Request.CreateResponse(httpStatusCode, customer);
            if (location != null)
                response.Headers.Location = location;
            return response;
        }

        // /api/customer/1
        [HttpGet]
        [Route("api/customer/{id}")]
        public Customer GetById(int id)
        {
            return new Customer { id = id };
        }

        // /api/customer/1/orders
        [HttpGet]
        [Route("api/customer/{id}/order")]
        public Order[] Orders(int id)
        {
            return new Order[]
            {
                new Order { id = 11, idCust = id },
                new Order { id = 12, idCust = id },
                new Order { id = 13, idCust = id }
            };
        }

        // /api/customer/1/orders/3
        [HttpGet]
        [Route("api/customer/{id}/order/{actionid}")]
        public Order Orders(int id, int actionid)
        {
            return new Order { id = actionid, idCust = id };
        }

        // /api/customer/1/orders
        [HttpPost]
        [Route("api/customer/{id}/order")]
        public HttpResponseMessage Orders(int id, Order order)
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
            order.idCust = id;
            HttpResponseMessage response = Request.CreateResponse(httpStatusCode, order);
            if (location != null)
                response.Headers.Location = location;
            return response;
        }

        // /api/customer/1/orders
        [HttpGet]
        [Route("api/customer/{id}/order/{actionid}/shipment")]
        public Shipment[] Shipments(int id, int actionid)
        {
            return new Shipment[]
            {
                new Shipment { id = 111, idCust = id, idOrder = actionid },
                new Shipment { id = 112, idCust = id, idOrder = actionid},
                new Shipment { id = 113, idCust = id, idOrder = actionid }
            };
        }

        // /api/customer/1/orders/3/shipments
        [HttpGet]
        [Route("api/customer/{id}/order/{actionid}/shipment/{subactionid}")]
        public Shipment Shipments(int id, int actionid, int subactionid)
        {
            return new Shipment { id = subactionid, idOrder = actionid, idCust = id };
        }

        // /api/customer/1/orders/3/shipments/1
        [HttpPost]
        [Route("api/customer/{id}/order/{actionid}/shipment")]
        public HttpResponseMessage Shipments(int id, int actionid, Shipment shipment)
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
            shipment.idCust = id;
            shipment.idOrder = actionid;
            HttpResponseMessage response = Request.CreateResponse(httpStatusCode, shipment);
            if (location != null)
                response.Headers.Location = location;
            return response;
        }
    }
}