using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoEngine;
using MonoEngine.Audio;
using MonoEngine.Game;
using MonoEngine.Render;
using MonoEngine.Physics;
using MonoEngine.Physics.Physics2D;
using MonoEngine.Shapes;

namespace Capstone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameMain : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Temporary
        GameObject obj;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            GraphicsHelper.graphics = graphics;
            Content.RootDirectory = "Content";
            ContentHelper.Content = Content;

            Window.AllowUserResizing = false;

            // Borderless Window functionality
            Window.IsBorderless = true;
            Window.Position = Point.Zero;

            Window.Title = "I am Poor and Hungry";

            // Scaleable resolution functionality
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;

            GraphicsHelper.screen = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            // Depth and Buffer format functionality
            graphics.PreferredDepthStencilFormat = DepthFormat.Depth16;
            graphics.PreferredBackBufferFormat = SurfaceFormat.Color;

            // V-Sync
            graphics.SynchronizeWithVerticalRetrace = true;

            // Anti-Aliasing functionality
            graphics.PreferMultiSampling = true;

            // Fullscreen functionality
            //graphics.ToggleFullScreen();

            this.Components.Add(Time.Instance(this));
            this.Components.Add(PhysicsEngine.Instance(this, PhysicsEngine.EngineTypes.Physics2D));
            this.Components.Add(GameObjectManager.Instance(this));
            this.Components.Add(SoundManager.Instance(this));
            this.Components.Add(SongManager.Instance(this));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Transform trans = new Transform();
            obj = new GameObject("wall");
            obj.transform.Translate(new Vector3(0, 0, 0));
            obj.AddComponent(ModelRenderer.MakeModelRenderer(obj, "BasicSingleWindow"));
            obj.AddComponent(ModelRenderer.MakeModelRenderer(obj, "FloorTile"));
            obj.AddComponent(new PhysicsBody2D("body", new AABB(obj.transform, 1, 1), PhysicsEngine.BodyType.STATIC));
            obj.AddComponent(new Camera("camera"));

            //PhysicsEngine2D.CalculateBoundsIndices(obj.GetComponent<PhysicsBody2D>() as PhysicsBody2D);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            System.Console.WriteLine(obj.transform.Position);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Aquamarine);
            
            obj.Render();

            base.Draw(gameTime);
        }
    }
}
