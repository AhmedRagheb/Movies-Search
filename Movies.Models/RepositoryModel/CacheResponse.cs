
namespace Movies.Models.RepositoryModel
{
    public class CacheResponse<T>
    {
        public bool IsLoadedFromCache { get; set; }
        public T Obj { get; set; }
    }
}
