﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RheinwerkAdventure.Model;

namespace RheinwerkAdventure.Components
{
    internal class SceneComponent : DrawableGameComponent
    {
        private readonly RheinwerkGame game;

        private SpriteBatch spriteBatch;

        private Texture2D pixel;

        public SceneComponent (RheinwerkGame game) : base(game)
        {
            this.game = game;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new [] { Color.White });
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

           Area area = game.Simulation.World.Areas[0];

            float scaleX = (GraphicsDevice.Viewport.Width - 20) / area.Width;
            float scaleY = (GraphicsDevice.Viewport.Height - 20) / area.Height;

            spriteBatch.Begin();
            

            for (int x = 0; x < area.Width; x++)
            {
                for (int y = 0; y < area.Height; y++)
                {

                    Tile tile = area.Tiles[x, y];

                    int offsetX = (int) (x * scaleX) + 10;
                    int offsetY = (int)(y * scaleY) + 10;
                    
                    spriteBatch.Draw(pixel, new Rectangle(offsetX, offsetY, (int)scaleX, (int)scaleY), Color.DarkGreen);
                    spriteBatch.Draw(pixel, new Rectangle(offsetX, offsetY, 2, (int)scaleY), Color.Black);
                    spriteBatch.Draw(pixel, new Rectangle(offsetX, offsetY, (int)scaleX, 2), Color.BlueViolet);

                }
                foreach (var item in area.Items)
                {
                    Color color = Color.Yellow;
                    if (item is Player)
                        color = Color.Red;

                    int posX = (int) ((item.Position.X - item.Radius) *scaleX) +10;
                    int posY = (int)((item.Position.Y - item.Radius) * scaleY) + 10;
                    int size = (int)((item.Radius * 2) * scaleX);
                    spriteBatch.Draw(pixel, new Rectangle(posX, posY, size, size), color);


                }

            }
            spriteBatch.End();
        }
        
    }
}

