using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly PetDbContext _dbContext;

    public UserRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }

    public async Task AddAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int userId)
    {
        var kullanici = await _dbContext.Users.FindAsync(userId);
        if (kullanici != null)
        {
            _dbContext.Users.Remove(kullanici);
            await _dbContext.SaveChangesAsync();
            return;
        }
        
        throw new BadHttpRequestException("User could not be deleted.");
    }
    
    public async Task<PetStatistics> GetPetStatisticsAsync(int kullaniciId)
    {
        var user = await _dbContext.Users
            .Where(u => u.Id == kullaniciId).Include(user => user.PetAnimals)
            .ThenInclude(petAnimal => petAnimal.HealthStatus).Include(user => user.PetAnimals)
            .ThenInclude(petAnimal => petAnimal.Activities).Include(user => user.PetAnimals)
            .ThenInclude(petAnimal => petAnimal.PetAnimalFoods)
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new Exception("The specified user was not found.");
        }

        var petStatistics = new PetStatistics
        {
            HealthStatuses = user.PetAnimals.SelectMany(pa => pa.HealthStatus).ToList(),
            Activities = user.PetAnimals.SelectMany(pa => pa.Activities).ToList(),
            PetAnimalFoods = user.PetAnimals.SelectMany(pa => pa.PetAnimalFoods).ToList()
        };

        return petStatistics;
    }
}