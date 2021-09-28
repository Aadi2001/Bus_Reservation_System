//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReservationApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusDetails()
        {
            this.ScheduleDetails = new HashSet<ScheduleDetails>();
            this.BookingDetails = new HashSet<BookingDetails>();
        }
    
        public int BusId { get; set; }
        public string BusNo { get; set; }
        public string BusType { get; set; }
        public int TotalSeats { get; set; }
        public string BusName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleDetails> ScheduleDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
