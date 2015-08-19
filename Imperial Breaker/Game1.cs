using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Imperial_Breaker
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D citizenTexture;
        List<Citizen> citizens;
        Random rand = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            citizens = new List<Citizen>();
            citizenTexture = Content.Load<Texture2D>("citizen.png");
            for(int i = 0; i < 1000; i++)
            {
                citizens.Add(new Citizen(rand.Next(1, 800), rand.Next(1, 600), genNewBrain(64)));
            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (Citizen citizen in citizens)
            {
                //Set inputs
                float[] inputs = new float[8];
                inputs[0] = (float)Mouse.GetState().Position.X / 800;
                inputs[1] = (float)Mouse.GetState().Position.Y / 600;
                inputs[2] = 0;
                inputs[3] = 0;
                inputs[4] = 0;
                inputs[5] = 0;
                inputs[6] = 0;
                inputs[7] = 0;

                //Get outputs
                float[] outputs = processInput(inputs, citizen.getBrain());
                if (outputs[0] > 1f) citizen.setX(citizen.getX() + 1);
                if (outputs[1] > 1f) citizen.setX(citizen.getX() - 1);
                if (outputs[2] > 1f) citizen.setY(citizen.getY() + 1);
                if (outputs[3] > 1f) citizen.setY(citizen.getY() - 1);
                if (outputs[4] > 1f) citizen.setX(citizen.getX() + 1);
                if (outputs[5] > 1f) citizen.setX(citizen.getX() - 1);
                if (outputs[6] > 1f) citizen.setY(citizen.getY() + 1);
                if (outputs[7] > 1f) citizen.setY(citizen.getY() - 1);
            }


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach(Citizen citizen in citizens)
            {
                spriteBatch.Draw(citizenTexture, citizen.getPosition(), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }


        //Takes a predetermined amount of inputs and outputs a equal amount of output values based on the nueral network's weights
        public static float[] processInput(float[] inputs, float[] Weights)
        {
            float[] Output = new float[inputs.Length];
            for (int a = 0; a < inputs.Length; a++)
            {
                for (int b = a * inputs.Length; b < (a * inputs.Length) + inputs.Length; b++)
                {
                    Output[a] = inputs[a] * Weights[b]; // + Program.rand.Next(-1, 1);
                }
            }
            return Output;
        }

        public float[] genNewBrain(int Size)
        {
            float[] brain = new float[Size];
            for(int i = 0; i < Size; i++)
            {
                brain[i] = ((float)rand.NextDouble() * 8) - 2;
            }
            return brain;
        }
    }
}
