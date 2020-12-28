using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Services
{
   public interface IFileService
    {
        Task<ServiceResult<FileModel>> SaveFile(IFormFile model);
        Task<ServiceResult<FileRowModel>> SaveFileData(IFormFile model, FileModel fileModel);
        Task<ServiceResult<List<FileModel>>> GetFiles();
        Task<ServiceResult<List<FileRowModel>>> GetFileData(int id);
    }
}
