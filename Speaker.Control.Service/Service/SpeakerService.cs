using AudioSwitcher.AudioApi.CoreAudio;
using Speaker.Control.Interface;

namespace Speaker.Control.Services
{
    public class SpeakerService : ISpeakerService
    {
        #region Private Properties

        private readonly CoreAudioController _audioController;

        private CoreAudioDevice GetPlaybackDevice() => _audioController.DefaultPlaybackDevice;

        #endregion Private Properties

        public SpeakerService(CoreAudioController coreAudioController)
        {
            _audioController = coreAudioController;
        }

        #region Public Properties

        public bool Mute
        {
            get => GetPlaybackDevice().IsMuted;
            set => GetPlaybackDevice().Mute(value);
        }

        public int Volume
        {
            get => (int)GetPlaybackDevice().Volume;
            set => GetPlaybackDevice().Volume = value;
        }

        #endregion Public Properties
    }
}