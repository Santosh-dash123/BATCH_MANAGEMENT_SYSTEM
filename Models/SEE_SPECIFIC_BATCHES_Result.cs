//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class SEE_SPECIFIC_BATCHES_Result
    {
        [DisplayName("COURSE ID")]
        public Nullable<int> COURSE_ID { get; set; }
        [DisplayName("BATCH ID")]
        public int BATCH_ID { get; set; }
        [DisplayName("BATCH NAME")]
        public string BATCH_NAME { get; set; }
        [DisplayName("BATCH DURATION")]
        public string BATCH_DURATION { get; set; }
    }
}
