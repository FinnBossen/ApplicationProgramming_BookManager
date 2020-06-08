using De.HSFlensburg.Bookmanager008.Business.Model.BusinessObjects;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace De.HSFlensburg.Bookmanager008.Logic.UI.ViewModelObjects
{
    public class BookcollectionViewModel : ObservableCollection<BookViewModel>
    {

        public BookCollection Books { get; set; }


        bool synchDisabled = false;

        public BookcollectionViewModel()
        {

            Books = new BookCollection();
            CollectionChanged += ViewModelCollectionChanged;
            Books.CollectionChanged += ModelCollectionChanged;


        }
        // calls if the ViewModelCollection is changed, starts the appropiate case
        public void ViewModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (synchDisabled) return;

            synchDisabled = true;

            switch (e.Action)
            {

                case NotifyCollectionChangedAction.Add:
                    foreach (var m in e.NewItems.OfType<BookViewModel>().Select(v => v.Book).OfType<Book>())
                        Books.Add(m);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var m in e.OldItems.OfType<BookViewModel>().Select(v => v.Book).OfType<Book>())
                        Books.Remove(m);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    Books.Clear();
                    foreach (var m in e.NewItems.OfType<BookViewModel>().Select(v => v.Book).OfType<Book>())
                        Books.Add(m);
                    break;
            }
            synchDisabled = false;

        }

        // calls if the ModelCollection is changed, starts the appropiate case
        public void ModelCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (synchDisabled) return;
            synchDisabled = true;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var m in e.NewItems.OfType<Book>())
                        this.Add(new BookViewModel(m));
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var m in e.OldItems.OfType<Book>())
                        this.Remove(GetViewModelOfModel(m));
                    break;
            }
            synchDisabled = false;

        }

        // gets the ViewModel of the Model Book, calls a Method from BookViewModel
        private BookViewModel GetViewModelOfModel(Book model)
        {

            return Items.OfType<BookViewModel>().FirstOrDefault(v => v.IsViewModelOf(model));

        }

        // Removes BookViewmodel if it contains same as data
        private void RemoveIfContains(BookViewModel model)
        {
            foreach (var data in this)
            {
                if (data == model)
                {
                    this.Remove(model);
                }
            }
        }



    }




}
