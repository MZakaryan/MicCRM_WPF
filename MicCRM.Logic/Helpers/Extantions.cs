using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicCRM.Logic.Helpers
{
  public static class Extantions
    {
        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> list)
        {
            ObservableCollection<T> obs = new ObservableCollection<T>();
            foreach (var item in list)
            {
                obs.Add(item);
            }
            return obs;
        }
    }
}
