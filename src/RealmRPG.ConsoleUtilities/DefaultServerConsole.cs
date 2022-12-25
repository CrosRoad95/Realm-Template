using Realm.Interfaces.Server;

namespace RealmRPG.ConsoleUtilities;

internal class DefaultServerConsole : IConsole
{
    public event Action<string?>? CommandExecuted;

    public void Start()
    {
        try
        {
            while (true)
            {
                var line = Console.ReadLine();
                CommandExecuted?.Invoke(line);
            }
        }
        finally
        {

        }
    }
}
