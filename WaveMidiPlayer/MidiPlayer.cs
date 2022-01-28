using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace WaveMidiPlayer
{
    public class MidiPlayer
    {
        public enum PlayerState { NoReady, Ready, Playing, Paused };

        private static WaveFormat WAVE_FORMAT = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);

        private MidiFile _midiFile;
        private TempoMap _tempoMap;
        private Playback _playback;
        private MixingSampleProvider _mixingSampleProvider;
        private WaveOutEvent _waveOut;

        public PlayerState State { get; private set; }
        public string FilePath { get; private set; }
        public SignalGeneratorType SignalGeneratorType { get; set; }
        public int Semitone { get; set; }

        public event Action Finished;

        public MidiPlayer()
        {
            State = PlayerState.NoReady;
        }

        public void Init(string filePath)
        {
            try
            {
                _midiFile = MidiFile.Read(filePath);
                _tempoMap = _midiFile.GetTempoMap();

                _playback?.Dispose();
                _playback = new Playback(_midiFile.GetTimedEvents(), _tempoMap);
                _playback.NotesPlaybackStarted += OnPlayNote;
                _playback.Finished += OnFinish;

                _waveOut?.Dispose();
                _waveOut = new WaveOutEvent();
                _waveOut.DesiredLatency = 50;

                FilePath = filePath;
                State = PlayerState.Ready;
            }
            catch
            {
                FilePath = null;
                State = PlayerState.NoReady;
            }
        }

        public void Play()
        {
            if (State == PlayerState.Playing) return;

            if (State == PlayerState.Ready)
            {
                _mixingSampleProvider = new MixingSampleProvider(WAVE_FORMAT)
                {
                    ReadFully = true
                };

                _waveOut.Init(_mixingSampleProvider);
            }

            State = PlayerState.Playing;

            _playback.Start();
            _waveOut.Play();
        }

        public void Pause()
        {
            if (State == PlayerState.Paused) return;

            State = PlayerState.Paused;

            _playback.Stop();
            _waveOut.Pause();
        }

        public void Stop()
        {
            if (State == PlayerState.Ready) return;

            State = PlayerState.Ready;

            _playback.Stop();
            _playback.MoveToStart();
            _waveOut.Stop();

            Finished?.Invoke();
        }

        private void OnFinish(object sender, EventArgs e)
        {
            Stop();
        }

        private void OnPlayNote(object sender, NotesEventArgs e)
        {
            foreach (var note in e.Notes)
            {
                int duration = (int)note.LengthAs<MetricTimeSpan>(_tempoMap).TotalMilliseconds;
                int frequency = (int)((Math.Pow(2, (note.NoteNumber - 69) / 12.0) * 440) * Math.Pow(2, Semitone / 12.0));

                if (duration > 0)
                {
                    double volume = note.Velocity / 127.0;
                    ISampleProvider samples = new SampleProvider(WAVE_FORMAT, frequency, duration, volume, SignalGeneratorType);
                    _mixingSampleProvider.AddMixerInput(samples);
                }
            }
        }

        private class SampleProvider : ISampleProvider
        {
            private const double GAIN = 0.2;

            private float[] _samplesData;
            private int _readPosition;

            public WaveFormat WaveFormat { get; init; }

            public SampleProvider(WaveFormat waveFormat, int frequency, int duration, double volume, SignalGeneratorType signalGeneratorType)
            {
                WaveFormat = waveFormat;

                SignalGenerator signalGenerator = new SignalGenerator(waveFormat.SampleRate, waveFormat.Channels)
                {
                    Gain = GAIN * volume,
                    Frequency = frequency,
                    Type = signalGeneratorType
                };

                _samplesData = GetSampleData(signalGenerator, duration);
            }

            public int Read(float[] buffer, int offset, int count)
            {
                int bytesToRead = _readPosition + count <= _samplesData.Length ?
                    count
                    : _samplesData.Length - _readPosition;

                if (bytesToRead > 0)
                {
                    Array.Copy(_samplesData, _readPosition, buffer, offset, bytesToRead);
                    _readPosition += bytesToRead;
                }

                return bytesToRead;
            }

            private float[] GetSampleData(SignalGenerator signalGenerator, int duration)
            {
                List<float> data = new List<float>();
                ISampleProvider samples = signalGenerator.Take(TimeSpan.FromMilliseconds(duration));
                float[] buffer = new float[1024];
                int bytesReaded;

                while ((bytesReaded = samples.Read(buffer, 0, buffer.Length)) > 0)
                {
                    data.AddRange(buffer.Take(bytesReaded));
                }

                for (int i = 0; i < data.Count; i++)
                {
                    data[i] *= (float)Math.Log2(2 - i / (float)data.Count);
                }

                return data.ToArray();
            }
        }
    }
}
