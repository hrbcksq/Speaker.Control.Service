using Microsoft.AspNetCore.Mvc;
using Speaker.Control.Interface;

namespace Speaker.Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        #region Private Properties

        private readonly ISpeakerService _speakerService;
        private readonly IMachineService _machineService;

        #endregion Private Properties

        public SpeakerController(
            ISpeakerService speakerService,
            IMachineService machineService)
        {
            _speakerService = speakerService;
            _machineService = machineService;
        }

        #region Mute

        [HttpGet("mute")]
        public bool GetMute()
        {
            return _speakerService.Mute;
        }

        [HttpPost("mute")]
        public void SetMute([FromBody]bool value)
        {
            _speakerService.Mute = value;
        }

        #endregion Mute

        #region Volume

        [HttpGet("volume")]
        public int GetVolume()
        {
            return _speakerService.Volume;
        }

        [HttpPost("volume")]
        public void SetVolume([FromBody]int volume)
        {
            _speakerService.Volume = volume;
        }

        #endregion Volume

        #region State

        [HttpGet("state")]
        public bool GetState() => true;

        [HttpPost("state")]
        public void SetState([FromBody]bool state)
        {
            if (state) { return; }
            _machineService.Hibernate();
        }

        #endregion State
    }
}