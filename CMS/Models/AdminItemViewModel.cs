using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class AdminItemViewModel
    {
        public int ItemId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public int Views { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public IFormFile? Picture { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
