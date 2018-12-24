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
    public partial class Form1 : Form
    {
        DbEntity2Entities db;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new DbEntity2Entities();
            artigosBindingSource.DataSource = db.Artigos.ToList();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (Form2 frm = new Form2(null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    artigosBindingSource.DataSource = db.Artigos.ToList();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (artigosBindingSource.Current != null)
            {
                using (Form2 frm = new Form2(artigosBindingSource.Current as Artigos))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        artigosBindingSource.DataSource = db.Artigos.ToList();
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (artigosBindingSource.Current != null)
            {
                if (MessageBox.Show("Voce quer mesmo excluir este artigo?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Artigos.Remove(artigosBindingSource.Current as Artigos);
                    artigosBindingSource.RemoveCurrent();
                    db.SaveChanges();
                }
            }
        }
    }
}
