namespace Student_Management_System.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int? ParentId { get; set; } // null for top-level menus
        public string Role { get; set; }   // Example: "Admin", "User", etc.
        public bool IsActive { get; set; }
    }


}
