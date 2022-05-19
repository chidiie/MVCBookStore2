using Microsoft.AspNetCore.Identity;
using MyBookStore2.Models;
using System.Threading.Tasks;

namespace MyBookStore2.Repository
{
    public interface IAccountRepository
    {
        Task <IdentityResult> CreateUserAsync(SignUpUserModel userModel);
    }
}