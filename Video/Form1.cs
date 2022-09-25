using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video
{
    public partial class Form1 : Form
    {
        String temp = "";
        String tempAudio = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
            temp = Path.GetTempFileName();
            File.Move(temp, temp = Path.ChangeExtension(temp, "mp4"));
            using(FileStream fs = new FileStream(temp, FileMode.OpenOrCreate))
            {
                MemoryStream memoryStream = new MemoryStream(global::Video.Properties.Resources.v1);
                memoryStream.CopyTo(fs);
                memoryStream.Close();
                fs.Close();
            }
            
            axWindowsMediaPlayer1.URL = temp;
          
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(e.newState == 8)
            {
                File.Delete(temp);
            }
        }

        private void btnplaySound_Click(object sender, EventArgs e)
        {
            tempAudio = Path.GetTempFileName();
            File.Move(tempAudio, tempAudio = Path.ChangeExtension(tempAudio, "mp3"));
            using(FileStream fs = new FileStream(tempAudio, FileMode.OpenOrCreate))
            {
                Properties.Resources.som3.CopyTo(fs);
                fs.Close();
            }
            SoundPlayer sp = new SoundPlayer(tempAudio);
            sp.Play();

        }
    }
}
