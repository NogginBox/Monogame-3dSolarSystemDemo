using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Demo3D.MyGame
{
	public class MoonModel : OrbittingModel
	{
		private readonly OrbittingModel _planet;

		public MoonModel(Model model, OrbittingModel planet, float distance, float speed) : base(model, distance, speed)
		{
			_planet = planet;
		}

		protected override void CalculateWorld()
		{
			World = Matrix.CreateScale(0.5f) * OrbitMatrix(Distance, Angle) * _planet.World;
		}
	}
}