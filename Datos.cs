using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex_FernandoInfantes
{
    public partial class Datos : Form
    {
        Conexion miConexion = new Conexion();
        DataTable misPokemon = new DataTable();
        public Datos(int idActual)
        {
            InitializeComponent();
            misPokemon = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemon.Rows[0]["nombre"].ToString();
            descripcion.Text = misPokemon.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemon.Rows[0]["imagen"]);
            movimiento1.Text = misPokemon.Rows[0]["movimiento1"].ToString();
            movimiento2.Text = misPokemon.Rows[0]["movimiento2"].ToString();
            movimiento3.Text = misPokemon.Rows[0]["movimiento3"].ToString();
            movimiento4.Text = misPokemon.Rows[0]["movimiento4"].ToString();
            tipo1.Text = misPokemon.Rows[0]["tipo1"].ToString();
            tipo2.Text = misPokemon.Rows[0]["tipo2"].ToString();
            Peso.Text = misPokemon.Rows[0]["peso"].ToString();
            habilidad.Text = misPokemon.Rows[0]["habilidad"].ToString();
        }

        private void Datos_Load(object sender, EventArgs e)
        {

        }

        private Image convierteBlobAImagen(byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }


    }
}
