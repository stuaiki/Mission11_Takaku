namespace Mission11_Takaku.Models.ViewModels
{
    //Pagination class. Set value
    public class PaginationInfo
    {
        public int TotalItems { get; set; }
        public int ItemPerPage {  get; set; }
        public int CurrentPage {  get; set; }
        public int TotalNumPages => (int) (Math.Ceiling((decimal) TotalItems / ItemPerPage)); //Make sure if decimal is 4.3, have 5 pages.
    }
}
