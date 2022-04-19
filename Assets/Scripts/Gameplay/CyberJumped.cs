using CyberHogg.Core;
using CyberHogg.Mechanics;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the cyber performs a Jump.
    /// </summary>
    /// <typeparam name="CyberJumped"></typeparam>
    public class CyberJumped : Simulation.Event<CyberJumped>
    {
        public CyberController cyber;

        public override void Execute()
        {
            if (cyber.audioSource && cyber.jumpAudio)
                cyber.audioSource.PlayOneShot(cyber.jumpAudio);
        }
    }
}