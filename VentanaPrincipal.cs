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
    public partial class VentanaPrincipal : Form
    {
        Conexion miConexion = new Conexion();
        DataTable misPokemons = new DataTable();
        int idActual = 1;//guarda el id del pokemon que estas viendo
        public VentanaPrincipal()
        {
            InitializeComponent();
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            descripcion.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            cambiarImagenes();
        }

        private void Izquierda_Click(object sender, EventArgs e)
        {
            if (idActual == 1)
            {
                idActual = 151;
            }
            else
            {
            idActual--;
            }
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            descripcion.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            cambiarImagenes();
        }

        private Image convierteBlobAImagen(byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }

        private void derecha_Click(object sender, EventArgs e)
        {
            if (idActual == 151)
            {
                idActual = 1;
            }
            else
            {
            idActual++;
            }
            misPokemons = miConexion.getPokemonPorId(idActual);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            descripcion.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            cambiarImagenes();
        }

        private void cambiarImagenes()
        {
            if(idActual ==134|| idActual == 135 || idActual == 136)
            {
                pictureBox2.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(133).Rows[0]["imagen"]);
                pictureBox3.Image = null;
            }
            else if (!misPokemons.Rows[0]["preEvolucion"].ToString().Equals("")&&
                !miConexion.getPokemonPorId(idActual - 1).Rows[0]["preEvolucion"].ToString().Equals(""))
            {
                pictureBox3.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 1).Rows[0]["imagen"]);
                pictureBox2.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 2).Rows[0]["imagen"]);
            }
            else if(!misPokemons.Rows[0]["preEvolucion"].ToString().Equals("")&&
                !misPokemons.Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                pictureBox2.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 1).Rows[0]["imagen"]);
                pictureBox3.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual + 1).Rows[0]["imagen"]);
            }
            else if (!misPokemons.Rows[0]["posEvolucion"].ToString().Equals("")&&
                !miConexion.getPokemonPorId(idActual+1).Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                pictureBox2.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual+1).Rows[0]["imagen"]);
                pictureBox3.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual+2).Rows[0]["imagen"]);
            }
            else if (!misPokemons.Rows[0]["preEvolucion"].ToString().Equals("")&&
                miConexion.getPokemonPorId(idActual - 1).Rows[0]["preEvolucion"].ToString().Equals(""))
            {
                pictureBox2.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 1).Rows[0]["imagen"]);
                pictureBox3.Image = null;
            }
            else if (!misPokemons.Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                pictureBox2.Image = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual + 1).Rows[0]["imagen"]);
                pictureBox3.Image = null;
            }else if (misPokemons.Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                pictureBox2.Image = null;
                pictureBox3.Image = null;
            }
        }

        private void VentanaPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Datos ventanaDatos = new Datos(idActual);
            ventanaDatos.Show();
        }
    }
}
