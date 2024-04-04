namespace Shop.Application.Interfaces;

public interface ISmsService
{
    Task SmsVerification(string mobile, string activeCode);
}