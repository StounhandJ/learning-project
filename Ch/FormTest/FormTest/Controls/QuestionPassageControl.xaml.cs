using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FormTest.Enums;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class QuestionPassageControl : UserControl
    {
        private Question _question;

        public Question Question
        {
            get { return _question; }
            set
            {
                hidenAll();
                this.OneFromListCollection = new ObservableCollection<AnswerDisplay>();
                this.FewFromListCollection = new ObservableCollection<AnswerDisplay>();
                QuestionTextBlock.Text = value.question;
                switch (value.TypeOfQuestion)
                {
                    case TypeOfQuestion.Line:
                        LineTextBox.Visibility = Visibility.Visible;
                        LineTextBox.IsEnabled = true;
                        break;
                    case TypeOfQuestion.OneFromList:
                        OneFromListStackPanel.Visibility = Visibility.Visible;
                        OneFromListStackPanel.IsEnabled = true;
                        this.OneFromListCollection = new ObservableCollection<AnswerDisplay>();
                        value.answers.ForEach(a=>this.OneFromListCollection.Add(new AnswerDisplay{answer = a, secret = this.secret}));
                        break;
                    case TypeOfQuestion.FewFromList:
                        FewFromListStackPanel.Visibility = Visibility.Visible;
                        FewFromListStackPanel.IsEnabled = true;
                        value.answers.ForEach(a=>this.FewFromListCollection.Add(new AnswerDisplay{answer = a, secret = this.secret}));
                        break;
                }

                OneFromListView.ItemsSource = this.OneFromListCollection;
                FewFromListView.ItemsSource = this.FewFromListCollection;
                _question = value;
            }
        }

        public bool IsAnswered
        {
            get
            {
                switch (Question.TypeOfQuestion)
                {
                    case TypeOfQuestion.Line:
                        return LineTextBox.Text != "";
                    case TypeOfQuestion.OneFromList:
                        return this.OneFromListCollection.ToList().FindIndex(a => a.IsChecked) != -1;
                    case TypeOfQuestion.FewFromList:
                        return this.FewFromListCollection.ToList().FindIndex(a => a.IsChecked) != -1;
                }

                return false;
            }
        }
        
        public bool IsCorrected
        {
            get
            {
                if (!IsAnswered)
                {
                    return false;
                }
                switch (Question.TypeOfQuestion)
                {
                    case TypeOfQuestion.Line:
                        return LineTextBox.Text == Question.answers[0];
                    case TypeOfQuestion.OneFromList:
                        AnswerDisplay answerDisplay = this.OneFromListCollection.ToList().FindAll(a => a.IsChecked)[0];
                        return answerDisplay.answer==Question.answers[Question.correctAnswerIDs[0]];
                    case TypeOfQuestion.FewFromList:
                        List<AnswerDisplay> answerDisplays = this.OneFromListCollection.ToList().FindAll(a => a.IsChecked);
                        List<string> correctAnswer = Question.correctAnswerIDs.ConvertAll(id=>Question.answers[id]);
                        bool res = true;
                        foreach (AnswerDisplay answer in answerDisplays)
                        {
                            if(correctAnswer.FindIndex(s => answer.answer == s)==-1)
                            {
                                res = false;
                            }
                        }
                        return res;
                }

                return false;
            }
        }
        
         private ObservableCollection<AnswerDisplay> OneFromListCollection;

        private ObservableCollection<AnswerDisplay> FewFromListCollection;

        private string secret;
        public QuestionPassageControl()
        {
            InitializeComponent();
            this.secret = DateTime.Now.Ticks.ToString();
        }

        private void TestListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void hidenAll()
        {
            LineTextBox.Visibility = Visibility.Hidden;
            LineTextBox.IsEnabled = false;

            OneFromListStackPanel.Visibility = Visibility.Hidden;
            OneFromListStackPanel.IsEnabled = false;

            FewFromListStackPanel.Visibility = Visibility.Hidden;
            FewFromListStackPanel.IsEnabled = false;
        }
    }
}