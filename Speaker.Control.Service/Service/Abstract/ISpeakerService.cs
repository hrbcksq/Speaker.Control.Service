namespace Speaker.Control.Interface
{
    public interface ISpeakerService
    {
        int Volume { get; set; }

        bool Mute { get; set; }
    }
}