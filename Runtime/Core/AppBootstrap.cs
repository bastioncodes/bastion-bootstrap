using System.Diagnostics;
using System.Threading.Tasks;
using Bastion.Logging;
using UnityEngine;
using Color = Bastion.Theme.Color;

namespace Bastion.Core
{
    [Log(nameof(AppBootstrap), Name = "App", Color = Color.Sky)]
    public class AppBootstrap : MonoBehaviour
    {
        private static AppBootstrap _instance;
        
        protected virtual void Awake()
        {
            if (_instance != null)
            {
                BastionLogger.LogWarning($"App instance already exists.");
                Destroy(gameObject);
                return;
            }

            _instance = this;
        }
        
        protected async Task InitManagersAsync(Manager[] managers)
        {
            var totalStopwatch = Stopwatch.StartNew();
            
            foreach (var manager in managers)
            {
                var stopwatch = Stopwatch.StartNew();
                var tcs = new TaskCompletionSource<bool>();
                manager.Init(() =>
                {
                    stopwatch.Stop();
                    long elapsedTime = stopwatch.ElapsedMilliseconds;
                    string startupTime = elapsedTime == 0 ? "< 1 ms" : $"{elapsedTime} ms";
                    string managerName = LogUtility.Colorize(manager.GetType().Name, Color.Blue);
                    BastionLogger.Log($"{managerName} initialized in ({startupTime}).");
                    tcs.SetResult(true);
                }, error =>
                {
                    BastionLogger.LogError($"{manager.GetType().Name} encountered errors during initialization.");
                    throw error;
                });
                await tcs.Task;
            }
            
            totalStopwatch.Stop();
            BastionLogger.LogInfo($"App started in {totalStopwatch.ElapsedMilliseconds} ms.");
        }
    }
}