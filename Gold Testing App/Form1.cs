namespace Gold_Testing_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Continuous;

            // Simulate progress
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                await Task.Delay(50); // Delay to make the progress bar visible

                // Check if progress is complete
                if (i == progressBar1.Maximum)
                {
                    OnProgressCompleted(); // Call completion event handler
                }
            }
        }

        private void OnProgressCompleted()
        {
            MessageBox.Show("Loading Complete ! Click to goto Login Page...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Show login form and close this form
            Login log = new Login();
            log.Show();

            this.Hide();
            Task.Delay(500).Wait(); // Small delay for smooth transition
            //this.Close();
        }
    }
}
