using System;
using Punto_Venta.BML;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_Venta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.codigo = textCodigo.Text;
            productos.descripcion = textDescripcion.Text;
            productos.unidadMedida = textUnudadMedida.Text;
            productos.precio = Convert.ToDecimal(textPrecio.Text);
            productos.stock = Convert.ToInt32(textStock.Text);
            productos.marca = textMarca.Text;
            productos.add();
        }
    }
}
