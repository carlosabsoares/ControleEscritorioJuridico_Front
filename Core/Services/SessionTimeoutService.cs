using Blazored.LocalStorage;
using CEJ_WebApp.Core.Services.Interface;
using Microsoft.JSInterop;

namespace CEJ_WebApp.Core.Services;

public class SessionTimeoutService : ISessionTimeoutService, IAsyncDisposable
{
    private readonly IAuthService _authService;
    private readonly ILocalStorageService _localStorage;
    private readonly IJSRuntime _jsRuntime;

    public SessionTimeoutService(IAuthService authService, ILocalStorageService localStorage, IJSRuntime jsRuntime)
    {
        _authService = authService;
        _localStorage = localStorage;
        _jsRuntime = jsRuntime;
    }

    public async Task StartMonitoringAsync()
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("sessionTimeout.setupActivityListeners", DotNetObjectReference.Create(this));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao configurar monitoramento de sessão: {ex.Message}");
        }
    }

    public async Task StopMonitoringAsync()
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("sessionTimeout.removeActivityListeners");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao remover listeners de sessão: {ex.Message}");
        }
    }

    public async Task ResetInactivityTimerAsync()
    {
        // Método não usado na implementação atual, mas mantido para compatibilidade futura
        await Task.CompletedTask;
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await StopMonitoringAsync();
    }
}
