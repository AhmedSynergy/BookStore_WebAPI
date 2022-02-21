using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BookStore_WebAPI.InfrastructureFolder.Dtos;

namespace BookStore_WebAPI.BusinessLayerFolder.Controllers
{
    interface IOrderController
    {
        IEnumerable<OrderDTO> GetAllOrders();

        IHttpActionResult AddToCart(int OrderId, int BookId, int Quantity, int CustomerID);

        IEnumerable<OrderDetailsDTO> GetOrderDetails(int OrderId);
    }
}
