using NAudio.CoreAudioApi;
using NAudio.Wave;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Audio_Processing
{

    /// <summary>
    /// Represents a form for audio processing, including recording and playback.
    /// </summary>
    public partial class AudioProcessor : Form
    {
        private WaveInEvent waveIn;
        private BufferedWaveProvider bufferedWaveProvider;
        private WaveOut waveOut;
        private bool isCapturing = false;
        private float volume;

        public AudioProcessor()
        {
            InitializeComponent();
            LoadInputDevices();
            LoadOutputDevices();
            waveOut = new WaveOut();
            bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat());
        }
        private void LoadInputDevices()
        {
            var enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            InputDev.Items.AddRange(devices.ToArray());
            InputDev.SelectedIndex = 0;
        }

        private void LoadOutputDevices()
        {
            var enumerator = new MMDeviceEnumerator();
            var device = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            OutputDev.Items.AddRange(device.ToArray());
            OutputDev.SelectedIndex = 0;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (!isCapturing)
            {
                waveIn = new WaveInEvent();
                waveIn.DeviceNumber = InputDev.SelectedIndex;
                waveIn.WaveFormat = new WaveFormat(44100, 1);

                waveOut = new WaveOut();
                waveOut.DeviceNumber = OutputDev.SelectedIndex;
                bufferedWaveProvider = new BufferedWaveProvider(waveIn.WaveFormat);

                waveIn.DataAvailable += Capture_DataAvailable;

                waveIn.StartRecording();
                StartPlayback();

                isCapturing = true;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (isCapturing)
            {
                waveIn.StopRecording();
                StopPlayback();
                bufferedWaveProvider.ClearBuffer();
                isCapturing = false;
            }
        }


        /// <summary>
        /// Handles the DataAvailable event of the WaveInEvent to process audio data during recording.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">An instance of WaveInEventArgs containing the audio data captured from the recording device.</param>
        /// <remarks>
        /// This method is invoked whenever new audio data is available from the recording device during the recording process. 
        /// It processes the incoming audio data, adjusts its volume, and adds it to the buffer for playback. The audio data is 
        /// processed in real-time, allowing for immediate adjustments to the audio stream. The volume adjustment is performed by 
        /// scaling each audio sample by the value of the 'volume' variable. Clipping is applied to ensure that the adjusted sample 
        /// remains within the valid range of 16-bit signed integers. The adjusted samples are then stored in the little-endian 
        /// format and added to the 'bufferedWaveProvider' for playback.
        /// </remarks>
        private void Capture_DataAvailable(object sender, WaveInEventArgs args)
        {

            for (int i = 0; i < args.BytesRecorded; i += 2)
            {
                short sample = (short)((args.Buffer[i + 1] << 8) | args.Buffer[i]);

                float adjustedSample = sample * volume;

                adjustedSample = Math.Max(short.MinValue, Math.Min(short.MaxValue, adjustedSample));

                short adjustedSampleInt16 = (short)adjustedSample;

                args.Buffer[i] = (byte)(adjustedSampleInt16 & 0xFF);
                args.Buffer[i + 1] = (byte)((adjustedSampleInt16 >> 8) & 0xFF);
            }
            bufferedWaveProvider.AddSamples(args.Buffer, 0, args.BytesRecorded);
        }


        private void StartPlayback()
        {
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();
        }
        private void StopPlayback()
        {
            waveOut.Stop();
            waveOut.Dispose();
        }

        private void InputDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCapturing)
            {
                Stop_Click(sender, e);
                Start_Click(sender, e);
            }
        }

        private void OutputDev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCapturing)
            {
                Stop_Click(sender, e);
                Start_Click(sender, e);
            }
        }

        private void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            volume = (float)VolumeTrackBar.Value;
        }


        /// <summary>
        /// Handles the FormClosing event of the form to stop recording and playback before closing.
        /// </summary>
        private void AudioProcessor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isCapturing)
            {
                Stop_Click(sender, EventArgs.Empty);
            }
        }
    }
}
