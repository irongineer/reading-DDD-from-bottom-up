public class UserRepository : IUserRepository
{
  private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

  public void Save(User user)
  {
    using (var connection = newSqlConnection(connectionString))
    using (var command = connection.CreateCommand())
    {
      connection.Open();
      command.CommandText = @"
        MERGE INTO users
          USING (
            SELECT @id AS id, @name AS name
          ) AS data
          ON users.id = data.id
          WHEN MATCHED THEN
            UPDATE SET name = data.name;
          WHEN NOT MATCHED THEN
            INSERT (id, name) VALUES (data.id, data.name);
      ";
      command.Parameters.Add(newSqlParameter("@id", user.Id.Value));
      command.Parameters.Add(newSqlParameter("@name", user.Name.Value));
      command.ExecuteNonQuery();
    }
  }
  (...略...)
}
