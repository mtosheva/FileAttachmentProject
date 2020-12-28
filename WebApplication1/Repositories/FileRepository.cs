using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repositories
{
    public class FileRepository: IFileRepository
    {

        private readonly MyDBContext _myDbContext = new MyDBContext();

        public async Task<FileModel> AddItemAsync(FileModel item)
        {

            await _myDbContext.AddAsync<FileModel>(item);
            await _myDbContext.SaveChangesAsync();

            return item;
        }

        public async Task<FileRowModel> AddItemAsync(FileRowModel item)
        {

            await _myDbContext.AddAsync<FileRowModel>(item);
            await _myDbContext.SaveChangesAsync();

            return item;
        }

        public async Task<List<FileModel>> GetFilesAsync()
        {

            var files = await _myDbContext.File.OrderByDescending(x=>x.Date).ToListAsync();
            return files;
        }

        public async Task<List<FileRowModel>> GetFileDataAsync(int id)
        {

            var files = await _myDbContext.FilesRows.Where(x=>x.FileFK == id).ToListAsync();
            return files;
        }
    }
}
