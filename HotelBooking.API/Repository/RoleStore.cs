using HotelBooking.API.Models;
using HotelBooking.API.Repository.DataBaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace HotelBooking.API.Repository
{
    public class RoleStore : IRoleStore<Role>
    {
        private readonly HotelBookingDataBaseContext _dbContext;
        public RoleStore(HotelBookingDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role != null)
            {
                role.Id = Guid.NewGuid().ToString();
                _dbContext.Roles.Add(role);
                await _dbContext.SaveChangesAsync();
                return IdentityResult.Success;
            }
            else
            {
                throw new ArgumentNullException(nameof(role));
            }
        }

        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role != null)
            {
                var roleDb = await _dbContext.Roles.FindAsync(role.Id);
                _dbContext.Remove(roleDb);
                await _dbContext.SaveChangesAsync();
                return IdentityResult.Success;
            }
            else
            {
                throw new ArgumentNullException(nameof(role));
            }
        }

        public void Dispose()
        {
        }

        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Roles.SingleOrDefaultAsync(r => r.Id == roleId, cancellationToken: cancellationToken);
        }

        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Roles.SingleOrDefaultAsync(r => r.Name == normalizedRoleName.ToLower(), cancellationToken: cancellationToken);
        }

        public async Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.Name.ToLowerInvariant());
        }

        public async Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.Id);
        }

        public async Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.Name = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            _dbContext.Update(role);
            await _dbContext.SaveChangesAsync();
            return IdentityResult.Success;
        }
    }

}
