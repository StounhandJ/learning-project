using System;
using System.Windows.Controls;
using Practical.Data;
using Practical.Data.DataSetTableAdapters;

namespace Practical.ComboBox
{
    public partial class StudentComboBox : UserControl
    {
        public string Text
        {
            get
            {
                return Box.Text;
            }
            set
            {
                Box.Text = value;
            }
        }
        
        public object SelectedValue
        {
            get
            {
                return Box.SelectedValue;
            }
            set
            {
                Box.SelectedValue = value;
            }
        }
        
        public StudentComboBox()
        {
            InitializeComponent();
            
            Box.ItemsSource = new studentTableAdapter().GetDataBy();
            Box.DisplayMemberPath = "Surname";
            Box.SelectedValuePath = "id";
        }
    }
}