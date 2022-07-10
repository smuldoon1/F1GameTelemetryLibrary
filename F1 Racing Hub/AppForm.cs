namespace F1_Racing_Hub
{
    public partial class AppForm : Form
    {
        private LiveGraph liveGraph;

        public AppForm()
        {
            InitializeComponent();
            liveGraph = new LiveGraph(pictureBox1);
            listenerObject = new RacingHubListener();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            liveGraph.PictureBox.Paint += new PaintEventHandler(liveGraph.Draw);

            // Add the PictureBox control to the Form.
            this.Controls.Add(liveGraph.PictureBox);
        }
    }
}