using BSD.Business.CrudInterfaces;
using BSD.Business.CrudServices;
using BSD.Business.Interfaces;
using BSD.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BSD.Business;

public static class AddBusinessServicesExtention
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IBankStatementExpenseService, BankStatementExpenseService>();
        services.AddScoped<IBankStatementInvoiceService, BankStatementInvoiceService>();
        services.AddScoped<IBankStatementService, BankStatementService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICompanyUserService, CompanyUserService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDocumentAttachmentService, DocumentAttachmentService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IDocumentTypeService, DocumentTypeService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IExpenseAttachmentService, ExpenseAttachmentService>();
        services.AddScoped<IExpensePriceService, ExpensePriceService>();
        services.AddScoped<IExpenseProductService, ExpenseProductService>();
        services.AddScoped<IExpenseService, ExpenseService>();
        services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
        services.AddScoped<IExperienceAttachmentService, ExperienceAttachmentService>();
        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<IExperienceTechnologyService, ExperienceTechnologyService>();
        services.AddScoped<IInvoiceAttachmentService, InvoiceAttachmentService>();
        services.AddScoped<IInvoiceEmailService, InvoiceEmailService>();
        services.AddScoped<IInvoicePriceService, InvoicePriceService>();
        services.AddScoped<IInvoiceProductService, InvoiceProductService>();
        services.AddScoped<IInvoiceRowService, InvoiceRowService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IInvoiceTransactionService, InvoiceTransactionService>();
        services.AddScoped<IInvoiceTypeService, InvoiceTypeService>();
        services.AddScoped<IInvoiceWorkorderService, InvoiceWorkorderService>();
        services.AddScoped<IProductPriceService, ProductPriceService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<IResidenceService, ResidenceService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<ITaxRateService, TaxRateService>();
        services.AddScoped<ITechnologyAttachmentService, TechnologyAttachmentService>();
        services.AddScoped<ITechnologyService, TechnologyService>();
        services.AddScoped<ITrafficRegistrationService, TrafficRegistrationService>();
        services.AddScoped<ITransactionLogParameterService, TransactionLogParameterService>();
        services.AddScoped<ITransactionLogService, TransactionLogService>();
        services.AddScoped<ITransactionParameterService, TransactionParameterService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWorkorderAttachmentService, WorkorderAttachmentService>();
        services.AddScoped<IWorkorderService, WorkorderService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IForgotPasswordService, ForgetPasswordService>();
    }
}