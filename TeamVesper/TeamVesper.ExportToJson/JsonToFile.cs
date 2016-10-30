using System;
using System.Collections.Generic;
using System.IO;
using TeamVesper.ExportToJson.Contracts;
using TeamVesper.Models;
using TeamVesper.Repositories.Contracts;

namespace TeamVesper.ExportToJson
{
    public class JsonToFile<TEntity> : IReporter<TEntity>
        where TEntity : Developer
    {
        private string folderPath;
        private IJsonSeriliazer seriliazer;
        private string type;

        public JsonToFile(string folderPath, IJsonSeriliazer seriliazer = null)
        {
            this.FolderPath = folderPath;
            this.Seriliazer = seriliazer;
            this.type = typeof(TEntity).Name;
        }

        private string FolderPath
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Directory path");
                }

                if (value == string.Empty)
                {
                    throw new ArgumentException("Direcotry path cannot be empty string!");
                }

                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }

                this.folderPath = value;
            }
        }

        private IJsonSeriliazer Seriliazer
        {
            set
            {
                if (value == null)
                {
                    this.seriliazer = new JsonSeriliazer();
                }
                else
                {
                    this.seriliazer = value;
                }
            }
        }

        public void ReportMany(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.ReportSingle(entity);
            }
        }

        public void ReportSingle(TEntity entity)
        {
            var json = this.seriliazer.Seriliaze(entity);

            var writer = new StreamWriter(this.folderPath + "/" + this.type + entity.Id + ".json", false);

            using (writer)
            {
                writer.Write(json);
            }
        }
    }
}
