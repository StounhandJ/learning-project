using System.Windows.Controls;
using Practical.Data;
using Practical.Data.DataSetTableAdapters;

namespace Practical.ComboBox
{
    public partial class FacultyComboBox : UserControl
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
        
        public FacultyComboBox()
        {
            InitializeComponent();
            
            facultyTableAdapter adapterGroup = new facultyTableAdapter();
            DataSet.facultyDataTable tableGroup  = new DataSet.facultyDataTable();
            adapterGroup .Fill(tableGroup);
            Box.ItemsSource = tableGroup;
            Box.DisplayMemberPath = "name";
            Box.SelectedValuePath = "id";
        }
    }
}