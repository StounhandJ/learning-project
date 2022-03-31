using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class ResultFormControl : UserControl
    {
        private List<Form> _forms;
        public List<Form> Forms
        {
            get
            {
                return _forms;
            }
            set
            {
                FillFormsComboBox(value);
                _forms = value;
            }
        }

        private AnswersController _answersController;

        public ResultFormControl()
        {
            InitializeComponent();

            this._answersController = new AnswersController();
        }
        
        private void FillFormsComboBox(List<Form> forms)
        {
            FormsComboBox.ItemsSource = new List<Form>();
            FormsComboBox.ItemsSource = forms;
            FormsComboBox.DisplayMemberPath = "name";
        }

        private void FormsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainDataGrid.Columns.Clear();
            MainDataGrid.Columns.Add(new DataGridTextColumn{Header = "ФИО", Binding = new Binding("studentName")});
            Form form = (Form) FormsComboBox.SelectedValue;
            int i = 0;
            form.questions.ForEach(q=>
            {
                MainDataGrid.Columns.Add(new DataGridTextColumn
                        {Header = q.question, Binding = new Binding($"result[{i}]")});
                i += 1;
            });
            MainDataGrid.Columns.Add(new DataGridTextColumn{Header = "Баллы", Binding = new Binding("points")});
            
            MainDataGrid.ItemsSource = this._answersController.getAnswersList(form.id);
            // Скрыть лищние поля
            int count = MainDataGrid.Columns.Count;
            MainDataGrid.Columns[count - 1].Visibility = Visibility.Hidden;
            MainDataGrid.Columns[count - 2].Visibility = Visibility.Hidden;
            MainDataGrid.Columns[count - 3].Visibility = Visibility.Hidden;
            MainDataGrid.Columns[count - 4].Visibility = Visibility.Hidden;
            MainDataGrid.Columns[count - 5].Visibility = Visibility.Hidden;
            MainDataGrid.Columns[count - 6].Visibility = Visibility.Hidden;
        }
    }
}