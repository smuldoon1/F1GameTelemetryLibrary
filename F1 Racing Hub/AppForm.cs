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
            ComboBoxSession[] sessions = Sql.ExecuteArray<ComboBoxSession>("SELECT S.id, T.name, S.type, S.createdOn FROM [F1App].[dbo].[Sessions] S JOIN [F1App].[dbo].[Tracks] T ON S.trackId = T.id");
            comboBox1.Items.AddRange(sessions);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selected = comboBox1.SelectedItem;
            if (selected != null)
                liveGraph.SetSession((selected as ComboBoxSession).Id);
            Refresh();
        }

        private class ComboBoxSession
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public string Type { get; set; }

            public DateTime CreatedOn { get; set; }

            public override string ToString()
            {
                return Name + " (" + Type + ")" + " - " + CreatedOn.ToString();
            }
        }
    }
}