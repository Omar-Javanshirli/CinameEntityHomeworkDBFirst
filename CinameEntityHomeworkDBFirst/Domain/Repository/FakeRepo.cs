using CinameEntityHomeworkDBFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CinameEntityHomeworkDBFirst.Repository
{
    public class FakeRepo
    {
        public List<MenuButtonClass> GetAllButton()
        {
            return new List<MenuButtonClass>
            {
                new MenuButtonClass
                {
                    Image="/Image/Home.png",
                    Text="Home"
                },

                new MenuButtonClass
                {
                    Image="/Image/favorite.png",
                    Text="Favorite"
                },

                new MenuButtonClass
                {
                    Image="/Image/purchase.png",
                    Text="Purchase"
                },
                new MenuButtonClass
                {
                    Image="/Image/reminder2.png",
                    Text="Reminder"
                },
                new MenuButtonClass
                {
                    Image="/Image/playlist.png",
                    Text="Palylist"
                },
                new MenuButtonClass
                {
                    Image="/Image/live.png",
                    Text="Live"
                },
                new MenuButtonClass
                {
                    Image="/Image/bookmarks.png",
                    Text="Bookmarks"
                },
                new MenuButtonClass
                {
                    Image="/Image/setting.png",
                    Text="Setting"
                }
            };
        }
    }
}
