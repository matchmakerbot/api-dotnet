using MatchmakerBotAPI.Core.Models.MatchmakerUsersModel;
using System.Threading.Tasks;
namespace MatchmakerBotAPI.Core.Connectors.MatchmakerUsers
{
    public interface IMatchmakerUsersConnector
    {
         Task<MatchmakerUsersModel> GetUserById(string id);

         Task<int> DeleteUser(string id);

         Task<int> AddUser(MatchmakerUsersModel user);

         Task<int> EditUser(string id, MatchmakerUsersModel user);
    }
}