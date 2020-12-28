using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [DisableRequestSizeLimit]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> SaveFile(IFormFile file)
        {

            if(!file.ContentType.Equals("text/plain"))
            {
                return StatusCode((int)HttpStatusCode.UnsupportedMediaType);
            }


            var result = await _fileService.SaveFile(file);

            if (!result.Success)
            {
                return StatusCode((int)result.Code, result.Message);
            }

            await _fileService.SaveFileData(file, result.Data);

            return Ok(result.Data);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("GetFiles")]
        public async Task<IActionResult> GetFiles()
        {

            var result = await _fileService.GetFiles();

            if (!result.Success)
            {
                return StatusCode((int)result.Code, result.Message);
            }

            return Ok(result.Data);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("GetFileData")]
        public async Task<IActionResult> GetFileData(int id)
        {

            var result = await _fileService.GetFileData(id);

            if (!result.Success)
            {
                return StatusCode((int)result.Code, result.Message);
            }

            return Ok(result.Data);
        }
    }
}
