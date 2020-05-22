using System;
using System.Threading.Tasks;

namespace IHttpFactoryWithAspNetMVCNinject.Services
{
    public interface IUrlStringReader
    {
        Task<string> GetJsonAsyncIncorrectUsage(Uri uri);
        Task<string> GetJsonAsyncCorrectUsage(Uri uri);
    }
}