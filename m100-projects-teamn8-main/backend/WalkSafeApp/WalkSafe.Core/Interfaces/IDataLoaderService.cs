using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkSafe.Core.Interfaces
{
    public interface IDataLoaderService
    {
        Task LoadDataAsync(string filePath);
    }
}
