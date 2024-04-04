using Kavenegar;
using Shop.Application.Interfaces;

namespace Shop.Application.Services;

public class SmsService : ISmsService
{
    private string apiKey = ""; 
    public async Task SmsVerification(string mobile, string activeCode)
    {
        Kavenegar.KavenegarApi api = new KavenegarApi(apiKey);
        await api.VerifyLookup(mobile, activeCode, "");
    }
}