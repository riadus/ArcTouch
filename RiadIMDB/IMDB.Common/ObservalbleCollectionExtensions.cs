using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace IMDB.Common
{
    public static class ObservalbleCollectionExtensions
    {
        public static MvxObservableCollection<T> ToMvxObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new MvxObservableCollection<T>(enumerable);
        }
    }
}
