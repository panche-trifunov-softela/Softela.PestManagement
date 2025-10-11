using MediatR;
using Microsoft.AspNetCore.Identity;
using Softela.PestManagement.Application.Queries.Account.GetAccounts;
using Softela.PestManagement.Application.Repositories;
using Softela.PestManagement.Application.Services.AuthToken;
using Softela.PestManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softela.PestManagement.Application.Queries.Auth.GetToken
{
    public class GetTokenHandler : IRequestHandler<GetTokenRequest, GetTokenResponse>
    {
        private readonly IAuthToken _authToken;
        private readonly IUserStore<User> _userStore;
        private readonly IRoleRepository _roleRepository;

        public GetTokenHandler(IAuthToken authToken, IUserStore<User> userStore, IRoleRepository roleRepository)
        {
            _authToken = authToken;
            _userStore = userStore;
            _roleRepository = roleRepository;
        }

        public async Task<GetTokenResponse> Handle(GetTokenRequest request, CancellationToken cancellationToken)
        {
            // Normalize username for lookup
            var normalizedUserName = request.Username.ToUpperInvariant();

            // Find user by normalized username
            var user = await _userStore.FindByNameAsync(normalizedUserName, cancellationToken);
            if (user == null || user.IsDeleted || !user.IsActive)
                return new GetTokenResponse { Success = false };

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return new GetTokenResponse { Success = false };

            // Get roles (assuming you have a way to resolve role names from UserRole)
            var roles = await _roleRepository.GetRolesByUserIdAsync(user.Id);

            // Generate JWT
            var token = _authToken.GenerateToken(user.Id, user.UserName, roles.Select(x => x.NormalizedName));

            return new GetTokenResponse { Success = true, AccessToken = token };
        }
    }
}
