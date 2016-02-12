using Microsoft.Xna.Framework.Input;

namespace Game1.Managers
{
    public class InputManager
    {
        private KeyboardState prevKS;
        private KeyboardState curKS;
        private MouseState prevMS;
        private MouseState curMS;
        
        public InputManager()
        {
            Statics.INPUT = this;
        }
        public void Update()
        {
            if (curKS != null)
                prevKS = curKS;
            curKS = Keyboard.GetState();
            if (curKS != null)
                prevMS = curMS;
            curMS = Mouse.GetState();
        }
        public bool isKeyPressed(Keys k)
        {
            return (prevKS.IsKeyUp(k) && curKS.IsKeyDown(k));
        }
        public bool isKeyRelease(Keys k)
        {
            return (prevKS.IsKeyUp(k) && curKS.IsKeyDown(k));
        }
        public bool isMousePushed()
        {
            return (curMS.LeftButton.Equals(ButtonState.Pressed) && prevMS.LeftButton.Equals(ButtonState.Pressed));
        }
        public bool isMouseReleased()
        {
            return (curMS.LeftButton.Equals(ButtonState.Released) && prevMS.LeftButton.Equals(ButtonState.Released));
        }
        public KeyboardState currentState()
        {
            return this.curKS;
        }
        public MouseState currentMouseState()
        {
            return this.curMS;
        }
    }
}
