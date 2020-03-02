using System.ComponentModel.DataAnnotations;

namespace Entities.Cart
{

    [MetadataType(typeof(AspNetUsersMetaData))]
    public partial class AspNetUsers
    {

    }

    public class AspNetUsersMetaData
    {
        [Key]
        public string Id { get; set; }

    }
}