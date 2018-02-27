using System;
using Xamarin.Forms;
using System.IO;
using System.Threading.Tasks;
using XamarinTest2.Droid;
using XamarinTest2.util;

[assembly: Dependency (typeof (SaveAndLoad_Android))]

namespace XamarinTest2.Droid
{
    class SaveAndLoad_Android : ISaveAndLoad
    {
        #region ISaveAndLoad implementation

        public bool FileExists(string filename)
        {
            return File.Exists(CreatePathToFile(filename));
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            var path = CreatePathToFile(filename);
            using (StreamReader sr = File.OpenText(path))
                return await sr.ReadToEndAsync();
        }

        public async Task SaveTextAsync(string filename, string text)
        {
            var path = CreatePathToFile(filename);
            using (StreamWriter sw = File.CreateText(path))
                await sw.WriteAsync(text);
        }

        #endregion 
        
        string CreatePathToFile(string  filename)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}