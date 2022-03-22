using System.Windows.Controls;
using Practical.Data;
using Practical.Data.DataSetTableAdapters;

namespace Practical.ComboBox
{
    public partial class GroupComboBox : UserControl
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

        public GroupComboBox()
        {
            InitializeComponent();
            
            groupTableAdapter adapterGroup = new groupTableAdapter();
            DataSet.groupDataTable tableGroup  = new DataSet.groupDataTable();
            adapterGroup .Fill(tableGroup);
            Box.ItemsSource = tableGroup;
            Box.DisplayMemberPath = "name";
            Box.SelectedValuePath = "id";
        }
    }
}