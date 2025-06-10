namespace BSD.Shared.ResponseDtos
{
    public class DeleteMyselfResponse : BaseResponse
    {
        public bool ErrorOnlyDeletesToYourselfAreAllowed { get; set; }
    }
}
