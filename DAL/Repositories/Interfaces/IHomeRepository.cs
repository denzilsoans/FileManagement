using DAL.DTO;
using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IHomeRepository : IRepository<FileData>
    {
        void SaveFileData(FileMetadataDTO fileMetadata);
    }
}