using System;
using System.ComponentModel.DataAnnotations;

namespace vNextAngularSPA.Model
{
    //[MetadataType(typeof(BookmarkedPlaceMetadata))] //Doesn't work in .NET 5.0 Core
    public partial class BookmarkedPlace
    {
        private sealed class BookmarkedPlaceMetadata
        {
            public int Id { get; set; }
            [StringLength(50)]
            public string UserName { get; set; }
            [StringLength(50)]
            public string VenueID { get; set; }
            [StringLength(100)]
            public string VenueName { get; set; }
            [StringLength(100)]
            public string Address { get; set; }
            [StringLength(100)]
            public string Category { get; set; }
            public Decimal Rating { get; set; }
            public DateTime? TS { get; set; }
        }
        public BookmarkedPlace() { }

    }
}