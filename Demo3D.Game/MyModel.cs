using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Demo3D.MyGame
{
	public class MyModel
	{
		private readonly Model _model;

		public Matrix World { get; set; }

		public MyModel(Model model)
		{
			_model = model;
			World = Matrix.Identity;
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
	}
}
