using CloudSuite.Marketing.Modules.Domain.Models;

namespace CloudSuite.Marketing.Modules.Domain.Contracts
{
    public interface ISearchResultRepository
    {
        Task<SearchResult> GetByWord(string wordKey);

        Task<SearchResult> GetByPage(string pageurl);

        Task<SearchResult> GetByPosition(string position);

        Task<IEnumerable<SearchResult>> GetList();

        Task Add(SearchResult searchResult);

        void Update(SearchResult searchResult);

        void Remove(SearchResult searchResult);
    }
}