using ApiResource.Application.DTOs;
using ApiResource.Application.DTOs.Validations;
using ApiResource.Application.Services.Interfaces;
using ApiResource.Domain.Authentication;
using ApiResource.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ApiResource.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if(userDTO == null)
            {
                return ResultService.Fail<dynamic>("Objeto deve ser informado!");
            }

            var validator = new UserDTOValidator().Validate(userDTO);
            if(!validator.IsValid)
            {
                return ResultService.RequestError<dynamic>("Problemas de validação", validator);
            }

            var user = await _userRepository.GetUserByEmailAndPassowrd(userDTO.Email, userDTO.Password);
            if(user == null)
            {
                return ResultService.Fail<dynamic>("Usuario ou senha não encontrado!");
            }

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }

        public async Task<ResultService<dynamic>> RefreshToken(string token, string refreshToken)
        {
            var principal = _tokenGenerator.GetPrincipalFromExpiredToken(token);
            var email = principal.Identity.Name;
            var savedRefreshToken = _tokenGenerator.GetRefreshToken(email);

            if(savedRefreshToken != refreshToken)
            {
                return ResultService.Fail<dynamic>("RefreshToken Invalido");
            }

            var newJwtToken = _tokenGenerator.Generator(principal.Claims);
            var newRefreshToken = _tokenGenerator.GenerateRefreshToken();

            _tokenGenerator.DeleteRefreshToken(email, refreshToken);
            _tokenGenerator.SaveRefreshToken(email, newRefreshToken);

            return ResultService.Ok<dynamic>(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }
    }
}
