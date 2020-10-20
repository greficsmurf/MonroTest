using ArtMonroTest.Database.Models;
using ArtMonroTest.DataBase;
using ArtMonroTest.Services.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtMonroTest.Services
{
    public class DataService : IDataService
    {
        private readonly dbContext _dbContext;
        public DataService(dbContext dbcontext) {
            _dbContext = dbcontext;
        }
        public async Task<List<TestData>> CheckSize(TestDataFilter filter)
        {
            await UpdateAvailable();

            var list = _dbContext.Set<TestData>().Where(x => x.ProductSize.ToLower().Equals(filter.ProductSize.ToLower()) && x.isAvailable == Database.Enums.IsInStock.IN_STOCK).ToList();
           
            return await Task.FromResult(list);
        }

        public async Task<List<TestData>> GetAllAsync()
        {
            await UpdateAvailable();
            return await Task.FromResult(_dbContext.Set<TestData>().ToList());
        }

        public async Task<List<TestData>> GetAllAvailableAsync()
        {
            await UpdateAvailable();

            return await Task.FromResult(_dbContext.Set<TestData>().Where(x => x.isAvailable == Database.Enums.IsInStock.IN_STOCK).ToList());
        }
        private async Task UpdateAvailable() {
            
            var list = _dbContext.Set<TestData>().Where(x => x.ProductAmount == 0).ToList();
            foreach (var i in list)
            {
                i.isAvailable = Database.Enums.IsInStock.NOT_IN_STOCK;
                _dbContext.Update(i);
            }
            list = _dbContext.Set<TestData>().Where(x => x.ProductAmount > 0).ToList();
            foreach (var i in list)
            {
                i.isAvailable = Database.Enums.IsInStock.IN_STOCK;
                _dbContext.Update(i);
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
