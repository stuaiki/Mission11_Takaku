namespace Mission11_Takaku.Models.ViewModels
{
    //This is BookListViewModel which has both IQueryable for Book and Pagination so that you can access to both in index.cshtml page
    public class BooksListViewModel
    {
        public IQueryable<Book> Books { get; set;}

        public PaginationInfo PaginationInfo { get; set;} = new PaginationInfo();
    }
}
