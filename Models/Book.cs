using System.ComponentModel.DataAnnotations;


 namespace Chandrakanth_CRUD.Models
{
    public class Book
    {

        [Key]
        [Display(Name = "Book Id")]
        [Required]
        public int Book_id { get; set; }
        
        [Display(Name = "Publisher")]
        [Required]
        public string Publisher { get; set; }
        
        [Display(Name = "Title Name")]
        [Required]
        public string Title  { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFirstName { get; set; }
        [Required]
        public float Price { get; set; }
        public string Style_Citation { get; set; }
    }
}
