using System.Collections.Generic;
using Data.Entities;

namespace Data.Providers
{
    public interface ICodesProvider 
    {
        IEnumerable<CodesDb> GetAll();

        CodesDb GetById(string codeId);

        void UpdateCode(CodesDb code);

        void Delete(string codeId);
    }
}
