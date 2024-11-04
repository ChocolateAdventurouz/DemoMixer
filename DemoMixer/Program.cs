using System.Runtime.CompilerServices;
using Un4seen.Bass;

namespace DemoMixer
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public Bass bass;
        
        [STAThread]
        static void Main()
        {
            try
            {
                if (!Bass.BASS_Init(-1, 44100, flags: BASSInit.BASS_DEVICE_STEREO | BASSInit.BASS_DEVICE_DSOUND, nint.Zero)) ;
                {

                    MessageBox.Show(Bass.BASS_ErrorGetCode().ToString());
                }
            }
            catch (System.TypeInitializationException)
            {
                if (MessageBox.Show("BASS x64 & Bassmix X64 not found.") == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            catch (System.BadImageFormatException)
            {
                MessageBox.Show("Bad BASS x64 & Bassmix X64 dlls. \nPlace the x64 dlls of the appropriate libaries onto directory");
                Application.Exit();
            }


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}