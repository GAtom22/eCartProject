using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Cart
{
    [MetadataType(typeof(CategoriesMetaData))]
    public partial class Categories
    {

    }

    public class CategoriesMetaData
    {
        [Key]
        public virtual int CategoryID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public virtual string CategoryName { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public virtual string Description { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}