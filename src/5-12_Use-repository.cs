var userRepository = new UserRepository();
var program = new Program(userRepository);
program.CreateUser("alice");
