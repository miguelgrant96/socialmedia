using Microsoft.Owin.Security.Infrastructure;
using project2._4.BL.Repositories;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace project2._4.API.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        public void Create(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            AuthRepository _repo = new AuthRepository();

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                RefreshToken_ID = refreshTokenId,
                Client_Id = clientid,
                Subject = context.Ticket.Identity.Name,
                CreatedDateTime = DateTime.UtcNow,
                ExpiresDateTime = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.CreatedDateTime;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresDateTime;

            token.ProtectedTicket = context.SerializeTicket();

            var result = _repo.AddRefreshToken(token);

            if (result.Result == true)
            {
                context.SetToken(refreshTokenId);
            }
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            AuthRepository _repo = new AuthRepository();

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshToken()
            {
                Id = Guid.NewGuid(),
                RefreshToken_ID = refreshTokenId,
                Client_Id = clientid,
                Subject = context.Ticket.Identity.Name,
                CreatedDateTime = DateTime.UtcNow,
                ExpiresDateTime = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.CreatedDateTime;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresDateTime;

            token.ProtectedTicket = context.SerializeTicket();

            var result = await _repo.AddRefreshToken(token);

            if (result)
            {
                context.SetToken(refreshTokenId);
            }


        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }


    }
}