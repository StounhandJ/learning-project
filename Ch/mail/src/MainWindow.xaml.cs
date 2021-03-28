using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace mail
{
    public partial class MainWindow
    {
        private string userMail;
        private string userPassword;
        private List<string> filePathList = new List<string>();

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        private bool debug = false;
        private string pathFilesDirectory = Directory.GetCurrentDirectory() + "\\sendFile";

        private MailClass draftVersionMail = new MailClass();
        
        
        public MainWindow()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            alignment.ItemsSource = new List<String>() { "Лево", "Центр", "Право", "Ширина"};
            if (Directory.Exists(pathFilesDirectory))
            {
                Directory.Delete(pathFilesDirectory, true);
            }
            if (debug)
            {
                coreForm.Width = 700;
                EditMailMenu.Visibility = Visibility.Visible;
                EditMailMenu.IsEnabled = true;

                LoginMenu.Visibility = Visibility.Hidden;
                LoginMenu.IsEnabled = false;
                
                userMail = "tester.mpt@gmail.com";
                userPassword = "7157725R";
                
                toMail.Text = userMail;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginEmail.Text=="" || LoginPassword.Password=="") return;
            if (!isValidEmail(LoginEmail.Text))
            {
                showErrorLogin("Неверный формат email");
                return;
            }
            MailAddress from = new MailAddress(LoginEmail.Text, "Tom");
            MailAddress to = new MailAddress(LoginEmail.Text);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Успешная авторизация";
            m.Body = "";
            m.IsBodyHtml = true;
            smtp.Credentials = new NetworkCredential(LoginEmail.Text, LoginPassword.Password);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
                userMail = LoginEmail.Text;
                userPassword = LoginPassword.Password;
                LoginMenu.Visibility = Visibility.Hidden;
                LoginMenu.IsEnabled = false;
                EditMailMenu.Visibility = Visibility.Visible;
                EditMailMenu.IsEnabled = true;
                coreForm.Width = 700;
                toMail.Text = userMail;
            }
            catch (Exception exception)
            {
                showErrorLogin("Неверный email или пароль");
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
            if(isValidEmail(whomMail.Text)){whomMailList.Items.Add(whomMail.Text);}
            foreach (var vari in whomMailList.Items)
            {
                whomMailListLast.Items.Add((string) vari);
                send_mes("Новое письмо", text, filePathList,(string)vari);
            }
            
            whomMailList.Items.Clear();
            rtbEditor.Document.Blocks.Clear();
            fileList.Items.Clear();
            showErrorMain("");
        }

        private void Add_user_to_Click(object sender, RoutedEventArgs e)
        {
            add_whomMail();
        }
        
        private void WhomMail_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) add_whomMail();
        }

        private void add_whomMail()
        {
            if (!isValidEmail(whomMail.Text))
            {
                showErrorMain("Неверный формат email");
                return;
            }
            whomMailList.Items.Add(whomMail.Text);
            whomMail.Text = "";
            showErrorMain("");
        }

        private void whomMailListLast_choiceElement(object sender, SelectionChangedEventArgs e)
        {
            whomMail.Text = whomMailListLast.SelectedItem.ToString();
        }
        
        private void whomMailList_choiceElement(object sender, SelectionChangedEventArgs e)
        {
            DeleteButton.IsEnabled = true;
        }
        
        private void fileList_choiceElement(object sender, SelectionChangedEventArgs e)
        {
            DeleteFileButton.IsEnabled = true;
        }

        private void Delete_from_Click(object sender, RoutedEventArgs e)
        {
            whomMailList.Items.Remove(whomMailList.SelectedItem);
            DeleteButton.IsEnabled = false;
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            int time = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            Directory.CreateDirectory(pathFilesDirectory);
            if (e.Data != null)
                foreach (var vari in (string[]) e.Data.GetData(DataFormats.FileDrop))
                {
                    add_file(vari, time);
                }
        }

        private void Add_file_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                add_file(dlg.FileName, (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            }
        }
        
        private void Del_file_Click(object sender, RoutedEventArgs e)
        {
            filePathList.Remove(((Label)fileList.SelectedItem).Uid);
            fileList.Items.Remove(fileList.SelectedItem);
            DeleteFileButton.IsEnabled = false;
        }

        private void send_mes(string title, string text, List<string> fileList ,string to=null)
        {
            MailMessage m = new MailMessage(new MailAddress(userMail), new MailAddress(@to??userMail));
            m.Subject = title;
            m.Body = text;
            m.IsBodyHtml = true;
            foreach (var vari in fileList)
            {
                m.Attachments.Add(new Attachment(vari));
            }
            smtp.Credentials = new NetworkCredential(userMail, userPassword);
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
        
        private void add_file(string path, int time)
        {
            Directory.CreateDirectory(pathFilesDirectory+"\\"+time);
                    
            string fileName = path.Split('\\').Last();
            string filePath = pathFilesDirectory+"\\"+time + "\\" + path.Split('\\').Last();
            File.Copy(path,filePath);
            filePathList.Add(filePath);
            fileList.Items.Add(new Label(){Content = fileName, Uid = filePath});
        }
        
        bool isValidEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        
        private void showErrorLogin(string error)
        {
            errorLabelLogin.Content = error;
        }
        
        private void showErrorMain(string error)
        {
            errorLabelMain.Content = error;
        }
    }
}