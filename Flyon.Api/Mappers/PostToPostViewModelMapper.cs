using Flyon.Api.ViewModels;

namespace Flyon.Api.Mappers
{
    public class PostToPostViewModelMapper
    {
        public static PostViewModel PostToPostViewModel(Domain.Post.Post post)
        {
            var postViewModel = new PostViewModel
            {
                PostId = post.PostId,
                UserId = post.UserId,
                CreationDate = post.CreationDate,
                EditionDate = post.EditionDate,
                OfferCountry = post.OfferCountry,
                OfferCity = post.OfferCity,
                OfferDescription = post.OfferDescription,
                OfferCost = post.OfferCost,
                HotelName = post.HotelName,
                DeparturePlace = post.DeparturePlace,
                DateOfDeparture = post.DateOfDeparture,
                DateOfReturn = post.DateOfReturn,
                IsActivePost = post.IsActivePost,
                IsBannedPost = post.IsBannedPost,
                OfferPhotoHref = post.OfferPhotoHref
            };
            return postViewModel;
        }

    }
}