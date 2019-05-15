using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lab3 : ContentPage
    {
        string faculty = "";
        string course = "";
        public Lab3()
        {
            InitializeComponent();
            facultyResult.Text = "Факультет ";
            courseResult.Text = "Курс ";
        }

        private void Faculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.faculty = faculties.SelectedItem.ToString();
            facultyResult.Text = "Факультет ";
            courseResult.Text = "Курс ";
        }

        private void Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.course = courses.SelectedItem.ToString();
        }
        //Pickers field
        private void OnSubmit(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(faculty))
            {
                DisplayAlert("Ви не обрали факультет", "Спочатку оберіть факультет", "Закрити");
                return;
            }
            if (string.IsNullOrEmpty(course))
            {
                DisplayAlert("Ви не обрали курс", "Спочатку оберіть курс", "Закрити");
                return;
            }
            facultyResult.Text = "Факультет " + faculty;
            courseResult.Text = "Курс "+ course;

            AddToDB();
        }
        private void OnCancel(object sender, EventArgs e)
        {
            faculty = "";
            course = "";

            faculties.SelectedIndexChanged -= Faculties_SelectedIndexChanged;
            courses.SelectedIndexChanged -= Courses_SelectedIndexChanged;

            faculties.SelectedIndex = -1;
            courses.SelectedIndex = -1;

            faculties.SelectedIndexChanged += Faculties_SelectedIndexChanged;
            courses.SelectedIndexChanged += Courses_SelectedIndexChanged;
        }
        //Text field
        private void OnClear(object sender, EventArgs e)
        {
            facultyResult.Text = "Факультет ";
            courseResult.Text = "Курс ";
        }
            
        private async void OnOpenDatabase(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Lab3DB());
        }
        private void AddToDB()
        {
            var result = App.Database.SaveItem(new Entities.StudentInfoEntity { Course = course, Faculty = faculty });
            string context = "Факультет: " + faculty + " Курс: " + course;
            DisplayAlert("Додавання до бази", result == 1 ? "Успішно" : "Не успішно :(", "Закрити");
        }
    }
}