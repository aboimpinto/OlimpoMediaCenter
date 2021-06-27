using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AvaloniaUI.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddEntities<TEntity>(this ObservableCollection<TEntity> observable, List<TEntity> entities)
        {
            observable.Clear();

            foreach(var entity in entities)
            {
                observable.Add(entity);
            }
        }
    }
}
