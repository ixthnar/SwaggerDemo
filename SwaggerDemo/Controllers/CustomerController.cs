using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    public class CustomerController : ApiController
    {
        // /api/customer/
        [HttpGet]
        [Route("api/customer")]
        public Customer[] Get()
        {
            return new Customer[] 
            {
                new Customer { id = 1 },
                new Customer { id = 2 },
                new Customer { id = 3 }
            };
        }

        // /api/customer/
        [HttpPost]
        [Route("api/customer")]
        public Customer Post(Customer c)
        {
            return c;
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
        public Order Orders(int id, Order order)
        {
            order.idCust = id;
            return order;
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
        public Shipment Shipments(int id, int actionid, Shipment shipment)
        {
            shipment.idCust = id;
            shipment.idOrder = actionid;
            return shipment;
        }
    }
}