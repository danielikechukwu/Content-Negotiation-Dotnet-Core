using System.Text.Json.Serialization;

namespace ContentNegotiationDemo.Models
{
    public class Student
    {
        [JsonIgnore]
        public int Id { get; set; } //Sensitive property

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        [JsonIgnore]
        public int Salary { get; set; } //Sensitive property

        public string Department { get; set; }

    }
}
