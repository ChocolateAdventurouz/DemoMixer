using System.Windows.Forms;
using Un4seen.Bass;


namespace DemoMixer
{
    public partial class Form1 : Form
    {
        int stream;
        string selectedFile;
        int counter;

        public int crossfadeTimeInMs;
        public int fadeNextTimeInMs;
        //public int pauseFadeTimeInMs;
        public int stopFadeTimeInMs;

        public bool repeat;
        Queue<string> strings = new Queue<string>();
        public Form1()
        {
            InitializeComponent();
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_STEREO, nint.Zero)) ;
            {

                MessageBox.Show(Bass.BASS_ErrorGetCode().ToString());
            }

            crossfadeTimeInMs = (int)numericUpDown2.Value * 1000;
            fadeNextTimeInMs = (int)numericUpDown3.Value * 1000;
            //pauseFadeTimeInMs = (int)numericUpDown1.Value * 1000;
            stopFadeTimeInMs = (int)numericUpDown4.Value * 1000;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = true;
            OFD.ShowDialog(this);

            foreach (string file in OFD.FileNames)
            {
                listBox1.Items.Add(file);
                strings.Enqueue(file);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { repeat = true; }
            else { repeat = false; }

            stream = Bass.BASS_StreamCreateFile(listBox1.Items[0].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE);

            Bass.BASS_ChannelPlay(stream, repeat);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, stopFadeTimeInMs);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, fadeNextTimeInMs);
            stream = Bass.BASS_StreamCreateFile(listBox1.Items[1].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE);
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0);
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 1, 1500);
            Bass.BASS_ChannelPlay(stream, repeat);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Bass.BASS_ChannelPause(stream);
            }
            else
            {
                Bass.BASS_ChannelPlay(stream, false);
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //pauseFadeTimeInMs = (int)numericUpDown1.Value * 1000;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            crossfadeTimeInMs = (int)numericUpDown2.Value * 1000;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            fadeNextTimeInMs = (int)numericUpDown3.Value * 1000;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            repeat = (bool)checkBox1.Checked;
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            stopFadeTimeInMs = (int)numericUpDown4.Value * 1000;
        }
    }
}
