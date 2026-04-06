using CEJ_WebApp.Model;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface ILegalProcessCategoryTypeService
    {
        Task<CourtDivisionEntity> GetByUuid(Guid uuid);

        Task<CourtDivisionEntity> GetById(long id);

        Task<IEnumerable<CourtDivisionEntity>> GetAll();

        Task<IEnumerable<CourtDivisionEntity>> GetByCategoryId(long categoryId);
    }
}
