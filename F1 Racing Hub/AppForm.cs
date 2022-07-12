namespace F1_Racing_Hub
{
    public partial class AppForm : Form
    {
        private LiveGraph liveGraph;

        public AppForm()
        {
            InitializeComponent();
            liveGraph = new LiveGraph(pictureBox1, comboBox2, label2, label4, label5);
            listenerObject = new RacingHubListener();
        }

        private void AppForm_Load(object sender, EventArgs e)
        {
            liveGraph.PictureBox.Paint += new PaintEventHandler(liveGraph.Draw);

            // Add the PictureBox control to the Form.
            this.Controls.Add(liveGraph.PictureBox);
            
            ComboBoxSession[] sessions = Sql.ExecuteArray<ComboBoxSession>("SELECT S.id, T.name, S.type, S.createdOn FROM [F1App].[dbo].[Sessions] S JOIN [F1App].[dbo].[Tracks] T ON S.trackId = T.id ORDER BY S.createdOn DESC");
            comboBox1.Items.AddRange(sessions);
            comboBox1.SelectedIndex = 0;
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

            public byte Type { get; set; }

            public DateTime CreatedOn { get; set; }

            public override string ToString()
            {
                return $"{ F1GameTelemetry_2021.SessionTypeExtensions.ToString((F1GameTelemetry_2021.SessionType)Type) } | { Name } | { CreatedOn }";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetGraphMetric("Speed", radioButton1.Checked);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetGraphMetric("Throttle", radioButton2.Checked);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetGraphMetric("Steer", radioButton3.Checked);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            SetGraphMetric("Gear", radioButton4.Checked);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            SetGraphMetric("EngineRPM", radioButton5.Checked);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            SetGraphMetric("Brake", radioButton5.Checked);
        }

        private void SetGraphMetric(string metric, bool isChecked)
        {
            if (isChecked)
            {
                liveGraph.selectedMetric = metric;
                Refresh();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}