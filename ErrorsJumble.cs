using System;
using System.Collections.Concurrent;

namespace RecordTypesWithLinq
{
    public static class ErrorsJumble
    {
        private static readonly ConcurrentBag<string> concurrentBag = new();
        public static string JsonFake(string json)
        {
            concurrentBag.Add(json);
            var njson = JsonProcess(json);

            foreach (var x in concurrentBag)
            {
                Console.WriteLine(x);
            }

            concurrentBag.Clear();

            return njson;
        }

        private static string JsonProcess(string json)
        {
            concurrentBag.Add(json);
            return json;
        }
    }
}
