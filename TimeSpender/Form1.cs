using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;


namespace TimeSpender
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private DateTime startTime;
        private TimeSpan elapsedTime;
        private List<string> categories;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            categories = new List<string>("Work", "Coding", "Gaming");
            UpdateCategoryComboBox();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - startTime;
            lblTimer.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            timer.Start();
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (cmbCategory.SelectedItem != null)
            {
                await SaveTimeAsync(cmbCategory.SelectedItem.ToString(), elapsedTime);
                MessageBox.Show($"Time saved for category: {cmbCategory.SelectedItem.ToString()}");
            }
            else
            {
                MessageBox.Show("Please select a category before stopping the timer.")
            }
        }

        private async Task SaveTimeAsync(string category, TimeSpan timeSpent)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent($"{{\"category\":\"{category}\",\"timeSpent\":\"{timeSpent.TotalSeconds}\"}}", Encoding.UTF8, "application/json");
                await client.PostAsync("http://localhost:3000/saveTime", content);
            } 
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var categoryForm = new CategoryForm(categories);
            categoryForm.CategoryListChanged += (s, args) => UpdateCategoryComboBox();
            categoryForm.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTimer.Text = "00:00:00";
            elapsedTime = TimeSpan.Zero;
        }

        private void UpdateCategoryComboBox()
        {
            cmbCategory.Items.Clear();
            cmdCategory.Items.AddRange(categories.ToArray());
            if(categories.Count >0 ) 
                cmbCategory.SelectedIndex = 0;
        }        
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
