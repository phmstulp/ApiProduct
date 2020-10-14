using Business.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IR
{
    public class CalcIR
    {

        //Imposto de Renda retido na fonte = [(Salário bruto – dependentes – INSS) X alíquota] – dedução

//        Base de cálculo Alíquota    Parcela a deduzir do IRPF
//    Até R$ 1.903,98	Isento R$ 0,00
//De R$ 1.903,99 até R$ 2.826,65	7,5%	R$ 142,80
//De R$ 2.826,66 até R$ 3.751,05	15%	R$ 354,80
//De R$ 3.751,06 até R$ 4.664,68	22,5%	R$ 636,13
//Acima de R$ 4.664,68	27,5%	R$869,36

        public double RetornaIR(Pessoa pessoa_calcular)
        {
            double IR = 0;
            Pessoa pessoa = CalculaInss(pessoa_calcular);
            if (pessoa.Salario < 1903.99)
                IR = 0;
            else if (pessoa.Salario >= 1903.99 && pessoa.Salario < 2826.65)
                IR = ((pessoa.Salario - pessoa.Dependentes - pessoa.Inss) * 0.075) - 142.80;
            else if (pessoa.Salario >= 2826.65 && pessoa.Salario < 3751.05)
                IR = ((pessoa.Salario - pessoa.Dependentes - pessoa.Inss) * 0.15) - 354.80;
            else if (pessoa.Salario >= 3751.05 && pessoa.Salario < 4664.68)
                IR = ((pessoa.Salario - pessoa.Dependentes - pessoa.Inss) * 0.225) - 636.13;
            else if (pessoa.Salario >= 4664.68)
                IR = ((pessoa.Salario - pessoa.Dependentes - pessoa.Inss) * 0.275) - 869.36;

            return IR;
        }



        /* 7,5% até um salário mínimo(R$ R$ 1.045);
        9% para quem ganha entre R$ 1.045,01 R$ e 2.089,60.
        12% para quem ganha entre R$ 2.089,61 e R$ 3.134,40.
        14% para quem ganha entre R$ 3.134,41 e R$ 6.101,06
        Salários que se enquadram neste regime geral e que estão acima do teto da previdência de R$ 6.101,06 contribuem os mesmos R$ 713,08. Neste patamar a alíquota efetiva é de aproximadamente 11,69%.
        */

        //1ª faixa salarial: R$ 1.045,00 x 7,5% = R$ 78,38
        //2ª faixa salarial: (R$ 2.089,60 – R$ 1.045,00) x 9% = R$ 1.044,60 x 9% = R$ 94,01
        //3ª faixa salarial: (R$ 3.134,40 – R$ 2.089,60) x 12% = R$ 1.044,80 x 12% = R$ 125,38
        //4ª faixa salarial: (R$ 6.101,06 – R$ 3.134,40) x 14% = R$ 2.966,66 x 14% = R$ 415,33
        //Total a recolher: R$ 78,38 + R$ 94,01 + R$ 125,38 + R$ 415,33 = R$ 713,10

        //https://www.jornalcontabil.com.br/como-calcular-o-desconto-de-inss-com-as-novas-aliquotas/
        public Pessoa CalculaInss(Pessoa pessoa)
        {
            if (pessoa.Salario <= 1045)
                pessoa.Inss = Math.Round(pessoa.Salario * 0.075, 2, MidpointRounding.ToEven);
            else if (pessoa.Salario >= 1045.01 && pessoa.Salario <= 2089.6)
                pessoa.Inss = Math.Round((pessoa.Salario - 1045) * 0.09, 2, MidpointRounding.ToEven) + 78.38;
            else if (pessoa.Salario >= 2089.61 && pessoa.Salario <= 3134.40)
                pessoa.Inss = Math.Round((pessoa.Salario - 2089.6) * 0.12, 2, MidpointRounding.ToEven) + 78.38 + 94.01;
            else if (pessoa.Salario >= 2089.61 && pessoa.Salario <= 6101.06)
                pessoa.Inss = Math.Round((pessoa.Salario - 3134.40) * 0.14, 2, MidpointRounding.ToEven) + 78.38 + 94.01 + 125.37;
            else if (pessoa.Salario > 6101.06)
                pessoa.Inss = 713.09;

            return pessoa;
        }

    }
}
