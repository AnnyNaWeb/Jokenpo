using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Jokenpo
{
    public class Jogador
    {
        Game game;
        Keys pedra, papel, tesoura;
        public string jogadaAtual = "";

        public Jogador(Game game, Keys pedra, Keys papel, Keys tesoura)
        {
            this.game = game;

            this.pedra = pedra;
            this.papel = papel;
            this.tesoura = tesoura;
        }

        public void Update(GameTime gameTime)
        {
            if (this.jogadaAtual == "")
            {
                KeyboardState state = Keyboard.GetState();

                if (state.IsKeyDown(this.pedra))
                {
                    jogadaAtual = "Pedra";
                }

                if (state.IsKeyDown(this.tesoura))
                {
                    jogadaAtual = "Tesoura";
                }

                if (state.IsKeyDown(this.papel))
                {
                    jogadaAtual = "Papel";
                    Console.WriteLine("alow carai");
                }
            }
        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
