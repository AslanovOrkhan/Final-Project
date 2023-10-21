using BackendProject.Models.Common;

namespace BackendProject.Models;

public class Chef : BaseEntity
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Image { get; set; }
	public int ExperienceInYears { get; set; }
	public bool IsDeleted { get; set; }
	public ICollection<SocialMedia> SocialMedias { get; set; }

}
