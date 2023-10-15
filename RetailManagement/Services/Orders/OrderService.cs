using System.Data;
using System.Data.SqlClient;

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

    public void GetActiveOrders(Guid UserId)
    {
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

            
        }

    }
}
