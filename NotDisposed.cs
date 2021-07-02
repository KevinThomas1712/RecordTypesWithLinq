using System.IO;

namespace RecordTypesWithLinq
{
    public class NotDisposed
    {
        public string GetString(Stream stream)
        {
            StreamReader sr = new(stream);
            //This allows you to do one Read operation.
            return sr.ReadToEnd();
        }
    }
}
