using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using System.IO;

namespace Painting
{
    class Stroke
    {
        List<Vector2> position_;
        List<uint> time_;
        Texture2D brush_;
        Color color_;
        float scale_;
        int smoothness_;
        int smoothnessHelper_;

        public Texture2D Brush { get { return brush_; } }
        public Color Colour { get { return color_; } }
        public float Scale { get { return scale_; } }

        uint age;
        const int MAX_LENGTH = 1000;

        bool active;

        public Stroke()
        {
            position_ = new List<Vector2>(MAX_LENGTH);
            time_ = new List<uint>(MAX_LENGTH);
            brush_ = ContentLibrary.Get("circle");
            color_ = Color.White;
            scale_ = 0.25f;
            smoothness_ = 4;
            smoothnessHelper_ = (Math.Min(brush_.Height, brush_.Width) / (int)(smoothness_ / scale_));
            age = 0;
            active = false;
        }

        public Stroke(List<Vector2> positionList, List<uint> timeList, Color brushColor, float brushScale, int strokeSmoothness)
        {
            position_ = positionList;
            time_ = timeList;
            brush_ = ContentLibrary.Get("circle");
            color_ = brushColor;
            scale_ = brushScale;
            smoothness_ = strokeSmoothness;
            smoothnessHelper_ = (Math.Min(brush_.Height, brush_.Width) / (int)(smoothness_ / scale_));
            age = 0;
            active = false;
        }

        public void Update()
        {
            if (active)
            {
                //     if(position.Count < MAX_LENGTH)
                if (Input.MouseLeftPressed())
                    if (Input.MouseLeftPressed(1))
                    {
                        Vector2 lastPosition = Input.MousePosition(1); //first position
                        Vector2 tempPosition = Input.MousePosition();  //second position
                        tempPosition = Vector2.Subtract(tempPosition, lastPosition); //differnce between the two

                        //check that it's different from the last added one.
                        if (tempPosition != Vector2.Zero)
                        {
                            //if they are different, include a number of steps between them.
                            int steps = 1 + (int)(tempPosition.Length() / (smoothnessHelper_));

                            for (int i = 1; i <= steps; i++)
                            {
                                //add each step in between them.
                                position_.Add(Vector2.Add(tempPosition * i / steps, lastPosition));
                                time_.Add(age);
                            }
                        }
                    }
                    else
                    {
                        position_.Add(Input.MousePosition());
                        time_.Add(age);
                    }

                if (Input.Toggle1())
                    color_ = Color.White;
                else if (Input.Toggle2())
                    color_ = Color.Gray;
                else if (Input.Toggle3())
                    color_ = Color.Blue;

            }

            //only start the timer after the first click
            if (time_.Count > 0)
                age++;
        }

        public void Draw()
        {
            for (int i = 0; i < position_.Count; i++)
                if(age > time_[i])
                    Game1.spriteBatch.Draw(brush_, position_[i], new Rectangle(0,0,brush_.Width,brush_.Height), color_, 0f, Origin, scale_, SpriteEffects.None, 0);

           // Game1.spriteBatch.Draw(brush, Input.MousePosition(), new Rectangle(0, 0, brush.Width, brush.Height), color, 0f, Origin, scale, SpriteEffects.None, 0);
        }

        ////////////////////////////////////////////////////////////////////////
        /////////  Brush Property Accessors and Mutators
        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Increase or decrease brush size.
        /// </summary>
        /// <param name="number">if >0, increase by 5%. if < 0 decrease by 5%</param>
        public void ScaleChange(int number)
        {
            if (number > 0)
                scale_ += 0.05f;
            else if (number < 0)
                scale_ -= 0.05f;
        }



        /////////////////////////////////////////
        /////  IO Functions
        /////////////////////////////////////////

        public void Export(int fileNumber)
        {
            FileStream fileStream;
            BinaryWriter writer;
            string filename;


            filename = "stroke" + fileNumber.ToString() + ".stk";
            fileStream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            writer = new BinaryWriter(fileStream);

            //Now write to file.
            //positions and time intermingled
            writer.Write(position_.Count);
            for (int j = 0; j < position_.Count; j++)
            {
                writer.Write(position_[j].X);
                writer.Write(position_[j].Y);
                writer.Write(time_[j]);
            }
            
            //the color
            writer.Write(color_.R);
            writer.Write(color_.G);
            writer.Write(color_.B);
            writer.Write(color_.A);
            //then scale and smoothness
            writer.Write(scale_);
            writer.Write(smoothness_);
            
            
            ////save the brush texture in a seperate file
            //string textureFilename = "brush" + i.ToString() + ".bsh";
            //brush.Save(textureFilename, ImageFileFormat.Png);
            
            writer.Close();
            fileStream.Close();
            
            
        }

        public static Stroke Import(int fileNumber)
        {
            FileStream fileStream;
            BinaryReader reader;
            string filename = "stroke" + fileNumber.ToString() + ".stk";

            try
            {
                fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                reader = new BinaryReader(fileStream);


                //begin reading.
                //position first.
                int positionCount = reader.ReadInt32();
                List<Vector2> positionList = new List<Vector2>(positionCount);
                List<uint> timeList = new List<uint>(positionCount);
                for (int i = 0; i < positionCount; i++)
                {
                    positionList.Add(new Vector2(reader.ReadSingle(), reader.ReadSingle()));
                    timeList.Add(reader.ReadUInt32());
                }

                //color next
                Color brushColor;
                brushColor = new Color(reader.ReadByte(),    //R
                                        reader.ReadByte(),    //G
                                        reader.ReadByte(),    //B
                                        reader.ReadByte());   //A

                //then scale and smoothness
                float brushScale = reader.ReadSingle();
                int strokeSmoothness = reader.ReadInt32();

                //now load texture from file.
                //string textureFilename = "brush" + fileNumber.ToString() + ".bsh";
                //Texture2D texture = Texture2D.FromFile(Game1.graphics.GraphicsDevice, textureFilename);

                //clean up
                fileStream.Close();
                reader.Close();


                return new Stroke(positionList, timeList, brushColor, brushScale, strokeSmoothness);
            }
            catch { return null; }
        }

        public static void Delete(int fileNumber)
        {
            string strokeFilename = "stroke" + fileNumber.ToString() + ".stk";
            string textureFilename = "brush" + fileNumber.ToString() + ".bsh";
            
            if(File.Exists(strokeFilename))
                File.Delete(strokeFilename);
            if (File.Exists(textureFilename))
                File.Delete(textureFilename);
        }

        public void Clear()
        {
            position_ = new List<Vector2>(MAX_LENGTH);
            time_ = new List<uint>(MAX_LENGTH);
            brush_ = ContentLibrary.Get("circle");
            color_ = Color.White;
            scale_ = 0.25f;
            smoothness_ = 4;
            smoothnessHelper_ = (Math.Min(brush_.Height, brush_.Width) / (int)(smoothness_ / scale_));
            age = 0;
        }

        public void Activate()
        {
            active = true;
        }

        public void Deactivate()
        {
            active = false;
        }

        ////////////////////////////////////////////////////////////////////////
        /////////  Private Functions
        ////////////////////////////////////////////////////////////////////////
        public Vector2 Origin { get { return new Vector2(brush_.Width / 2f, brush_.Height / 2f); } }
    }
}
