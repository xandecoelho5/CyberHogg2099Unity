using CyberHogg.Core;
using CyberHogg.Model;

namespace CyberHogg.Gameplay
{
    /// <summary>
    /// This event is fired when user input should be enabled.
    /// </summary>
    public class EnableCyberInput : Simulation.Event<EnableCyberInput>
    {
        CyberHoggModel model = Simulation.GetModel<CyberHoggModel>();

        public override void Execute()
        {
            var player = model.cyber;
            player.controlEnabled = true;
        }
    }
}