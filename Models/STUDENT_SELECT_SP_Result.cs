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

    public partial class STUDENT_SELECT_SP_Result
    {
        [DisplayName("BATCH ID")]
        public Nullable<int> BATCH_ID { get; set; }
        [DisplayName("STUDENT ID")]
        public int STUDENT_ID { get; set; }
        [DisplayName("STUDENT NAME")]
        public string STUDENT_NAME { get; set; }
        [DisplayName("STUDENT AGE")]
        public Nullable<int> STUDENT_AGE { get; set; }
        [DisplayName("STUDENT EMAILID")]
        public string STUDENT_EMAILID { get; set; }
    }
}
