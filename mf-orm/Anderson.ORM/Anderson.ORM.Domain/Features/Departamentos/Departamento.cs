using Anderson.ORM.Domain.Base;

namespace Anderson.ORM.Domain.Features.Departamentos
{
    public class Departamento : Entity
    {
        public string Descricao { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
