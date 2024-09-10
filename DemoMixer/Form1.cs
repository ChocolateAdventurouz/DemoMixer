using System.Windows.Forms;
using Un4seen.Bass;


namespace DemoMixer
{
    public partial class Form1 : Form
    {
        int stream;
        string selectedFile;
        int counter;

        Queue<string> strings = new Queue<string>();
        public Form1()
        {
            InitializeComponent();
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_STEREO, nint.Zero)) ;
            {

                MessageBox.Show(Bass.BASS_ErrorGetCode().ToString());
            }
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
            stream = Bass.BASS_StreamCreateFile(listBox1.Items[0].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE);
            Bass.BASS_ChannelPlay(stream, false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, 1500);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0, 1500);
            stream = Bass.BASS_StreamCreateFile(listBox1.Items[1].ToString(), 0, 0, BASSFlag.BASS_STREAM_AUTOFREE);
            Bass.BASS_ChannelSetAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 0);
            Bass.BASS_ChannelSlideAttribute(stream, BASSAttribute.BASS_ATTRIB_VOL, 1, 1500);
            Bass.BASS_ChannelPlay(stream, false);
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
    }
}
