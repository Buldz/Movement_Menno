using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class SimpleBall : SpriteNode
	{
		float xspeed = 400;
		float yspeed = 400;
		// your private fields here


		// constructor + call base constructor
		public SimpleBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.MAGENTA;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			Position.X += xspeed * deltaTime;
			Position.Y += yspeed * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width - spr_width / 2)
			{
				Position.X = scr_width - spr_width / 2;
				xspeed = xspeed * -1;
			}

			if (Position.X < 0 + spr_width / 2)
			{
				Position.X = 0 + spr_width / 2;
				xspeed = xspeed * -1;
			}


			if (Position.Y > scr_height - spr_heigth / 2)
			{
				Position.Y = scr_height - spr_heigth / 2;
				yspeed = yspeed * -1;
			}

			if (Position.Y < 0 + spr_heigth / 2)
			{
				Position.Y = 0 + spr_heigth / 2;
				yspeed = yspeed * -1;
			}

		}

	}
}
