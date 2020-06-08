using De.HSFlensburg.Bookmanager008.Business.Model.BusinessObjects;
using De.HSFlensburg.Bookmanager008.Logic.UI.Messages;
using De.HSFlensburg.Bookmanager008.Logic.UI.ViewModelObjects;
using De.HSFlensburg.Bookmanager008.Service.ServiceBus;
using System.Linq;
using System.Windows.Input;

namespace De.HSFlensburg.Bookmanager008.Logic.UI
{
    public class ViewModelMainWindow
    {
        public BookcollectionViewModel BCVM { get; set; }
        public RelayCommand openBookCommand;
        public RelayCommand saveBookCommand;
        public ICommand ClickOpen { get { return openBookCommand; } }
        public ICommand ClickSave { get { return saveBookCommand; } }

        public ViewModelMainWindow()
        {
            // assigns a RelayCommand as a Message
            openBookCommand = new RelayCommand(() => Messenger.Instance.Send<OpenNewBookWindowMessage>(new OpenNewBookWindowMessage()));
            saveBookCommand = new RelayCommand(() => Messenger.Instance.Send<AddNewBookWindowMessage>(new AddNewBookWindowMessage()));


            // instantiates the BVCVM and adds books and propertys to the BCVM
            BCVM = new BookcollectionViewModel();

            BCVM.Add(new BookViewModel(new Book()));
            BCVM.Add(new BookViewModel(new Book()));
            BCVM.Add(new BookViewModel(new Book()));
            BCVM.Add(new BookViewModel(new Book()));

            BCVM.ElementAt(0).Author = "Friedrich";
            BCVM.ElementAt(0).Genre = "Horror";
            BCVM.ElementAt(0).Title = "Das Schrecken";
            BCVM.ElementAt(0).Publisher = "Der Verlag";
            BCVM.ElementAt(1).Author = "Dietrich";
            BCVM.ElementAt(1).Genre = "Romance";
            BCVM.ElementAt(1).Title = "Die Liebe";
            BCVM.ElementAt(1).Publisher = "Bester Verlag";
            BCVM.ElementAt(2).Author = "Günther";
            BCVM.ElementAt(2).Genre = "Action";
            BCVM.ElementAt(2).Title = "Last Actionhero";
            BCVM.ElementAt(2).Publisher = "Extreme Books";
            BCVM.ElementAt(3).Author = "Thomas";
            BCVM.ElementAt(3).Genre = "Thriller";
            BCVM.ElementAt(3).Title= "Der Killer";
            BCVM.ElementAt(3).Publisher = "Mindfuck Books";
            BCVM.Add(new BookViewModel(new Book()));
            BCVM.ElementAt(4).Author = "Günther";
            BCVM.ElementAt(4).Genre = "Romanze";
            BCVM.ElementAt(4).Title = "Günther und Rufus";
            BCVM.ElementAt(4).Publisher = "GümpelBooks";
            BCVM.Remove(BCVM.ElementAt(0));
            BCVM.Books.Add(new Book());
            BCVM.Books.ElementAt(4).Author= "BookCollectionBook";
            BCVM.Books.ElementAt(4).Genre = "Sync";
            BCVM.Books.ElementAt(4).Title = "Sncroncization";
            BCVM.Books.ElementAt(4).Publisher = "Pretty cool";
            BCVM.Books.Remove(BCVM.Books.ElementAt(4));


        }

        // Adds Book to BCVM and applys variables to propertys
        public void AddBook(string autor, string genre, string titel, string verlag)
        {
            BCVM.Add(new BookViewModel(new Book()));
            BCVM.ElementAt(BCVM.Count - 1).Author = autor;
            BCVM.ElementAt(BCVM.Count - 1).Genre = genre;
            BCVM.ElementAt(BCVM.Count - 1).Title= titel;
            BCVM.ElementAt(BCVM.Count - 1).Publisher = verlag;
        }



    }


}
