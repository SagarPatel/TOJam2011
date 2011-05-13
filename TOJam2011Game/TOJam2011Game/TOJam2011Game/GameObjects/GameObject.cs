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




    public abstract class GameObject : Microsoft.Xna.Framework.DrawableGameComponent
    {



        protected SpriteBatch spriteBatch;
        public Texture2D texture;

        public bool isAlive;

        public Vector2 position;
        public Vector2 velocity;

        public Vector2 origin;
        public float radius;

        public float speed;
        public float scale;
        public float rotation;
        public float friction;

        public Rectangle rect;

     

        public GameObject(Game game, SpriteBatch sB): base(game)
        {
            spriteBatch = sB;

            isAlive = false;
            position = new Vector2(0, 0);
            velocity = new Vector2(0, 0);

            origin = new Vector2(0, 0);



        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected virtual void UnloadContent()
        {
            base.UnloadContent();
        }







        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);


        }













    }











}
