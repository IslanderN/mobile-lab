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

using static Android.Views.View;

namespace Lab2.Droid
{
    public class ChoiceFragment : Fragment
    {
        int fChoosen = 0;
        int cChoosen = 0;
        List<string> facultiesList = new List<string>()
        {
            /*"--не обранно--",*/
            "ФІОТ",
            "ІПСА",
            "ФПМ"
        };
        List<string> coursesList = new List<string>()
        {
            /*"--не обранно--",*/"1","2","3","4","5","6"
        };

        IOnFragmentInteractionListener onFragmentInteractionListener;

        private Spinner facultySpinner = null;
        private Spinner coursesSpinner = null;

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);

            var listener = context as IOnFragmentInteractionListener;
            if (listener != null)
            {
                onFragmentInteractionListener = listener;
                onFragmentInteractionListener.noChoosen = facultiesList[0];
            }
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Create your fragment here

            //Spinner spinner = Activity.FindViewById<Spinner>(Resource.Id.spinner);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.ChoiceFragment, container, false);

            facultySpinner = view.FindViewById<Spinner>(Resource.Id.facultiesPicker);

            var facultyAdapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleSpinnerItem, facultiesList);
            facultyAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            facultySpinner.Adapter = facultyAdapter;
            facultySpinner.SetSelection(0);
            facultySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(faculty_ItemSelected);

            TextView facultyLael = view.FindViewById<TextView>(Resource.Id.facultiesLabel);
            facultyLael.Text = "Факультет:";

            TextView courseLabel = view.FindViewById<TextView>(Resource.Id.coursesLabel);
            courseLabel.Text = "Курс:";

            coursesSpinner = view.FindViewById<Spinner>(Resource.Id.coursesPicker);

            var courseAdapter = new ArrayAdapter(view.Context, Android.Resource.Layout.SimpleSpinnerItem, coursesList);
            courseAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            coursesSpinner.Adapter = courseAdapter;
            coursesSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(course_ItemSelected);
            coursesSpinner.SetSelection(0);


            Button choose = view.FindViewById<Button>(Resource.Id.choose);
            //var listener = view.oncli
            choose.Click += OnClickButton;


            return view;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void faculty_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = sender as Spinner;
            //var item = spinner?.GetItemAtPosition(e.Position);

            //if (!string.IsNullOrEmpty((string)item))
            //{
            //    onFragmentInteractionListener.OnFacultyChoosen((string)item);
            //}
            fChoosen = e.Position;



        }

        private void course_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = sender as Spinner;
            //var item = spinner?.GetItemAtPosition(e.Position);

            //if (!string.IsNullOrEmpty((string)item))
            //{
            //    onFragmentInteractionListener.OnCourseChoosen((string)item);
            //}
            cChoosen = e.Position;
        }

        private void OnClickButton(object sender, EventArgs e)
        {
            onFragmentInteractionListener.OnFacultyChoosen(facultiesList[fChoosen]);
            onFragmentInteractionListener.OnCourseChoosen(coursesList[cChoosen]);

            coursesSpinner.SetSelection(0);
            facultySpinner.SetSelection(0);
        }


        public interface IOnFragmentInteractionListener
        {
            string noChoosen { get; set; }

            void OnFacultyChoosen(string faculty);

            void OnCourseChoosen(string course);
        }
    }
}