using Business.Domain;
using Business.IR;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Teste_Soma()
        {
            Assert.GreaterOrEqual(1, 1, "Valore diferentes");
        }

        [Test]
        public void Teste_Multiplicacao()
        {
            //Processamento preparatório para os testes 
            Assert.AreEqual(MultiplicaRegistros(58, 126), 7308, "Valor da multiplicação incorreta!");
            Assert.AreEqual(MultiplicaRegistros(2, 58.69), 117.38, "Valor da multiplicação incorreta!");
            Assert.AreEqual(MultiplicaRegistros(544, 2), 1088, "Valor da multiplicação incorreta!");
            Assert.AreEqual(MultiplicaRegistros(128, 236), 30208, "Valor da multiplicação incorreta!");
            //Assert.AreEqual(MultiplicaRegistros(965, 4548.5), 7308.5, "Valor da multiplicação incorreta!");
            //Assert.AreEqual(MultiplicaRegistros(59, 487.7), 7308.5, "Valor da multiplicação incorreta!");
            //Assert.AreEqual(MultiplicaRegistros(1, 44), 7308.5, "Valor da multiplicação incorreta!");
        }

        [TestCase(58, 126, 7308)]
        [TestCase(2, 58.69, 117.38)]
        [TestCase(544, 2, 1088)]
        [TestCase(128, 236, 30208)]
        public void Teste_Multiplicacao_Multiplos(double v1, double v2, double result)
        {
            //Processamento preparatório para os testes 
            Assert.AreEqual(MultiplicaRegistros(v1, v2), result, "Valor da multiplicação incorreta!");
        }


        public double MultiplicaRegistros(double v1, double v2) => v1 * v2;


        [Test]
        public void Verifica_inss_funcionario()
        {
            Pessoa pessoa = new Pessoa(1, "Marcelo", 1045, 0);
            CalcIR calcIR = new CalcIR();
            calcIR.CalculaInss(pessoa);
            Assert.AreEqual(pessoa.Inss, 78.38);

            pessoa.Salario = 1990;
            calcIR.CalculaInss(pessoa);
            Assert.AreEqual(pessoa.Inss, 163.43);
        }

        [Test]
        public void Verifica_inss_funcionario_sem_instancia()
        {
            Pessoa pessoa = new Pessoa();
            CalcIR calcIR = new CalcIR();
            calcIR.CalculaInss(pessoa);
            Assert.AreEqual(pessoa.Inss, 0);

        }

        [Test]
        public void Verifica_ir_faixa_15()
        {
            Pessoa pessoa = new Pessoa(1, "Marcelo", 3000, 1);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.RetornaIR(pessoa), 43.23);
        }

        [Test]
        public void tipos_assert()
        {
            string teste = string.Empty;

            /*Assert.AreNotEqual(10, 10); //Testa valores diferentes
            Assert.Greater();//Maior
            Assert.IsEmpty(teste);//Vazio
            Assert.IsTrue(string.IsNullOrEmpty(teste));
            Assert.NotNull();
            var ex = Assert.Throws<ArgumentNullException>(() => foo.Bar(null));
            Assert.That(ex.ParamName, Is.EqualTo("bar"));
            Assert.That(1 == 2);*/
        }

        [Test]
        public void verifica_ir_isento()
        {
            Pessoa pessoa = new Pessoa(1, "Marcelo", 1900, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.RetornaIR(pessoa), 0);
        }

        [Test]
        public void verifica_ir_7_e_5()
        {
            Pessoa pessoa = new Pessoa(1, "Pedro", 2800, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.RetornaIR(pessoa), 48.30);
        }

        [Test]
        public void verifica_ir_15()
        {
            Pessoa pessoa = new Pessoa(1, "Matheus", 3700, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.RetornaIR(pessoa), 139.15);
        }

        [Test]
        public void verifica_ir_22_e_5()
        {
            Pessoa pessoa = new Pessoa(1, "Eduardo", 4600, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.RetornaIR(pessoa), 285.02);
        }

        [Test]
        public void verifica_ir_27_e_5()
        {
            Pessoa pessoa = new Pessoa(1, "Luana", 6000, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.RetornaIR(pessoa), 604);
        }

        [Test]
        public void verifica_salario_minimo()
        {
            Pessoa pessoa = new Pessoa(1, "Felipe", 6000, 0);
            Assert.GreaterOrEqual(pessoa.Salario, 1045);
        }

        [Test]
        public void verifica_nulos(Pessoa pessoa)
        {
            Assert.IsNotNull(pessoa.Codigo);
            Assert.IsNotNull(pessoa.Nome);
            Assert.IsNotNull(pessoa.Salario);
            Assert.IsNotNull(pessoa.Dependentes);
        }

        [Test]
        public void verifica_nome_vazio(Pessoa pessoa)
        {
            Assert.IsNotEmpty(pessoa.Nome);
        }

        [Test]
        public void verifica_se_tem_dependentes()
        {
            Pessoa pessoa = new Pessoa(1, "Felipe", 6000, 0);
            Assert.Greater(pessoa.Dependentes, 0);
        }

        [Test]
        public void verifica_inss_7_e_5()
        {
            Pessoa pessoa = new Pessoa(1, "Joao", 1045, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.CalculaInss(pessoa), 78.37);
        }

        [Test]
        public void verifica_inss_9()
        {
            Pessoa pessoa = new Pessoa(1, "Claudio", 1990, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.CalculaInss(pessoa), 163.42);
        }

        [Test]
        public void verifica_inss_12()
        {
            Pessoa pessoa = new Pessoa(1, "Maria", 2500, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.CalculaInss(pessoa), 221.62);
        }

        [Test]
        public void verifica_inss_14()
        {
            Pessoa pessoa = new Pessoa(1, "Luana", 5125, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.CalculaInss(pessoa), 278.68);
        }

        [Test]
        public void verifica_inss_acima_de_14()
        {
            Pessoa pessoa = new Pessoa(1, "Ana", 7000, 0);
            CalcIR calcIR = new CalcIR();
            Assert.AreEqual(calcIR.CalculaInss(pessoa), 713.09);
        }

        [Test]
        public void verifica_inss_nulo()
        {
            Pessoa pessoa = new Pessoa(1, "Carlos", 2500, 0);
            CalcIR calcIR = new CalcIR();
            Assert.IsNotNull(calcIR.CalculaInss(pessoa));
        }
    }
}