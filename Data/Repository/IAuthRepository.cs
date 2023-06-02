using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface  IAuthRepository:IRepository<User>
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO);
        Task<User> Register(RegistrationRequestDto registrationRequestDto);
        Task<User> UpdateAsync(User entity);
    }
}
