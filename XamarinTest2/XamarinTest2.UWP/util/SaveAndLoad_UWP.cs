using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XamarinTest2.util;
using XamarinTest2.UWP;


[assembly: Dependency(typeof(SaveAndLoad_UWP))]
namespace XamarinTest2.UWP
{
    class SaveAndLoad_UWP : ISaveAndLoad
    {

        #region ISaveAndLoad implementation

        public bool FileExists(string filename)
        {
            var localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                localFolder.GetFileAsync(filename).AsTask().Wait();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<string> LoadTextAsync(string filename)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
            return text;
        }

        public async Task SaveTextAsync(string filename, string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
        }

        #endregion
    }
}
