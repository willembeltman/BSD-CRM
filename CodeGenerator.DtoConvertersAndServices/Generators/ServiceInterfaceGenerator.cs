namespace CodeGenerator.Dtos_Converters_Services.Generators;

public class ServiceInterfaceGenerator : BaseGenerator
{
    public ServiceInterfaceGenerator(
        ServiceHandlerGenerator serviceHandler,
        DirectoryInfo dtoConvertersDirectory,
        string dtoConvertersNamespace)
    {
    }

    public void GenerateCode()
    {
        //using BSD.Shared.RequestDtos;
        //using BSD.Shared.ResponseDtos;

        //namespace BSD.Business.Interfaces;

        //public interface ICompanyService
        //{
        //    CompanyCreateResponse Create(CompanyCreateRequest request);
        //    CompanyDeleteResponse Delete(CompanyDeleteRequest request);
        //    CompanyListResponse List(CompanyListRequest request);
        //    CompanyReadResponse Read(CompanyReadRequest request);
        //    CompanyUpdateResponse Update(CompanyUpdateRequest request);
        //}
    }
}