using System.Threading.Tasks;
using MatchmakerBotAPI.Core.Connectors.MatchmakerUsers;
using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;

namespace MatchmakerBotAPI.Core.Services.MatchmakerUsers
{
    public class MatchmakerUsersService : IMatchmakerUsersService
    {
        private IMatchmakerUsersConnector _matchmakerUsersConnector;

        public MatchmakerUsersService(IMatchmakerUsersConnector matchmakerUsersConnector) {
            _matchmakerUsersConnector = matchmakerUsersConnector;
        }

        public async Task<bool> AddUser(MatchmakerUsersModel user)
        {
            var inserted = await _matchmakerUsersConnector.AddUser(user);

            return inserted != 0;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var deleted = await _matchmakerUsersConnector.DeleteUser(id);

            return deleted != 0;
        }

        public async Task<bool> EditUser(string id, MatchmakerUsersModel user)
        {
            var edited = await _matchmakerUsersConnector.EditUser(id, user);

            return edited != 0;
        }

        public async Task<MatchmakerUsersModel> GetUserById(string id)
        {
            var user = await _matchmakerUsersConnector.GetUserById(id);

            return user;
        }
    }
}