using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Batch_select
    {
        [DisplayName("COURSE ID")]
        public Nullable<int> COURSE_ID { get; set; }
        [DisplayName("BATCH ID")]
        public int BATCH_ID { get; set; }
        [DisplayName("COURSE NAME")]
        public string COURSE_NAME { get; set; }
        [DisplayName("BATCH NAME")]
        public string BATCH_NAME { get; set; }
        [DisplayName("BATCH DURATION")]
        public string BATCH_DURATION { get; set; }
        [DisplayName("TEACHER NAME")]
        public string TEACHER_NAME { get; set; }
    }
}