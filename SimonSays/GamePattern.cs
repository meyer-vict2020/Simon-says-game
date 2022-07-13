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
        List<int> _generated = new List<int> ();
        

        public GamePattern(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _mouseService = serviceFactory.GetMouseService();
        }
        
        public static List<int> AddToPattern(List<int> existingPattern) {
            Random random = new Random();
            int newPattern = random.Next();
            existingPattern.Add(newPattern);
            return existingPattern;
        }
        
        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                _generated = AddToPattern(_generated);
                List<Actor> squares = scene.GetAllActors("actors");
                

                //for each of the numbers in the generated list,
                //scale the respective squares one after another
                foreach(int number in _generated)
                { 
                    if(number == 0){
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (squares[0].GetScale() > 0.3) ? -0.25f : 0;
                        squares[0].Scale(percent1);
                    }
                    else if(number == 1){
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (squares[1].GetScale() > 0.3) ? -0.25f : 0;
                        squares[1].Scale(percent1);
                    }
                    else if(number == 2){
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (squares[2].GetScale() > 0.3) ? -0.25f : 0;
                        squares[2].Scale(percent1);
                    }
                    else if(number == 3){
                        // scale the actor down to a minimum of 30 percent
                        float percent1 = (squares[3].GetScale() > 0.3) ? -0.25f : 0;
                        squares[3].Scale(percent1);


                        // MAKE IT BIGGER HERE
                    }
                    else{
                        
                    }
                        

                        //wait part of a second so the scaling is visible


                        // scale the actor up a maximum of 300 percent
                        // float percent2 = (square.GetScale() < 3.0) ? 0.25f : 0;
                        // square.Scale(percent2);

                        //wait for at least a second between each square's scaling

                }
                
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't scale actor.", exception);
            }
            
        }
    }
}