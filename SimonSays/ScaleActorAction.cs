using System;
using Raylib_cs;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using System.Threading;


namespace SimonSays
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

                foreach (Actor square in squares)
                {
                    float right = square.GetRight();
                    float left = square.GetLeft();
                    float top = square.GetTop();
                    float bottom = square.GetBottom();

                    // scale the actor up or down 
                    if (_mouseService.IsButtonPressed(Byui.Games.Services.MouseButton.Left) &&
                    (Raylib.GetMouseX() >= left && Raylib.GetMouseX() <= right) &&
                    (Raylib.GetMouseY() <= bottom && Raylib.GetMouseY() >= top))
                    {
                        // scale the actor down to a minimum of 80 percent
                        float percent1 = (square.GetScale() > 0.8) ? 0.8f : 0;
                        square.ScaleTo(percent1);
                    } 

                    else if (_mouseService.IsButtonReleased(Byui.Games.Services.MouseButton.Left)){
                        // scale the actor back up on mouse up
                        float percent2 = (square.GetScale() < 2.0) ? 1.0f : 0;
                        square.ScaleTo(percent2);
                        
                        //if the square is clicked on, we want to add that square 
                        //to the user's pattern list
                        if (square == squares[0]) {
                            _player.Add(0);
                        }
                        else if (square == squares[1]) {
                            _player.Add(1);
                        }
                        else if (square == squares[2]) {
                            _player.Add(2);
                        }
                        else if (square == squares[3]){
                            _player.Add(3);
                        }
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