using De.HSFlensburg.Bookmanager008.Business.Model.BusinessObjects;
using System;

namespace De.HSFlensburg.Bookmanager008.Logic.UI.ViewModelObjects
{
    public class BookViewModel
    {
        public Book Book { get; set; }


        public String Title
        {
            get
            {
                return Book.Title;
            }
            set
            {
                Book.Title = value;
            }
        }

        public String Author
        {
            get
            {
                return Book.Author;
            }
            set
            {
                Book.Author = value;
            }
        }

        public String Publisher
        {
            get
            {
                return Book.Publisher;
            }
            set
            {
                Book.Publisher = value;
            }
        }

        public String Genre
        {
            get
            {
                return Book.Genre;
            }
            set
            {
                Book.Genre = value;
            }
        }

        public BookViewModel(Book book)
        {
            this.Book = book;
        }


        // looks if the ViewModel is the same as the model

        public bool IsViewModelOf(Book model)
        {
            return this.Book == model;
        }
    }
}
