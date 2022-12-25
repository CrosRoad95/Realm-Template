var builder = new RPGServerBuilder();
builder.AddDefaultModules()
    .AddDefaultLogger()
    .AddDefaultConsole()
    .AddDefaultConfiguration();

SemaphoreSlim semaphore = new(0);

var server = builder.Build(null, extraBuilderSteps: serverBuilder =>
{
    serverBuilder.AddLogic<PlayerJoinedLogic>();
    serverBuilder.AddLogic<CommandsLogic>();
#if DEBUG
    serverBuilder.AddLogic<HotReloadLogic>("../../../Server/Gui");
#endif
});

Console.CancelKeyPress += async (sender, args) =>
{
    await server.Stop();
    semaphore.Release();
};

await server.Start();
server.GetRequiredService<IConsole>().Start();
await semaphore.WaitAsync();




