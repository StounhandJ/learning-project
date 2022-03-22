using Practical.Data.DataSetTableAdapters;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataSet = Practical.Data.DataSet;

namespace Practical.TablesPage
{
    /// <summary>
    /// Логика взаимодействия для PersonalMattersPage.xaml
    /// </summary>
    public partial class PersonalMattersPage : Page
    {
        private int selectRow = -1;
        public PersonalMattersPage()
        {
            InitializeComponent();
            update();
        }

        private void update()
        {
            Surname.Text = "";
            FirstName.Text = "";
            Patronymic.Text = "";
            Date.Text = "";
            PersonalMattersViewTableAdapter g = new PersonalMattersViewTableAdapter();
            DataSet.PersonalMattersViewDataTable table = new DataSet.PersonalMattersViewDataTable();

            g.Fill(table);
            Data.ItemsSource = table;
            Data.SelectedIndex = selectRow < Data.Items.Count ? selectRow : -1;
            Buttons.selectItem(selectRow > -1 && selectRow < Data.Items.Count);
        }

        private void ClickAdd(object sender)
        {
            if (this.IsFillArea())
            {
                new personal_mattersTableAdapter().Insert(Surname.Text, FirstName.Text, Patronymic.Text, Date.Text);
                update();
            }
            else
            {
                this.showError("Заполнены не все поля");
            }
        }

        private void ClickChange(object sender)
        {
            try
            {
                if (this.IsFillArea())
                {
                    new personal_mattersTableAdapter().Update(Surname.Text, FirstName.Text, Patronymic.Text, Date.Text, Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]));
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
                new personal_mattersTableAdapter().Delete(Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]));
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
            Surname.Text = "";
            FirstName.Text = "";
            Patronymic.Text = "";
            Date.Text = "";
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
                Surname.Text = items.ItemArray[1].ToString();
                FirstName.Text = items.ItemArray[2].ToString();
                Patronymic.Text = items.ItemArray[3].ToString();
                Date.Text = items.ItemArray[4].ToString();
                Buttons.selectItem(true);
            }
        }

        private void showError(string text)
        {
            MessageBox.Show(text);
        }

        private bool IsFillArea()
        {
            var g = Methods.IsGoodString(Patronymic.Text, true);
             return Methods.IsGoodString(Surname.Text) && Methods.IsGoodString(FirstName.Text) && Methods.IsGoodString(Patronymic.Text, true) &&
                   Date.DisplayDate<DateTime.Now.AddYears(-10);
        }
        private void FirstUpper_OnKeyDown(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            TextBox TB = sender as TextBox;
            int position = TB.CaretIndex;
            if (TB.Text.Length>0)
            {
                TB.Text = TB.Text[0].ToString().ToUpper() + TB.Text.Substring(1).ToLower();
                TB.CaretIndex = position;
            }
        }
    }
}
