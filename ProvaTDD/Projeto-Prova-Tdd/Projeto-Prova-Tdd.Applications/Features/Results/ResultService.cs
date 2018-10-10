using System;
using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Features.Results;
using Projeto_Prova_Tdd.Domain.Exceptions;
using Projeto_Prova_Tdd.Domain.Features.Results.Exceptions;

namespace Projeto_Prova_Tdd.Applications.Features.Results
{
    public class ResultService : IService<Result>
    {
        private IResultRepository _resultRepository;

        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public Result Add(Result result)
        {
            result.Validate();

            var resultFounded = _resultRepository.Exist(result.Student.Id);
            if (resultFounded)
                throw new DuplicatedGradeException();

            return _resultRepository.Add(result);
        }

        public void Delete(Result result)
        {
            if (result.Id < 1)
                throw new IdentifierUndefinedException();

            if (IsTiedTo(result.Id))
                throw new IsTiedException();

            _resultRepository.Delete(result.Id);
        }

        public Result Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _resultRepository.Get(id);
        }

        public IList<Result> GetAll()
        {
            return _resultRepository.GetAll();
        }

        public Result Update(Result result)
        {
            if (result.Id < 1)
                throw new IdentifierUndefinedException();

            result.Validate();

            return _resultRepository.Update(result);
        }

        public bool IsTiedTo(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _resultRepository.IsTiedTo(id);
        }
    }
}
