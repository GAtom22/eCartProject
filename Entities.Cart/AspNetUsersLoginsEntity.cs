using System.ComponentModel.DataAnnotations;

namespace Entities.Cart
{


    [MetadataType(typeof(AspNetUserLoginsMetaData))]
    public partial class AspNetUserLogins
    {

    }

    public class AspNetUserLoginsMetaData
    {
        [Key]
        public string ProviderKey { get; set; }

    }
}