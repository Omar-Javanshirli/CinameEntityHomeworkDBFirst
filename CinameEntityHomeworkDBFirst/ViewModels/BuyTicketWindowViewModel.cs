using CinameEntityHomeworkDBFirst;
using CinameEntityHomeworkDBFirst.Command;
using CinameEntityHomeworkDBFirst.Domain.Entities;
using CinameEntityHomeworkDBFirst.Domain.Service;
using CinameEntityHomeworkDBFirst.Domain.Views.UserControls;
using CinemaPCinameEntityHomeworkDBFirstrojectWpf.Domain.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace CinameEntityHomeworkDBFirst.ViewModel
{
    public class BuyTicketWindowViewModel : BaseViewModel
    {
        private readonly LocationService _locationService;
        private readonly MovieDateService _dateService;
        private readonly TimeService _timeService;

        public Movy Movie { get; set; } = new Movy();
        public MovieDate MovieDates { get; set; }
        public RelayCommand RowButoonCommand { get; set; }
        public RelayCommand CheckOutCommand { get; set; }
        public RelayCommand CinemaSelectedCommand { get; set; }
        public RelayCommand DateSelectedCommand { get; set; }
        public RelayCommand TimeSelectedCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public ObservableCollection<Location> Locations { get; set; }

        private ObservableCollection<MovieDate> movieDatess;

        public ObservableCollection<MovieDate> MovieDatess
        {
            get { return movieDatess; }
            set { movieDatess = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Seat> seats;

        public ObservableCollection<Seat> Seats
        {
            get { return seats; }
            set { seats = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> dates;

        public ObservableCollection<string> Dates
        {
            get { return dates; }
            set { dates = value; OnPropertyChanged(); }
        }

        private ObservableCollection<string> movieTimes;
                
        public ObservableCollection<string> MovieTimes
        {
            get { return movieTimes; }
            set { movieTimes = value; OnPropertyChanged(); }
        }


        public List<MovieDate> listMovieDate { get; set; }
        private ObservableCollection<Time> times;

        public ObservableCollection<Time> Times
        {
            get { return times; }
            set { times = value; OnPropertyChanged(); }
        }

        public List<string> SerialNumber { get; set; } = new List<string>();

        public int Count { get; set; } = 0;

        private string ticketNumber;

        public string TicketNumber
        {
            get { return ticketNumber; }
            set { ticketNumber = value; OnPropertyChanged(); }
        }

        public List<Movy> Movies { get; set; }


        public BuyTicketWindowViewModel()
        {
            _locationService = new LocationService();
            _dateService = new MovieDateService();
            _timeService = new TimeService();
            LocationSelected();
            DateSelected();
            TimeSelected();
            RowButton();
            CheckOut();
        }

        public async Task LocationSelected()
        {
            CinemaSelectedCommand = new RelayCommand((e) =>
            {
                Locations = new ObservableCollection<Location>(Movie.Locations);
                listMovieDate = new List<MovieDate>();
                Dates = new ObservableCollection<string>();
                foreach (var item in Locations)
                {
                    var data = _locationService.GetMovieDates(item.Id);
                    foreach (var d in data.MovieDates)
                    {
                        listMovieDate.Add(d);
                        Dates.Add(d.DateName);
                    }
                    break;
                }
                MovieDatess = new ObservableCollection<MovieDate>(listMovieDate);
            });
        }
        public async void DateSelected()
        {
            DateSelectedCommand = new RelayCommand((e) =>
            {
                Times = new ObservableCollection<Time>();
                MovieTimes = new ObservableCollection<string>();
                foreach (var item in MovieDatess)
                {
                    var data = _dateService.GetTimeDate(item.Id);
                    foreach (var t in data.Times)
                    {
                        Times.Add(t);
                        MovieTimes.Add(t.Time1);
                    }
                    break;
                }
            });
        }
        public void RowButton()
        {
            RowButoonCommand = new RelayCommand((e) =>
            {
                Count++;
                var btn = e as Button;
                var button = GetButton(btn);

                if (button.Background != Brushes.LightSeaGreen)
                    button.Background = Brushes.LightSeaGreen;

                else
                    button.Background = Brushes.Transparent;

                SerialNumber.Add(button.Content.ToString());
            });
        }
        public void TimeSelected()
        {
            var data2 = from i in App.DB.SeatRepository.GetAll()
                       select i;
            var list= data2.ToList();
            TimeSelectedCommand = new RelayCommand((t) =>
            {
                int count = 0;
                foreach (var item in Times)
                {
                    var data = _timeService.GetDataSeat(item.Id);
                    for (int i = 0; i < data.Seats.Count; i++)
                    {
                        ++count;
                        var vm = new SeatViewModel();
                        var uc = new SeatUC();
                        uc.DataContext = vm;
                        vm.Seat.No = list[i+1].No;
                        App.MyUniformGrid.Children.Add(uc);
                    }
                    break;
                }
            });
        }
        public Button GetButton(Button button)
        {
            var uniform = button.Parent as UniformGrid;

            foreach (var item in uniform.Children)
            {
                if (item is Button bt)
                {
                    if (bt.Content == button.Content)
                        return bt;
                }
            }
            return null;
        }
        public void CheckOut()
        {

            //CheckOutCommand = new RelayCommand((e) =>
            //{
            //    TicketNumber = Count.ToString() + " Ticket" + " Row:";

            //    foreach (var item in SerialNumber)
            //    {
            //        TicketNumber += item + "/";
            //    }
            //    FileHelper.WriteMovie(Movies.ToList());
            //});
        }
        public void BackButton()
        {
            BackCommand = new RelayCommand((e) =>
            {

            });
        }
    }
}
