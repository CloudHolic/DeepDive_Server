using System.Threading.Tasks;

namespace DeepDive_Server.Hubs.Clients
{
    public interface IPlayerClient
    {
        Task GetSkillList();

        Task SetSkill();
    }
}