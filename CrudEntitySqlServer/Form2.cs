using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudEntitySqlServer
{
    public partial class Form2 : Form
    {
        DbEntity2Entities db;

        public Form2(Artigos obj)
        {
            InitializeComponent();

            db = new DbEntity2Entities();

            if (obj == null)
            {
                artigosBindingSource.DataSource = new Artigos();
                db.Artigos.Add(artigosBindingSource.Current as Artigos);
            }
            else
            {
                artigosBindingSource.DataSource = obj;
                db.Artigos.Attach(artigosBindingSource.Current as Artigos);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(txtPalavra.Text))
                {
                    MessageBox.Show("Por favor digite a palavra", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPalavra.Focus();
                    e.Cancel = true;
                    return;
                }
                db.SaveChanges();
                e.Cancel = false;
            }
            e.Cancel = false;
        }
    }
}
