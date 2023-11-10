using Rest.Web.Model;
using System.Collections.Generic;

namespace Rest.Web.Interfaces
{
    public interface ISavedViewsService
    {
        List<SavedView> GetAllSavedViews();
    }
}