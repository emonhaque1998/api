using freelancereman.Models;
using Microsoft.AspNetCore.Mvc;

namespace freelancereman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("All", Name = "GetAllProjects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjects()
        {
            var projects = ProjectRepository.Projects.Select(s => new ProjectDTO()
            {
                Id = s.Id,
                ProjectName = s.ProjectName,
                Description = s.Description,
                Slug = s.Slug,
            });
            return Ok(projects);
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetProjectById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ProjectDTO> GetProjectByID(int id)
        {
            //Cleint error for bad request - 400
            if (id <= 0)
                return BadRequest();

            var project = ProjectRepository.Projects.Where(n => n.Id == id).FirstOrDefault();

            if(project == null)
                return NotFound($"This id {id} data not found!");

            var projectDTO = new ProjectDTO()
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Description = project.Description,
                Slug = project.Slug,    
            };

            return Ok(projectDTO);
        }

        [HttpDelete("{id}", Name = "DeleteProjectById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteProject(int id)
        {
            if (id <= 0)
                return BadRequest();

            var project = ProjectRepository.Projects.Where(n => n.Id == id).FirstOrDefault();

            if (project == null)
                return NotFound();

            ProjectRepository.Projects.Remove(project);

            return true;
        }
    }
}
