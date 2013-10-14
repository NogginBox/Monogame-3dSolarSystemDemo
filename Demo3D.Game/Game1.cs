using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Demo3D.MyGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
	    private Camera _camera;
	    private MyModel _model;
	    private List<OrbittingModel> _subModels;
	    private List<MoonModel> _moons;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _camera = new Camera(new Vector3(0,20,-50), Vector3.Zero, Vector3.Up, Window.ClientBounds);

            base.Initialize();
        }

        protected override void LoadContent()
        {
	        var modelObject = Content.Load<Model>("Shape");
			_model = new MyModel(modelObject);

			_subModels = new List<OrbittingModel>();
			_moons = new List<MoonModel>();
			for (var i = 4; i < 50; i += 5)
			{
				var planet = new OrbittingModel(modelObject, i, 0.0001f + (0.00001f*i));
				_subModels.Add(planet);
				_moons.Add(new MoonModel(modelObject, planet, 2, 0.001f));
				_moons.Add(new MoonModel(modelObject, planet, 3, 0.0015f));
			}
				
        }

        protected override void Update(GameTime gameTime)
        {
	        foreach (var model in _subModels)
	        {
		        model.Update(gameTime);
	        }

			foreach (var model in _moons)
	        {
		        model.Update(gameTime);
	        }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkRed);

            _model.Draw(_camera);
			foreach (var model in _subModels)
	        {
		        model.Draw(_camera);
	        }
			foreach (var model in _moons)
	        {
		        model.Draw(_camera);
	        }

            base.Draw(gameTime);
        }
    }
}