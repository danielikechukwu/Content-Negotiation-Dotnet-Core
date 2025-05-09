namespace ContentNegotiationDemo.Models
{
    public class Student
    {
        public int Id { get; set; } //Sensitive property

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; } //Sensitive property

        public string Department { get; set; }

    }
}
