using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using WindowsApp_Seminar3_S3A1.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Mvvm;
using Template10.Common;
using System.Diagnostics;
using Template10.Services.LoggingService;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace WindowsApp_Seminar3_S3A1
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
            #region App settings

            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
        }

        public void Log()
        {
            LoggingService.Enabled = true;
            LoggingService.WriteLine = new DebugWriteDelegate((v,s,t,c) =>
            {
                Debug.WriteLine($"{v},{s},{t},{c}");
            });
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            // long-running startup tasks go here

            NavigationService.Navigate(typeof(Views.MainPage), "DavidBrown");
            await Task.CompletedTask;
        }

    }
}

