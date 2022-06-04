using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceProject3.Models
{
    public class MaterialSubCatePrice
    {
        public int Id { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Price { get; set; }
        public int? MaterialId { get; set; }
        public Material Material { get; set; }
        //[Column(Order = 1)]
        public int? MaterialSubCategoryId { get; set; }
        public MaterialSubCategory MaterialSubCategory { get; set; }
    }
}
