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
    public partial class QuestionChangeControl : UserControl
    {
        public event Action<QuestionChangeControl> QuestionDelete;
        public Question Question
        {
            get { return new Question(TypeOfQuestion, QuestionText, AnswerList, AnswerCorrectIDs); }
        }

        private TypeOfQuestion _typeOfQuestion;

        public TypeOfQuestion TypeOfQuestion
        {
            get { return _typeOfQuestion; }
        }

        public string QuestionText
        {
            get { return this.QuestionTextBox.Text; }
        }

        public List<string> AnswerList
        {
            get
            {
                List<string> answerList = new List<string>();
                switch (TypeOfQuestion)
                {
                    case TypeOfQuestion.Line:
                        answerList.Add(this.LineTextBox.Text);
                        break;
                    case TypeOfQuestion.OneFromList:
                        foreach (AnswerDisplay question in this.OneFromListCollection)
                        {
                            answerList.Add(question.answer);
                        }
                        break;
                    case TypeOfQuestion.FewFromList:
                        foreach (AnswerDisplay question in this.FewFromListCollection)
                        {
                            answerList.Add(question.answer);
                        }
                        break;
                }

                return answerList;
            }
        }

        public List<int> AnswerCorrectIDs
        {
            get
            {
                List<int> answerCorrectIDs = new List<int>();
                switch (TypeOfQuestion)
                {
                    case TypeOfQuestion.Line:
                        answerCorrectIDs.Add(0);
                        break;
                    case TypeOfQuestion.OneFromList:
                        for (var i = 0; i < this.OneFromListCollection.Count; i++)
                        {
                            if (this.OneFromListCollection[i].IsChecked)
                            {
                                answerCorrectIDs.Add(i);
                            }
                        }
                        break;
                    case TypeOfQuestion.FewFromList:
                        for (var i = 0; i < this.FewFromListCollection.Count; i++)
                        {
                            if (this.FewFromListCollection[i].IsChecked)
                            {
                                answerCorrectIDs.Add(i);
                            }
                        }
                        break;
                }

                return answerCorrectIDs;
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

        private ObservableCollection<AnswerDisplay> OneFromListCollection;

        private ObservableCollection<AnswerDisplay> FewFromListCollection;

        private string secret;

        public QuestionChangeControl()
        {
            InitializeComponent();
            this.secret = DateTime.Now.Ticks.ToString();
            // Выбор типа вопроса
            Dictionary<TypeOfQuestion, string> types = new Dictionary<TypeOfQuestion, string>
            {
                {TypeOfQuestion.Line, "Строка"}, {TypeOfQuestion.OneFromList, "Один вариант"},
                {TypeOfQuestion.FewFromList, "Несколько вариантов"}
            };
            this.SelectingComboBox.ItemsSource = types;
            this.SelectingComboBox.DisplayMemberPath = "Value";
            this.SelectingComboBox.SelectedValuePath = "Key";

            this.SelectingComboBox.SelectedValue = TypeOfQuestion.Line;

            // Начальный ответ для всех типов полей
            this.OneFromListCollection = new ObservableCollection<AnswerDisplay> {new AnswerDisplay {answer = "Ответ", secret = this.secret}};
            this.FewFromListCollection = new ObservableCollection<AnswerDisplay> {new AnswerDisplay {answer = "Ответ", secret = this.secret}};

            // Привзяка элементов к полям
            OneFromListView.ItemsSource = this.OneFromListCollection;
            FewFromListView.ItemsSource = this.FewFromListCollection;
            LineTextBox.Text = "Ответ";
            QuestionTextBox.Text = "Вопрос";
        }

        private void SelectingComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hidenAll();
            this._typeOfQuestion = (TypeOfQuestion) SelectingComboBox.SelectedValue;
            switch ((TypeOfQuestion) SelectingComboBox.SelectedValue)
            {
                case TypeOfQuestion.Line:
                    LineTextBox.Visibility = Visibility.Visible;
                    LineTextBox.IsEnabled = true;
                    break;
                case TypeOfQuestion.OneFromList:
                    OneFromListStackPanel.Visibility = Visibility.Visible;
                    OneFromListStackPanel.IsEnabled = true;
                    break;
                case TypeOfQuestion.FewFromList:
                    FewFromListStackPanel.Visibility = Visibility.Visible;
                    FewFromListStackPanel.IsEnabled = true;
                    break;
            }
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

        private void OneFromListCreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.OneFromListCollection.Add(new AnswerDisplay {answer = "Ответ", secret = secret});
        }
        
        private void FewFromListCreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.FewFromListCollection.Add(new AnswerDisplay {answer = "Ответ", secret = secret});
        }

        private void TestListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ListView) sender).SelectedIndex != -1)
            {
                ((ListView) sender).SelectedIndex = -1;
            }
        }

        private void QuestionDeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            QuestionDelete?.Invoke(this);
        }
    }
}