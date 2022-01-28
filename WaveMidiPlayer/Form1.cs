using System.Runtime.InteropServices;
using NAudio.Wave.SampleProviders;

namespace WaveMidiPlayer
{
    public partial class Form1 : Form
    {
        private MidiPlayer _midiPlayer;

        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        private int Volume
        {
            get
            {
                waveOutGetVolume(IntPtr.Zero, out uint volume);
                volume = volume & 0x0000ffff;

                return (int)Math.Round(volume / (ushort.MaxValue / 100.0));
            }
            set
            {
                uint volume = (uint)Math.Round(ushort.MaxValue / 100.0 * value);
                volume = (volume & 0x0000ffff) | (volume << 16);

                waveOutSetVolume(IntPtr.Zero, volume);
            }
        }

        public Form1()
        {
            InitializeComponent();

            _volumeSlider.Value = Volume;

            _waveTypeComboBox.DataSource = Enum.GetValues<SignalGeneratorType>();
            _waveTypeComboBox.SelectedItem = SignalGeneratorType.Sin;

            _midiPlayer = new MidiPlayer()
            {
                SignalGeneratorType = (SignalGeneratorType)_waveTypeComboBox.SelectedItem,
                Semitone = (int)_semitoneNumericUpDown.Value,
            };

            UpdatePlayPauseButton();
        }

        private void OnExamineButtonClicked(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Midi |*.midi;*.mid";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _filePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void OnPlayPauseButtonClicked(object sender, EventArgs e)
        {
            if (_midiPlayer.State == MidiPlayer.PlayerState.Playing)
            {
                _midiPlayer.Pause();
                UpdatePlayPauseButton();
            }
            else
            {
                string filePath = _filePathTextBox.Text;

                if (_midiPlayer.FilePath != filePath)
                {
                    try
                    {
                        _midiPlayer.Init(filePath);
                    }
                    catch
                    {
                        MessageBox.Show($"No se ha podido cargar el archivo {filePath}");
                    }
                }

                switch (_midiPlayer.State)
                {
                    case MidiPlayer.PlayerState.Ready:
                    case MidiPlayer.PlayerState.Paused:
                        _midiPlayer.Play();
                        UpdatePlayPauseButton();
                        break;
                };
            }
        }

        private void OnStopButtonClicked(object sender, EventArgs e)
        {
            _midiPlayer.Stop();
            UpdatePlayPauseButton();
        }

        private void OnVolumeSliderScrolled(object sender, ScrollEventArgs e)
        {
            if (e.NewValue != Volume)
            {
                Volume = e.NewValue;
            }
        }

        private void OnWaveTypeValueChanged(object sender, EventArgs e)
        {
            _midiPlayer.SignalGeneratorType = (SignalGeneratorType)_waveTypeComboBox.SelectedItem;
        }

        private void UpdatePlayPauseButton()
        {
            switch (_midiPlayer.State)
            {
                case MidiPlayer.PlayerState.Playing:
                    _playPauseButton.Text = "Pause";
                    break;

                default:
                    _playPauseButton.Text = "Play";
                    break;
            };
        }

        private void OnSemitoneChanged(object sender, EventArgs e)
        {
            _midiPlayer.Semitone = (int)_semitoneNumericUpDown.Value;
        }

        private void OnSemitoneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}