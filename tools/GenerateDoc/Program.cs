using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tmds.LibC;

namespace GenerateDoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var methodNames = new List<string>();
            var methods = typeof(Definitions).GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var method in methods)
            {
                // Skip property getters
                bool isGetAccessor = method.DeclaringType.GetProperties() 
                    .Any(prop => prop.GetGetMethod() == method);
                if (isGetAccessor)
                {
                    continue;
                }

                // Skip MACRO functions
                if (method.Name == method.Name.ToUpper())
                {
                    continue;
                }

                methodNames.Add(method.Name);
            }

            // Sort
            methodNames.Sort();
            methodNames = methodNames.Distinct().ToList();

            var sb = new StringBuilder();
            using (HttpClient httpClient = new HttpClient())
            {
                foreach (var methodName in methodNames)
                {
                    string url = string.Empty;

                    string man2url = $"http://man7.org/linux/man-pages/man2/{methodName}.2.html";
                    string man3url = $"http://man7.org/linux/man-pages/man3/{methodName}.3.html";

                    if (await IsValidManPage(httpClient, man3url))
                    {
                        url = man3url;
                    }
                    else if (await IsValidManPage(httpClient, man2url))
                    {
                        url = man2url;
                    }

                    if (string.IsNullOrEmpty(url))
                    {
                        sb.Append($"{methodName}, ");
                    }
                    else
                    {
                        sb.Append($"[{methodName}]({url}), ");
                    }
                }
            }

            string readme = File.ReadAllText("../../README.md.in");

            readme = readme.Replace("##FUNCTIONS##", sb.ToString());

            File.WriteAllText("../../README.md", readme);
        }

        private async static Task<bool> IsValidManPage(HttpClient httpClient, string url)
        {
            try
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                return false;
            }
        }
    }
}
