using dotNetCoreWPF_Project.Context;
using dotNetCoreWPF_Project.Models;
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

namespace dotNetCoreWPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Employee> Employees { get; set; }
        public MainWindow()
        {
            var db = new MyContext();
            //make ensure that bank has created!!
            db.Database.EnsureCreated();
            if (db.Employees?.Count() == 0)
            {
                Employee employee = new Employee()
                {
                    Name="mohammadHossein",
                    Age=21
                };
                db.Employees.Add(employee);

                Employee employee1 = new Employee()
                {
                    Name = "Ahmad",
                    Age = 32
                };
                db.Employees.Add(employee1);

                Employee employee2 = new Employee()
                {
                    Name = "Shayan",
                    Age = 25
                };
                db.Employees.Add(employee2);
                db.SaveChanges();
            }
            Employees = db.Employees.ToList();
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
