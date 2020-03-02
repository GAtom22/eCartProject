using System.ComponentModel.DataAnnotations;

namespace Entities.Cart
{

    [MetadataType(typeof(AspNetUserClaimsMetaData))]
    public partial class AspNetUserClaims
    {

    }

    public class AspNetUserClaimsMetaData
    {
        [Key]
        public int Id { get; set; }

    }
}
