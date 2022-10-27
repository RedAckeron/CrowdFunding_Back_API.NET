namespace CrowdFundingAPI.Models
{
    public class ProjectForm
    {
		public int Id { get; set; }
		public int IdOwner { get; set; }
		public string Title { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Goal { get; set; }

		public DateTime BeginDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsValidate { get; set; }
	}
}
