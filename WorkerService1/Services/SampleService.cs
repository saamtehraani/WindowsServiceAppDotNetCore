using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerService1.DataModel.Model;
using WorkerService1.Interfaces;
using WorkerService1.Models;

namespace WorkerService1.Services
{
    class SampleService : ISampleService
    {
        private TestDbContext _adventureWorksContext;
        private readonly IServiceProvider _serviceProvider;
        public SampleService(
            TestDbContext adventureWorksContext,
            IServiceProvider serviceProvider
        )
        {
            _adventureWorksContext = adventureWorksContext;
            _serviceProvider = serviceProvider;
        }

        public async Task<List<PersonModel>> GetPersons()
        {
            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<TestDbContext>();
            var persons = await dbContext.Person.Select(q => new PersonModel()
            {
                Id = q.Id,
                FirstName = q.FirstName
            }).ToListAsync();

            return persons;
        }
    }
}
