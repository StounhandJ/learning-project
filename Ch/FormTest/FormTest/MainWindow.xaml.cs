using FormTest.Enums;
using FormTest.Page;
using FormTest.Structs;

namespace FormTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            setAuthPage();
        }

        public void setAuthPage()
        {
            AuthPage authPage = new AuthPage();
            authPage.EndAuth += EndAuth;
            MainContent.Content = authPage;
        }

        private void EndAuth(User user)
        {
            switch (user.TypeOfUser)
            {
                case TypeOfUser.Admin:
                    AdminPage adminPage = new AdminPage();
                    adminPage.Exit += UserExit;
                    MainContent.Content = adminPage;
                    break;
                case TypeOfUser.Teachaer:
                    TeacherPage teachaerPage = new TeacherPage();
                    teachaerPage.Teacher = user;
                    teachaerPage.Exit += UserExit;
                    MainContent.Content = teachaerPage;
                    break;
                case TypeOfUser.Studen:
                    StudentPage studentPage = new StudentPage();
                    studentPage.Student = user;
                    studentPage.Exit += UserExit;
                    MainContent.Content = studentPage;
                    break;
            }
        }

        private void UserExit()
        {
            this.setAuthPage();
        }
    }
}