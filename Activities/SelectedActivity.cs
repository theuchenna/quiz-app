
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Quiz_App.DataModels;

namespace Quiz_App.Activities
{
    [Activity(Label = "@string/app_name", Theme ="@style/AppTheme")]
    public class SelectedActivity : AppCompatActivity
    {
        // Views
        TextView quizTopicText;
        TextView descriptionText;
        Button startQuizButton;
        ImageView quizImage;

        // Variables
        string quizTopic;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.selected_topic);
            ConnectViews();
        }

        void ConnectViews()
        {
            quizTopicText = (TextView)FindViewById(Resource.Id.quizTopicText);
            descriptionText = (TextView)FindViewById(Resource.Id.quizDescriptionText);
            quizImage = (ImageView)FindViewById(Resource.Id.quizImage);
            startQuizButton = (Button)FindViewById(Resource.Id.startQuizButton);

            quizTopic = Intent.GetStringExtra("topic");
            quizTopicText.Text = quizTopic;

            QuizHelper quizHelper = new QuizHelper();
            descriptionText.Text = quizHelper.GetTopicDescription(quizTopic);

            startQuizButton.Click += StartQuizButton_Click;
        }

        void StartQuizButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(QuizActivity));
            intent.PutExtra("topic", quizTopic);
            this.Finish();
            StartActivity(intent);
        }

    }
}
