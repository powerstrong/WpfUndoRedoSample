using Microsoft.EntityFrameworkCore;
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
        private UndoManager _undoManager = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_ClearAll(object sender, RoutedEventArgs e)
        {
            //_context.JointAngles.RemoveRange(_context.JointAngles);
            //_context.PrimitiveObjects.RemoveRange(_context.PrimitiveObjects);
            //_context.SaveChanges();

            //// reset key index
            //_context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name = 'JointAngles';");
            //_context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name = 'PrimitiveObjects';");

            //_context.Database.ExecuteSqlRaw("VACUUM;");
        }

        private void Button_Click_AddJointAngle(object sender, RoutedEventArgs e)
        {
            var data = new JointAngle(1, 2, 3, 4, 5, 6);
            var command = new AddCommand<JointAngle>(_context, data);
            _undoManager.Execute(command);
        }

        private void Button_Click_AddPrimitiveObject(object sender, RoutedEventArgs e)
        {
            var data = new PrimitiveObject("name", "type");
            var command = new AddCommand<PrimitiveObject>(_context, data);
            _undoManager.Execute(command);
        }

        private void Button_Click_AddTwoData(object sender, RoutedEventArgs e)
        {
            var dataAngle = new JointAngle(2, 3, 4, 5, 6, 7);
            var commandAngle = new AddCommand<JointAngle>(_context, dataAngle);

            var dataObject = new PrimitiveObject("name2", "type2");
            var commandObject = new AddCommand<PrimitiveObject>(_context, dataObject);

            var CompositeCommand = new TransactionalCompositeCommand(_context);
            CompositeCommand.AddCommand(commandAngle);
            CompositeCommand.AddCommand(commandObject);

            _undoManager.Execute(CompositeCommand);
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
        
        private void Button_Click_Undo(object sender, RoutedEventArgs e)
        {
            _undoManager.Undo();
        }

        private void Button_Click_Redo(object sender, RoutedEventArgs e)
        {
            _undoManager.Redo();
        }
    }
}