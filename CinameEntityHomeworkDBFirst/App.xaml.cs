using CinameEntityHomeworkDBFirst.Domain.Entities;
using CinemaProjectWpf.DataAccess.EFrameworkServer;
using CinemaProjectWpf.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace CinameEntityHomeworkDBFirst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public static UniformGrid MyUniformGrid;
        public static Button SelectedBtn;
        public App()
        {
            DB = new EFUnitWork();
            using (var context = new CinemaPlusEntities())
            {
                try
                {
                    context.Database.CreateIfNotExists();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
