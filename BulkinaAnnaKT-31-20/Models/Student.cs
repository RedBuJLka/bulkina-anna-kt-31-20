namespace BulkinaAnnaKT_31_20.Models
{
    public class Student
    {   
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Patronym { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
