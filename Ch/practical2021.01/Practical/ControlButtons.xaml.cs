using System;
using System.Windows;
using System.Windows.Controls;

namespace Practical
{
    public partial class ControlButtons : UserControl
    {

        public delegate void ClickEvent(object sender);
        
        public event ClickEvent ClickAdd;
        public event ClickEvent ClickChange;
        public event ClickEvent ClickDelete;
        public event ClickEvent ClickCancel;

        
        public ControlButtons()
        {
            InitializeComponent();
        }
        
        public void selectItem(bool IsSelectItem)
        {
            ButtonAdd.IsEnabled = !IsSelectItem;
            ButtonChange.IsEnabled = IsSelectItem;
            ButtonDelete.IsEnabled = IsSelectItem;
            ButtonCancel.IsEnabled = IsSelectItem;
        }

        private void ClickAddB(object sender, RoutedEventArgs routedEventArgs)
        {
            ClickAdd?.Invoke(this);
        }

        private void ClickChangeB(object sender, RoutedEventArgs e)
        {
            ClickChange?.Invoke(this);
        }

        private void ClickDeleteB(object sender, RoutedEventArgs e)
        {
            ClickDelete?.Invoke(this);
        }

        private void ClickCancelB(object sender, RoutedEventArgs e)
        {
            ClickCancel?.Invoke(this);
        }
    }
}