using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace mail
{
    public partial class MainWindow
    {
        private string userMail = "tester.mpt@gmail.com";
        private string userPassword = "7157725R";
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        
        public MainWindow()
        {
            // MailAddress from = new MailAddress("tester.mpt@gmail.com", "Tom");
            // MailAddress to = new MailAddress("tester.mpt@gmail.com");
            // MailMessage m = new MailMessage(from, to);
            // m.Subject = "Тест";
            // m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // m.IsBodyHtml = true;
            
            
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            alignment.ItemsSource = new List<String>() { "Лево", "Центр", "Право", "Ширина"};
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginEmail.Text=="" || LoginPassword.Text=="") return;
            MailAddress from = new MailAddress(LoginEmail.Text, "Tom");
            MailAddress to = new MailAddress(LoginEmail.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Успешная авторизация";
            m.Body = "";
            m.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential(LoginEmail.Text, LoginPassword.Text);
            smtp.EnableSsl = true;
            //"tester.mpt@gmail.com", "7157725R"
            try
            {
                smtp.Send(m);
                userMail = LoginEmail.Text;
                userPassword = LoginPassword.Text;
                LoginMenu.Visibility = Visibility.Hidden;
                LoginMenu.IsEnabled = false;
                EditMailMenu.Visibility = Visibility.Visible;
                EditMailMenu.IsEnabled = true;
                coreForm.Width = 700;
                toMail.Text = userMail;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            
        }
        
        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }
        
        private void cmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
        }
        
        private void Alignment_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            var Alignment = TextAlignment.Left;
            switch (alignment.SelectedValue)
            {
                case "Лево":
                    Alignment = TextAlignment.Left; break;
                case "Центр":
                    Alignment = TextAlignment.Center; break;
                case "Право":
                    Alignment = TextAlignment.Right; break;
                case "Ширина":
                    Alignment = TextAlignment.Justify; break;
            }
            rtbEditor.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, Alignment);
        }
        
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
            temp = rtbEditor.Selection.GetPropertyValue(Paragraph.TextAlignmentProperty);
            switch ((TextAlignment)temp)
            {
                case TextAlignment.Left:
                    alignment.SelectedIndex = 0;
                    break;
                case TextAlignment.Center:
                    alignment.SelectedIndex = 1;
                    break;
                case TextAlignment.Right:
                    alignment.SelectedIndex = 2;
                    break;
                case TextAlignment.Justify:
                    alignment.SelectedIndex = 3;
                    break;
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "/ff.rtf";
            FileStream fileStream = new FileStream(path, FileMode.Create);
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            range.Save(fileStream, DataFormats.Rtf);
            fileStream.Close();
            
            SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
            string rtfString = File.ReadAllText(path);
            r.ImageStyle.IncludeImageInHtml = true;
            string text = r.ConvertString(rtfString);
            whomMailListLast.Items.Clear();
            foreach (var vari in whomMailList.Items)
            {
                whomMailListLast.Items.Add((string) vari);
                send_mes("Новое письмо", text,(string)vari);
            }
            
            whomMailList.Items.Clear();
            rtbEditor.Document.Blocks.Clear();
        }

        private void send_mes(string title, string text, string to=null)
        {
            MailMessage m = new MailMessage(new MailAddress(userMail), new MailAddress(@to??userMail));
            m.Subject = title;
            m.Body = text;
            m.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential(userMail, userPassword);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }

        private void Add_user_to_Click(object sender, RoutedEventArgs e)
        {
            whomMailList.Items.Add(whomMail.Text);
            whomMail.Text = "";
        }

        private void whomMailListLast_choiceElement(object sender, SelectionChangedEventArgs e)
        {
            whomMail.Text = whomMailListLast.SelectedItem.ToString();
        }
        
        private void whomMailList_choiceElement(object sender, SelectionChangedEventArgs e)
        {
            DeleteButton.IsEnabled = true;
        }

        private void Delete_from_Click(object sender, RoutedEventArgs e)
        {
            whomMailList.Items.Remove(whomMailList.SelectedItem);
            DeleteButton.IsEnabled = false;
        }
    }
}