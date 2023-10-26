﻿namespace Entidades
{
    public enum ESistema
    {
        Binario,
        Decimal
    }
    public abstract class Numeracion
    {
        protected static string msgError;
        protected string valor;

        public string Valor
        {
            get { return this.valor; }
        }

        internal abstract double ValorNumerico
        {
            get; 
        }

        static Numeracion()
        {
            Numeracion.msgError = "Numero Invalido";
        }

        protected Numeracion(string valor)
        {
            this.InicializarValor(valor);
        }

        private void InicializarValor(string valor)
        {
           if(this.EsNumeracionValida(valor))
            {
                this.valor = valor;
            }
           else
            {
                this.valor = Numeracion.msgError;
            }
        }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);

        virtual protected bool EsNumeracionValida(string valor)
        {

            return !string.IsNullOrWhiteSpace(valor);
   
        }

        public static explicit operator double(Numeracion numeracion)
        {
            return (double)numeracion.ValorNumerico;
        }

        public static bool operator == (Numeracion n1, Numeracion n2)
        {
            return n1 is not null && n2 is not null && n1.GetType() == n2.GetType();
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }









    }
}