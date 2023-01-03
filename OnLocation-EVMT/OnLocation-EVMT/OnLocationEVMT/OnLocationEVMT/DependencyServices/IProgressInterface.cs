using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.DependencyServices
{
    /// <summary>
    /// IProgressInterface interface implementation
    /// </summary>
    public interface IProgressInterface
    {
        void Show(string title = "Please Wait...");
        void Hide();
    }
}
