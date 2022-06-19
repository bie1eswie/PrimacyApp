using PrimacyApp.Models.Data;
using PrimacyApp.Models.Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimacyApp.BusinessLogic.Interface
{
    public interface IFolderManager
    {
        void LoadFolder(string folderName);
        List<Bucket<string, FileValue>> GetDuplicateFiles();

    }
}
