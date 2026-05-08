namespace CEJ_WebApp.Core.Services.Interface;

public interface ISessionTimeoutService
{
    Task StartMonitoringAsync();
    Task StopMonitoringAsync();
    Task ResetInactivityTimerAsync();
}
