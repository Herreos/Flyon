using Flyon.Api.ViewModels;

namespace Flyon.Api.Mappers
{
    public class UserToUserViewModelMapper
    {
        public static UserViewModel UserToUserViewModel(Domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                UserName = user.UserName,
                BirthDate = user.BirthDate,
                RegistrationDate = user.CreationDate,
                CurrentCountry = user.CurrentCountry,
                CurrentCity = user.CurrentCity,
                CurrentStreetName = user.CurrentStreetName,
                CurrentHouseNumber = user.CurrentHouseNumber,
                CurrentFlatNumber = user.CurrentFlatNumber,
                IsActiveUser = user.IsActiveUser,
                IsBannedUser = user.IsBannedUser,
                IconHref = user.IconHref,
            };
            return userViewModel;
        }

    }
}