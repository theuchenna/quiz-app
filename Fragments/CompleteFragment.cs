
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
    public class CompleteFragment : Android.Support.V4.App.DialogFragment
    {
        string remarks, score, image;

        ImageView thisImage;
        TextView remarksText;
        TextView scoreText;
        Button goHomeButton;

        public event EventHandler GoHome;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public CompleteFragment(string mRemarks, string mScore, string mImage)
        {
            remarks = mRemarks;
            score = mScore;
            image = mImage;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.completed, container, false);

            thisImage = (ImageView)view.FindViewById(Resource.Id.image);
            remarksText = (TextView)view.FindViewById(Resource.Id.remarksText);
            scoreText = (TextView)view.FindViewById(Resource.Id.scoreText);
            goHomeButton = (Button)view.FindViewById(Resource.Id.goHomeButton);

            if(image == "failed")
            {
                thisImage.SetImageResource(Resource.Drawable.sad);
            }

            remarksText.Text = remarks;
            scoreText.Text = score;
            goHomeButton.Click += GoHomeButton_Click;

            return view;
        }

        void GoHomeButton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            GoHome?.Invoke(this, new EventArgs());
        }

    }
}
