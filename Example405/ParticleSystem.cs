using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		List<Particle> particles;
		private List<Color> colors;
		Random rand = new Random();
		float Timer;

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			Timer = 0.0f;

			Position = new Vector2(x, y);

			colors = new List<Color>();
			colors.Add(Color.WHITE);
			//colors.Add(Color.ORANGE);
			//colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			//colors.Add(Color.GREEN);
			//colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			//colors.Add(Color.YELLOW);
			colors.Add(Color.SKYBLUE);

			particles = new List<Particle>();
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Timer += deltaTime;

			if (Timer > 0.001f)
			{
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 vel = new Vector2(randX, randY) * 200;
				vel -= new Vector2(100, 1000);
				Particle p = new Particle(0, 0, colors[rand.Next()%colors.Count]);
				p.Velocity = vel;
				particles.Add(p);
				AddChild(p);
				Timer = 0.0f;
			}


			if(particles.Count >= 1300)
			{
				RemoveChild(particles[0]);
				particles.RemoveAt(0);
			}
		
		}


	}
}
