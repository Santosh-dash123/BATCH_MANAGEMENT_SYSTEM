using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Student_select
    {
        [DisplayName("BATCH ID")]
        public Nullable<int> BATCH_ID { get; set; }

        [DisplayName("BATCH NAME")]
        public string BATCH_NAME { get; set; }

        [DisplayName("STUDENT ID")]
        public int STUDENT_ID { get; set; }

        [DisplayName("STUDENT NAME")]
        public string STUDENT_NAME { get; set; }

        [DisplayName("STUDENT AGE")]
        public Nullable<int> STUDENT_AGE { get; set; }

        [DisplayName("STUDNET EMAILID")]
        public string STUDENT_EMAILID { get; set; }
    }
}