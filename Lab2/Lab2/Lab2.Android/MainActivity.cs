using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Lab2.Droid;

namespace Lab2.Droid
{
    [Activity(Label = "Lab2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity, ChoiceFragment.IOnFragmentInteractionListener /*global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity*/
    {
        public string noChoosen { get; set; }

        public void OnCourseChoosen(string course)
        {
            if (string.Equals(course, noChoosen))
            {
                course = string.Empty;
            }
            var resultFragment = FragmentManager.FindFragmentById(Resource.Id.result_fragment) as ResultFragment;
            if (resultFragment != null)
            {

                resultFragment.SetCourse(course);
            }
        }

        public void OnFacultyChoosen(string facullty)
        {
            if (string.Equals(facullty, noChoosen))
            {
                facullty = string.Empty;
            }
            var resultFragment = FragmentManager.FindFragmentById(Resource.Id.result_fragment) as ResultFragment;
            if (resultFragment != null)
            {
                resultFragment.SetFaculty(facullty);
            }
        }


        TextView course, faculty;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //LoadApplication(new App());

            SetContentView(Resource.Layout.Lab2Layout);
        }
    }
}