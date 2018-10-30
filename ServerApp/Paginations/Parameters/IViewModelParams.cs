namespace ServerApp.Paginations
{
    public interface IViewModelParams
    {
        int MaxPageSize { get; }
        int MinPageSize { get; }
        int PageNumber  { get; set; }
        int PageSize    { get; set; }
    }
}