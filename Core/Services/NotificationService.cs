using MudBlazor;

namespace CEJ_WebApp.Core.Services
{
    public class NotificationService
    {
        private readonly ISnackbar _snackbar;

        public NotificationService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void ExibirMensagem(string mensagem, Severity severity = Severity.Error)
        {
            var config = (SnackbarOptions options) =>
            {
                options.DuplicatesBehavior = SnackbarDuplicatesBehavior.Prevent;
            };

            _snackbar.Add(mensagem, severity, configure: config, key: "User");
        }

        // Sobrecargas úteis
        public void Sucesso(string mensagem) => ExibirMensagem(mensagem, Severity.Success);

        public void Aviso(string mensagem) => ExibirMensagem(mensagem, Severity.Warning);

        public void Info(string mensagem) => ExibirMensagem(mensagem, Severity.Info);
    }
}