using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Data.Providers;
using Entities;

namespace Services
{
    public class CodesService : ICodesService
    {
        private readonly ICodesProvider _codesProvider;

        public CodesService(ICodesProvider codesProvider)
        {
            _codesProvider = codesProvider;
        }

        public void DeleteCode(string codeId)
        {
            _codesProvider.Delete(codeId);
        }

        public IEnumerable<CodesEntity> GetAllCodes()
        {
            return _codesProvider.GetAll().Select(c => 
                new CodesEntity
                {
                    CodeId = c.CodeId,
                    Code = c.Code,
                    CodeTypeId = c.CodeTypeId,
                    Description = c.Description
                });
        }

        public CodesEntity GetCodeById(string codeId)
        {
            var code = _codesProvider.GetById(codeId);

            return new CodesEntity
            {
                CodeId = code.CodeId,
                Code = code.Code,
                CodeTypeId = code.CodeTypeId,
                Description = code.Description
            };
        }

        public void UpdateCode(CodesEntity code)
        {
            _codesProvider.UpdateCode(new CodesDb
            {
                CodeId = code.CodeId,
                Code = code.Code,
                CodeTypeId = code.CodeTypeId,
                Description = code.Description
            });
        }
    }
}
