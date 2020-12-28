using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1
{
    public class FileModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get;  set; }
        public DateTime Date { get;  set; }

        public string FileName { get;  set; }

        private FileModel()
        {
        
        }
        public FileModel(string name)
        {
            Date = DateTime.Now;
            FileName = name;
        }

        //private void setFileDate()
        //{
        //    Date = DateTime.Now;
        //}
        //private void setFinaName(string name)
        //{
        //    FileName = "sdfsd";
        //}
    }
}
