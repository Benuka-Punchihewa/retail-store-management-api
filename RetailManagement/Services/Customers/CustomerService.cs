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

        var rawQuery = "SELECT * FROM Customers";
        var cmd = new SqlCommand(rawQuery, con)
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
                        bool.Parse(isActive)
                    );

                customers.Add(customer);
            }
        }

        return customers;
    }

    public ErrorOr<Created> CreateCustomer(Customer customer)
    {
        var rawQuery = "INSERT INTO Customers (UserId, Username, Email, FirstName, LastName, CreatedOn, IsActive)" +
            "VALUES(@UserId, @Username, @Email, @FirstName, @LastName, @CreatedOn, @IsActive);";
        var cmd = new SqlCommand(rawQuery, con)
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
            return Errors.Customer.FailedToCreateCustomer;
        }

        return Result.Created;
    }

    public ErrorOr<Customer> GetCustomer(Guid id)
    {
        var rawQuery = "SELECT * FROM Customers WHERE UserId = @UserId";
        var cmd = new SqlCommand(rawQuery, con)
        {
            CommandType = System.Data.CommandType.Text
        };

        cmd.Parameters.AddWithValue("@UserId", id);

        // Execute the query
        SqlDataReader rdr = cmd.ExecuteReader();

        if (rdr.Read())
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
                return new Customer(
                        Guid.Parse(userId),
                        userName,
                        email,
                        firstName,
                        lastName,
                        DateTime.Parse(createdOn),
                        bool.Parse(isActive)
                    );
            }
        }

        return Errors.Customer.CustomerNotFound;
    }

    public ErrorOr<Updated> UpdateCustomer(Customer customer)
    {
        var rawQuery = "UPDATE Customers SET Username = @Username, Email = @Email, FirstName = @FirstName," +
            "LastName = @LastName, IsActive = @IsActive WHERE UserId = @UserId";
        var cmd = new SqlCommand(rawQuery, con)
        {
            CommandType = System.Data.CommandType.Text
        };

        cmd.Parameters.AddWithValue("@UserId", customer.UserId);
        cmd.Parameters.AddWithValue("@Username", customer.Username);
        cmd.Parameters.AddWithValue("@Email", customer.Email);
        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
        cmd.Parameters.AddWithValue("@IsActive", customer.IsActive ? 1 : 0);

        // Execute the query
        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
            return Errors.Customer.FailedToUpdateCustomer;
        }

        return Result.Updated;
    }

    public ErrorOr<Deleted> DeleteCustomer(Guid userId)
    {
        var rawQuery = "DELETE FROM Customers WHERE UserId = @UserId";
        var cmd = new SqlCommand(rawQuery, con)
        {
            CommandType = System.Data.CommandType.Text
        };

        cmd.Parameters.AddWithValue("@UserId", userId);

        // Execute the query
        int rowsAffected = cmd.ExecuteNonQuery();

        if (rowsAffected == 0)
        {
            return Errors.Customer.FailedToDeleteCustomer;
        }

        return Result.Deleted;
    }
}