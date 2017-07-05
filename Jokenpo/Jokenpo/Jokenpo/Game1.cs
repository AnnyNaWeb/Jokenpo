using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Jokenpo
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Jogador jogador1;
        Jogador jogador2;
        Juiz juiz;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Screen.WIDTH;
            graphics.PreferredBackBufferHeight = Screen.HEIGHT;
            Content.RootDirectory = "Content";
        }

   
        protected override void Initialize()
        {
            this.jogador1 = new Jogador(this, Keys.A, Keys.S, Keys.D);
            this.jogador2 = new Jogador(this, Keys.J, Keys.K, Keys.L);
            
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            jogador1.Update(gameTime);
            jogador2.Update(gameTime);
            if (juiz == null)
            {
                if (jogador1.jogadaAtual != "" && jogador2.jogadaAtual != "")
                {
                    this.juiz = new Juiz(this, jogador1.jogadaAtual, jogador2.jogadaAtual);
                }
            }
            if (juiz != null)
            {

                juiz.Update(gameTime);
                if (juiz.resultado != null)
                {
                    KeyboardState state = Keyboard.GetState();

                    if (state.IsKeyDown(Keys.Enter))
                    {
                        juiz.resultado = null;
                        juiz.jogada1 = "";
                        juiz.jogada2 = "";
                 
                        juiz.time = 0;
                        jogador1.jogadaAtual = "";
                        jogador2.jogadaAtual = "";
                        juiz = null;

                    }

                    if (state.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }
                }
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
             GraphicsDevice.Clear(Color.CornflowerBlue);
             if (juiz != null)
             {
                 // TODO: Add your drawing code here
                 spriteBatch.Begin();
                 juiz.Draw(gameTime, spriteBatch);
                 spriteBatch.End();
             }

            base.Draw(gameTime);
        }
    }
}
