namespace F1_Racing_Hub
{
    public partial class AppForm : Form
    {
        public AppForm()
        {
            listenerObject = new RacingHubListener();
            InitializeComponent();
        }
    }
}