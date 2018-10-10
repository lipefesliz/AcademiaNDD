using System.Collections.Generic;
using Projeto_Prova_Tdd.Domain.Features.Auditions;
using Projeto_Prova_Tdd.Domain.Exceptions;
using Projeto_Prova_Tdd.Domain.Features.Auditions.Exceptions;

namespace Projeto_Prova_Tdd.Applications.Features.Auditions
{
    public class AuditionService : IService<Audition>
    {
        private IAuditionRepository _auditionRepository;

        public AuditionService(IAuditionRepository auditionRepository)
        {
            _auditionRepository = auditionRepository;
        }

        public Audition Add(Audition audition)
        {
            audition.Validate();

            var auditionFounded = _auditionRepository.Exist(audition.Theme);
            if (auditionFounded)
                throw new DuplicatedThemeException();

            return _auditionRepository.Add(audition);
        }

        public void Delete(Audition audition)
        {
            if (audition.Id < 1)
                throw new IdentifierUndefinedException();

            _auditionRepository.Delete(audition.Id);
        }

        public Audition Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();

            return _auditionRepository.Get(id);
        }

        public IList<Audition> GetAll()
        {
            return _auditionRepository.GetAll();
        }

        public Audition Update(Audition audition)
        {
            if(audition.Id < 1)
                throw new IdentifierUndefinedException();

            audition.Validate();

            var auditionFounded = _auditionRepository.GetByAudition(audition.Theme);
            if (auditionFounded != null)
            {
                if (auditionFounded.Id != audition.Id)
                    throw new DuplicatedThemeException();
            }

            return _auditionRepository.Update(audition);
        }
    }
}
