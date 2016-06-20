namespace Entities
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Location Location { get; set; }

        public override string ToString()
        {
            return $"{DepartmentName} ({Location.City})";
        }
    }
}
