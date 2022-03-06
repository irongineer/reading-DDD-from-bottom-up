public interface IUserRepository
{
  void Save(UserService user);

  Option<User> Find(UserName name);
}
