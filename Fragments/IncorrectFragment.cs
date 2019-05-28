﻿
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

namespace Quiz_App.Fragments
{
    public class IncorrectFragment : Android.Support.V4.App.DialogFragment
    {
        string correctAnswer;
        TextView correctAnswerText;
        Button nextButton;

        public event EventHandler NextQuestion;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public IncorrectFragment(string answer)
        {
            correctAnswer = answer;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View view = inflater.Inflate(Resource.Layout.wrong, container, false);

            correctAnswerText = (TextView)view.FindViewById(Resource.Id.correctAnswerText);
            correctAnswerText.Text = correctAnswer;

            nextButton = (Button)view.FindViewById(Resource.Id.nextButton);
            nextButton.Click += NextButton_Click;

            return view;
        }

        void NextButton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            NextQuestion?.Invoke(this, new EventArgs());
        }

    }
}
