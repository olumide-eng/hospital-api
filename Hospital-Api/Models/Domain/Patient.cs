namespace Hospital_Api.Models.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }


    }
}
