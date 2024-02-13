using LeagueTables.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeagueTables.Data.Entities;

[EntityTypeConfiguration(typeof(UserConfiguration))]
public class UserEntity : IdentityUser<Guid>
{
    public ICollection<TeamEntity> FavoriteTeams { get; set; } = new List<TeamEntity>();
}
