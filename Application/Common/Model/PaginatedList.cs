using Microsoft.EntityFrameworkCore;

namespace Application.Common.Model
{
    public class PaginatedList<T> : List<T>
    {
        public MetaData MetaData { get; private set; }
        private PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData(pageNumber, pageSize, count);
            AddRange(items);
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var count = await source.CountAsync(cancellationToken);
            var items = await source.Skip((pageNumber-1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
