using De.HSFlensburg.Bookmanager008.Logic.UI;
using De.HSFlensburg.Bookmanager008.Logic.UI.Messages;
using De.HSFlensburg.Bookmanager008.Service.ServiceBus;
using System.Windows;

namespace De.HSFlensburg.Bookmanager008.Ui.Desktop
{

    public partial class NewBookWindow : Window
    {

        public NewBookWindow()
        {

            InitializeComponent();

            // Tried to apply the add button, a function to add a book to the Collection.
            // I have done basically the same thing, I have done with the opening Message,
            // but now it calls the function AddBook instead of OpenDialog.
            // But my approach needs some fixing. It adds multiples books on the second time
            // you click the add button. I think its because it registers the Message multiple times.
            // The function needs to be unregistered or the method register needs to be initiated on 
            // another place in the project, instead of the Constructor of the Window.

            Messenger.Instance.Register<AddNewBookWindowMessage>(this, () =>
            {
                ViewModelMainWindow viewModel = this.DataContext as ViewModelMainWindow;

                viewModel.AddBook(this.Titel.Text, this.Genre.Text, this.Verlag.Text, this.Autor.Text);

                this.Close();

            });

        }

    }
}
