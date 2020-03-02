using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Cart
{
    [MetadataType(typeof(ProductsMetaData))]
    public partial class Products
    {

    }

    public class ProductsMetaData
    {
        [Key]
        public virtual int ProductID { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public virtual string ProductName { get; set; }
        [Required]
        [Display(Name = "Descripción")]
        public virtual string Description { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public virtual string ImagePath { get; set; }
        [Required]
        [Display(Name = "Precio Unitario")]
        public virtual Nullable<double> UnitPrice { get; set; }

        [Display(Name = "Categoría")]
        public virtual Nullable<int> CategoryID { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }

    }
}