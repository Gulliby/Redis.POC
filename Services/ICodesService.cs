using System.Collections.Generic;
using Entities;

namespace Services
{
    public interface ICodesService
    {
        IEnumerable<CodesEntity> GetAllCodes();

        CodesEntity GetCodeById(string codeId);

        void UpdateCode(CodesEntity code);

        void DeleteCode(string codeId);
    }
}
