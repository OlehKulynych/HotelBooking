using HotelBooking.API.Models;
using HotelBooking.API.Repository.DataBaseContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.API.Repository
{
    public class UserStore : IUserPasswordStore<User>, IUserRoleStore<User>
    {
        private readonly HotelBookingDataBaseContext _dbContext;

        public UserStore(HotelBookingDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user != null)
            {
                var role = await _dbContext.Roles.Include(u => u.Users).SingleOrDefaultAsync(r => r.Name == roleName);
                role.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user != null)
            {
                user.Id = Guid.NewGuid().ToString();
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return IdentityResult.Success;
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user != null)
            {
                var userDb = await _dbContext.Users.FindAsync(user.Id);
                _dbContext.Remove(userDb);
                await _dbContext.SaveChangesAsync();
                return IdentityResult.Success;
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        public void Dispose()
        {
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.Id == userId, cancellationToken: cancellationToken);

        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _dbContext.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.UserName == normalizedUserName.ToLower(), cancellationToken: cancellationToken);
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.UserName.ToLowerInvariant());
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var userDb = await _dbContext.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.UserName == user.UserName);
            if (userDb != null)
            {
                var Roles = userDb.Roles.ToList();
                if (Roles != null)
                {
                    List<string> roleNames = new List<string>();
                    foreach (var r in Roles)
                    {
                        roleNames.Add(r.Name);
                    }
                    return roleNames;
                }
                return null;
            }
            return null;
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Id);
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.UserName);
        }

        public async Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            var roleDb = await _dbContext.Roles.Include(r => r.Users).SingleOrDefaultAsync(r => r.Name == roleName);
            if (roleDb != null)
            {
                var users = roleDb.Users.ToList();

                return users;
            }
            return null;
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return await Task.FromResult(!string.IsNullOrWhiteSpace(user.PasswordHash));

        }

        public async Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            var roles = await GetRolesAsync(user, cancellationToken);
            return roles.Contains(roleName);
        }

        public async Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user != null)
            {
                var userDb = await _dbContext.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.UserName == user.Email);
                var roleDb = await _dbContext.Roles.Include(r => r.Users).SingleOrDefaultAsync(r => r.Name == roleName);
                userDb.Roles.Remove(roleDb);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(user));
            }
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.UserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.PasswordHash = passwordHash;
            return Task.FromResult<object>(null);
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return IdentityResult.Success;
        }
    }
}
