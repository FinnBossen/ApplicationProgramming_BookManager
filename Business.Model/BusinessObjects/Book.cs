namespace De.HSFlensburg.Bookmanager008.Business.Model.BusinessObjects
{
    public class Book
    {
        private string title;
        private string author;
        private string publisher;
        private string genre;

        public Book()
        {
            this.title = Title;
            this.author = Author;
            this.publisher = Publisher;
            this.genre = Genre;
        }

        // assigns the given variable as a property
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

    }
}
