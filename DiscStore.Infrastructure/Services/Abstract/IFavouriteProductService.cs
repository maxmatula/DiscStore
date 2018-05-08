using DiscStore.Infrastructure.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscStore.Infrastructure.Services.Abstract
{
    public interface IFavouriteProductService
    {
        bool AddToFavourites(Guid productId, string userId);
        bool RemoveFromFavourites(Guid favouriteId);
        List<ProductViewModel> FavouritesProductList(string userId);
    }
}