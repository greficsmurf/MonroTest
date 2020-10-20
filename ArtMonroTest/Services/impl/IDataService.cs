using ArtMonroTest.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtMonroTest.Services.impl
{
    public interface IDataService
    {
        Task<List<TestData>> GetAllAsync();
        Task<List<TestData>> GetAllAvailableAsync();
        Task<List<TestData>> CheckSize(TestDataFilter filter);

    }
}
