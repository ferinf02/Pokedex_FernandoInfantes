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
        int id1 = 0;
        int id2 = 0;
        int id3 = 0;
        Conexion miConexion = new Conexion();
        DataTable misPokemons = new DataTable();
        int idActual;
        public Datos(int id)
        {
            InitializeComponent();
            idActual = id;
            mostrarDatos(idActual);
            cambiarImagenes();
        }

        private void Datos_Load(object sender, EventArgs e)
        {

        }

        private Image convierteBlobAImagen(byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }

        private void cambiarImagenes()
        {
            if (idActual == 134 || idActual == 135 || idActual == 136)
            {
                id1 = 133;
                id2 = idActual;
                button1.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(133).Rows[0]["imagen"]);
                button3.Hide();
                button2.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            }
            else if (!misPokemons.Rows[0]["preEvolucion"].ToString().Equals("") &&
                !miConexion.getPokemonPorId(idActual - 1).Rows[0]["preEvolucion"].ToString().Equals(""))
            {
                id2 = idActual - 1;
                id1 = idActual - 2;
                id3 = idActual;
                button3.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
                button2.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 1).Rows[0]["imagen"]);
                button1.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 2).Rows[0]["imagen"]);
            }
            else if (!misPokemons.Rows[0]["preEvolucion"].ToString().Equals("") &&
                !misPokemons.Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                id1 = idActual - 1;
                id2 = idActual;
                id3 = idActual + 1;
                button2.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
                button1.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 1).Rows[0]["imagen"]);
                button3.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual + 1).Rows[0]["imagen"]);
            }
            else if (!misPokemons.Rows[0]["posEvolucion"].ToString().Equals("") &&
                !miConexion.getPokemonPorId(idActual + 1).Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                id1 = idActual;
                id2 = idActual + 1;
                id3 = idActual + 2;
                button1.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
                button2.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual + 1).Rows[0]["imagen"]);
                button3.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual + 2).Rows[0]["imagen"]);
            }
            else if (!misPokemons.Rows[0]["preEvolucion"].ToString().Equals("") &&
                miConexion.getPokemonPorId(idActual - 1).Rows[0]["preEvolucion"].ToString().Equals(""))
            {
                id1 = idActual - 1;
                id2 = idActual;
                button2.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
                button1.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual - 1).Rows[0]["imagen"]);
                button3.Hide();
            }
            else if (!misPokemons.Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                id1 = idActual;
                id2 = idActual + 1;
                button2.BackgroundImage = convierteBlobAImagen((byte[])miConexion.getPokemonPorId(idActual + 1).Rows[0]["imagen"]);
                button3.Hide();
                button1.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            }
            else if (misPokemons.Rows[0]["posEvolucion"].ToString().Equals(""))
            {
                id1 = idActual;
                button1.BackgroundImage = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
                button2.Hide();
                button3.Hide();
            }
        }


        public void mostrarDatos(int idNueva)
        {
            misPokemons = miConexion.getPokemonPorId(idNueva);
            nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
            descripcion.Text = misPokemons.Rows[0]["descripcion"].ToString();
            pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            movimiento1.Text = misPokemons.Rows[0]["movimiento1"].ToString();
            movimiento2.Text = misPokemons.Rows[0]["movimiento2"].ToString();
            movimiento3.Text = misPokemons.Rows[0]["movimiento3"].ToString();
            movimiento4.Text = misPokemons.Rows[0]["movimiento4"].ToString();
            tipo1.Text = misPokemons.Rows[0]["tipo1"].ToString();
            tipo2.Text = misPokemons.Rows[0]["tipo2"].ToString();
            Peso.Text = misPokemons.Rows[0]["peso"].ToString();
            altura.Text = misPokemons.Rows[0]["altura"].ToString();
            habilidad.Text = misPokemons.Rows[0]["habilidad"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarDatos(id1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarDatos(id2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mostrarDatos(id3);
        }
    }
}
