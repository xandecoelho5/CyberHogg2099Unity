using CyberHogg.Core;
using CyberHogg.Mechanics;
using CyberHogg.Model;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    /// <typeparam name="CyberEnteredDeathZone"></typeparam>
    public class CyberEnteredDeathZone : Simulation.Event<CyberEnteredDeathZone>
    {
        public DeathZone deathzone;

        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            Simulation.Schedule<CyberDeath>(0);
        }
    }
}