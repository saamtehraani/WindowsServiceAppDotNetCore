using System.Collections.Generic;
using System.Threading.Tasks;
using WorkerService1.Models;

namespace WorkerService1.Interfaces
{
    public interface ISampleService
    {
        Task<List<PersonModel>> GetPersons();
    }
}
