using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.iOS.CustomRenders;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoad_iOS))]
namespace OnLocationEVMT.iOS.CustomRenders
{
    public class SaveAndLoad_iOS : ISaveAndLoad
    {
        #region ISaveAndLoad implementation

        public async Task SaveTextAsync(string filename, string text)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, filename);

            // File.WriteAllText will create a file and then write text to it. If the
            // file already exists, File.WriteAllText will overwrite it.
            File.WriteAllText(filePath, text);
            await Task.Delay(10);

            //using (StreamWriter sw = File.CreateText(filename))
            //{
            //    await sw.WriteAsync(text);
            //}


        }

        public async Task<string> LoadTextAsync(string filename)
        {
            string text;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, filename);

            text = File.ReadAllText(filePath);
            //using (StreamReader sr = File.OpenText(filename))
            //{
            //    text = await sr.ReadToEndAsync();
            //}
            await Task.Delay(10);
            return text;
        }

        #endregion
    }
}