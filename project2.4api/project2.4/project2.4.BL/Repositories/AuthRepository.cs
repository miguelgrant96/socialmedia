using project2._4.DAL;
using project2._4.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2._4.BL.Repositories
{
    public class AuthRepository
    {
        private DatabaseContext Db;

        public AuthRepository()
        {
            Db = new DatabaseContext();
        }

        public Client FindClient(string clientId)
        {
            var client = Db.Clients.Where(x=>x.Client_ID.Equals(clientId)).FirstOrDefault();

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = Db.RefreshTokens.Where(r => r.Subject == token.Subject && r.Client_Id == token.Client_Id).SingleOrDefault();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            Db.RefreshTokens.Add(token);

            return await Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await Db.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                Db.RefreshTokens.Remove(refreshToken);
                return await Db.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            Db.RefreshTokens.Remove(refreshToken);
            return await Db.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await Db.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return Db.RefreshTokens.ToList();
        }
    }
}
