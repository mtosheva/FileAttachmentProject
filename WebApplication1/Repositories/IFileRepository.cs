using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public interface IFileRepository
    {
        Task<FileModel> AddItemAsync(FileModel item);
        Task<FileRowModel> AddItemAsync(FileRowModel item);
        Task<List<FileModel>> GetFilesAsync();
        Task<List<FileRowModel>> GetFileDataAsync(int id);

    }
}
