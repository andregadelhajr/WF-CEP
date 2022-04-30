using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula41_Cep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", txtCEP.Text);
                ds.ReadXml(xml);
                txtLogradouro.Text = ds.Tables[0].Rows[0]["Logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["Bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["Cidade"].ToString();
                txtUF.Text = ds.Tables[0].Rows[0]["UF"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }
    }
}
