using CodeGenerator.Dtos_Converters_Services.Generators;

namespace CodeGenerator.Step1.DtosConvertersAndServices.Generators
{
    public class BaseResponseGenerator : BaseGenerator
    {
        public BaseResponseGenerator(StateDtoGenerator stateDto, DirectoryInfo requestDtoDirectory, string requestDtoNamespace)
        {
            StateDto = stateDto;
            Directory = requestDtoDirectory;
            Namespace = requestDtoNamespace;

            BaseRequest = StateDto.BaseRequest;

            Name = "BaseResponse";
        }

        public StateDtoGenerator StateDto { get; }
        public string Namespace { get; }

        public BaseRequestGenerator BaseRequest { get; }

        public void GenerateCode()
        {
            //using BSD.Shared.Dtos;
            //using CodeGenerator.Shared.Attributes;

            //namespace BSD.Shared.ResponseDtos;

            //[TsHidden]
            //public class BaseResponse
            //{
            //    public bool Success { get; set; }
            //    public bool ErrorGettingState { get; set; }
            //    public bool ErrorNotAuthorized { get; set; }
            //    public bool ErrorItemNotFound { get; set; }
            //    public bool ErrorAlreadyUsed { get; set; }
            //    public bool ErrorAttachingState { get; set; }
            //    public bool ErrorUpdatingState { get; set; }

            //    public State State { get; set; } = new State();
            //}

            Code = $@"using {StateDto.Namespace};
using CodeGenerator.Shared.Attributes;

namespace {Namespace};

[TsHidden]
public class {Name}
{{
    public bool Success {{ get; set; }}
    public bool ErrorGettingState {{ get; set; }}
    public bool ErrorNotAuthorized {{ get; set; }}
    public bool ErrorItemNotFound {{ get; set; }}
    public bool ErrorAlreadyUsed {{ get; set; }}
    public bool ErrorAttachingState {{ get; set; }}
    public bool ErrorUpdatingState {{ get; set; }}

    public {StateDto.Name} {StateDto.Name} {{ get; set; }} = new {StateDto.Name}();
}}";

            Save();
        }
    }
}