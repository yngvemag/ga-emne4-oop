namespace SimpleCalculator
{
    public partial class SimpleCalc : Form
    {
        public SimpleCalc()
        {
            InitializeComponent();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            lblWarningTallA.Text = string.Empty;
            lblWarningTallB.Text = string.Empty;

            // hvis input er tom eller ikke et tall
            if (txtTallA.Text.Equals(string.Empty) || !int.TryParse(txtTallA.Text, out int tallA))
            {
                lblWarningTallA.Text = "Du må skrive inn et tall!";
                return;
            }

            // hvis input er tom eller ikke et tall
            if (txtTallB.Text.Equals(string.Empty) || !int.TryParse(txtTallB.Text, out int tallB))
            {
                lblWarningTallB.Text = "Du må skrive inn et tall!";
                return;
            }

            // sikker på at det er tall i txtTallA!!  => ligger i variable tallA og tallB
            int sum = tallA + tallB;

            txtSum.Text = sum.ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile.InitialDirectory = "C:\\ga\\Emne 4 OOP Introduksjon";
            openFile.Filter = "csv files (*.csv)|*.csv";

            if (openFile.ShowDialog().Equals(DialogResult.OK))
            {
                lblWarningTallA.Text = openFile.FileName;
            }
        }
    }
}