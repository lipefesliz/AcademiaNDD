using Anderson.ORM.Domain.Base;

namespace Anderson.ORM.Domain.Features.Cargos
{
    public class Cargo : Entity
    {
        public string Descricao { get; set; }

        public override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
