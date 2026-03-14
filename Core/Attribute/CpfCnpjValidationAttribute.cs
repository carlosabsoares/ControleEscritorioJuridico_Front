using CEJ_WebApp.Model;
using CEJ_WebApp.Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

public class CpfCnpjValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var client = (ClientEntity)validationContext.ObjectInstance;
        var document = value?.ToString()?.Replace(".", "").Replace("-", "").Replace("/", "");

        if (string.IsNullOrEmpty(document))
            return new ValidationResult("Documento é obrigatório");

        if (client.DocumentType == DocumentType.CPF)
        {
            if (!IsValidCpf(document))
                return new ValidationResult("CPF inválido");
        }
        else
        {
            if (!IsValidCnpj(document))
                return new ValidationResult("CNPJ inválido");
        }

        return ValidationResult.Success;
    }

    private bool IsValidCpf(string cpf)
    {
        if (cpf.Length != 11) return false;

        if (new string(cpf[0], 11) == cpf) return false;

        int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        var tempCpf = cpf.Substring(0, 9);
        int sum = 0;

        for (int i = 0; i < 9; i++)
            sum += int.Parse(tempCpf[i].ToString()) * mult1[i];

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        string digit = remainder.ToString();
        tempCpf += digit;

        sum = 0;

        for (int i = 0; i < 10; i++)
            sum += int.Parse(tempCpf[i].ToString()) * mult2[i];

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        digit += remainder.ToString();

        return cpf.EndsWith(digit);
    }

    private bool IsValidCnpj(string cnpj)
    {
        if (cnpj.Length != 14) return false;

        int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        var temp = cnpj.Substring(0, 12);
        int sum = 0;

        for (int i = 0; i < 12; i++)
            sum += int.Parse(temp[i].ToString()) * mult1[i];

        int remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        string digit = remainder.ToString();
        temp += digit;

        sum = 0;

        for (int i = 0; i < 13; i++)
            sum += int.Parse(temp[i].ToString()) * mult2[i];

        remainder = sum % 11;
        remainder = remainder < 2 ? 0 : 11 - remainder;

        digit += remainder.ToString();

        return cnpj.EndsWith(digit);
    }
}