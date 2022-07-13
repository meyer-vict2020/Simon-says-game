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
    public class GamePattern : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private IMouseService _mouseService;
        List<int> generated = new List<int> ();
        

        public GamePattern(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _mouseService = serviceFactory.GetMouseService();
        }
        
        public static List<int> GeneratePattern(List<int> existingPattern) {
            Random random = new Random();
            int newPattern = random.Next(0,4);
            existingPattern.Add(newPattern);
            return existingPattern;
        }
        
        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                generated = GeneratePattern(generated);
                List<Actor> squares = scene.GetAllActors("actors");
                int i =0;
                foreach(Actor square in squares)
                { 
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (square.GetScale() > 0.3) ? -0.25f : 0;
                        square.Scale(percent1);

                        //wait part of a second so the scaling is visible


                        // scale the actor up a maximum of 300 percent
                        // float percent2 = (square.GetScale() < 3.0) ? 0.25f : 0;
                        // square.Scale(percent2);

                        //wait for at least a second between each square's scaling

                        i++;
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't scale actor.", exception);
            }
            
        }
    }
}