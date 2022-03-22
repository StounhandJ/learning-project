using System.Windows.Controls;
using Practical.Data;
using Practical.Data.DataSetTableAdapters;

namespace Practical.ComboBox
{
    public partial class PersonalComboBox : UserControl
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

        public PersonalComboBox()
        {
            InitializeComponent();
            
            personal_mattersTableAdapter adapterPersonal = new personal_mattersTableAdapter();
            DataSet.personal_mattersDataTable tablePersonal = new DataSet.personal_mattersDataTable();
            adapterPersonal.Fill(tablePersonal);
            Box.ItemsSource = tablePersonal;
            Box.DisplayMemberPath = "Surname";
            Box.SelectedValuePath = "id";
        }
    }
}