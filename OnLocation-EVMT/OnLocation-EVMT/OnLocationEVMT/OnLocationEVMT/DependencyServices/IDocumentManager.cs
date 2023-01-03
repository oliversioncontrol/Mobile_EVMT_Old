using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.DependencyServices
{
    /// <summary>
    /// /// <summary>
    /// IDocumentManager interface implementation
    /// </summary>
    /// </summary>
    public interface IDocumentManager
    {
        void SaveFile(byte[] rawData, string strFileName);
    }
}
