
using CinameEntityHomeworkDBFirst;
using CinameEntityHomeworkDBFirst.Command;
using CinameEntityHomeworkDBFirst.Domain.Entities;
using CinameEntityHomeworkDBFirst.Domain.Views.UserControls;
using CinameEntityHomeworkDBFirst.Model;
using CinameEntityHomeworkDBFirst.Repository;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CinemaProjectWpf.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo DataBase { get; set; }
        public ObservableCollection<MenuButtonClass> MenuButtons { get; set; }
        public MainWindow _mainWindow;

        public ObservableCollection<Movy> Movies { get; set; }

        public RelayCommand SearchMosueEnterCommand { get; set; }
        public RelayCommand SearchMosueLeaveCommand { get; set; }
        public RelayCommand SearchClickCommand { get; set; }
        public RelayCommand HollywoodCommand { get; set; }
        public RelayCommand NetflixCommand { get; set; }
        public RelayCommand BollywoodCommand { get; set; }
        public RelayCommand UniversalStudioCommand { get; set; }
        public RelayCommand PixarCommand { get; set; }
        public RelayCommand ViuCommand { get; set; }
        public RelayCommand DisneyCommand { get; set; }

        public AppViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            DataBase = new FakeRepo();
            MenuButtons = new ObservableCollection<MenuButtonClass>(DataBase.GetAllButton());

            AddMovie();
            AddMenuButoon();
            CheckSearchCommand();
            SearchClick();
            //AddMovieAbout(Movies);
            MovieCommand();

        }

        public void AddMenuButoon()
        {
            int count = 0;
            foreach (var item in MenuButtons)
            {
                MenuButtonUcViewModel menuButtonUcViewModel = new MenuButtonUcViewModel();

                menuButtonUcViewModel.MenuButton = item;
                MenuButtonUc menuButtonUc = new MenuButtonUc();
                menuButtonUc.DataContext = menuButtonUcViewModel;

                _mainWindow.menuButtonSp.Children.Add(menuButtonUc);
                count += 1;
                if (count == 4)
                {
                    Label label = new Label();
                    label.Content = "other";
                    label.Foreground = Brushes.LightGray;
                    label.Margin = new System.Windows.Thickness(35, 0, 0, 0);
                    label.FontStyle = FontStyles.Italic;
                    label.FontFamily = new FontFamily("Verdana");
                    _mainWindow.menuButtonSp.Children.Add(label);
                }
            }
        }
        public void AddMovie()
        {
            var m=from i in App.DB.MovieRepository.GetAll()
                  where i.Platform == null
                  select i;

            Movies = new ObservableCollection<Movy>(m);
            int count = 0;
            foreach (var item in Movies)
            {
                MovieCellViewModel view = new MovieCellViewModel();
                view.Movies = Movies.ToList();
                view.Movie = item;
                MovieCellUc uc = new MovieCellUc();
                uc.DataContext = view;

                if (count < 5)
                {
                    _mainWindow.filmWrap.Children.Add(uc);
                    count++;
                }
                else
                {
                    _mainWindow.filmWrap2.Children.Add(uc);
                }
            }

        }

        public void CheckSearchCommand()
        {
            SearchMosueEnterCommand = new RelayCommand((e) =>
            {
                if (_mainWindow.searchTb.Text == "Search...")
                    _mainWindow.searchTb.Text = String.Empty;
            });

            SearchMosueLeaveCommand = new RelayCommand((e) =>
            {
                if (_mainWindow.searchTb.Text == String.Empty)
                    _mainWindow.searchTb.Text = "Search...";
            });
        }

        public void SearchClick()
        {
            //SearchClickCommand = new RelayCommand((e) =>
            //{
            //    var movies = MovieService.GetMovies(_mainWindow.searchTb.Text);

            //    _mainWindow.filmWrap.Children.RemoveRange(0, 5);

            //    foreach (var m in movies)
            //    {
            //        var ucVm = new MovieCellViewModel
            //        {
            //            Movie = m,
            //        };

            //        var uc = new MovieCellUc();
            //        uc.DataContext = ucVm;

            //        _mainWindow.filmWrap.Children.Add(uc);
            //    }

            //});
        }

        //public void AddMovieAbout(ObservableCollection<Movie> m)
        //{
        //    //0,4,6
        //    int count = 0;
        //    foreach (var item in m)
        //    {
        //        MovieAboutUcViewModel view = new MovieAboutUcViewModel();
        //        view.Movie = item;
        //        MovieAboutUC uc = new MovieAboutUC();
        //        uc.DataContext = view;

        //        if (count == 0)
        //            _mainWindow.row1.Children.Add(uc);
        //        else if (count == 4)
        //            _mainWindow.row2.Children.Add(uc);
        //        else if (count == 6)
        //            _mainWindow.row3.Children.Add(uc);
        //        count++;
        //    }
        //}

        public void MovieCommand()
        {

            //HollywoodCommand = new RelayCommand((e) =>
            //  {
            //      DataBase = new FakeRepo();
            //      Movies = new ObservableCollection<Movie>(DataBase.GetAllHollywoodMovie());
            //      _mainWindow.filmWrap.Children.RemoveRange(0, 5);
            //      _mainWindow.filmWrap2.Children.RemoveRange(0, 5);
            //      int count = 0;

            //      foreach (var item in Movies)
            //      {
            //          var view = new MovieCellViewModel
            //          {
            //              Movie = item
            //          };
            //          var uc = new MovieCellUc();
            //          uc.DataContext = view;

            //          if (count < 5)
            //          {
            //              _mainWindow.filmWrap.Children.Add(uc);
            //              count++;
            //          }
            //          else
            //          {
            //              _mainWindow.filmWrap2.Children.Add(uc);
            //          }
            //      }
            //  });


            //DisneyCommand = new RelayCommand((e) =>
            //{
            //    DataBase = new FakeRepo();
            //    Movies = new ObservableCollection<Movie>(DataBase.GetAllDisneyMovie());

            //    _mainWindow.filmWrap.Children.RemoveRange(0, 5);
            //    _mainWindow.filmWrap2.Children.RemoveRange(0, 5);
            //    int count = 0;

            //    foreach (var item in Movies)
            //    {
            //        var view = new MovieCellViewModel
            //        {
            //            Movie = item
            //        };
            //        var uc = new MovieCellUc();
            //        uc.DataContext = view;

            //        if (count < 5)
            //        {
            //            _mainWindow.filmWrap.Children.Add(uc);
            //            count++;
            //        }
            //        else
            //        {
            //            _mainWindow.filmWrap2.Children.Add(uc);
            //        }
            //    }
            //});
        }


    }
}
