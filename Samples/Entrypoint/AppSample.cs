using Bastion.Core;
using Reflex.Attributes;
using Bastion.Logging;
using Bastion.Storage;
using Color = Bastion.Theme.Color;

namespace Bastion
{
    /// <summary>
    /// The entry point of the application.
    /// </summary>
    [Log(nameof(AppSample), Color = Color.Sky)]
    public class AppSample : AppBootstrap
    {
        [Inject] private readonly FileManager _fileManager;

        private async void Start()
        {
            await InitManagersAsync(new Manager[]
            {
                _fileManager,
                // Add managers here ...
            });
        }
    }
}