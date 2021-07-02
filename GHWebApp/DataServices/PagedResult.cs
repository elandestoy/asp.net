using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GHWebApp.DataServices
{
    public class PagedResult<T>
    {
        public PagedResult(IEnumerable<T> result, int total)
        {
            Result = new ReadOnlyCollection<T>(new List<T>(result));
            Total = total;
        }

        public PagedResult()
            : this(new List<T>(), 0)
        {
        }

        #region Properties

        public ICollection<T> Result { get; private set; }
        public int Total { get; private set; }

        public bool IsEmpty
        {
            get { return (Result.Count == 0) || (Total == 0); }
        }

        #endregion
    }
}