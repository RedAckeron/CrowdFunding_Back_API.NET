namespace CrowdFundingAPI.Models
{
    public class ProjectContributorForm
    {
        public int IdProject { get; set; }
        public int IdUser { get; set; }
        public int Amount { get; set; }
    }
}
