using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace sheet
{
    public partial class Roll : Form
    {
        private const string DiscordWebhookUrl = "";

        readonly Character character;
        public Roll()
        {
            InitializeComponent();
        }

        public Roll(Character character)
        {
            InitializeComponent();
            this.character = character;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rollDice(4);
        }

        private void rollDice(int sides)
        {
            Random rnd = new Random();
            int result = rnd.Next(1, sides + 1);
            string message = "Rolled " + sides + "-sided dice and got " + result + ".";
            lbl_roll.Text = result.ToString();
            SendToDiscord(message);
        }

        private async Task SendToDiscord(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "content", message }
                });

                await client.PostAsync(DiscordWebhookUrl, content);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rollDice(6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rollDice(8);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rollDice(10);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rollDice(12);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            rollDice(20);
        }
    }
}
