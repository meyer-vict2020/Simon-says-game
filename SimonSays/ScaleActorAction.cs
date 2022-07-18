using System;
using Raylib_cs;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scaling
{
    /// <summary>
    /// Scales the actor up or down depending on key presses.
    /// </summary>
    public class ScaleActorAction : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private IMouseService _mouseService;
        private double delay = 200;
        private DateTime start;
        List<int> _player = new List<int>();


        public ScaleActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _mouseService = serviceFactory.GetMouseService();
            this.delay = delay;
            this.start = start;
        }

        // this is a test function to make the squares pause before upscaling
        public void safeWait(int milliseconds, Actor square)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);
            if (elapsedTime.Seconds > delay)
            {
                float percent2 = (square.GetScale() < 2.0) ? 0.8f : 0;
                square.ScaleTo(percent2);
            }
        }


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actor from the cast
                List<Actor> squares = scene.GetAllActors("actors");
                int i = 0;

                foreach (Actor square in squares)
                {
                    float right = square.GetRight();
                    float left = square.GetLeft();
                    float top = square.GetTop();
                    float bottom = square.GetBottom();

                    // scale the actor up or down 
                    if (_mouseService.IsButtonDown(Byui.Games.Services.MouseButton.Left) &&
                    (Raylib.GetMouseX() >= left && Raylib.GetMouseX() <= right) &&
                    (Raylib.GetMouseY() <= bottom && Raylib.GetMouseY() >= top))
                    {
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (square.GetScale() > 0.8) ? 0.8f : 0;
                        square.ScaleTo(percent1);
                        bool buttonWasDown = true;
                        
                        if(buttonWasDown && _mouseService.IsButtonUp(Byui.Games.Services.MouseButton.Left)){
                            // scale the actor up a maximum of 300 percent
                            float percent2 = (square.GetScale() < 2.0) ? 0.8f : 0;
                            square.ScaleTo(percent2);
                        }
                        
                        
                        //wait part of a second so the scaling is visible

                        //if the square is clicked on, we want to add that square 
                        //to the user's pattern list
                        _player.Add(i);

                    }
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't scale actor.", exception);
            }
        }
    }
}