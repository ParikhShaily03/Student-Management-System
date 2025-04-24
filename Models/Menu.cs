public class Menu
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
    public int? ParentId { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }
    public int SortOrder { get; set; }
    public bool IsSubMenu { get; set; }
    public bool IsExternal { get; set; }
    public string Target { get; set; }
    public string CssClass { get; set; }
}
