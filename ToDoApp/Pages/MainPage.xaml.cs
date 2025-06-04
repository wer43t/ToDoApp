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
using ToDoApp.Data;
using ToDoApp.Windows;

namespace ToDoApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<MyTask> Tasks { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Tasks = new List<MyTask>
            {
                new MyTask { Id = 1, Name = "Task 1", Description = "Description 1" },
                new MyTask { Id = 2, Name = "Task 2", Description = "Description 2" },
                new MyTask { Id = 3, Name = "Task 3", Description = "Description 3" }
            };


            this.DataContext = this;
        }

        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditTaskPage());
        }

        private void taskListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbTaskDetail.Text = (taskListView.SelectedItem as MyTask)?.Description;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            if (newTaskWindow.ShowDialog() == true)
            {
                string name = newTaskWindow.newName;
                string description = newTaskWindow.Description;
                MyTask newTask = new MyTask {Name = name, Description = description };
                Tasks.Add(newTask);
                taskListView.ItemsSource = null; 
                taskListView.ItemsSource = Tasks;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((taskListView.SelectedItem as MyTask)?.Id.ToString());
            foreach (var task in Tasks) {
                if(task.Id == (taskListView.SelectedItem as MyTask)?.Id)
                {
                    task.Description = tbTaskDetail.Text;
                }
            }

            taskListView.ItemsSource = Tasks;
            taskListView.Items.Refresh();



           // MyTask editedTask = Tasks.Where(x => x.Id == (taskListView.SelectedItem as MyTask)?.Id).FirstOrDefault();   
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MyTask taskForDelete = ((sender as Button).DataContext as MyTask);

            foreach (var task in Tasks) {
                if (task.Id == taskForDelete.Id) { 
                    Tasks.Remove(task);
                    break;
                }
            }
            taskListView.ItemsSource = Tasks;
            taskListView.Items.Refresh();
        }
    }
}
