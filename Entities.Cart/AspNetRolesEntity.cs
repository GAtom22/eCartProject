using System.ComponentModel.DataAnnotations;

namespace Entities.Cart
{

    [MetadataType(typeof(AspNetRolesMetaData))]
    public partial class AspNetRoles
    {

    }

    public class AspNetRolesMetaData
    {
        [Key]
        public string Id { get; set; }

    }
}