using System;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TravailleurScientifique
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

namespace TravailleurScientifique
{
    public class MainForm : Form
    {
        private Button btnAfficher;
        private TextBox txtResultat;

        public MainForm()
        {
            Text = "Test Scientifique";
            Width = 500;
            Height = 400;

            btnAfficher = new Button
            {
                Text = "Créer Scientifique",
                Top = 20,
                Left = 20,
                Width = 150
            };
            btnAfficher.Click += BtnAfficher_Click;

            txtResultat = new TextBox
            {
                Multiline = true,
                Top = 60,
                Left = 20,
                Width = 430,
                Height = 280,
                ReadOnly = true
            };

            Controls.Add(btnAfficher);
            Controls.Add(txtResultat);
        }

        private void BtnAfficher_Click(object sender, EventArgs e)
        {
            Scientifique scientifique = new Scientifique(
                "Einstein",
                "Albert",
                "0600000000",
                "albert@science.com",
                "Université de Princeton",
                "Princeton, USA",
                "0123456789",
                Discipline.Physique,
                TypeScientifique.Theorique
            );

            txtResultat.Text = scientifique.ToString();
        }
    }
