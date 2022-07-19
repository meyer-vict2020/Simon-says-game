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
    public class GamePattern : Byui.Games.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private IMouseService _mouseService;
        string _generated = "Simon says: Click on Blue, Red, Yellow, Green";
        

        public GamePattern(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _mouseService = serviceFactory.GetMouseService();
        }
        
        // public static List<int> AddToPattern(List<int> existingPattern) {
        //     Random random = new Random();
        //     int newPattern = random.Next(0,3);
        //     existingPattern.Add(newPattern);
        //     return existingPattern;
        // }
        
        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                List<Actor> squares = scene.GetAllActors("actors");
                

                // //for each of the numbers in the generated list,
                // //scale the respective squares one after another
                // foreach(int number in _generated)
                // { 
                //     if(number == 0){
                //         // scale the actor down to a minimum of 30 percent
                //         float percent1 = (squares[0].GetScale() > 0.3) ? 0.8f : 0;
                //         squares[0].Scale(percent1);
                        
                //         // wait 1 second 
                //         Task.Delay(1000);
                //         // get bigger
                //         float percent2 = (squares[number].GetScale() < 2.0) ? 1.0f : 0;
                //         squares[number].ScaleTo(percent2);
                //     }
                //     else if(number == 1){
                //         // scale the actor down to a minimum of 30 percent
                //         float percent1 = (squares[number].GetScale() > 0.3) ? 0.8f : 0;
                //         squares[number].Scale(percent1);
                        
                //         // wait 1 second 
                //         Task.Delay(1000);
                //         // get bigger
                //         float percent2 = (squares[number].GetScale() < 2.0) ? 1.0f : 0;
                //         squares[number].ScaleTo(percent2);
                //     }
                //     else if(number == 2){
                //         // scale the actor down to a minimum of 30 percent
                //         float percent1 = (squares[2].GetScale() > 0.3) ? 0.8f : 0;
                //         squares[2].Scale(percent1);
                        
                //         // wait 1 second 
                //         Task.Delay(1000);
                //         // get bigger
                //         float percent2 = (squares[number].GetScale() < 2.0) ? 1.0f : 0;
                //         squares[number].ScaleTo(percent2);
                //     }
                //     else if(number == 3){
                //         // scale the actor down to a minimum of 30 percent
                //         float percent1 = (squares[3].GetScale() > 0.3) ? 0.8f : 0;
                //         squares[3].Scale(percent1);

                //         /// wait 1 second 
                //         Task.Delay(1000);
                //         // get bigger
                //         float percent2 = (squares[number].GetScale() < 2.0) ? 1.0f : 0;
                //         squares[number].ScaleTo(percent2);
                //     }
                    
                //     //wait for at least a second between each square's scaling
                //     Task.Delay(1000);
                // }
                
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't scale actor.", exception);
            }
            
        }
    }
}