using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Demo3D.MyGame
{
	public class OrbittingModel
	{
		private readonly Model _model;

		protected float Angle;
		protected readonly float Distance;
		protected readonly float Speed;

		public Matrix World { get; set; }

		public OrbittingModel(Model model, float distance, float speed)
		{
			_model = model;
			Distance = distance;
			Speed = speed;
			World = OrbitMatrix(Distance, Angle);
		}

		public void Draw(Camera camera)
		{
			foreach (var mesh in _model.Meshes)
			{
				foreach (BasicEffect effect in mesh.Effects)
				{
					effect.EnableDefaultLighting();
					effect.World = World;
					effect.Projection = camera.Projection;
					effect.View = camera.View;
				}
				mesh.Draw();
			}
		}

		public void Update(GameTime gameTime)
		{
			Angle += (float)gameTime.ElapsedGameTime.TotalMilliseconds * Speed;
			CalculateWorld();
		}

		protected virtual void CalculateWorld()
		{
			World = OrbitMatrix(Distance, Angle);
		}

		protected Matrix OrbitMatrix(float distance, float angle)
		{
			return Matrix.CreateTranslation(distance, 0, 0) * Matrix.CreateRotationY(angle);
		}
	}
}
