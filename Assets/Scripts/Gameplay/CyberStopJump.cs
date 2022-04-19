using CyberHogg.Core;
using CyberHogg.Mechanics;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the Jump Input is deactivated by the user, cancelling the upward velocity of the jump.
    /// </summary>
    /// <typeparam name="CyberStopJump"></typeparam>
    public class CyberStopJump : Simulation.Event<CyberStopJump>
    {
        public CyberController cyber;

        public override void Execute()
        {

        }
    }
}