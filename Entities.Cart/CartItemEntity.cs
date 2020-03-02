using System.ComponentModel.DataAnnotations;

namespace Entities.Cart
{
    [MetadataType(typeof(CartItemMetaData))]
    public partial class CartItem
    {

    }
    public class CartItemMetaData
    {
        [Key]
        public string ItemId { get; set; }
        [Display(Name = "Carro")]
        public string CartId { get; set; }
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
        [Display(Name = "Fecha de Creación")]
        public System.DateTime DateCreated { get; set; }
        [Display(Name = "Producto")]
        public int ProductId { get; set; }

        public virtual Products Products { get; set; }
    }
}