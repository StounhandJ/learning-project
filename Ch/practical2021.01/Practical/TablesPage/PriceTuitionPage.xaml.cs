﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Practical.Data.DataSetTableAdapters;

using DataSet = Practical.Data.DataSet;

namespace Practical.TablesPage
{
    public partial class PriceTuitionPage : Page
    {
        private int selectRow = -1;
        
        public PriceTuitionPage()
        {
            InitializeComponent();
            update();
            Data.AutoGeneratedColumns += CollapsedColumns;
        }
        
        private void update()
        {
            StudentComboBox.Text = "";
            DiscountTextBox.Text = "";
            PriceTuitionViewTableAdapter g = new PriceTuitionViewTableAdapter();
            DataSet.PriceTuitionViewDataTable table = new DataSet.PriceTuitionViewDataTable();

            g.Fill(table);
            Data.ItemsSource = table;
            Data.SelectedIndex = selectRow < Data.Items.Count ? selectRow : -1;
            Buttons.selectItem(selectRow > -1 && selectRow < Data.Items.Count);
        }
        
        private void CollapsedColumns(object sender, EventArgs eventArgs)
        {
            Data.Columns[1].Visibility = Visibility.Collapsed;
        }

        private void ClickAdd(object sender)
        {
            if (!IsNumberGood())
            {
                this.showError("Указан неверный тип данных");
            }
            else if (this.IsFillArea())
            {
                new price_tuitionTableAdapter().Insert(Convert.ToInt32(StudentComboBox.SelectedValue), Convert.ToInt32(DiscountTextBox.Text));
                update();
            }
            else 
            {
                this.showError("Заполнены не все поля");
            }
        }

        private void ClickChange(object sender)
        {
            if (!IsNumberGood())
            {
                this.showError("Указан неверный тип данных");
            }
            else if (this.IsFillArea())
            {
                var items = (Data.SelectedItem as DataRowView).Row;
                new price_tuitionTableAdapter().Update(Convert.ToInt32(StudentComboBox.SelectedValue), Convert.ToInt32(DiscountTextBox.Text), Convert.ToInt32(items.ItemArray[0]),
                        Convert.ToInt32(items.ItemArray[1]),Convert.ToInt32(items.ItemArray[2]),Convert.ToInt32(items.ItemArray[0]));
                update();
            }
            else
            {
                this.showError("Заполнены не все поля");
            }
        }

        private void ClickDelete(object sender)
        {
            try
            {
                new price_tuitionTableAdapter().Delete(Convert.ToInt32((Data.SelectedItem as DataRowView).Row.ItemArray[0]), Convert.ToInt32(StudentComboBox.SelectedValue), Convert.ToInt32(DiscountTextBox.Text));
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
            StudentComboBox.Text = "";
            DiscountTextBox.Text = "";
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
                StudentComboBox.SelectedValue = items.ItemArray[1];
                DiscountTextBox.Text = items.ItemArray[2].ToString();
                Buttons.selectItem(true);
            }
        }

        private void showError(string text)
        {
            MessageBox.Show(text);
        }

        private bool IsFillArea()
        {
            return Methods.IsGoodString(StudentComboBox.Text) && Methods.IsGoodString(DiscountTextBox.Text);
        }
        
        private bool IsNumberGood()
        {
            return Methods.IsGoodInt(DiscountTextBox.Text, 0, 100);
        }
    }
}