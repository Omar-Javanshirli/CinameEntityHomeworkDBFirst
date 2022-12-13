
using CinameEntityHomeworkDBFirst;
using CinameEntityHomeworkDBFirst.Command;
using CinameEntityHomeworkDBFirst.Domain.Entities;
using CinameEntityHomeworkDBFirst.Domain.Views;
using CinameEntityHomeworkDBFirst.ViewModel;
using System.Collections.Generic;

namespace CinameEntityHomeworkDBFirst.ViewModel
{
    public class MovieCellViewModel:BaseViewModel
    {
        public Movy Movie { get; set; }
        public RelayCommand BuyCommand { get; set; }
        public List<Movy> Movies { get; set; }

        public Movy SelectedItem { get; set; }

        public MovieCellViewModel()
        {
            Movie=new Movy();

            BuyCommand = new RelayCommand((e) =>
            {
                SelectedItem = App.DB.MovieRepository.Getdata(Movie.Id);
                var view = new BuyTicketWindowViewModel();
                var window = new BuyTicketWindow();
                window.DataContext = view;
                view.Movie = SelectedItem;
                view.Movies = Movies;
                window.Show();

            });
        }
    }
}
