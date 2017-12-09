using System.Net.Http;
using Newtonsoft.Json;

namespace Utilities
{
    /// <summary>
    /// Set of functions which help when dealing with Multipart type contents 
    /// </summary>
    public static class MultipartFileHelper
    {
        /// <summary>
        /// Returns the name of a file
        /// </summary>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public static string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        private static string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}