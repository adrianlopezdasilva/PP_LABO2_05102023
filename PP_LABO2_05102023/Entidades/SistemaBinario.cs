using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaBinario : Numeracion
    {
        internal override double ValorNumerico
        {
            get { return Convert.ToDouble(Valor); }
        }

        SistemaBinario(string valor) : base(valor) {}
        
        public override Numeracion CambiarSistemaDeNumeracion(ESistema sistema)
        {
            SistemaBinario auxBinario = null;

            if (sistema == ESistema.Binario)
            {
                auxBinario = new SistemaBinario(valor);

            }

            return auxBinario;
        }
        override protected bool EsNumeracionValida(string valor)
        {
            bool auxbool = true;

           if (base.EsNumeracionValida(valor) == false || decimal.TryParse(valor, out decimal aux) == false)
            {
                 auxbool = false;
            }
            return auxbool;
        }

        private bool EsSistemaBinarioValido(string valor)
        {
            {
                bool auxBool = true;

                for (int i = 0; i < valor.Length; i++)
                {
                    if (valor[i] != '0' && valor[i] != '1')
                    {
                        auxBool = false;
                        break;
                    }
                }

                return auxBool;
        }
          
        private SistemaDecimal BinarioADecimal()
        {
            if (base.valor != Numeracion.msgError)
                {
                    int potencia = base.valor.Length - 1;
                    int resultado = 0;

                    foreach (char item in base.valor)
                    {
                        if (item == '1')
                        {
                            resultado = resultado + (int)Math.Pow(x: 2, potencia);
                        }
                        potencia--;
                    }
                    return resultado;
                }
                return double.MinValue;
        } 

        public static implicit operator SistemaBinario(string valor)
        {
            return new SistemaBinario(valor);
        }



    }
}
