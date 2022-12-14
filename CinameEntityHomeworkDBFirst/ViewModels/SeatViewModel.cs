
using CinameEntityHomeworkDBFirst;
using CinameEntityHomeworkDBFirst.Command;
using CinameEntityHomeworkDBFirst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using static CinameEntityHomeworkDBFirst.Domain.Entities.Seat;

namespace CinameEntityHomeworkDBFirst.ViewModel
{
    public class SeatViewModel : BaseViewModel
    {
        private Seat seat;

        public Seat Seat
        {
            get { return seat; }
            set { seat = value; OnPropertyChanged(); }
        }

        public RelayCommand SeatSelectCommand { get; set; }

        public SeatViewModel()
        {
            var seats = App.DB.SeatRepository.GetAll();
            foreach (var item in seats)
            {
                if (item.IsEmpty == true)
                {

                }
            }

            Seat = new Seat();
            SeatSelectCommand = new RelayCommand((e) =>
            {
                string no = Seat.No;
                var id=seat.Id;
                if (Seat.IsEmpty == false)
                {
                    Seat = new Seat
                    {
                        IsEmpty = true,
                        No = no
                    };
                    App.DB.SeatRepository.UpdateData(seat);
                }
                else if (Seat.IsEmpty == true)
                {
                    Seat = new Seat
                    {   

                        IsEmpty = false,
                        No = no
                    };
                    App.DB.SeatRepository.UpdateData(seat);
                }
            });
        }

    }
}
