using OnLocationEVMT.DependencyServices;
using OnLocationEVMT.Droid.CustomRenders;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Diagnostics;

[assembly: Dependency(typeof(SaveAndLoadAndroid))]
namespace OnLocationEVMT.Droid.CustomRenders
{
    public class SaveAndLoadAndroid : ISaveAndLoad
    {
        public async Task<string> LoadTextAsync(string filename)
        {
            try
            {
                string textData;
                var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(docsPath, filename);

                using (StreamReader sr = File.OpenText(path))
                {
                    textData = await sr.ReadToEndAsync();
                }
                return textData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task SaveTextAsync(string filename, string text)
        {
            try
            {
                var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var path = Path.Combine(docsPath, filename);

                using (StreamWriter sw = File.CreateText(path))
                {
                    await sw.WriteAsync(text);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}