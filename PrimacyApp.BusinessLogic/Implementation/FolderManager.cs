using PrimacyApp.BusinessLogic.Interface;
using PrimacyApp.Models.Data;
using PrimacyApp.Models.Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.BusinessLogic.Implementation
{
    public class FolderManager : IFolderManager
    {
        public readonly IHashTable<string, FileValue> _hashTable;
        public FolderManager(IHashTable<string, FileValue> hashTable)
        {
            _hashTable = hashTable;
        }
        public List<Bucket<string,FileValue>> GetDuplicateFiles()
        {
            var items = _hashTable.BucketArray.Where(x => x.Value !=null && x.Value.Size > 1).Select(X=>X.Value).ToList();
            return   items ==null ? new List<Bucket<string,FileValue>>() : items;   
        }

        public void LoadFolder(string folderName)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(folderName);
            foreach (string fileName in fileEntries)
            {
                var file = processFile(fileName);
                _hashTable.Add(file.Value, file);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(folderName);
            foreach (string subdirectory in subdirectoryEntries)
                LoadFolder(subdirectory);
        }

        private FileValue processFile(string fileName)
        {
            byte[] fileData = System.IO.File.ReadAllBytes(path: fileName);
            string fileDataBase64 = Convert.ToBase64String(fileData);
            var node = new FileValue(fileName, fileDataBase64);
            return node;
        }

    }
}
