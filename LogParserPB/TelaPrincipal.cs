using System.Windows.Forms;

namespace LogParserPB
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private void txtBxEntrada_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBxSaida_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAnalisar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBxEntrada.Text.Trim().ToString()))
            {
                DialogResult dialogResult = MessageBox.Show("Verifique se TODOS os campos foram preenchidos!",
                  "Campos obrigatórios não preenchidos!", MessageBoxButtons.OK);
            }
            else
            {
                if (CheckBoxPb.Checked)
                {
                    LogParser logParser = new LogParser();
                    logParser.ExtractSqlFromLog(txtBxEntrada.Text.Trim().ToString(), txtBxSaida.Text.Trim().ToString());
                }
                else if (checkBoxJava.Checked) {
                    JBossLogParser jBossLogParser = new JBossLogParser();
                    jBossLogParser.ExtractSqlFromJBossLog(txtBxEntrada.Text.Trim().ToString(), txtBxSaida.Text.Trim().ToString());

                }
                else
                {
                 DialogResult dialogResult = MessageBox.Show("Selecione Java ou PB",
                  "Campos obrigatórios não preenchidos!", MessageBoxButtons.OK);

                }

            }


        }

        private void checkBoxJava_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxPb_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
