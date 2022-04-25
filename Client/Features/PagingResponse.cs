using HogeBlazor.Shared.RequestFeatures;

namespace HogeBlazor.Client.Features;

public class PagingResponse<T> where T : class
{
    public List<T> Items { get; set; } = new List<T>();
    public MetaData MetaData { get; set; }
}