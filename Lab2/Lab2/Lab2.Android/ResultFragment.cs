using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Lab2.Droid
{
    public class ResultFragment : Fragment
    {



        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ResultFragment, container, false);


            Button result = view.FindViewById<Button>(Resource.Id.result);
            result.Click += OnResultClick;

            return view;
        }

        public void SetFaculty(string faculty)
        {
            TextView resultFaculty = View.FindViewById<TextView>(Resource.Id.facultyResult);
            if (resultFaculty != null)
            {
                resultFaculty.Text = faculty;
            }
        }

        public void SetCourse(string course)
        {
            TextView resultCourse = View.FindViewById<TextView>(Resource.Id.courseResult);
            if (resultCourse != null)
            {
                resultCourse.Text = course;
            }
        }

        private void OnResultClick(object sender, EventArgs e)
        {
            TextView resultFaculty = View.FindViewById<TextView>(Resource.Id.facultyResult);
            TextView resultCourse = View.FindViewById<TextView>(Resource.Id.courseResult);
            resultFaculty.Text = "";
            resultCourse.Text = "";
        }
    }
}