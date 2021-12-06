using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int cR, cG, cB;

        private String nombreimagen="";
        public Form1()
        {
            InitializeComponent();
            button9 .Visible=false;
            AddtextBD.Visible = false;
            comboBox2.Visible = false;

            actualizarcombobox1();
        }
        public void actualizarcombobox1()
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            SqlConnection conexion = new SqlConnection();
            SqlDataAdapter data = new SqlDataAdapter();
            DataSet ds = new DataSet();
            conexion.ConnectionString = "Data Source=DESKTOP-B31I13B;Initial Catalog=examen324;Integrated Security=True";
            data.SelectCommand = new SqlCommand();
            data.SelectCommand.Connection = conexion;
            data.SelectCommand.CommandText = "SELECT * FROM PICTURE";

            data.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                String codigo = ds.Tables[0].Rows[i]["id_img"].ToString();
                comboBox1.Items.Add(codigo);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Cargar imagen
            openFileDialog1.ShowDialog();
            
  
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);

            nombreimagen = (String)openFileDialog1.SafeFileName;
            pictureBox1.Image = bmp;
            button9.Visible = true;
            AddtextBD.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Recuperar color
            Bitmap bpm = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bpm.GetPixel(10, 10);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
            Bitmap bpm = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            int x,y;
            x=e.X;
            y=e.Y;
            int mG=0, mR=0, mB=0;
            for(int i=x; i<x+10; i++){
                for(int j=y; j<y+10; j++){
                    //No funciona en los extremos
                    c = bpm.GetPixel(i, j);
                     mR=mR+c.R;
                     mG=mG+c.G;
                     mB=mB+c.B;
                }
            }
            mR=mR/100;
            mG=mG/100;
            mB=mB/100;
            cR = mR;
            cG = mG;
            cB = mB;
            c = bpm.GetPixel(e.X, e.Y);
            textBox1.Text = cR.ToString();
            textBox2.Text = cG.ToString();
            textBox3.Text = cB.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for(int i=1; i<bmp.Width; i++){
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    copia.SetPixel(i, j, c);
                }
            }
            pictureBox2.Image = copia;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
            {
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    copia.SetPixel(i, j, Color.FromArgb(c.R,0,0));
                }
            }
            pictureBox2.Image = copia;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
            {
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    copia.SetPixel(i, j, Color.FromArgb(0, c.G, 0));
                }
            }
            pictureBox2.Image = copia;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
            {
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    copia.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            }
            pictureBox2.Image = copia;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 1; i < bmp.Width; i++)
            {
                for (int j = 1; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (cR-10 <= c.R && c.R <= cR+10 && cG-10 <= c.G && c.G <= cG+10  && cB-10 <= c.B && c.B <= cB+10 )
                    {
                        copia.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        copia.SetPixel(i, j, c);
                    }

                }
            }
            pictureBox2.Image = copia;
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width-10; i+=10)
            {
                for (int j = 0; j < bmp.Height-10; j+=10)
                {
                    meR=0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i+10; k++) {
                        for (int l = j; l < j+10; l++) {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    }

                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;

                    if ((cR - 10) <= meR && meR <= (cR + 10) && (cG - 10) <= meG && meG <= (cG + 10 )&& (cB - 10) <= meB && meB <= (cB + 10))
                    {
                        for (int k = i; k <= i + 10; k++)
                        {
                            for (int l = j; l <= j + 10; l++)
                            {
                                Color color = System.Drawing.ColorTranslator.FromHtml("#FF00FF");
                                copia.SetPixel(k, l, color);
                            }
                        }
                    }
                    else
                    {
                        for (int k = i; k <= i + 10; k++)
                        {
                            for (int l = j; l <= j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                copia.SetPixel(k, l, c);
                            }
                        }
                    }

                }
            }
            pictureBox2.Image = copia;
            AddtextBD.Visible = true;
        }


        private void button9_Click(object sender, EventArgs e)
        {
            
            Bitmap img = new Bitmap(pictureBox1.Image);

            byte[] Imagencod = ImagenaByte(img);
            String imagendata64= "data:image/jpg;base64,"+Convert.ToBase64String(Imagencod);
            
            //insertar en la base de datos
            SqlConnection con= new SqlConnection();
            SqlDataAdapter ada= new SqlDataAdapter();
            DataSet ds =new DataSet();
            con.ConnectionString = "Data Source=DESKTOP-B31I13B;Initial Catalog=examen324;Integrated Security=True";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "INSERT INTO PICTURE (Img) values (@img)";
            ada.SelectCommand.Parameters.Add("@img",SqlDbType.Image).Value=Imagencod;
            ada.Fill(ds);
            actualizarcombobox1();
        }

        public static byte[] ImagenaByte(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cargamos la imagen
            string codigo = (string)comboBox1.SelectedItem;

            SqlConnection con = new SqlConnection();
            SqlDataAdapter ada = new SqlDataAdapter();
            DataSet ds = new DataSet();
            con.ConnectionString = "Data Source=DESKTOP-B31I13B;Initial Catalog=examen324;Integrated Security=True";
            ada.SelectCommand = new SqlCommand();
            ada.SelectCommand.Connection = con;
            ada.SelectCommand.CommandText = "SELECT * FROM PICTURE WHERE id_img= @id";
            nombreimagen = codigo;
            ada.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = codigo;    
            ada.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];

                byte[] imagencod = (byte[])ds.Tables[0].Rows[i]["img"];
                ImageConverter ic = new ImageConverter();

                Image imagen = (Image)ic.ConvertFrom(imagencod);
                Bitmap img = new Bitmap(imagen);
                pictureBox1.Image = imagen;
            }
            button9.Visible = false;
            comboBox2.Visible = true;
            // Cargamos la lista de texturas
            cargarcombobox2(codigo);

        }

        public void cargarcombobox2(String codigo){

            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            SqlConnection con2 = new SqlConnection();
            SqlDataAdapter ada2 = new SqlDataAdapter();
            DataSet ds2 = new DataSet();

            con2.ConnectionString = "Data Source=DESKTOP-B31I13B;Initial Catalog=examen324;Integrated Security=True";
            ada2.SelectCommand = new SqlCommand();
            ada2.SelectCommand.Connection = con2;
            ada2.SelectCommand.CommandText = "SELECT * FROM coordenada WHERE id_img= @id";
            ada2.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = codigo;
            ada2.Fill(ds2);
            int cont = ds2.Tables[0].Rows.Count;

            for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds2.Tables[0].Rows[i];
                String codtext = ds2.Tables[0].Rows[i]["id_textura"].ToString();
                String R = ds2.Tables[0].Rows[i]["R"].ToString();
                String G = ds2.Tables[0].Rows[i]["G"].ToString();
                String B = ds2.Tables[0].Rows[i]["B"].ToString();
                String pintura = ds2.Tables[0].Rows[i]["color"].ToString();
                comboBox2.Items.Add(R + "," + G + "," + B + ";" + pintura);
            }

        }

        private void AddtextBD_Click(object sender, EventArgs e)
        {
            //Seleccionamos color
            if(colorDialog1.ShowDialog()==DialogResult.OK){
                 
                Color col = colorDialog1.Color;
             
                string hex = col.R.ToString("X2") + col.G.ToString("X2") + col.B.ToString("X2");
                String color ="#"+hex;
                SqlConnection con = new SqlConnection();
                SqlDataAdapter ada = new SqlDataAdapter();
                DataSet ds = new DataSet();
                con.ConnectionString = "Data Source=DESKTOP-B31I13B;Initial Catalog=examen324;Integrated Security=True";
                ada.SelectCommand = new SqlCommand();
                ada.SelectCommand.Connection = con;
                ada.SelectCommand.CommandText = "INSERT INTO coordenada (id_img,color,nombre,R,G,B) values (@id_img, @color,@nombre,@R, @G, @B)";
                ada.SelectCommand.Parameters.Add("@id_img", SqlDbType.Int).Value = Int32.Parse(nombreimagen);
                ada.SelectCommand.Parameters.Add("@color", SqlDbType.Text).Value = color;
                ada.SelectCommand.Parameters.Add("@nombre", SqlDbType.Text).Value = textBox4.Text.ToString();
                ada.SelectCommand.Parameters.Add("@R", SqlDbType.Int).Value = cR;
                ada.SelectCommand.Parameters.Add("@G", SqlDbType.Int).Value = cG;
                ada.SelectCommand.Parameters.Add("@B", SqlDbType.Int).Value = cB;
                ada.Fill(ds);

                cargarcombobox2(nombreimagen);
                AddtextBD.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            String  textura = (string)comboBox2.SelectedItem;
            String[] elementos = textura.Split(';');
            String colores = elementos[0];
            String codi = elementos[1];

            String[] RGB=colores.Split(',');

            String R = RGB[0];
            String G = RGB[1];
            String B = RGB[2];
            cR =Int32.Parse(R);
            cG = Int32.Parse(G);
            cB = Int32.Parse(B);

            String tonopint = textura.Substring(textura.IndexOf("p=")+1);
            textBox1.Text = R;
            textBox2.Text = G;
            textBox3.Text = B;

            int meR, meG, meB;
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap copia = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
                       

            for (int i = 0; i < bmp.Width - 10; i += 10)
            {
                for (int j = 0; j < bmp.Height - 10; j += 10)
                {
                    meR = 0;
                    meG = 0;
                    meB = 0;

                    for (int k = i; k < i + 10; k++)
                    {
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            meR = meR + c.R;
                            meG = meG + c.G;
                            meB = meB + c.B;
                        }
                    }

                    meR = meR / 100;
                    meG = meG / 100;
                    meB = meB / 100;

                    if (cR - 10 <= meR && meR <= cR + 10 && cG - 10 <= meG && meG <= cG + 10 && cB - 10 <= meB && meB <= cB + 10)
                    {
                        for (int k = i; k < i + 10; k++)
                        {
                            for (int l = j; l < j + 10; l++)
                            {
                                Color color = System.Drawing.ColorTranslator.FromHtml(codi);
                                copia.SetPixel(k, l, color);
                            }
                        }
                    }
                    else
                    {
                        for (int k = i; k < i + 10; k++)
                        {
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                copia.SetPixel(k, l, c);
                            }
                        }
                    }

                }
            }
            pictureBox2.Image = copia;
            AddtextBD.Visible = true;
            AddtextBD.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
