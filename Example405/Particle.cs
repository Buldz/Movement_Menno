using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
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
	class Particle : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			Position = new Vector2(x, y);
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Gravity(deltaTime);
			Move(deltaTime);
			Rotation = (float)Math.Atan2(Velocity.Y, Velocity.X);
		}

		public void Gravity(float deltaTime)
		{
			Vector2 gravity = new Vector2(0.0f, 980.0f);

			AddForce(gravity);
		}
	}
}
