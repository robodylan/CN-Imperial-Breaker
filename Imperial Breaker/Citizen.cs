using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Imperial_Breaker
{
    class Citizen
    {
        private float x;
        private float y;
        private float[] brain = new float[4];
         
        public Citizen(int x, int y, float[] brain)
        {
            this.x = x;
            this.y = y;
            this.brain = brain;
        }

        public Vector2 getPosition()
        {
            return new Vector2(this.x,this.y);
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public float[] getBrain()
        {
            return brain;
        }

        public void setPosition(Vector2 position)
        {
            this.x = position.X;
            this.y = position.Y;
        }

        public void setX(float x)
        {
            this.x = x;
        }

        public void setY(float y)
        {
            this.y = y;
        }

    }
}
