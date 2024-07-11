using System.ComponentModel.DataAnnotations;

namespace School.Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        public int DID { get; set; }
        public string DName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
    }
}
