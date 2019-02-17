using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSGSI.Nodes;
using Newtonsoft.Json;

namespace gsitool
{
    public partial class GsitoolForm : Form
    {
        public GsitoolForm()
        {
            InitializeComponent();
        }

        private void playerComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox10.SelectedItem) != null)
            {
                Program.playerSeats[9].Name = ((PlayerIdNode)playerComboBox10.SelectedItem).Name;
                textBox10.Text = ((PlayerIdNode)playerComboBox10.SelectedItem).SteamID;
            }
        }

        private void playerComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox9.SelectedItem) != null)
            {
                Program.playerSeats[8].Name = ((PlayerIdNode)playerComboBox9.SelectedItem).Name;
                textBox9.Text = ((PlayerIdNode)playerComboBox9.SelectedItem).SteamID;
            }
        }

        private void playerComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox8.SelectedItem) != null)
            {
                Program.playerSeats[7].Name = ((PlayerIdNode)playerComboBox8.SelectedItem).Name;
                textBox8.Text = ((PlayerIdNode)playerComboBox8.SelectedItem).SteamID;
            }
        }

        private void playerComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox7.SelectedItem) != null)
            {
                Program.playerSeats[6].Name = ((PlayerIdNode)playerComboBox7.SelectedItem).Name;
                textBox7.Text = ((PlayerIdNode)playerComboBox7.SelectedItem).SteamID;
            }
        }

        private void playerComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox6.SelectedItem) != null)
            {
                Program.playerSeats[5].Name = ((PlayerIdNode)playerComboBox6.SelectedItem).Name;
                textBox6.Text = ((PlayerIdNode)playerComboBox6.SelectedItem).SteamID;
            }
        }

        private void playerComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox1.SelectedItem) != null)
            {
                Program.playerSeats[0].Name = ((PlayerIdNode)playerComboBox1.SelectedItem).Name;
                textBox1.Text = ((PlayerIdNode)playerComboBox1.SelectedItem).SteamID;
            }
        }

        private void playerComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox2.SelectedItem) != null)
            {
                Program.playerSeats[1].Name = ((PlayerIdNode)playerComboBox2.SelectedItem).Name;
                textBox2.Text = ((PlayerIdNode)playerComboBox2.SelectedItem).SteamID;
            }
        }

        private void playerComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox3.SelectedItem) != null)
            {
                Program.playerSeats[2].Name = ((PlayerIdNode)playerComboBox3.SelectedItem).Name;
                textBox3.Text = ((PlayerIdNode)playerComboBox3.SelectedItem).SteamID;
            }
        }

        private void playerComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox4.SelectedItem) != null)
            {
                Program.playerSeats[3].Name = ((PlayerIdNode)playerComboBox4.SelectedItem).Name;
                textBox4.Text = ((PlayerIdNode)playerComboBox4.SelectedItem).SteamID;
            }
        }

        private void playerComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((PlayerIdNode)playerComboBox5.SelectedItem) != null)
            {
                Program.playerSeats[4].Name = ((PlayerIdNode)playerComboBox5.SelectedItem).Name;
                textBox5.Text = ((PlayerIdNode)playerComboBox5.SelectedItem).SteamID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerComboBox1.Items.Clear();
            playerComboBox2.Items.Clear();
            playerComboBox3.Items.Clear();
            playerComboBox4.Items.Clear();
            playerComboBox5.Items.Clear();
            playerComboBox6.Items.Clear();
            playerComboBox7.Items.Clear();
            playerComboBox8.Items.Clear();
            playerComboBox9.Items.Clear();
            playerComboBox10.Items.Clear();
            if (Program.GsiManager.players != null)
            {
                foreach (PlayerNode n in Program.GsiManager.players)
                {
                    PlayerIdNode p = new PlayerIdNode(n);
                    if (!playerComboBox1.Items.Contains(p))
                    {
                        playerComboBox1.Items.Add(p);
                        playerComboBox2.Items.Add(p);
                        playerComboBox3.Items.Add(p);
                        playerComboBox4.Items.Add(p);
                        playerComboBox5.Items.Add(p);
                        playerComboBox6.Items.Add(p);
                        playerComboBox7.Items.Add(p);
                        playerComboBox8.Items.Add(p);
                        playerComboBox9.Items.Add(p);
                        playerComboBox10.Items.Add(p);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            playerComboBox1.SelectedIndex = -1;
            playerComboBox2.SelectedIndex = -1;
            playerComboBox3.SelectedIndex = -1;
            playerComboBox4.SelectedIndex = -1;
            playerComboBox5.SelectedIndex = -1;
            playerComboBox6.SelectedIndex = -1;
            playerComboBox7.SelectedIndex = -1;
            playerComboBox8.SelectedIndex = -1;
            playerComboBox9.SelectedIndex = -1;
            playerComboBox10.SelectedIndex = -1;
        }

        private void GsitoolForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.GsiManager.Stop();
            Application.Exit();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[9].SteamID = textBox10.Text;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[1].SteamID = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[2].SteamID = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[3].SteamID = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[4].SteamID = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[5].SteamID = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[6].SteamID = textBox7.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[7].SteamID = textBox8.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[8].SteamID = textBox9.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.playerSeats[0].SteamID = textBox1.Text;
        }

        private void LoadLeftTeam_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                var fileContents = sr.ReadToEnd();
                sr.Close();
                
                var conf = JsonConvert.DeserializeObject<PkmConfData>(fileContents);
                SetLeftTeam(conf);
            }
        }

        private void SetLeftTeam(PkmConfData teamConfig)
        {
            foreach(KeyValuePair<string,PkmPlayerConf> kvp in teamConfig.players)
            {
                switch (kvp.Value.place)
                {
                    case 1:
                        textBox1.Text = kvp.Key;
                        Program.playerSeats[0].Name = kvp.Value.player_name;
                        Program.playerSeats[0].SteamID = kvp.Key;
                        break;
                    case 2:
                        textBox2.Text = kvp.Key;
                        Program.playerSeats[1].Name = kvp.Value.player_name;
                        Program.playerSeats[1].SteamID = kvp.Key;
                        break;
                    case 3:
                        textBox3.Text = kvp.Key;
                        Program.playerSeats[2].Name = kvp.Value.player_name;
                        Program.playerSeats[2].SteamID = kvp.Key;
                        break;
                    case 4:
                        textBox4.Text = kvp.Key;
                        Program.playerSeats[3].Name = kvp.Value.player_name;
                        Program.playerSeats[3].SteamID = kvp.Key;
                        break;
                    case 5:
                        textBox5.Text = kvp.Key;
                        Program.playerSeats[4].Name = kvp.Value.player_name;
                        Program.playerSeats[4].SteamID = kvp.Key;
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetRightTeam(PkmConfData teamConfig)
        {
            foreach (KeyValuePair<string, PkmPlayerConf> kvp in teamConfig.players)
            {
                switch (kvp.Value.place)
                {
                    case 1:
                        textBox6.Text = kvp.Key;
                        Program.playerSeats[5].Name = kvp.Value.player_name;
                        Program.playerSeats[5].SteamID = kvp.Key;
                        break;
                    case 2:
                        textBox7.Text = kvp.Key;
                        Program.playerSeats[6].Name = kvp.Value.player_name;
                        Program.playerSeats[6].SteamID = kvp.Key;
                        break;
                    case 3:
                        textBox8.Text = kvp.Key;
                        Program.playerSeats[7].Name = kvp.Value.player_name;
                        Program.playerSeats[7].SteamID = kvp.Key;
                        break;
                    case 4:
                        textBox9.Text = kvp.Key;
                        Program.playerSeats[8].Name = kvp.Value.player_name;
                        Program.playerSeats[8].SteamID = kvp.Key;
                        break;
                    case 5:
                        textBox10.Text = kvp.Key;
                        Program.playerSeats[9].Name = kvp.Value.player_name;
                        Program.playerSeats[9].SteamID = kvp.Key;
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadRightTeam_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                var fileContents = sr.ReadToEnd();
                sr.Close();

                var conf = JsonConvert.DeserializeObject<PkmConfData>(fileContents);
                SetRightTeam(conf);
            }
        }

        private void SaveLeftJson_Click(object sender, EventArgs e)
        {
            PkmConfData data = new PkmConfData();
            data.players = new Dictionary<string, PkmPlayerConf>();
            for (int i = 0; i < 5; i++)
            {
                var pc = new PkmPlayerConf();
                pc.channel = "cam" + (i + 1);
                pc.place = i + 1;
                pc.player_name = Program.playerSeats[i].Name;
                pc.server = 0;
                data.players.Add(Program.playerSeats[i].SteamID, pc);
            }
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName != "")
            {
                System.IO.TextWriter writer = null;
                try
                {
                    writer = new StreamWriter(saveFileDialog1.FileName, false);
                    writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }

        private void SaveRightJson_Click(object sender, EventArgs e)
        {
            PkmConfData data = new PkmConfData();
            data.players = new Dictionary<string, PkmPlayerConf>();
            for (int i = 0; i < 5; i++)
            {
                var pc = new PkmPlayerConf();
                pc.channel = "cam" + (i + 1);
                pc.place = i + 1;
                pc.player_name = Program.playerSeats[i+5].Name;
                pc.server = 0;
                data.players.Add(Program.playerSeats[i+5].SteamID, pc);
            }
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.TextWriter writer = null;
                try
                {
                    writer = new StreamWriter(saveFileDialog1.FileName, false);
                    writer.Write(JsonConvert.SerializeObject(data, Formatting.Indented));
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }
    }
}
