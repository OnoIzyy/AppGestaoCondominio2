using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestaoCondominio.RegrasDeNegocio
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public double Renda { get; set; }

        public string Titular(string titular)
        {
            if (titular == "S")
            {
                titular = "É PROPRIETARIO TITULAR";
            }
            else if (titular == "N")
            {
                titular = "NÃO É PROPRIETARIO TITULAR";
            }
            return titular;
        }


    }
}
