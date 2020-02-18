using DAL.Repositories.Interfaces;
using DAL.DTO;
using DAL.Entities;
using System;

namespace DAL.Repositories
{
    public class HomeRepository : Repository<FileData>, IHomeRepository
    {
        public HomeRepository(ApplicationDbContext context) : base(context)
        { }

        public void SaveFileData(FileMetadataDTO fileMetadata)
        {
            FileData fileData = new FileData {
                FileName = fileMetadata.FileName,
                Location = fileMetadata.Location,
                UploadedOn = DateTime.Now,
                UpdatedBy = fileMetadata.UpdatedBy
            };

            Add(fileData);
        }
    }
}
