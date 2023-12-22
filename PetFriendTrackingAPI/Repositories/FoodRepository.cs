using Microsoft.EntityFrameworkCore;
using PetFriendTrackingAPI.DBOperations;
using PetFriendTrackingAPI.Entities;
using PetFriendTrackingAPI.Repositories.Contracts;

namespace PetFriendTrackingAPI.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly PetDbContext _dbContext;

    public FoodRepository(PetDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Food>> GetAllAsync()
    {
        return await _dbContext.Foods.ToListAsync();
    }

    public async Task<Food> GetnByIdAsync(int besinId)
    {
        return await _dbContext.Foods.FindAsync(besinId);
    }

    public async Task AddAsync(Food besin)
    {
        _dbContext.Foods.Add(besin);
        await _dbContext.SaveChangesAsync();
    }

    public async Task GiveFoodAsync(int petAnimalId, string foodName)
    {
        var pet = await _dbContext.PetAnimals.FindAsync(petAnimalId);
        var food = await _dbContext.Foods.Where(x => x.Name == foodName).FirstAsync();

        if (pet != null || food != null)
        {
            PetAnimalFood yeniBesinler = new PetAnimalFood
            {
                PetAnimalId = pet.Id,
                FoodId = food.Id
            };


            _dbContext.PetAnimalFoods.Add(yeniBesinler);

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Food food)
    {
        _dbContext.Entry(food).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(int foodId)
    {
        var food = await _dbContext.Foods.FindAsync(foodId);
        if (food != null)
        {
            _dbContext.Foods.Remove(food);
            await _dbContext.SaveChangesAsync();
        }

        throw new BadHttpRequestException("Food could not be deleted.");
    }
}