using System;
namespace OnLocationEVMT.DependencyServices
{
    public interface IDownloadService
    {
        byte[] DownloadImage(string URL,string name);
    }
}
