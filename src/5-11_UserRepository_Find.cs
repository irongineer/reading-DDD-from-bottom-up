public class UserRepository : IUserRepository
{
  (...略...)

  public void Find(UserName userName)
  {
    using (var connection = newSqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
      connection.Open();
      command.CommandText = "SELECT * FROM users WHERE name = @name";
      command.Parameters.Add(newSqlParameter("@name", user.Name.Value));
      using (var reader = command.ExecuteReader())
      {
        if (reader.Read())
        {
          var id = reader["id"] as string;
          var name = reader["name"] as string;
          return new User(
            new UserId(id),
            new UserName(name)
          );
        }
        else
        {
          return null;
        }
      }
    }
  }
}
