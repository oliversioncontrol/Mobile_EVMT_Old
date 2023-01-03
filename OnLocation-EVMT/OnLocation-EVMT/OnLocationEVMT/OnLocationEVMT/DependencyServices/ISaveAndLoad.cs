using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.DependencyServices
{
    /// <summary>
    /// ISave And Load interface implementation
    /// </summary>
    public interface ISaveAndLoad
    {
        Task SaveTextAsync(string filename, string text);

        Task<string> LoadTextAsync(string filename);
    }
}
