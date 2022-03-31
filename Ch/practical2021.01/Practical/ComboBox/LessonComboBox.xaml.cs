using System.Windows.Controls;
using Practical.Data;
using Practical.Data.DataSetTableAdapters;

namespace Practical.ComboBox
{
    public partial class LessonComboBox : UserControl
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
        
        public LessonComboBox()
        {
            InitializeComponent();
            
            lessonTableAdapter adapterGroup = new lessonTableAdapter();
            DataSet.lessonDataTable tableGroup  = new DataSet.lessonDataTable();
            adapterGroup .Fill(tableGroup);
            Box.ItemsSource = tableGroup;
            Box.DisplayMemberPath = "name";
            Box.SelectedValuePath = "id";
        }
    }
}