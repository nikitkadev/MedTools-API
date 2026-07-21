namespace Infrastructure.Database.Enitites.Auth;

public class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }

    public string Description { get; set; } = string.Empty;
    public string? DisplayName { get; set; }

    public bool IsSystem { get; set; } = false;
    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } 
    public DateTime UpdatedAt { get; set; }

    public List<UserRoleEntity> UserRoles { get; set; } = [];
}
