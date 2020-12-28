using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1
{
    public class FileRowModel
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }
        public string Color { get; set; }

        public int Number { get; set; }
        public string Label { get; set; }

        public FileModel FileModel { get; set; }

        [ForeignKey("FileModel")]
        public int FileFK { get; set; }

        private FileRowModel() { }

        public FileRowModel(string color,int number, string label, FileModel file)
        {
            setColor(color);
            Number = number;
            Label = label;
            FileModel = file;
        }

        private void setColor(string color)
        {

            ColorsEnum colorDefined = (ColorsEnum)Enum.Parse(typeof(ColorsEnum), color);

            if (!Enum.IsDefined(typeof(ColorsEnum), colorDefined))
            {
                throw new InvalidOperationException();
            }
            else
            {

                Color = color.Trim();
            }
        }

        private void setNumber(int numberVal)
        {

            Number = numberVal;
        }

    }
}
