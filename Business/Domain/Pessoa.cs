using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Domain
{
    public class Pessoa
    {
        public Pessoa() {}

        public Pessoa(int codigo, string nome, double salario, int dependentes)
        {
            Codigo = codigo;
            Nome = nome;
            Salario = salario;
            Dependentes = dependentes;
        }

        public int Codigo{ get; set; }
        public string Nome { get; set; }
        public double Salario{ get; set; }
        public int Dependentes { get; set; }
        public double Inss { get; set; }
    }
}
