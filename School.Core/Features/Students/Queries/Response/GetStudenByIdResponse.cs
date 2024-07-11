namespace School.Core.Features.Students.Queries.Response
{
    public class GetStudenByIdResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string DepartmentName { get; set; }
    }
}
