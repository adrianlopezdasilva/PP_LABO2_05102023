namespace Entidades
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
            get { return valor; }
        }

        virtual internal double ValorNumerico
        {
            get; 
        }

        static Numeracion()
        {
            msgError = "Numero Invalido";
        }

        protected Numeracion(string valor)
        {
            InicializarValor(valor);
        }

        private void InicializarValor(string valor)
        {
           if( EsNumeracionValida(valor) == false)
            {
                valor = msgError;
            }
        }

        public abstract Numeracion CambiarSistemaDeNumeracion(ESistema sistema);

        virtual protected bool EsNumeracionValida(string valor)
        {
            bool auxBool = true;

            if(string.IsNullOrWhiteSpace(valor))
            {
                auxBool = false;
            }

            return auxBool;
        }

        public static explicit operator double(Numeracion numeracion)
        {
            return (double)numeracion.ValorNumerico;
        }

        public static bool operator == (Numeracion n1, Numeracion n2)
        {
            return (n1.GetType() == n2.GetType());
        }

        public static bool operator !=(Numeracion n1, Numeracion n2)
        {
            return !(n1 == n2);
        }









    }
}