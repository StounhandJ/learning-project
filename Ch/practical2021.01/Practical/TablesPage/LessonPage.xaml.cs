using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Practical.Data.DataSetTableAdapters;

using DataSet = Practical.Data.DataSet;

namespace Practical.TablesPage
{
    public partial class LessonPage : Page
    {
        private int selectRow = -1;
        
        public LessonPage()
        {
            InitializeComponent();
            update();
        }
        private void update()
        {
            NameTextBox.Text = "";
            LessonViewTableAdapter g = new LessonViewTableAdapter();
            DataSet.LessonViewDataTable table = new DataSet.LessonViewDataTable();

            g.Fill(table);
            Data.ItemsSource = table;
            Data.SelectedIndex = selectRow < Data.Items.Count ? selectRow : -1;
            Buttons.selectItem(selectRow > -1 && selectRow < Data.Items.Count);
        }

        private void ClickAdd(object sender)
        {
            try
            {
                if (this.IsFillArea())
                {
                    new lessonTableAdapter().Insert(NameTextBox.Text);
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
                if (this.IsFillArea())
                {
                    new lessonTableAdapter().Update(NameTextBox.Text, Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]), (Data.SelectedItem as DataRowView).Row.ItemArray[1].ToString());
                    update();
                }
                else
                {
                    this.showError("Заполнены не все поля");
                }
            }
            catch (Exception exception)
            {
                // ignored
            }
        }

        private void ClickDelete(object sender)
        {
            try
            {
                new lessonTableAdapter().Delete(Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]), (Data.SelectedItem as DataRowView).Row.ItemArray[1].ToString());
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
                Buttons.selectItem(true);
            }
        }

        private void showError(string text)
        {
            MessageBox.Show(text);
        }

        private bool IsFillArea()
        {
            return Methods.IsGoodString(NameTextBox.Text);
        }
    }
}