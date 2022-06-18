using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PartyMaker.Application.Configuration;
using PartyMaker.Application.Exceptions;
using PartyMaker.Application.Interfaces;
using PartyMaker.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

namespace PartyMaker.Application.Manager
{
    public class AccountManager : IAccountManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AuthConfiguration _authConfiguration;

        public AccountManager(UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager,
                              IOptions<AuthConfiguration> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authConfiguration = options.Value;
        }

        public async Task<string> Login(string username, string password)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(username, password, false, false);

            if (!checkingPasswordResult.Succeeded)
            {
                throw new AccountLoginException("Wrong credentials");
            }

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new AccountLoginException("Invalid username");
            }

            var claims = new List<Claim>()
            {
                new Claim(nameof(ApplicationUser.Id), user.Id.ToString()),
                new Claim(nameof(ApplicationUser.UserName), user.UserName),
                new Claim(nameof(ApplicationUser.FirstName), user.FirstName),
                new Claim(nameof(ApplicationUser.LastName), user.LastName),
                new Claim(nameof(ApplicationUser.Image), user.Image),
                new Claim(nameof(ApplicationUser.IdentityCard), user.IdentityCard)
            };

            var signinCredentials = new SigningCredentials(_authConfiguration.GetSymmetricSecurityKey(),
                                                           SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _authConfiguration.Issuer,
                audience: _authConfiguration.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: signinCredentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

            return encodedToken;
        }

        public async Task Register(ApplicationUser user, string password)
        {
            using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                throw new AccountRegisterException(string.Join('\n', result.Errors.Select(x => x.Description).ToArray()));
            }

            var userResult = await _userManager.FindByNameAsync(user.UserName);

            scope.Complete();
        }
    }
}
