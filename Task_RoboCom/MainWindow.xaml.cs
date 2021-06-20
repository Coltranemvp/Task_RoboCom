using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;


namespace Task_RoboCom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> rooud = new List<string>();
            var files = Directory.GetFiles($"{box.Text}", "*.*", SearchOption.AllDirectories)
           .Where(s => s.EndsWith(".dll"));
            foreach (string t in files)
            {
                rooud.Add(t);
            }
            box1.Clear();
            foreach (string t in rooud)
            {
                box1.Text += t+ Environment.NewLine;
                foreach (Type type in GetTypes(Assembly.LoadFile(t))) 
                {
                    box1.Text += type.Name+ Environment.NewLine;
                    foreach (MemberInfo mi in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    {
                        box1.Text += $"{mi.MemberType} {mi.Name}"+ Environment.NewLine;
                    }
                }
                box1.Text += Environment.NewLine+Environment.NewLine;
            }
        }


        public IEnumerable<Type> GetTypes( Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null);
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }

}
