using System.Windows.Controls;
using Practical.Data;
using Practical.Data.DataSetTableAdapters;

namespace Practical.ComboBox
{
    public partial class TeacherComboBox : UserControl
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
        
        public TeacherComboBox()
        {
            InitializeComponent();
            
            Box.ItemsSource = new teacherTableAdapter().GetDataBy();
            Box.DisplayMemberPath = "Surname";
            Box.SelectedValuePath = "id";
        }
    }
}