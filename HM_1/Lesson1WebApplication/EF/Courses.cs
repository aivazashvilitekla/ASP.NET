namespace Lesson1WebApplication.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            CourseStream = new HashSet<CourseStream>();
        }

        public int ID { get; set; }

        public int CurriculumID { get; set; }

        public int PersonLimit { get; set; }

        [Column(TypeName = "date")]
        public DateTime AnnouncementDate { get; set; }

        public virtual Curriculum Curriculum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourseStream> CourseStream { get; set; }
    }
}
