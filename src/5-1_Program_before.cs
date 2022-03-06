class Program
{
  public void CreateUser(string userName)
  {
    var user = new User(
      new UserName(userName)
    );

    var userService = new UserService();
    if (UserService.Exists(user))
    {
      throw new Exception($"{userName}は既に存在しています");
    }

    var connectionString = ConfigurationManager.ConnectionStrings["FooConnection"].ConnectionString;
    using (var connection = newSqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
      connection.Open();
      command.CommandText = "INSERT INTO users (id, name) VALUES(@id, @name)";
      command.Parameters.Add(newSqlParameter("@id", user.Id.Value));
      command.Parameters.Add(newSqlParameter("@name", user.Name.Value));
      command.ExecuteNonQuery();
    }
  }
}
