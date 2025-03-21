namespace Student_Management_System.Models.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }


    }
    public class Add_EditDTO
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Department { get; set; }


    }
}
