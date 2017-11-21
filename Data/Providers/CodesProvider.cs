using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;

namespace Data.Providers
{
    public class CodesProvider : ICodesProvider
    {
        private readonly IUnitOfWork _unitOfWork;

        public CodesProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(string codeId)
        {
            _unitOfWork.Repository<CodesDb>().Delete(GetById(codeId));
        }

        public IEnumerable<CodesDb> GetAll()
        {
            return _unitOfWork.Repository<CodesDb>().FindAll();
        }

        public CodesDb GetById(string codeId)
        {
            return _unitOfWork.Repository<CodesDb>()
                .FindAll()
                .FirstOrDefault(q => q.CodeId.Equals(codeId, StringComparison.OrdinalIgnoreCase));
        }

        public void UpdateCode(CodesDb code)
        {
            _unitOfWork.Repository<CodesDb>().Update(code);
        }
    }
}
