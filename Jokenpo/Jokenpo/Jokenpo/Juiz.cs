using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jokenpo
{
    public class Juiz 
    {
        Game game;
        Texture2D[] texturas; 
        public string jogada1;
        public string jogada2;
        public string resultado;
        SpriteFont font, font2;
        public float time;

        public Juiz(Game game, string jogada1, string jogada2)
        {
            this.jogada1 = jogada1;
            this.jogada2 = jogada2;
            this.game = game;
            this.texturas = new Texture2D[3];

            this.font = this.game.Content.Load<SpriteFont>(@"Textures\SpriteFont1");
            this.font2 = this.game.Content.Load<SpriteFont>(@"Textures\SpriteFont2");

            for (var i = 0; i < this.texturas.Length; i++)
            {
                this.texturas[i] = this.game.Content.Load<Texture2D>(@"Textures\imagem" + i);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.resultado == null)
            {
                if (this.jogada1 == this.jogada2)
                {
                    this.resultado = "Empate";
                    Console.WriteLine("tenta de novo");
                }
                else if (this.jogada1 == "Pedra" && this.jogada2 == "Tesoura")
                {
                    this.resultado = "Jogador1 VENCEU";
                }
                else if (this.jogada1 == "Pedra" && this.jogada2 == "Papel")
                {
                    this.resultado = "Jogador2 VENCEU";
                }
                else if (this.jogada1 == "Tesoura" && this.jogada2 == "Pedra")
                {
                    this.resultado = "Jogador2 VENCEU";
                }
                else if (this.jogada1 == "Tesoura" && this.jogada2 == "Papel")
                {
                    this.resultado = "Jogador1 VENCEU";
                }
                else if (this.jogada1 == "Papel" && this.jogada2 == "Pedra")
                {
                    this.resultado = "Jogador1 VENCEU";
                }
                else if (this.jogada1 == "Papel" && this.jogada2 == "Tesoura")
                {
                    this.resultado = "Jogador2 VENCEU";
                }
            }

            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            if (this.jogada1 == "Pedra")
                spriteBatch.Draw(this.texturas[0], new Rectangle(30, 30, 40, 40), Color.White);

            if (this.jogada1 == "Tesoura")
                spriteBatch.Draw(this.texturas[1], new Rectangle(30, 30, 40, 40), Color.White);

            if (this.jogada1 == "Papel")
                spriteBatch.Draw(this.texturas[2], new Rectangle(30, 30, 40, 40), Color.White);

            if (this.jogada2 == "Pedra")
                spriteBatch.Draw(this.texturas[0], new Rectangle(100, 30, 40, 40), Color.White);

            if (this.jogada2 == "Tesoura")
                spriteBatch.Draw(this.texturas[1], new Rectangle(100, 30, 40, 40), Color.White);

            if (this.jogada2 == "Papel")
                spriteBatch.Draw(this.texturas[2], new Rectangle(100, 30, 40, 40), Color.White);

            if (this.resultado != null)
            {
                time += gameTime.ElapsedGameTime.Milliseconds * 0.001f;

                if (time > 1.5f)
                {
                    spriteBatch.DrawString(font, this.resultado, new Vector2(Screen.WIDTH / 2 - 200, Screen.HEIGHT / 2), Color.Black);
                    spriteBatch.DrawString(font2, "APERTE ENTER PARA JOGAR NOVAMENTE", new Vector2(Screen.WIDTH / 2 - 200, Screen.HEIGHT / 2 + 40), Color.Black);
                    spriteBatch.DrawString(font2, "APERTE ESC PARA SAIR", new Vector2(Screen.WIDTH /2 - 200, Screen.HEIGHT / 2 + 80), Color.Black);
                   
                }
            }
        }
    }
}
