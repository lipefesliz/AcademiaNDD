using Anderson.MF7.Domain.Features.Funcionarios;
using System;

namespace Anderson.MF7.Domain.Features.Gastos
{
    public class Gasto : Entity
    {
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public TipoGastoEnum Tipo { get; set; }
        public int FuncionarioID { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
