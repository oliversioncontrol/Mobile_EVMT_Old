using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.DependencyServices
{
    /// <summary>
    /// IScreenshotManager interface implementation
    /// </summary>
    public interface IScreenshotManager
    {
        Task<byte[]> CaptureAsync();
    }
}
