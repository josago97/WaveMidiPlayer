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





            _filePathTextBox.Text = @"D:\JOSE\Downloads\Rafal - The Ride.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\AWholeNewWorld-Aladdin.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Alejandro-LadyGaga.mid";

            _filePathTextBox.Text = @"D:\JOSE\Downloads\TestDrive-ComoEntrenarATuDragon.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Rasputin - Boney M.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Fast Car - Tracy Chapman.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Every breath you take - The Police.mid";
            //_filePathTextBox.Text = @"D:\JOSE\Downloads\Navajita plateá - Noches de bohemia.mid";

            _filePathTextBox.Text = @"D:\JOSE\Downloads\Cyndi Lauper - Time After Time.mid";
            //_filePathTextBox.Text = @"D:\JOSE\Downloads\Don't You Want Me - Human League.mid";
            //_filePathTextBox.Text = @"D:\JOSE\Downloads\Canon en C - Johann Pachelbel.mid";
            //_filePathTextBox.Text = @"D:\JOSE\Downloads\Aha_-_Take_On_Me.mid";
            /*_filePathTextBox.Text = @"D:\JOSE\Downloads\The Greatest Showman - A Million Dream.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Navajita plateá - Noches de bohemia.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Soulsister-TheWayToYourHeart.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\Every breath you take - The Police.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\NeverendingStory.mid";
            _filePathTextBox.Text = @"D:\JOSE\Downloads\King-Years&Years.mid";*/
            //_filePathTextBox.Text = @"D:\JOSE\Downloads\Running_Scared_-_Ell__Nikki_2011.mid";
            //_filePathTextBox.Text = @"D:\JOSE\Downloads\Running_Scared_-_Ell__Nikki_2011_-_Piano__Voice.mid";
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