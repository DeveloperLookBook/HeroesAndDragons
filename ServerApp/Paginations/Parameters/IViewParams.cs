namespace ServerApp.Paginations
{
    public interface IViewParams
    {
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
        int MaxPageNumber { get; }
        int MaxPageSize { get; }
        int MinPageNumber { get; }
        int MinPageSize { get; }
        int ModelsCount { get; }
        int PageNumber { get; set; }
        int PageSize { get; set; }

        IViewParams Clone();
        int Skip();
    }
}