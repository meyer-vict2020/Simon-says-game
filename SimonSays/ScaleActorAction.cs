using System;
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

        public ScaleActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _mouseService = serviceFactory.GetMouseService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actor from the cast
                List<Actor> squares = scene.GetAllActors("actors");

                foreach(Actor square in squares)
                {
                    // scale the actor up or down 
                    if (_mouseService.IsButtonPressed(MouseButton.Left))
                    {
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (square.GetScale() > 0.3) ? -0.25f : 0;
                        square.Scale(percent1);

                        // scale the actor up a maximum of 300 percent
                        float percent2 = (square.GetScale() < 3.0) ? 0.25f : 0;
                        square.Scale(percent2);
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