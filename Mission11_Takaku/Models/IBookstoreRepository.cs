//This is interface
namespace Mission11_Takaku.Models
{
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get;  } //get value
    }
}
