using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Educative.Core;

namespace Educative.Infrastructure.Interface
{
    public interface IAddressRepository
    {
        Task<Address> GetByIdAsync(string id);

        Task<IEnumerable<Address>> GetAllAsync();

        Task<Address> AddAsync(Address entity);

        Task<Address> UpdateAsync(Address entity);

        Task<bool> DeleteAsync(string id);
        
    }
}