using Android.Content;
using Android.Support.V4.Content;
using OnLocationEVMT.DependencyServices;
using System;
using System.IO;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(OnLocationEVMT.Droid.CustomRenders.DocumentManage))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    public class DocumentManage : IDocumentManager
    {
        /// <summary>
        /// Method for Save PDF file
        /// </summary>
        /// <param name="fileData"></param>
        /// <param name="sFileName"></param>
        public void SaveFile(byte[] rawData, string strFileName)
        {
            try
            {
                string directory = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDownloads);
                string file = Path.Combine(directory, strFileName);
                //FileStream fileStream = new FileStream(file, FileMode.Create);
                //var imgFile = new Java.IO.File(file);
                //var stream = new Java.IO.FileInputStream(imgFile);
                //var bytes = new byte[imgFile.Length()];
                //stream.Read(bytes);
                File.WriteAllBytes(file, rawData);
                //Device.OpenUri(new Uri(file)); //Use This for PDF(s) Only.

                Java.IO.File dfile = new Java.IO.File(file);
                //Intent intent = new Intent();
                //intent.AddFlags(ActivityFlags.NewTask);
                //intent.SetAction(Intent.ActionView);

                String type = GetMimeTypeFromPath(file);
                //intent.SetDataAndType(Android.Net.Uri.FromFile(dfile), type);
                var  path = dfile.AbsolutePath;
                Intent install = new Intent();
               //install.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
                Android.Net.Uri apkURI = FileProvider.GetUriForFile(MainActivity.thisContext,  MainActivity.thisContext.PackageName+ ".fileprovider", dfile);
                install.SetDataAndType(apkURI, type);
                install.AddFlags(ActivityFlags.GrantReadUriPermission);

                MainActivity.thisContext.StartActivity(install);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        /// <summary>
        /// getting the type of extension
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetMimeTypeFromPath(string url)
        {
            try
            {
                if (url.Contains(".doc") || url.Contains(".docx"))
                {
                    // Word document
                    return "application/msword";
                }
                else if (url.Contains(".pdf"))
                {
                    // PDF file
                    return "application/pdf";
                }
                else if (url.Contains(".ppt") || url.Contains(".pptx"))
                {
                    // Powerpoint file
                    return "application/vnd.ms-powerpoint";
                }
                else if (url.Contains(".xls") || url.Contains(".xlsx"))
                {
                    // Excel file
                    return "application/vnd.ms-excel";
                }
                else if (url.Contains(".zip") || url.Contains(".rar"))
                {
                    // WAV audio file
                    return "application/x-wav";
                }
                else if (url.Contains(".rtf"))
                {
                    // RTF file
                    return "application/rtf";
                }
                else if (url.Contains(".txt"))
                {
                    // Text file
                    return "text/plain";
                }
                else
                {
                    //if you want you can also define the intent type for any other file
                    //additionally use else clause below, to manage other unknown extensions
                    //in this case, Android will show all applications installed on the device
                    //so you can choose which application to use
                    return "*/*";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "*/*";
            }
        }
    }
}