using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ReviewManagerEntities
{
    public class Expert
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        [StringLength(500)]
        [DefaultValue("")]
        public string Description { get; set; }

        [StringLength(200)]
        [Index("UrlIndex", IsUnique = true)]
        [Required]
        public string Url { get; set; }

        [StringLength(200)]
        public string Name { get; set; }


        [StringLength(200)]
        public string ListingTitle { get; set; }

        [StringLength(400)]
        public string Slogan { get; set; }

        public int? InBusinessSince { get; set; }

        [Required]
        public int ServiceRadius { get; set; }

        #region contactPoint
        [StringLength(200)]
        //  [Index("EmailIndex",IsClustered =false, IsUnique = true)]
        public string Email { get; set; }

        [StringLength(10)]
        public string FaxNumber { get; set; }

        [StringLength(10)]
        public string Telephone { get; set; }

        [StringLength(200)]
        public string WebSite { get; set; }
        #endregion

        #region NavigationProperties
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        // An image of the item. This can be a URL or a fully described ImageObject
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        #endregion
    }

    public class Image 
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AlternateName { get; set; }
        public string Title { get; set; }              
    }
}
