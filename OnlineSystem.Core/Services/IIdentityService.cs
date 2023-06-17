using OnlineSystem.Core.Entities;

namespace OnlineSystem.Core.Services;

public interface IIdentityService
{
    string GetToken(User user);
}