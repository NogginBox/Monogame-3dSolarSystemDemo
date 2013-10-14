using Microsoft.Xna.Framework;

namespace Demo3D.MyGame
{
	public class Camera
	{
		public Matrix View { get; private set; }
		public Matrix Projection { get; private set; }

		private const int FarPlaneDistance = 200;

		public Camera(Vector3 position, Vector3 target, Vector3 up, Rectangle screensize)
		{
			View = Matrix.CreateLookAt(position, target, up);
			Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2,
																screensize.Width/(float) screensize.Height,
																1, FarPlaneDistance);
		}
	}
}