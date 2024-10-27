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
            Task.Run(() => Play());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, stopFadeTimeInMs);
        }

        public static int GetRemainingMilliseconds(int channel)
        {
            // Get the total length in bytes and convert to seconds
            long length = Bass.BASS_ChannelGetLength(channel);
            double totalSeconds = Bass.BASS_ChannelBytes2Seconds(channel, length);

            // Get the current position in bytes and convert to seconds
            long position = Bass.BASS_ChannelGetPosition(channel);
            double currentSeconds = Bass.BASS_ChannelBytes2Seconds(channel, position);

            // Calculate remaining time in milliseconds and round to an integer
            double remainingSeconds = totalSeconds - currentSeconds;
            return (int)(remainingSeconds * 1000); // Convert seconds to milliseconds and cast to int
        }


        private async Task Play()
        {
            Thread crossfade = new Thread(PlayNext);
            if (checkBox1.Checked) { repeat = true; }
            else { repeat = false; }

            stream = Bass.BASS_StreamCreateFile(listBox1.Items[0].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE);

            Bass.BASS_ChannelPlay(stream, repeat);
            while (Bass.BASS_ChannelIsActive(stream) == BASSActive.BASS_ACTIVE_PLAYING)
            {
                if (GetRemainingMilliseconds(stream) == crossfadeTimeInMs) {

                    crossfade.Start();
                    Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, crossfadeTimeInMs); // fade-out
                }
            }



        }
        private void PlayNext() {
            stream = Bass.BASS_StreamCreateFile(listBox1.Items[1].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE); // create next stream
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0); // settings its volume to 0
            Bass.BASS_ChannelPlay(stream, repeat); // play next stream
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 1, crossfadeTimeInMs); // fadein
        }
        private void Next()
        {
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, fadeNextTimeInMs);
            stream = Bass.BASS_StreamCreateFile(listBox1.Items[1].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE);
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0);
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 1, 1500);
            Bass.BASS_ChannelPlay(stream, repeat);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Next();
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
            // fix up - workaround needed
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
