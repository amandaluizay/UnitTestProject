using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestProject
{
    public class Logica
    {
        /// <summary>
        /// Metodo recebe um numero em texto usando separador . como separador de milhar e , como separador decimal
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        internal decimal ConverteStringParaDecimal(string numeroString)
        {
            return Convert.ToDecimal(numeroString);
        }

        /// <summary>
        /// Metodo recebe uma data em texto no formato dd/MM/yyyy e retorna a data convertida
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        internal DateTime ConverteStringParaData(string dataString)
        {
            return Convert.ToDateTime(dataString);
        }

        internal int ConvertStringParaInt(string value)
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Vendedor Gustavo
        /// Código Produto	quantidade    valor total 	     Data venda
        /// ARA-1012	    17 UN          R$ 3.642,17 	         08/04/2021
        /// </summary>
        /// <param name="produtosString"></param>
        /// <returns></returns>

        public List<VendaTO> ConverteStringParaVendas(string produtosString)
        {
            // iniciando a lista de vendas
            var vendas = new List<VendaTO>();

            //divide uma string chamada "produtosString" em um array de strings,
            //usando as sequências de escape "\r\n" ou "\n" como delimitadores de linha
            var linhas = produtosString.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            var vendedor = string.Empty;

            // Essa linha de código em C# inicia um loop "for" que irá percorrer
            // o array de "linhas", criado anteriormente
            for (int i = 0; i < linhas.Length; i++)
            {
                //verifica se a string no índice atual do array contém a substring "Vendedor"
                //Se a substring for encontrada, a variável "vendedor" é atualizada com o valor da linha atual que começa após a palavra "Vendedor"
                // removendo quaisquer espaços em branco.
                if (linhas[i].Contains("Vendedor"))
                {
                    vendedor = linhas[i].Substring("Vendedor ".Length).Trim().Replace("Vendedor", "").Replace(" ", "");
                    continue;
                }

                // divide a string do índice atual do array em um array de substrings,
                // usando o caractere ('\t') como delimitador, removendo as entradas vazias do array
                var campos = linhas[i].Split('\t', (char)StringSplitOptions.RemoveEmptyEntries);

                // se o tamanho do array for diferente de 4, o código pula para a
                // próxima iteração, ignorando o processamento adicional dessa linha.
                if (campos.Length != 4) continue;

                //os valores dos campos dessa instância são definidos com base nos dados da linha atual do array "linhas"
                //e do vendedor extraído anteriormente.
                var venda = new VendaTO();
                venda.Vendedor = vendedor;
                venda.Codigo = campos[0].Trim();
                venda.Quantidade = int.Parse(campos[1].Trim().Replace("UN", ""));
                venda.Valor = decimal.Parse(campos[2].Trim().Replace("R$", ""));
                venda.Data = DateTime.ParseExact(campos[3].Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None);
                vendas.Add(venda);
            }
            return vendas;
        }

        }
    }

    
