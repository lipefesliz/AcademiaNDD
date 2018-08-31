using Anderson.MF7.Domain.Features.Gastos;
using System;

namespace Anderson.MF7.Application.Features.Gastos.ViewModels
{
    public class GastoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public TipoGastoEnum Tipo { get; set; }
        public string Funcionario { get; set; }
    }
}
