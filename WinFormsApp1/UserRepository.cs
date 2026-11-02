using System.Data;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    internal static class UserRepository
    {
        private const string ConnectionString = @"Data Source=DESKTOP-B0M9AK9\SQLEXPRESS;Initial Catalog=MobiWarehouseDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private const int PasswordIterations = 600_000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        internal static void EnsureUsersTable()
        {
            const string query = """
                IF OBJECT_ID(N'dbo.AppUsers', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.AppUsers
                    (
                        UserId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_AppUsers PRIMARY KEY,
                        Username nvarchar(50) NOT NULL,
                        PasswordHash varbinary(32) NOT NULL,
                        PasswordSalt varbinary(16) NOT NULL,
                        IsAdmin bit NOT NULL CONSTRAINT DF_AppUsers_IsAdmin DEFAULT (0),
                        CreatedAt datetime2 NOT NULL CONSTRAINT DF_AppUsers_CreatedAt DEFAULT (SYSUTCDATETIME()),
                        CONSTRAINT UQ_AppUsers_Username UNIQUE (Username)
                    );
                END;
                """;

            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }

        internal static int GetUserCount()
        {
            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new("SELECT COUNT(*) FROM dbo.AppUsers", connection);
            connection.Open();
            return (int)command.ExecuteScalar()!;
        }

        internal static bool CreateFirstAdmin(string username, string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = HashPassword(password, salt);

            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);

            using SqlCommand countCommand = new("SELECT COUNT(*) FROM dbo.AppUsers WITH (UPDLOCK, HOLDLOCK)", connection, transaction);
            if ((int)countCommand.ExecuteScalar()! != 0)
            {
                transaction.Rollback();
                return false;
            }

            InsertUser(connection, transaction, username, hash, salt, isAdmin: true);
            transaction.Commit();
            return true;
        }

        internal static void AddUser(string username, string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = HashPassword(password, salt);

            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            InsertUser(connection, null, username, hash, salt, isAdmin: false);
        }

        internal static bool UpdateUser(int userId, string username, string? password)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();

            if (password is null)
            {
                using SqlCommand command = new(
                    "UPDATE dbo.AppUsers SET Username = @Username WHERE UserId = @UserId",
                    connection);
                command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                command.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
                return command.ExecuteNonQuery() == 1;
            }

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = HashPassword(password, salt);
            using SqlCommand updateCommand = new(
                "UPDATE dbo.AppUsers SET Username = @Username, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt WHERE UserId = @UserId",
                connection);
            updateCommand.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
            updateCommand.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, HashSize).Value = hash;
            updateCommand.Parameters.Add("@PasswordSalt", SqlDbType.VarBinary, SaltSize).Value = salt;
            updateCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            return updateCommand.ExecuteNonQuery() == 1;
        }

        internal static bool DeleteUser(int userId)
        {
            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            using SqlTransaction transaction = connection.BeginTransaction(IsolationLevel.Serializable);

            using SqlCommand userCommand = new(
                "SELECT IsAdmin FROM dbo.AppUsers WITH (UPDLOCK, HOLDLOCK) WHERE UserId = @UserId",
                connection,
                transaction);
            userCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            object? isAdminValue = userCommand.ExecuteScalar();
            if (isAdminValue is null)
            {
                transaction.Rollback();
                return false;
            }

            if ((bool)isAdminValue)
            {
                using SqlCommand adminCountCommand = new(
                    "SELECT COUNT(*) FROM dbo.AppUsers WITH (UPDLOCK, HOLDLOCK) WHERE IsAdmin = 1",
                    connection,
                    transaction);
                if ((int)adminCountCommand.ExecuteScalar() <= 1)
                {
                    transaction.Rollback();
                    return false;
                }
            }

            using SqlCommand deleteCommand = new(
                "DELETE FROM dbo.AppUsers WHERE UserId = @UserId",
                connection,
                transaction);
            deleteCommand.Parameters.Add("@UserId", SqlDbType.Int).Value = userId;
            bool deleted = deleteCommand.ExecuteNonQuery() == 1;
            transaction.Commit();
            return deleted;
        }

        internal static bool TryAuthenticate(string username, string password, out bool isAdmin)
        {
            using SqlConnection connection = new(ConnectionString);
            using SqlCommand command = new(
                "SELECT PasswordHash, PasswordSalt, IsAdmin FROM dbo.AppUsers WHERE Username = @Username",
                connection);
            command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
            if (!reader.Read())
            {
                isAdmin = false;
                return false;
            }

            byte[] storedHash = (byte[])reader["PasswordHash"];
            byte[] salt = (byte[])reader["PasswordSalt"];
            isAdmin = (bool)reader["IsAdmin"];
            byte[] providedHash = HashPassword(password, salt);
            return CryptographicOperations.FixedTimeEquals(storedHash, providedHash);
        }

        internal static DataTable GetUsers()
        {
            using SqlConnection connection = new(ConnectionString);
            using SqlDataAdapter adapter = new(
                "SELECT UserId, Username, IsAdmin, CreatedAt FROM dbo.AppUsers ORDER BY Username",
                connection);
            DataTable users = new();
            adapter.Fill(users);
            return users;
        }

        private static void InsertUser(SqlConnection connection, SqlTransaction? transaction, string username, byte[] hash, byte[] salt, bool isAdmin)
        {
            using SqlCommand command = new(
                "INSERT INTO dbo.AppUsers (Username, PasswordHash, PasswordSalt, IsAdmin) VALUES (@Username, @PasswordHash, @PasswordSalt, @IsAdmin)",
                connection,
                transaction);
            command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
            command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, HashSize).Value = hash;
            command.Parameters.Add("@PasswordSalt", SqlDbType.VarBinary, SaltSize).Value = salt;
            command.Parameters.Add("@IsAdmin", SqlDbType.Bit).Value = isAdmin;
            command.ExecuteNonQuery();
        }

        private static byte[] HashPassword(string password, byte[] salt)
        {
            return Rfc2898DeriveBytes.Pbkdf2(password, salt, PasswordIterations, HashAlgorithmName.SHA256, HashSize);
        }
    }
}
