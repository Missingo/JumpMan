using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    public class Statics
    {
        private const String settingsFileName = "settings.txt";

        public static int GAME_WIDTH = 1000;
        public static int GAME_HEIGHT = 700;

        public static String GAME_TITLE = "JumpMan";
        public static Random RANDOM = new Random();
        public static GameTime GAMETIME;
        public static SpriteBatch SPRITEBATCH;
        public static ContentManager CONTENT;
        public static GraphicsDevice GRAPHICSDEVICE;
        public static Texture2D PIXEL;
        //public static List<SoundEffect> SOUNDEFFECTS;

        public static Managers.InputManager INPUT;
        public static Managers.KBInput KINPUT;
        //public static Managers.MouseInput MINPUT;
        //public static Managers.Settings SETTINGS;
        //public static String SETTINGSFILE = Path.GetDirectoryName(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + settingsFileName);
        public static bool DEBUG = false;

    }
}
