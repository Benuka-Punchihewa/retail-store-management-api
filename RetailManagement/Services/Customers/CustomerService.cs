using System.Data.SqlClient;
using RetailManagement.Models;
using ErrorOr;
using RetailManagement.ServiceErrors;

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

    public ErrorOr<Created> CreateCustomer(Customer customer)
    {
        var rawCommand = "INSERT INTO Customers (UserId, Username, Email, FirstName, LastName, CreatedOn, IsActive)" +
            "VALUES(@UserId, @Username, @Email, @FirstName, @LastName, @CreatedOn, @IsActive);";
        var cmd = new SqlCommand(rawCommand, con)
        {
            CommandType = System.Data.CommandType.Text
        };

        cmd.Parameters.AddWithValue("@UserId", customer.UserId);
        cmd.Parameters.AddWithValue("@Username", customer.Username);
        cmd.Parameters.AddWithValue("@Email", customer.Email);
        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
        cmd.Parameters.AddWithValue("@CreatedOn", customer.CreatedOn);
        cmd.Parameters.AddWithValue("@IsActive", customer.IsActive ? 1 : 0);

        // Execute the query
        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
            return Errors.Customer.InvalidUsernameLength;
        }

        return Result.Created;
    }
}