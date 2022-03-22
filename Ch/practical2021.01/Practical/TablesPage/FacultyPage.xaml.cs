using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Practical.Data.DataSetTableAdapters;

using DataSet = Practical.Data.DataSet;

namespace Practical.TablesPage
{
    public partial class FacultyPage : Page
    {
        private int selectRow = -1;

        public FacultyPage()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            NameTextBox.Text = "";
            PriceTutionTextBox.Text = "";
            FacultyViewTableAdapter g = new FacultyViewTableAdapter();
            DataSet.FacultyViewDataTable table = new DataSet.FacultyViewDataTable();

            g.Fill(table);
            Data.ItemsSource = table;
            Data.SelectedIndex = selectRow < Data.Items.Count ? selectRow : -1;
            Buttons.selectItem(selectRow > -1 && selectRow < Data.Items.Count);
        }

        private void ClickAdd(object sender)
        {
            try
            {
                if (!IsNumberGood())
                {
                    this.showError("Указан неверный тип данных");
                }
                else if (this.IsFillArea())
                {
                    new facultyTableAdapter().Insert(NameTextBox.Text, Convert.ToInt32(PriceTutionTextBox.Text));
                    update();
                }
                else
                {
                    this.showError("Заполнены не все поля");
                }
            }
            catch (Exception exception)
            {
                this.showError("Данная строка уже существует");
            }
        }

        private void ClickChange(object sender)
        {
            try
            {
                if (!IsNumberGood())
                {
                    this.showError("Указан неверный тип данных");
                }
                else if (this.IsFillArea())
                {
                    new facultyTableAdapter().Update(NameTextBox.Text, Convert.ToInt32(PriceTutionTextBox.Text), Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]), (Data.SelectedItem as DataRowView).Row.ItemArray[1].ToString(), Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[2]));
                    update();
                }
                else
                {
                    this.showError("Заполнены не все поля");
                }
            }
            catch (Exception exception)
            {
                this.showError("Данная строка уже существует");
            }
        }

        private void ClickDelete(object sender)
        {
            try
            {
                new facultyTableAdapter().DeleteQuery(Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]));
                Buttons.selectItem(false);
                update();
            }
            catch (Exception exception)
            {
                this.showError("Нельзя удалить строчку");
            }

        }
        
        private void ClickCancel(object sender)
        {
            NameTextBox.Text = "";
            PriceTutionTextBox.Text = "";
            this.selectRow = -1;
            Data.SelectedIndex = -1;
            Buttons.selectItem(false);
        }

        private void Doljnost_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Data.SelectedIndex > -1 && Data.SelectedIndex < Data.Items.Count)
            {
                selectRow = Data.SelectedIndex;
                var items = (Data.SelectedItem as DataRowView).Row;
                NameTextBox.Text = items.ItemArray[1].ToString();
                PriceTutionTextBox.Text = items.ItemArray[2].ToString();
                Buttons.selectItem(true);
            }
        }

        private void showError(string text)
        {
            MessageBox.Show(text);
        }

        private bool IsFillArea()
        {
            return Methods.IsGoodString(NameTextBox.Text) && Methods.IsGoodString(PriceTutionTextBox.Text);
        }

        private bool IsNumberGood()
        {
            return Methods.IsGoodInt(PriceTutionTextBox.Text);
        }
    }
}