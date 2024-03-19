
//THis is EF Repository File
namespace Mission11_Takaku.Models
{
    public class EFBookstoreRepository : IBookstoreRepository //Inherite from IBookstoreRepository
    {
        private BookstoreContext _context; // set context file to access data
        public EFBookstoreRepository(BookstoreContext temp)
        {
            _context = temp;
        }

        public IQueryable<Book> Books => _context.Books;
    }
}
