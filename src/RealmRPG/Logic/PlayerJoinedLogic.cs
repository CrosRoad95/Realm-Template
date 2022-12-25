namespace RealmRPG.Logic;

internal sealed class PlayerJoinedLogic
{
    private readonly IInternalRPGServer _rpgServer;

    public PlayerJoinedLogic(IInternalRPGServer rpgServer)
    {
        _rpgServer = rpgServer;

        _rpgServer.PlayerJoined += HandlePlayerJoined;
    }

    private void HandlePlayerJoined(Entity entity)
    {
        var playerElementComponent = entity.GetRequiredComponent<PlayerElementComponent>();
        entity.AddComponent(new AdminComponent()).DebugView = true;
        entity.AddComponent(new LoginGuiComponent());

        entity.ComponentAdded += HandleComponentAdded;
    }

    private void HandleComponentAdded(Component component)
    {
        if (component is AccountComponent)
        {
            var playerElementComponent = component.Entity.GetRequiredComponent<PlayerElementComponent>();
            if (!playerElementComponent.TrySpawnAtLastPosition())
            {
                playerElementComponent.Spawn(new Vector3(362.58f + (float)Random.Shared.NextDouble() * 3, -91.07f + (float)Random.Shared.NextDouble() * 3, 1.38f),
                    new Vector3(0, 0, 90));
            }
        }
    }
}
