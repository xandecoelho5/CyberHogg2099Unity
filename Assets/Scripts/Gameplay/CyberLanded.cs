using CyberHogg.Core;
using CyberHogg.Mechanics;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when the cyber character lands after being airborne.
    /// </summary>
    /// <typeparam name="CyberLanded"></typeparam>
    public class CyberLanded : Simulation.Event<CyberLanded>
    {
        public CyberController cyber;

        public override void Execute()
        {

        }
    }
}