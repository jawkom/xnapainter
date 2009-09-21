using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Painting
{
    static class ContentLibrary
    {
        static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static void Add(string key, Texture2D value)
        {
            if (textures == null){
                textures = new Dictionary<string, Texture2D>();
            }

            try{
                textures.Add(key, value);
            }
            catch{
                throw new Exception("Content key " + key + " has already been used.");
            }
        }

        public static Texture2D Get(string key)
        {
            Texture2D value = null;
            textures.TryGetValue(key, out value);
            
            return value;
        }
    }
}
