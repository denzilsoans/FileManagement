using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using DAL.Repositories.Interfaces;
using DAL.DTO;
using Microsoft.AspNetCore.Identity;
using DAL.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FileManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class HomeController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly IHomeRepository _homeRepository;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(IWebHostEnvironment hostingEnvironment,
                              IHomeRepository homeRepository,
                              UserManager<ApplicationUser> userManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _homeRepository = homeRepository;
            _userManager = userManager;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadFile")]
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string folderName = "FileUploads";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    ClaimsPrincipal currentUser = this.User;
                    var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                    ApplicationUser user = _userManager.FindByNameAsync(currentUserName).Result;

                    var userName = $"{ user.FirstName }{ user.LastName }";

                    FileMetadataDTO fileDTO = new FileMetadataDTO
                    {
                        FileName = fileName,
                        Location = fullPath,
                        UpdatedBy = userName
                    };

                    _homeRepository.SaveFileData(fileDTO);
                    return Ok("Upload Successful.");
                }

                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest("Upload Failed: " + ex.Message);
            }
        }
    }
}