using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfEFTest.Data;
using WpfEFTest.Models;

namespace WpfEFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SimulatorDbContext _context = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_AddJointAngle(object sender, RoutedEventArgs e)
        {
            _context.JointAngles.Add(new JointAngle(1,2,3,4,5,6));
            _context.SaveChanges();
        }

        private void Button_Click_AddPrimitiveObject(object sender, RoutedEventArgs e)
        {
            _context.PrimitiveObjects.Add(new PrimitiveObject("name", "type"));
            _context.SaveChanges();
        }

        private void Button_Click_ShowJointAngleList(object sender, RoutedEventArgs e)
        {
            var list = _context.JointAngles.ToList();
            // messagebox 한방에 출력
            StringBuilder sb = new();
            foreach (var angle in list) {
                sb.Append($"id : {angle.Id}, value : {angle.J1}, {angle.J2}, {angle.J3}, {angle.J4}, {angle.J5}, {angle.J6}");
                sb.Append("\n");
            }

            MessageBox.Show(sb.ToString());
        }

        private void Button_Click_ShowPrimitiveObjectList(object sender, RoutedEventArgs e)
        {
            var list = _context.PrimitiveObjects.ToList();
            // messagebox 한방에 출력
            StringBuilder sb = new();
            foreach (var angle in list)
            {
                sb.Append($"id : {angle.Id}, value : {angle.Name}, {angle.Type}");
                sb.Append("\n");
            }

            MessageBox.Show(sb.ToString());
        }
    }
}