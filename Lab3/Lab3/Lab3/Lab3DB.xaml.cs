using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab3.Entities;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lab3DB : ContentPage
    {
        public List<StudentInfoEntity> Students;
        public Lab3DB()
        {
            //InitializeComponent();
            Init();
        }
        private void Init()
        {
            Students = (List<StudentInfoEntity>)App.Database.GetItems();

            if (Students.Count == 0)
            {
                Label dbEmpty = new Label
                {
                    Text = "Дані ще не було додано",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                this.Content = dbEmpty;
            }
            else
            {
                //this.BindingContext = this;

                ListView listView = new ListView
                {
                    HasUnevenRows = true,
                    ItemsSource = Students,

                    ItemTemplate = new DataTemplate(() =>
                    {
                        Label facultyLabel = new Label { FontSize = 25 };
                        facultyLabel.SetBinding(Label.TextProperty, "Faculty");

                        Label courseLabel = new Label { FontSize = 25 };
                        courseLabel.SetBinding(Label.TextProperty, "Course");

                        return new ViewCell
                        {
                            View = new StackLayout
                            {
                                Padding = new Thickness(5, 5),
                                Orientation = StackOrientation.Vertical,
                                Children = { facultyLabel, courseLabel }
                            }
                        };
                    })
                };

                Button delete = new Button
                {
                    Text = "Очистити базу",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.End,
                    Padding = new Thickness(10)
                };
                delete.Clicked += (sender, e) =>
                {
                    int result = App.Database.Delete();
                    DisplayAlert("Результат", result > 0 ? "Успішно" : "Не успішно :(", "Закрити");
                    Init();
                };

                this.Content = new StackLayout { Children = { listView, delete } };
            }
        }
    }
}