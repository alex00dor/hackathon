namespace hachathon.Resource
{
    public class QueryUserResource
    {
        public int? PlanId { get; set; } = null;
        public int? StatusId { get; set; } = null;
        public string Name { get; set; } = null;
        public string Email { get; set; } = null;
        public string Address { get; set; } = null;
        public int Page { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 10;
    }
}