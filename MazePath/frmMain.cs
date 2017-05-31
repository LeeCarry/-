using System;
using System.Windows.Forms;

namespace MazePath
{
    public partial class frmMain : Form
    {
        ShowMaze sm;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!sm.SearchPath((IMaze)cmbAlgorithm.SelectedItem))
                MessageBox.Show("无解");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            sm = new ShowMaze();
            paMaze.Controls.Add(sm);
            cmbAlgorithm.Items.Add(new BFSAlgorithm());
            cmbAlgorithm.SelectedIndex = 0;
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {
            sm.SetAllBalk();
        }

        private void btnEmptyAll_Click(object sender, EventArgs e)
        {
            sm.EmptyAllBalk();
        }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
