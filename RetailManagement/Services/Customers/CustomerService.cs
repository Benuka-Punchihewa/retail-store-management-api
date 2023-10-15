using System.Data.SqlClient;
using RetailManagement.Models;

namespace RetailManagement.Services.Customers;

public class CustomerService : ICustomerService
{
    public SqlConnection con;

    public CustomerService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConnection");
        if (con == null)
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
    }

    public List<Customer> GetCustomers()
    {
        List<Customer> customers = new();

        var cmd = new SqlCommand("SELECT * FROM dbo.Customers", con)
        {
            CommandType = System.Data.CommandType.Text
        };

        SqlDataReader rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            var userId = rdr["UserId"].ToString();
            var userName = rdr["Username"].ToString();
            var email = rdr["Email"].ToString();
            var firstName = rdr["FirstName"].ToString();
            var lastName = rdr["LastName"].ToString();
            var createdOn = rdr["CreatedOn"].ToString();
            var isActive = rdr["IsActive"].ToString();

            if (userId != null && userName != null && email != null && firstName != null &&
            lastName != null && createdOn != null && isActive != null)
            {
                Customer customer = new(
                        Guid.Parse(userId),
                        userName,
                        email,
                        firstName,
                        lastName,
                        DateTime.Parse(createdOn),
                        isActive == "1"
                    );

                customers.Add(customer);
            }

        }

        return customers;
    }
}