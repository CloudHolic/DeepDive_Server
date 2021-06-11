using DeepDive_Server.DbContext;
using Microsoft.Extensions.DependencyInjection;

namespace DeepDive_Server.Engine
{
    public class GameManager : IGameManager
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public GameManager(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void EndGame()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DeepDiveContext>();

            }
        }
    }
}
