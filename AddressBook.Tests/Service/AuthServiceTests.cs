using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System;
using BusinessLayer.Service;
using ModelLayer.DTO;
using RepositoryLayer.Service;
using RepositoryLayer;
using RepositoryLayer.Context;
using Microsoft.Extensions.Configuration;

namespace AddressBookTests.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        private AddressBookService _authService;
        private AddressBookDbContext _dbContext;
        private IConfiguration _configuration; // ✅ Ensure config for JWT
        private JwtService _jwtService;  // ✅ JWT dependency added

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AddressBookDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // ✅ Unique DB for each test
                .Options;

            _dbContext = new AddressBookDbContext(options);

            // ✅ Fake JWT Configuration
            var inMemorySettings = new Dictionary<string, string>
            {
                {"JWT:Key", "ThisIsASecretKeyForTestingPurposes"},
                {"JWT:Issuer", "TestIssuer"}
            };

            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _jwtService = new JwtService((Microsoft.Extensions.Options.IOptions<JwtOptions>)_configuration); // ✅ Fix: Inject JWT Service

            var addressBookRepository = new AddressBookRL(_dbContext);

            // ✅ Fix: Ensure AddressBookService is correctly initialized with JWT
            _authService = new AddressBookService(addressBookRepository, _jwtService);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Test]
        public void RegisterUser_Should_Return_Success_Message()
        {
            // Arrange
            var user = new UserDTO
            {
                Name = "Vanshita",
                Email = "khantalvanshita@gmail.com",
                Password = "Vanshita123"
            };

            // Act
            var result = _authService.Register(user);

            // Assert
            Assert.IsNotNull(result, "Registration failed, returned null.");
            Assert.IsInstanceOf<string>(result, "Return type should be a string.");
            Assert.IsTrue(result.Contains("success", StringComparison.OrdinalIgnoreCase), "Success message not found.");
        }

        [Test]
        public void LoginUser_Should_Return_JWT_Token()
        {
            // Arrange: Register user first
            var user = new UserDTO
            {
                Name = "Vanshita",
                Email = "khantalvanshita@gmail.com",
                Password = "Vanshita123"
            };
            _authService.Register(user); // ✅ Ensure user exists before login

            // Act
            var result = _authService.Login(user.Email, user.Password);

            // Assert
            Assert.IsNotNull(result, "Login failed, returned null.");
            Assert.IsInstanceOf<string>(result, "Return type should be a JWT token string.");
            Assert.IsTrue(result.Length > 10, "JWT token is too short.");
        }

        [Test]
        public void LoginUser_Should_Return_Null_If_Credentials_Are_Incorrect()
        {
            // Act
            var result = _authService.Login("invalid@example.com", "WrongPass");

            // Assert
            Assert.IsNull(result, "Login should return null for invalid credentials.");
        }
    }
}
