// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrimacyApp.BusinessLogic.Implementation;
using PrimacyApp.BusinessLogic.Interface;
using PrimacyApp.Models.Data;
using PrimacyApp.Models.Data_Structure;
using PrimacyApp.Utilities.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace PrimacyApp
{
    public class Program
    {

        public static Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            if (args.Length == 0)
            {
                ManageFolderWithDependencyInjection(host.Services, Constants.DEFAULT_DIRECTORY);
            }
            else
            {
                ManageFolderWithDependencyInjection(host.Services, args[0]);
            }
            return host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddTransient<IHashTable<string, FileValue>, HashTable<string, FileValue>>()
                        .AddTransient<IFolderManager, FolderManager>());
        }

        private static void ManageFolderWithDependencyInjection(IServiceProvider services, string directory)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            var folderManager = provider.GetRequiredService<IFolderManager>();

            folderManager.LoadFolder(directory);
            var duplicateFiles = folderManager.GetDuplicateFiles();

            if (duplicateFiles != null)
            {
                Console.WriteLine("The folowing is a list of the duplicated files" + Environment.NewLine);
                foreach (var duplicateFile in duplicateFiles)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    var item = duplicateFile.Head;
                    while (item != null)
                    {
                        Console.WriteLine($"File path: {item.Value.Name}");
                        item = item.Next;
                    }
                    Console.WriteLine("---------------------------------------------------------");
                }
                Console.WriteLine(Environment.NewLine);
            }
        }
    }
}