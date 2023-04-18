using System; // Console
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
	class Follower : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		Vector2 Velocity;
		Vector2 Acceleration;

		// constructor + call base constructor
		public Follower() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Velocity = new Vector2(1);

			Color = Color.GREEN;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Acceleration = new Vector2();
			Follow(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Follow(float deltaTime)
		{
			Vector2 mouse = Raylib.GetMousePosition();	
			// Console.WriteLine(mouse);
			
			Acceleration = mouse - Position;
			

			// TODO implement
			Position += Velocity * deltaTime;
			Velocity += Acceleration * deltaTime;
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
				Velocity.X *= -1;
			}

			if (Position.X < 0 + spr_width / 2)
			{
				Position.X = 0 + spr_width / 2;
				Velocity.X *= -1;
			}


			if (Position.Y > scr_height - spr_heigth / 2)
			{
				Position.Y = scr_height - spr_heigth / 2;
				Velocity.Y *= -1;
			}

			if (Position.Y < 0 + spr_heigth / 2)
			{
				Position.Y = 0 + spr_heigth / 2;
				Velocity.Y *= -1;
			}

		}
	}
}
