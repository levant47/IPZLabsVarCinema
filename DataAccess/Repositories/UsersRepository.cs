using System.Linq;

namespace IPZLabsVarCinema
{
    public class UsersRepository
    {
        private readonly CinemaDbContext _dbContext;

        public UsersRepository(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Create(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User? GetById(int userId) => _dbContext.Users.FirstOrDefault(user => user.Id == userId);
    }
}
