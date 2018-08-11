using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado.Dominio
{
    public class Produto : Entidade
    {   
        public string Nome { get; set; }

        public double Preco { get; set; }

        public string Categoria { get; set; }
        
        public int Quantidade { get; set; }

        public void Validacao()
        {
            if (string.IsNullOrEmpty(Nome) || Nome.Trim() == "")
                throw new Exception("Nome do produto não pode estar em branco!");

            if (SomenteNumeros())
                throw new Exception("Nome do produto não pode conter somente números!");

            if (ComecaComNumero())
                throw new Exception("Nome do produto não pode comecar com um número!");

            if (!System.Text.RegularExpressions.Regex.IsMatch(Nome.ToLower(), @"^[1-9a-z-A-Z_á-úçãõâêôà\s]+$"))
                throw new Exception("Nome do produto não pode conter caracters especiais!");

            if (Nome.Length < 4)
                throw new Exception("Nome do produto deve ter mais que 3 caracteres!");

            if (Nome.Length > 25)
                throw new Exception("Nome do produto deve ser menor que 25 caracteres!");

            if (Preco == 0)
                throw new Exception("Preço do produto não pode estar zerado!");

            if (Quantidade == 0)
                throw new Exception("Quantidade do produto não pode estar zerado!");
        }

        private bool SomenteNumeros()
        {
            string numeros = "0123456789";
            int cont = 0;

            for (int i = 0; i < Nome.Length; i++)
            {
                if (numeros.Contains(Nome[i]))
                    cont++;
            }

            if (cont == Nome.Length)
                return true;
            else
                return false;
        }

        private bool ComecaComNumero()
        {
            string numeros = "0123456789";
            foreach (var item in numeros)
            {
                if (item.Equals(Nome[0]))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return String.Format("Nome: {0}     -       Preco: {1:N}      -       Categoria: {2}      -       Quantidade: {3}",
                Nome, Preco, Categoria, Quantidade);
        }

        public override bool Equals(object obj)
        {
            var pro = obj as Produto;
            if (pro == null)
                return false;
            if(this.Nome.Trim() == pro.Nome.Trim() 
                && this.Preco == pro.Preco 
                && this.Quantidade == pro.Quantidade 
                && this.Categoria == pro.Categoria)
                return true;            
            return false;
        }
    }
}
