using De.HSFlensburg.Bookmanager008.Logic.UI.Messages;
using De.HSFlensburg.Bookmanager008.Service.ServiceBus;
using System.Windows;


namespace De.HSFlensburg.Bookmanager008.Ui.Desktop
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            Messenger.Instance.Register<OpenNewBookWindowMessage>(this, () =>
            {
                NewBookWindow window = new NewBookWindow();

                window.Titel.Text = "unknown";
                window.Genre.Text = "unknown";
                window.Verlag.Text = "unknown";
                window.Autor.Text = "unknown";

                window.ShowDialog();


            });
        }

    }
}
