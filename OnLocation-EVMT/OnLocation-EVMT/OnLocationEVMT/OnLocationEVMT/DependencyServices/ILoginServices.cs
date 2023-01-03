using System.Threading.Tasks;

namespace OnLocationEVMT.DependencyServices
{
    /// <summary>
    /// ILoginServices interface implementation
    /// </summary>
    public interface ILoginServices
    {
        Task<int> VerfiyLogin(string UserName,string Password);
    }
}
