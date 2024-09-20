using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfEFTest.Data;

namespace WpfEFTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new SimulatorDbContext())
            {
                context.Database.EnsureCreated(); // 데이터베이스 및 테이블 생성
            }
        }
    }

}
