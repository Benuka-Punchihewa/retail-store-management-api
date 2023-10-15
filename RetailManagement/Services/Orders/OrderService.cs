using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using RetailManagement.DTO.Orders;
using RetailManagement.Models;

namespace RetailManagement.Services.Orders;

public class OrderService : IOrderService
{
    public SqlConnection con;

    public OrderService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConnection");
        if (con == null)
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
    }

    public List<OrderDTO> GetActiveOrders(Guid UserId)
    {
        List<OrderDTO> orderDTOs = new();

        var storedProcedure = "GetActiveOrdersByCustomer";
        var cmd = new SqlCommand(storedProcedure, con)
        {
            CommandType = CommandType.StoredProcedure
        };

        cmd.Parameters.Add(new SqlParameter("@CustomerId", SqlDbType.UniqueIdentifier) { Value = UserId });

        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            // retrieve order details
            var orderId = rdr["OrderId"].ToString();
            var orderStatus = rdr["OrderStatus"].ToString();
            var orderType = rdr["OrderType"].ToString();
            var orderBy = rdr["OrderBy"].ToString();
            var orderedOn = rdr["OrderedOn"].ToString();
            var orderShippedOn = rdr["OrderShippedOn"].ToString();
            var orderIsActive = rdr["OrderIsActive"].ToString();

            // retrieve product details
            var productId = rdr["ProductId"].ToString();
            var productName = rdr["ProductName"].ToString();
            var productUnitPrice = rdr["ProductUnitPrice"].ToString();
            var productCreatedOn = rdr["ProductCreatedOn"].ToString();
            var productIsActive = rdr["ProductIsActive"].ToString();

            // retrieve supplier details
            var SupplierId = rdr["SupplierId"].ToString();
            var SupplierName = rdr["SupplierName"].ToString();
            var SupplierCreatedOn = rdr["SupplierCreatedOn"].ToString();
            var SupplierIsActive = rdr["SupplierIsActive"].ToString();

            if (orderId != null && orderStatus != null && orderType != null && orderBy != null &&
                orderedOn != null && orderShippedOn != null && orderIsActive != null && productId != null &&
                productName != null && productUnitPrice != null && productCreatedOn != null && productIsActive != null &&
                SupplierId != null && SupplierName != null && SupplierCreatedOn != null && SupplierIsActive != null)
            {
                Order order = new(
                    Guid.Parse(orderId),
                    Guid.Parse(productId),
                    int.Parse(orderStatus),
                    int.Parse(orderType),
                    Guid.Parse(orderBy),
                    DateTime.Parse(orderedOn),
                    DateTime.Parse(orderShippedOn),
                    bool.Parse(orderIsActive)
                );

                Supplier supplier = new(
                   Guid.Parse(SupplierId),
                   SupplierName,
                   DateTime.Parse(SupplierCreatedOn),
                   bool.Parse(SupplierIsActive)
               );

                Product product = new(
                    Guid.Parse(productId),
                    productName,
                    decimal.Parse(productUnitPrice),
                    Guid.Parse(SupplierId),
                    DateTime.Parse(productCreatedOn),
                    bool.Parse(productIsActive)
                );

                OrderDTO orderDTO = new(order, supplier, product);

                orderDTOs.Add(orderDTO);
            }

        }

        return orderDTOs;
    }
}
