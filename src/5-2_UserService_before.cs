class UserService
{
  public bool Exists(User user)
  {
    var connectionString = ConfigurationManager.ConnectionStrings["FooConnection"].ConnectionString;
    using (var connection = newSqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
      connection.Open();
      command.CommandText = "SELECT * FROM users WHERE name = @name";
      command.Parameters.Add(newSqlParameter("@name", user.Name.Value));
      using (var reader = command.ExecuteReader())
      {
        var exist = reader.Read();
        return exist;
      }
    }
  }
}
