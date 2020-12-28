using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<ServiceResult<FileModel>> SaveFile(IFormFile file)
        {
            var serviceResult = new ServiceResult<FileModel>();

            try
            {

                FileModel fileModel = new FileModel(file.FileName);

                serviceResult.Data = await _fileRepository.AddItemAsync(fileModel);

                serviceResult.Code = HttpStatusCode.Created;
                serviceResult.Success = true;

            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.Code = HttpStatusCode.InternalServerError;
                serviceResult.Message = ex.Message;
            }

            return serviceResult;
        }
        public async Task<ServiceResult<FileRowModel>> SaveFileData(IFormFile file, FileModel fileModel)
        {
            var serviceResult = new ServiceResult<FileRowModel>();
            String result = "";
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result = reader.ReadLine();
                    var list = result.Split(',');
                    if (list.Length != 3)
                    {
                        continue;
                    }
                    try
                    {
                        var fileRowModel = new FileRowModel(list[0], int.Parse(list[1]), list[2], fileModel);

                        serviceResult.Data = await _fileRepository.AddItemAsync(fileRowModel);

                        serviceResult.Code = HttpStatusCode.Created;

                        serviceResult.Success = true;
                    }

                    catch (Exception ex)
                    {
                        serviceResult.Success = false;
                        serviceResult.Code = HttpStatusCode.InternalServerError;
                        serviceResult.Message = ex.Message;
                    }


                }

            }
            return serviceResult;
        }

        public async Task<ServiceResult<List<FileModel>>> GetFiles()
        {
            var serviceResult = new ServiceResult<List<FileModel>>();

            try
            {

                serviceResult.Data = await _fileRepository.GetFilesAsync();
                serviceResult.Code = HttpStatusCode.Created;
                serviceResult.Success = true;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.Code = HttpStatusCode.InternalServerError;
                serviceResult.Message = ex.Message;
            }

            return serviceResult;
        }

        public async Task<ServiceResult<List<FileRowModel>>> GetFileData(int id)
        {
            var serviceResult = new ServiceResult<List<FileRowModel>>();

            try
            {

                serviceResult.Data = await _fileRepository.GetFileDataAsync(id);
                serviceResult.Code = HttpStatusCode.Created;
                serviceResult.Success = true;
            }
            catch (Exception ex)
            {
                serviceResult.Success = false;
                serviceResult.Code = HttpStatusCode.InternalServerError;
                serviceResult.Message = ex.Message;
            }

            return serviceResult;
        }


    }

}

