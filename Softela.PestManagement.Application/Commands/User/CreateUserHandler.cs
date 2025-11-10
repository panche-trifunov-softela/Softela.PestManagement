using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Softela.PestManagement.Application.Repositories;
using System.Threading;
using UserEntity = Softela.PestManagement.Domain.Entities.User;

namespace Softela.PestManagement.Application.Commands.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public CreateUserHandler(IUserRepository userRepository, IPasswordHasher<UserEntity> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            Guid guid = Guid.NewGuid();
            var user = new UserEntity
            {
                Id = 0,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow,
                CreatedBy = guid,
                ModifiedBy = guid,
                UserId = guid,
                UserName = request.UserName,
                NormalizedUserName = request.UserName.ToUpperInvariant(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpperInvariant(),
                EmailConfirmed = false,
                IsActive = true,
                IsDeleted = false
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.CreateUserAsync(user);
            return true;
        }
    }
}
