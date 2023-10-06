using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private string nombreAlumno;
        private List<string> operaciones;
        private Numeracion primerOperando;
        private Numeracion resultado;
        private Numeracion segundoOperando;
        private static ESistema sistema;

        private Calculadora()
        {
            sistema = ESistema.Decimal;

        }

        public Calculadora()
        {
            operaciones = new List<string>();
        }

        public Calculadora(string nombreAlumno)
        {

        }

        public List<string> Operaciones
        {
            get { return operaciones; }
        }

        public Numeracion Resultado
        { 
            get { return resultado; } 
        }

        public static ESistema Sistema
        { 
          get { return sistema; } 
          set { sistema = value; }    
        }

        public Numeracion PrimerOperando
        {
            get { return primerOperando; }
            set { primerOperando = value; }
        }
        public Numeracion SegundoOperando
        {
            get { return segundoOperando; }
            set { segundoOperando = value; }
        }

        public string NombreAlumno
        {
            get { return nombreAlumno; }
            set { nombreAlumno = value; }
        }
        public void Calcular()
        {
            Numeracion auxNumeracion;

        }

        public void Calcular(char operador)
        {
            Numeracion auxPrimerNumeracion;
            Numeracion auxSegundoNumeracion;
            Numeracion auxResultado;


            if(auxPrimerNumeracion == auxSegundoNumeracion )

            {
                switch (operador)
                {
                    case '+':
                        auxResultado.ValorNumerico = auxPrimerNumeracion.ValorNumerico + auxSegundoNumeracion.ValorNumerico;
                        break;

                    case '-':
                        auxResultado = PrimerOperando - SegundoOperando;
                        break;
                    case '*':
                        auxResultado = PrimerOperando * SegundoOperando;
                        break;
                    case '/':
                        auxResultado = PrimerOperando / SegundoOperando;
                        break;

                    default:
                        auxResultado = PrimerOperando + SegundoOperando;
                        break;
                }

            }

            else
            {
                auxResultado.ValorNumerico = double.MinValue;
            }

            return auxResultado;
        }





    }
}
