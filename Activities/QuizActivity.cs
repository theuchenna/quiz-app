
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Quiz_App.DataModels;
using Quiz_App.Fragments;

namespace Quiz_App.Activities
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : AppCompatActivity
    {
        Android.Support.V7.Widget.Toolbar toolbar;

        // Radio Buttons
        RadioButton optionARadio, optionBRadio, optionCRadio, optionDRadio;

        // TextViews
        TextView optionAText, optionBText, optionCText, optionDText, questionText, quizPositionText, timeCounterText;

        // Button 
        Button proceedQuizButton;
        CoordinatorLayout rootView;

        // Variable
        List<Question> quizQuestionsList;
        QuizHelper quizHelper = new QuizHelper();

        string quizTopic;
        int quizPosition;
        int correctAnswerCount;
        int timeCounter = 0;

        DateTime dateTime;
        System.Timers.Timer coundown = new System.Timers.Timer();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.quiz_page);

            quizTopic = Intent.GetStringExtra("topic");

            toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = quizTopic + " Quiz";

            Android.Support.V7.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Mipmap.ic_action_arrow_back);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            ConnectViews();
            BeginQuiz();

            coundown.Interval = 1000;
            coundown.Elapsed += Coundown_Elapsed;
        }

        void Coundown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timeCounter++;
            DateTime dt = new DateTime();
            dt = dateTime.AddSeconds(-1);

            var dateDifference = dateTime.Subtract(dt);
            dateTime = dateTime - dateDifference;


            RunOnUiThread(() =>
            {
                timeCounterText.Text = dateTime.ToString("mm:ss");
            });

            // End Quiz on Timeout
            if (timeCounter == 120)
            {
                coundown.Enabled = false;
                CompleteQuiz();
            }
        }


        void ConnectViews()
        {
            // RadioButtons
            optionARadio = (RadioButton)FindViewById(Resource.Id.optionARadio);
            optionBRadio = (RadioButton)FindViewById(Resource.Id.optionBRadio);
            optionCRadio = (RadioButton)FindViewById(Resource.Id.optionCRadio);
            optionDRadio = (RadioButton)FindViewById(Resource.Id.optionDRadio);

            optionARadio.Click += OptionARadio_Click;
            optionBRadio.Click += OptionBRadio_Click;
            optionCRadio.Click += OptionCRadio_Click;
            optionDRadio.Click += OptionDRadio_Click;

            // TextViews
            optionAText = (TextView)FindViewById(Resource.Id.optionAText);
            optionBText = (TextView)FindViewById(Resource.Id.optionBText);
            optionCText = (TextView)FindViewById(Resource.Id.optionCText);
            optionDText = (TextView)FindViewById(Resource.Id.optionDText);
            questionText = (TextView)FindViewById(Resource.Id.questionText);
            quizPositionText = (TextView)FindViewById(Resource.Id.quizPositionText);
            timeCounterText = (TextView)FindViewById(Resource.Id.timeCounterText);


            // Button
            proceedQuizButton = (Button)FindViewById(Resource.Id.proceedQuizButton);
            proceedQuizButton.Click += CheckAnswerButton_Click;

            // Views
            rootView = (CoordinatorLayout)FindViewById(Resource.Id.rootView);
                 
        }

        public void BeginQuiz()
        {
            quizPosition = 1;
            quizQuestionsList = quizHelper.GetQuizQuestions(quizTopic);
            questionText.Text = quizQuestionsList[0].QuizQuestion;
            optionAText.Text = quizQuestionsList[0].OptionA;
            optionBText.Text = quizQuestionsList[0].OptionB;
            optionCText.Text = quizQuestionsList[0].OptionC;
            optionDText.Text = quizQuestionsList[0].optionD;

            quizPositionText.Text = "Question  " + quizPosition.ToString() + "/" + quizQuestionsList.Count.ToString();

            dateTime = new DateTime();
            dateTime = dateTime.AddMinutes(2);
            timeCounterText.Text = dateTime.ToString("mm:ss");

            coundown.Enabled = true;

        }

        // Radio Button Click Event handlers
        void OptionARadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelection();
            optionARadio.Checked = true;
        }

        void OptionBRadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelection();
            optionBRadio.Checked = true;
        }

        void OptionCRadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelection();
            optionCRadio.Checked = true;
        }

        void OptionDRadio_Click(object sender, EventArgs e)
        {
            ClearOptionSelection();
            optionDRadio.Checked = true;
        }

        void CheckAnswerButton_Click(object sender, EventArgs e)
        {


            if(!optionARadio.Checked && !optionBRadio.Checked && !optionCRadio.Checked && !optionDRadio.Checked)
            {
                Snackbar.Make(rootView, "Please choose your answer!!", Snackbar.LengthShort).Show();
            }

            // Checks for Correct Answer A
            else if (optionARadio.Checked)
            {
                if(optionAText.Text == quizQuestionsList[quizPosition - 1].Answer)
                {
                    CorrectAnswer();
                }
                else
                {
                    Incorrect();
                }
            }

            // Checks for Correct Answer B
            else if (optionBRadio.Checked)
            {
                if (optionBText.Text == quizQuestionsList[quizPosition - 1].Answer)
                {
                    CorrectAnswer();
                }
                else
                {
                    Incorrect();
                }
            }

            // Checks for Correct Answer C
            else if (optionCRadio.Checked)
            {
                if (optionCText.Text == quizQuestionsList[quizPosition - 1].Answer)
                {
                    CorrectAnswer();
                }
                else
                {
                    Incorrect();
                }
            }

            // Checks for Correct Answer D
            else if (optionDRadio.Checked)
            {
                if (optionDText.Text == quizQuestionsList[quizPosition - 1].Answer)
                {
                    CorrectAnswer();
                }
                else
                {
                    Incorrect();
                }
            }

           
        }

        void CorrectAnswer()
        {
            correctAnswerCount++;
            CorrectFragment correctFragment = new CorrectFragment();
            var trans1 = SupportFragmentManager.BeginTransaction();
            correctFragment.Cancelable = false;
            correctFragment.Show(trans1, "correct");
            correctFragment.NextQuestion += (sender, e) => 
            {
                NextQuestion();
            };

        }

        void Incorrect()
        {
            IncorrectFragment incorrectFragment = new IncorrectFragment(quizQuestionsList[quizPosition - 1].Answer);
            var trans = SupportFragmentManager.BeginTransaction();
            incorrectFragment.Cancelable = false;
            incorrectFragment.Show(trans, "incorrect");
            incorrectFragment.NextQuestion += (sender, e) => 
            {
                NextQuestion();
            };
        }

        void NextQuestion()
        {
            quizPosition++;

            if(quizPosition > quizQuestionsList.Count)
            {
                CompleteQuiz();
                return;
            }

            int indx = quizPosition - 1;

            ClearOptionSelection();

            questionText.Text = quizQuestionsList[indx].QuizQuestion;
            optionAText.Text = quizQuestionsList[indx].OptionA;
            optionBText.Text = quizQuestionsList[indx].OptionB;
            optionCText.Text = quizQuestionsList[indx].OptionC;
            optionDText.Text = quizQuestionsList[indx].optionD;

            quizPositionText.Text = "Question  " + quizPosition.ToString() + "/" + quizQuestionsList.Count.ToString();

        }


        void ClearOptionSelection()
        {
            optionARadio.Checked = false;
            optionBRadio.Checked = false;
            optionCRadio.Checked = false;
            optionDRadio.Checked = false;

        }

        void CompleteQuiz()
        {
            coundown.Enabled = false;
            timeCounterText.Text = "00:00";

            string score = correctAnswerCount.ToString() + "/" + quizQuestionsList.Count.ToString();
            double percentage = correctAnswerCount / quizQuestionsList.Count;
            string remarks = "";
            string image = "pass";

            if (percentage > 50 && percentage < 80)
            {
                remarks = "Very Good result, you\nReally tried";
            }
            else if (percentage == 50)
            {
                remarks = "You really made it,\nAverage result";
            }
            else if (percentage < 50)
            {
                remarks = "So sad you didn't make it, \nBut you can try again";
                image = "failed";
            }

            CompleteFragment completeFragment = new CompleteFragment(remarks, score, image);
            completeFragment.Cancelable = false;
            var trans = SupportFragmentManager.BeginTransaction();
            completeFragment.Show(trans, "completefragment");
            completeFragment.GoHome += (sender, e) => 
            {
                this.Finish();
            };

        }
    }
}
