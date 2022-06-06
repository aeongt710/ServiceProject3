namespace ServiceProject3.Models
{
    public class MaterialSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MaterialCategoryId { get; set; }
        public MaterialCategory MaterialCategory { get; set; }
    }
}
