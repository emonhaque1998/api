namespace freelancereman.Models
{
    public static class ProjectRepository
    {
        public static List<Project> Projects { get; set; } = new List<Project>() {
            new Project
            {
                Id = 1,
                ProjectName = "This site build using Laravel",
                Description = "This site build using Laravel This site build using Laravel This site build using Laravel",
                Slug = "this-site-build-laravel"
            },
            new Project
            {
                Id = 2,
                ProjectName = "This site build using Wordpress",
                Description = "This site build using Laravel This site build using Laravel This site build using Laravel",
                Slug = "this-site-build-wordpress"
            }
        };
    }
}
