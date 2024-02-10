using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using sheet.Properties;

namespace sheet
{
    public partial class Roll : Form
    {
        private const string DiscordWebhookUrl = "https://discord.com/api/webhooks/1202673367551967263/LrX7jPTLWUwjcmJ2lNS1gvdxKfeAkpJ7fTYUUSXkq0PyeEuGYMY05Hmir6-6F2YtIckf";

        public int last_roll = 0;
        string[] weapon_info = new string[2];
        public string pc_name = "";

        private int modifier = 0;
        public Roll()
        {
            InitializeComponent();
        }

        public Roll(int modifier, string weapon)
        {
            InitializeComponent();
            this.modifier = modifier;
            panel1.Visible = false;
            if (weapon != "")
            {
                weapon_info[0] = weapon.Split(',')[0];
                weapon_info[1] = weapon.Split(',')[1];
            }

            // center label and increase font size
            lbl_roll.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl_roll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //size of form is 150x80
            lbl_roll.Location = new System.Drawing.Point(Width / 2 - lbl_roll.Width / 2, Height / 2 - lbl_roll.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rollDice(4);
        }

        public void rollDice(int sides)
        {
            Random rnd = new Random();
            int result = rnd.Next(1, sides + 1);
            string message = $"{Properties.Settings.Default.pl_name} rolled {sides}-sided dice and got {result} {(modifier > 0 ? $"+{modifier}" : (modifier == 0 ? "" : $"{modifier}"))}.{(result == 20 ? "NAT20 - Critical!!!" :"")}{(result==1 ? "NAT1 - Critical Fail!!!" : "")}";

            result += modifier;
            if (weapon_info[0] != null)
            {
                string x = pc_name != "" ? $"{pc_name} ({Properties.Settings.Default.pl_name})" : Properties.Settings.Default.pl_name;
                message = $"{x} {weapon_info[1]} with {weapon_info[0]} and inflicted {result} damage.";
            }
            lbl_roll.Text = result.ToString();
            last_roll = result;
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
