using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace SummerofXNA.Classes.Camera
{
    public class Camera2D
    {

        #region Class-level Variables
        Vector2 positionValue;             
        bool cameraChanged;

        public Vector2 Position
        {
            set
            {
                if (positionValue != value)
                {
                    cameraChanged = true;
                    positionValue = value;
                }
            }
            get { return positionValue; }
        }

        public bool IsChanged
        {
            get { return cameraChanged; }
        }
        #endregion

        //Constructor
        public Camera2D()
        {
            positionValue = Vector2.Zero;
        }        

        //Reset
        public void ResetChanged()
        {
            cameraChanged = false;
        }

        //Right
        public void MoveRight(float dist)
        {
            if (dist != 0)
            {
                cameraChanged = true;                
                positionValue.X += dist;
            }
        }
        
        //Left
        public void MoveLeft(float dist)
        {
            if (dist != 0)
            {
                cameraChanged = true;
                positionValue.X += dist;
            }
        }
        
        //Up
        public void MoveUp(float dist)
        {
            if (dist != 0)
            {
                cameraChanged = true;
                positionValue.Y -= dist;
            }
        }
        
        //Down
        public void MoveDown(float dist)
        {
            if (dist != 0)
            {
                cameraChanged = true;                
                positionValue.Y -= dist;
            }
        }
    }
}
