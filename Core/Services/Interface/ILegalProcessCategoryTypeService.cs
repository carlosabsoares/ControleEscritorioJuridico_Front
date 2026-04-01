using CEJ_WebApp.Model;

namespace CEJ_WebApp.Core.Services.Interface
{
    public interface ILegalProcessCategoryTypeService
    {
        Task<LegalProcessCategoryTypeEntity> GetByUuid(Guid uuid);

        Task<LegalProcessCategoryTypeEntity> GetById(long id);

        Task<IEnumerable<LegalProcessCategoryTypeEntity>> GetAll();

        Task<IEnumerable<LegalProcessCategoryTypeEntity>> GetByCategoryId(long categoryId);
    }
}
