using IfourTechnolab.Business.ViewModels.General;
using Microsoft.AspNetCore.Http;
using eshop_cartapi.Business.Enums.General;
using System;
using System.Threading.Tasks;

namespace eshop_cartapi.Business.Helpers
{
    public interface IFileHelper
    {
        Task<bool> SaveFile(IFormFile file, UploadDirectories directory);

        Task<UploadfileModel> SaveFile(UploadfileModel fileModel, IFormFile file, UploadDirectories directory, Guid? identifier = null);

        string FullFileServerMapPath(UploadDirectories directory);

        string FullFileApiServerMapPath(UploadDirectories directory);
    }
}