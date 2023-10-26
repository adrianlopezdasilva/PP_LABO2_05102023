using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {

        internal override double ValorNumerico
        {
            get { return (double)this; }
        }

        SistemaDecimal(string valor) : base(valor) { }


        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            switch(sistema)
            {
                case ESistema.Binario:
                    return this.DecimalABinario();

            }

            return this;

        }

        protected override bool EsNumeracionValida(string valor )
        {
         return base.EsNumeracionValida(valor) && this.EsSistemaDecimalValido(valor);
        }
        private bool EsSistemaDecimalValido(string valor)
        {
            return double.TryParse(valor, out double value);
        }

        private SistemaBinario DecimalABinario()
        {
            int valor = (int)this.ValorNumerico;

            if(valor >0)
            {
                string binario = string.Empty;
                while (valor > 0)
                {
                    int resto = valor % 2;
                    valor = valor / 2;

                    binario = resto + binario;
                }
                return binario;
            }

            return Numeracion.msgError;
        }

        public static implicit operator SistemaDecimal(string valor)
        {
            return new SistemaDecimal(valor);
        }

        public static implicit operator SistemaDecimal(double valor)
        {
            return new SistemaDecimal(valor.ToString());
        }
    }




        

    }
}
