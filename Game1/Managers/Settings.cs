using System;
using Microsoft.Xna.Framework.Input;

namespace FlappyBird.Managers
{
    interface ISettings
    {
        Keys JumpKey { get; set; }
        Keys RestartKey { get; set; }
        Boolean MouseUse { get; set; }
        String MouseBtn { get; set; }
    }
    public class Settings : IStorable, ISettings
    {
        Boolean needsSave;
        String fileName;
        Keys jumpKey;
        Keys restartKey;
        Boolean mouseUse;
        String mouseBtn;

        public Settings(String _fileName)
        {
            this.fileName = _fileName;
        }
        public void Save()
        {
            // Implement Save of settings file with default path set in Statics
        }
        public void Load()
        {
            // Implement Load of settings file with default path set in Statics
        }
        public Boolean NeedsSave {
            get { return this.needsSave; }
            set { this.needsSave = value; }
        }
        public String FileName {
            get { return this.fileName; }
            set { this.fileName = value; }
        }
        public Keys JumpKey
        {
            get { return this.jumpKey; }
            set { this.jumpKey = value; }
        }
        public Keys RestartKey
        {
            get { return this.restartKey; }
            set { this.restartKey = value; }
        }
        public Boolean MouseUse
        {
            get { return this.mouseUse; }
            set { this.mouseUse = value; }
        }
        public String MouseBtn
        {
            get { return this.mouseBtn; }
            set { this.mouseBtn = value; }
        }
    }
}
