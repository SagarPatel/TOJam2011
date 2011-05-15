﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace TOJam2011Game
{


    public class Level2Screen: ScreenObject
    {

        PlayerObject mainPlayer;

        SpriteFont spriteFont1;

        TitleObject canyouseemeTitle;
        TitleObject IPreadytolearnTitle;

        double timeCounter;

        public Level2Screen(Game game, SpriteBatch sB): base(game, sB)
        {
            isActive = true;
            isCompleted = false;
            timeCounter = 0;

            mainPlayer = GameFlowManager.player1;

            canyouseemeTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/canyouseemeV1"));
            canyouseemeTitle.position = new Vector2(400, 100);

            IPreadytolearnTitle = new TitleObject(game, sB, Game.Content.Load<Texture2D>("Sprites/Level2/IPreadytolearn"));
            IPreadytolearnTitle.position = new Vector2(600, 300);


            spriteFont1 = Game.Content.Load<SpriteFont>("Fonts/SF1");


            

        }




        protected override void LoadContent()
        {
            canyouseemeTitle.isActive = true;
            Game.Components.Add(canyouseemeTitle);
            //base.LoadContent();
        }



        public override void Update(GameTime gameTime)
        {
            // Level logic update here


            Handle_and_CheckWeaponCollision(canyouseemeTitle);

            if (canyouseemeTitle.isKilled)
            {
                //continue to next message
                mainPlayer.activeTextureID = 8;
                timeCounter += gameTime.ElapsedGameTime.TotalMilliseconds;
                //enter only once
                if (timeCounter > 2000 && IPreadytolearnTitle.isActive == false)
                {
                    //add next message
                    IPreadytolearnTitle.isActive = true;
                    Game.Components.Add(IPreadytolearnTitle);
                    
                }

            }


            base.Update(gameTime);

        }




        public override void Draw(GameTime gameTime)
        {

            //  spriteBatch.Draw stuff here

            spriteBatch.DrawString(spriteFont1, "test2", new Vector2(400, 0), Color.Green);


            base.Draw(gameTime);
        }


        public void Handle_and_CheckWeaponCollision(GameObject gameObject)
        {
            if (gameObject.isAlive)
            {
                foreach (KeyValuePair<int, WeaponObject[]> entry in mainPlayer.weaponDict)
                {
                    foreach (WeaponObject w in entry.Value)
                    {
                        if (w.isAlive && w.isSolid)
                        {
                            if (gameObject.CheckCollision(w.position, w.texture.Width, w.texture.Height))
                            {
                                w.isAlive = false;
                                gameObject.isAlive = false;
                                gameObject.isKilled = true;
                                Game.Components.Remove(gameObject);
                                gameObject.Dispose();
                            }
                        }
                    }
                }
            }
        }





    }






}
