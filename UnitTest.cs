using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void ConverteStringParaInt()
        {
            var logica = new Logica();

            string numeroString = "153";

            int numeroDecimal = logica.ConvertStringParaInt(numeroString);

            int resultado = 153;

            Assert.AreEqual(resultado, numeroDecimal);
        }


        [TestMethod]
        public void ConverteStringParaDecimal()
        {
            var logica = new Logica();

            string numeroString = "1.000,89";

            decimal numeroDecimal = logica.ConverteStringParaDecimal(numeroString);

            decimal resultado = 1000.89M;

            Assert.AreEqual(resultado, numeroDecimal);
        }

        [TestMethod]
        public void ConverteStringParaData()
        {
            var logica = new Logica();

            string dataString = "30/04/1992";

            DateTime data = logica.ConverteStringParaData(dataString);

            DateTime resultado = new DateTime(1992, 04, 30);

            Assert.AreEqual(resultado, data);
        }

        [TestMethod]
        public void ConfereVendas()
        {
            var logica = new Logica();

            var produtosString =
                @"Vendedor Gustavo
                    Código Produto	quantidade    valor total 	     Data venda
                    SSA-1005	    10 UN	      R$ 2.000,00 	         01/04/2021
                    AAT-1006	    11 UN	      R$ 746,00 	         02/04/2021
                    AFA-1007	    12 UN	      R$ 18,56 	             03/04/2021
                    GGA-1008	    13 UN	                 R$ 3.500,59 	         04/04/2021

                    AAF-1009	    14 UN	      R$ 2.509,87 	         05/04/2021
                            ABV-1010	    15 UN	      R$ 2.887,30 	         06/04/2021

                    AAA-1011	    16 UN	      R$ 3.264,74 	         07/04/2021
                Vendedor Paulo
                    Código Produto	quantidade    valor total 	     Data venda
                    ARA-1012	    17 UN	      R$ 3.642,17 	         08/04/2021
                    ACA-1013	    18 UN	      R$ 4.019,60 	         08/04/2021
                    SDA-1014	    19 UN	      R$ 4.397,04 	         10/04/2021
                  AAF-1015	    20 UN	      R$ 4.774,47 	         11/04/2021";

            List<VendaTO> vendas = logica.ConverteStringParaVendas(produtosString);


            var somaValor = vendas.Sum(x => x.Valor);
            var quantidadeProdutos = vendas.Sum(x => x.Quantidade);
            var totalVendas = vendas.Count();

            var somaValorEsperado = 31760.34M;
            var quantidadeProdutosEsperado = 165;
            var totalVendasEsperadas = 11;
            Assert.AreEqual(somaValorEsperado, somaValor, $"A soma dos valores tem que ser {somaValor}");
            Assert.AreEqual(quantidadeProdutosEsperado, quantidadeProdutos, $"A quantidade de produtos em que ser {quantidadeProdutos}");
            Assert.AreEqual(totalVendasEsperadas, totalVendas, $"A quantidade de produtos em que ser {quantidadeProdutos}");



            var vendaProdutoAAF1015 = vendas.FirstOrDefault(x => x.Codigo.Equals("AAF-1015"));
            var vendedorEsperado = "Paulo";
            var valorEsperado = 4774.47M;
            var quantidadeEsperada = 20;
            var dataEsperada = new DateTime(2021, 04, 11);
            Assert.AreEqual(vendedorEsperado, vendaProdutoAAF1015.Vendedor, $"O vendendedor esperado é {vendedorEsperado}");
            Assert.AreEqual(valorEsperado, vendaProdutoAAF1015.Valor, $"O valor esperado é {valorEsperado}");
            Assert.AreEqual(quantidadeEsperada, vendaProdutoAAF1015.Quantidade, $"A quantidade esperado é {quantidadeEsperada}");
            Assert.AreEqual(dataEsperada, vendaProdutoAAF1015.Data, $"A quantidade esperado é {dataEsperada}");
        }
    }
}


