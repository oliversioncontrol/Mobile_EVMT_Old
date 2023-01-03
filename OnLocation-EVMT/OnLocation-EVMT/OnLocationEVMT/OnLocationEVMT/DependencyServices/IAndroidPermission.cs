
namespace OnLocationEVMT.DependencyServices
{
    /// <summary>
    /// IAndroidPermission interface implementation
    /// </summary>
    public interface IAndroidPermission
    {
        void GrantPermission(int iPermissionindex = -1);

        bool CheckPermission(int iPermissionindex);

        bool CheckIsNeverAskAgain(int permissionindex);

        void OpenAppDetails();
    }
}
