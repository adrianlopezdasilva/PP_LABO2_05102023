using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaDecimal : Numeracion
    {

        internal override double ValorNumerico
        {
            get { return Convert.ToDouble(Valor); }
        }

        SistemaDecimal(string valor) : base(valor) { }


        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            SistemaDecimal auxDecimal = null;

            if (sistema == ESistema.Decimal)
            {
                 auxDecimal = new SistemaDecimal(valor);

            }

            return auxDecimal;
        }

        protected bool EsNumacionValida(string valor )
        {
            bool auxbool = true;

            if (base.EsNumeracionValida(valor) == false || EsSistemaDecimalValido(valor) == false)
            {
                auxbool = false;
            }
            return auxbool;
        }
        private bool EsSistemaDecimalValido(string valor)
        {
            bool auxBool = true;

            if (double.TryParse(valor, out double doubleValor) == false)
            {
                auxBool = false;
            }

            return auxBool;
        }

        private SistemaBinario DecimalABinario()
        {
            SistemaBinario auxBinario = new SistemaBinario(valor);

            if (auxBinario.ValorNumerico > 0)
            {
                auxBinario = Convert.ToString(Convert.ToInt32(valor), 2);

            }

            return auxBinario;
        }

        public static implicit operator  SistemaDecimal(string valor)
        {
            return;
        }

        public static implicit operator SistemaDecimal(double valor)
        {
            return;
        }
    }




        

    }
}
