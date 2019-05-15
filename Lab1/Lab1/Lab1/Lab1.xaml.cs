using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lab1 : ContentPage
    {

        string faculty = "";
        string course = "";

        public Lab1()
        {
            InitializeComponent();
        }

        private void Faculties_SelectedIndexChanged(object sender, EventArgs e)
        {
            faculty = faculties.SelectedItem.ToString();
        }

        private void Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            course = courses.SelectedItem.ToString();
        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(faculty))
            {
                DisplayAlert("Ви не обрали факультет", "Спочатку оберіть факультет", "Закрти");
                return;
            }
            if (string.IsNullOrEmpty(course))
            {
                DisplayAlert("Ви не обрали курс", "Спочатку оберіть курс", "Закрти");
                return;
            }

            string context = "Факультет: " + faculty + "\nКурс: " + course;

            DisplayAlert("Ви обрали", context, "Закрити");
        }

        private void Cance_Clicked(object sender, EventArgs e)
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
    }
}