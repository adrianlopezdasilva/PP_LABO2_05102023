using Entidades;
namespace FrmCalculadora

{
    public partial class FrmCalculadora : Form
    {
        private FrmCalculadora calculadora;

        public FrmCalculadora()
        {
            InitializeComponent();
            this.calculadora = new Calculadora("Adrian Lopez Da Silva");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.calculadora.EliminarHistorialDeOperaciones();
            this.txtPrimerOperando.Text = string.Empty;
            this.txtSegundoOperando.Text = string.Empty;
            this.lblResultado.Text = $"Resultado:";
            this.MostrarHistorial();
        }

        private void setResultado()
        {
            if(this.sistema == ESistema.Binario)
            {
                lblResultado.Text = resultado.ConvertirA(sistema);
            }else
            { 
            lblResultado.Text = resultado.Valor;

            }

        }

        private void FrmCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la calculadora?", "Cierre", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

                char operador;
                calculadora.PrimerOperando =
                this.GetOperador(this.txtPrimerOperando.Text);
                calculadora.SegundoOperando =
                this.GetOperador(this.txtSegundoOperando.Text);
                operador = (char)this.cmbOperacion.SelectedItem;
                this.calculadora.Calcular(operador);
                this.calculadora.ActualizaHistorialDeOperaciones(operador);
                this.lblResultado.Text = $"Resultado:{ calculadora.Resultado.Valor}";
                this.MostrarHistorial();
        }

        private void FrmCalculadora_Load(object sender, EventArgs e)
        {
            this.cmbOperacion.DataSource = new char[]
            { '+', '-', '*','/' };
            rdbDecimal.Checked = true;

        }

        private void txtPrimerOperador_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSegundoOperador_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            Calculadora.Sistema = ESistema.Decimal;       
        }

        private void rdbBinario_CheckedChanged(object sender, EventArgs e)
        {
            Calculadora.Sistema = ESistema.Binario;
        }

       /* private void MostrarHistorial()
        {
            this.lstHistorial.DataSource = null;
            this.lstHistorial.DataSource =
            this.calculadora.Operaciones;
        }*/
    }
}