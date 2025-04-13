using FarmIt.Models.DTO;

namespace FarmIt.Respositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(Login model);

        Task LogoutAsync();
        Task<Status> RegisterAsync(Registration model);
        //Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
    }
}
