using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
namespace Punto1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DTP.Format = DateTimePickerFormat.Custom;
            DTP.CustomFormat = "MM yy";
            lstError.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TXTNumber_TextChanged(object sender, EventArgs e)
        {
            string Number = Convert.ToString(TXTNumber.Text.Length);
        }
        private void TXTNumber_TextChanged(object sender, KeyPressEventArgs e)
        {
            Validar.Numbers(e);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            lstError.Items.Clear();
            var all = false;
            ValidarTarjeta ValTar = new ValidarTarjeta();

            if (!ValTar.NumeroNulo(TXTNumber.Text))
            {
                lstError.Items.Add(ValTar.Messaje);

                if (!ValTar.FechaCadNula(DTP.Value.ToString("yyyy")))
                {
                    lstError.Items.Add(ValTar.Messaje);

                    if (!ValTar.LenghNumber16(TXTNumber.Text))
                    {
                        lstError.Items.Add(ValTar.Messaje);

                        if (!ValTar.Betw07y20year(DTP.Value.ToString("MM yy")))
                        {
                            lstError.Items.Add(ValTar.Messaje);

                            if (!ValTar.CadYearMet(DTP.Value.ToString("yyyy")))
                            {
                                lstError.Items.Add(ValTar.Messaje);

                                if (!ValTar.NumberStarts(TXTNumber.Text))
                                {
                                    lstError.Items.Add(ValTar.Messaje);
                                    all = true;
                                    lstError.Items.Add("Se cumplio con todos los requerimientos anteriores_ Estado: "+all ) ;
                                    return;
                                }
                                else { lstError.Items.Add(ValTar.Messaje); }

                            }
                            else { lstError.Items.Add(ValTar.Messaje); }
                        }
                        else { lstError.Items.Add(ValTar.Messaje); }
                    }
                    else { lstError.Items.Add(ValTar.Messaje); }
                }
                else { lstError.Items.Add(ValTar.Messaje); }
            }

            lstError.Visible = true;

        }

        private void LVTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnPerfectos_Click(object sender, EventArgs e)
        {
            lstperfects.Items.Clear();
            if (Validar.validarNulo(txtPerfectos.Text))
            { lstperfects.Items.Add("Favor ingresar un numero para evaluar");
                return;
            };
            PefectNumbers evalue = new PefectNumbers(txtPerfectos.Text);
            lstperfects.Items.Add(evalue.perfects);
            int ContarPares(int d) => d.ToString().Where(x => x % 2 == 0).Count();
            Console.WriteLine(ContarPares(Convert.ToInt32(txtPerfectos.Text)));
        }

        private void txtPerfect(object sender, KeyPressEventArgs e)
        {
            Validar.Numbers(e);
        }
    }
}
