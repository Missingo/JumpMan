using Microsoft.Xna.Framework.Input;

namespace Game1.Managers
{
    interface iKBInput
    {
        void Update();
        bool isKeyPressed();
        bool isKeyRelease();
        KeyboardState currentState();
    }
    public class KBInput
    {
        private KeyboardState prevKS;
        private KeyboardState curKS;

        public KBInput()
        {
            Statics.KINPUT = this;
        }
        public void Update()
        {
            if (curKS != null)
                prevKS = curKS;
            curKS = Keyboard.GetState();
        }
        public bool isDown()
        {
            return true;
        }
        public bool isUp()
        {
            return true;
        }
        public bool isKeyPressed(Keys k)
        {
            return (prevKS.IsKeyUp(k) && curKS.IsKeyDown(k));
        }
        public bool isKeyRelease(Keys k)
        {
            return (prevKS.IsKeyUp(k) && curKS.IsKeyDown(k));
        }
        public KeyboardState currentState()
        {
            return this.curKS;
        }
    }
}
