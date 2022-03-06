public interface IUserRepository
{
  void Save(UserService user);

  User Find(UserName name);
}
