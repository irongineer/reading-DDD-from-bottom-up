var userRepository = new EFUserRepository(myContext);
var program = new Program(userRepository);

program.CreateUser("naruse");

//データを取り出して確認
var head = myContext.Users.First();
Assert.AreEqual("naruse", head.Name);
