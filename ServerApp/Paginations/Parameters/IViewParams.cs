namespace ServerApp.Paginations
{
    public interface IViewParams
    {
        bool HasNextPage     { get; }
        bool HasPreviousPage { get; }
        int  MaxPageNumber   { get; set; }
        int  MaxPageSize     { get; }
        int  MinPageNumber   { get; }
        int  MinPageSize     { get; }
        int  PageNumber      { get; set; }
        int  PageSize        { get; set; }

        int  Skip();

        IViewParams Clone();
    }
}