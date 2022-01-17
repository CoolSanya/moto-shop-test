using moto_shop_test.DAL;
using moto_shop_test.DTO.AuthDTO;
using moto_shop_test.Models;

namespace moto_shop_test.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _db;
        public AuthService(ApplicationDbContext db)
        {
            _db = db;
        }
        public User RegisterUser(RegisterDTO registerDTO)
        {
            try
            {
                var _user = new User()
                {
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Phone = registerDTO.Phone,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password
                };

                var createdUser = _db.Users.Add(_user);
                _db.SaveChanges();

                return createdUser.Entity;
            }
            catch (Exception)
            {

                throw new Exception("Email is exist");
            }
        }
        public User CheckPassword(string email, string password)
        {
            var user = _db.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("Invalid email. User not found");
            }
            if (password==user.Password)
            {
                return user;
            }
            return null;
        }

        public User GetUserById(int id)
        {
            return _db.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
