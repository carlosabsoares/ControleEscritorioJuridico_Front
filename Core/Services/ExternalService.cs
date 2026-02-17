using CEJ_WebApp.Core.Services.Interface;
using CEJ_WebApp.Core.Shared;
using CEJ_WebApp.Model;
using CEJ_WebApp.Model.Dto;
using Newtonsoft.Json;
using OneOf.Types;
using System.Net.Http.Json;
using static MudBlazor.FilterOperator;

namespace CEJ_WebApp.Core.Services
{
    public class ExternalService: IExternalService
    {
        private readonly HttpClient Http = new();
        private string url;
        private bool _return = false;
        private string _object = "User";
        private readonly Parameters Parameters;
        private readonly UserSessionInformation _userSessionInformation;

        public ExternalService(Parameters parameters, UserSessionInformation userSessionInformation)
        {
            Parameters = parameters;
            url = Parameters.GetUrlAddress();
            _userSessionInformation = userSessionInformation;
        }

        public async Task<AddressResponseDto>? GetAddressCep(string cep)
        {

                AddressResponseDto _addressResponse = new();

                // Remove formatação do CEP (mantém apenas números)
                cep = cep.Replace("-", "").Replace(".", "").Trim();

                if (cep.Length != 8)
                    throw new ArgumentException("CEP deve conter 8 dígitos");

                string url = $"https://viacep.com.br/ws/{cep}/json/";

                try
                {

                    _addressResponse = await Http.GetFromJsonAsync<AddressResponseDto>(url);

                    return _addressResponse;
                }
                catch (Exception ex)
                {
                    throw ex;
                    return _addressResponse;
                }

        }
    }
}
