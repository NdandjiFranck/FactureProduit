using FactureProduit.BO;
using FactureProduit.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactureProduit.Winforms
{
    public partial class FrmProduit : Form
    {
        private ProduitRepository produitRepository { get; }
        private Produit oldProduit;
        public FrmProduit(ProduitRepository produitRepository)
        {
            InitializeComponent();
            this.produitRepository = produitRepository;
            dataGridView1.AutoGenerateColumns = false;

        }      
        private void LoadGrid(IEnumerable<Produit> produits)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = produits;
        }

        private void FrmProduit_Load(object sender, EventArgs e)
        {
            LoadGrid(this.produitRepository.GetAll());
        }

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<Produit> produits = new List<Produit>();
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    produits.Add(dataGridView1.SelectedRows[i].DataBoundItem as Produit);

                }
                this.produitRepository.Delete(produits, LoadGrid);

                MessageBox.Show
                     (
                       "Suppression effectuer!",
                       "Confirmation",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                     );
            }
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                Produit produit = new Produit(txtNom.Text, txtPrixUnitaire.Text, txtRefeerence.Text, txtTva.Text);
                if (this.oldProduit == null)
                    this.produitRepository.Add(produit, LoadGrid);
                else
                    this.produitRepository.Set(this.oldProduit, produit, LoadGrid);
                LoadGrid(this.produitRepository.GetAll());
                MessageBox.Show
                 (
                   "Enregistrement effectuer!",
                   "Confirme",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
                 );
                this.oldProduit = null;
                txtNom.Clear();
                txtPrixUnitaire.Clear();
                txtRefeerence.Clear();
                txtTva.Clear();

            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur c'est produit!", "Confirme",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRecherche_TextChanged_1(object sender, EventArgs e)
        {
            this.produitRepository.Find
            (X => X.Reference.ToLower().Contains(txtRecherche.Text.ToLower()) || X.Nom.ToLower().Contains(txtRecherche.Text.ToLower()),LoadGrid );
        }

        private void btnFacture_Click_1(object sender, EventArgs e)
        {
            List<Produit> items = new List<Produit>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Produit p = dataGridView1.Rows[i].DataBoundItem as Produit;
                items.Add
                (new Produit(p.Reference, p.Nom,p.PrixUnitaire,p.TVA));
            }
            Form f = new FrmPreview("RptProductList.rdlc", items);
            f.Show();
        }
    }  
}
