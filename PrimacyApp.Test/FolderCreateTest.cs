using Moq;
using PrimacyApp.BusinessLogic.Implementation;
using PrimacyApp.BusinessLogic.Interface;
using PrimacyApp.Models.Data;
using PrimacyApp.Models.Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PrimacyApp.Test
{
    public class FolderCreateTest
    {
        private readonly FolderManager folderManager;

        public FolderCreateTest()
        {
            folderManager = new FolderManager(new HashTable<string, FileValue>());
        }
        [Fact]
        public void FolderManager_ShouldLoadDataIntoDataStracture()
        {
            folderManager.LoadFolder(@"..\..\..\..\..\PrimacyApp\PrimacyApp.Test\MockData\photos\");
            var result = folderManager._hashTable;
            Assert.NotEmpty(result.BucketArray);
        }
        [Fact]
        public void FolderManager_ShouldGetDuplicates()
        {
            folderManager.LoadFolder(@"..\..\..\..\..\PrimacyApp\PrimacyApp.Test\MockData\photos\");
            var result = folderManager.GetDuplicateFiles();
            Assert.NotEmpty(result);
        }
    }
}
