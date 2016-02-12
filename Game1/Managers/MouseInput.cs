using Microsoft.Xna.Framework.Input;

namespace FlappyBird.Managers
{
    interface iMouseInput
    {
        void Update();
        bool isLeftPressed();
        bool isLeftRelease();
        MouseState currentState();
    }
    public class MouseInput
    {
        private MouseState prevMS;
        private MouseState curMS;

        public MouseInput()
        {
            Statics.MINPUT = this;
        }
        public void Update()
        {
            if (curMS != null)
                prevMS = curMS;
            curMS = Mouse.GetState();
        }
        public bool isLeftPressed()
        {
            return (curMS.LeftButton.Equals(ButtonState.Pressed) && prevMS.LeftButton.Equals(ButtonState.Pressed));
        }
        public bool isLeftRelease()
        {
            return (curMS.LeftButton.Equals(ButtonState.Released) && prevMS.LeftButton.Equals(ButtonState.Released));
        }
        public MouseState currentMouseState()
        {
            return this.curMS;
        }
    }
    
}
