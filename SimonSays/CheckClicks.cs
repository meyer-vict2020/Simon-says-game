using System;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;



namespace SimonSays
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class CheckClicks : Byui.Games.Scripting.Action
    {
        private int numberOfSquares;
        private bool enoughClicks;
        private ScaleActorAction player;

        private bool win;
        // in theory here you would get the generated list
        List<int> generated = new List<int> { 1, 2, 3, 4 };
        private IVideoService _videoService;

        //this method checks if the player has clicked the right amount of boxes to start a check


        public CheckClicks(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }
        private bool CheckEnoughClicks()
        {
            if(player == null) {
                return false;
            }
            // put the amount of squares in the string here!! v
            numberOfSquares = 4;
            if (player.PlayerClicksCount() >= numberOfSquares)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // check clicks 
                enoughClicks = CheckEnoughClicks();
                Label message = new Label();

                if (enoughClicks)
                {
                    // get the player list 
                    List<int> playerClicks = player.GetPlayerClicks();

                    for (int i = 0; i < generated.Count; i++)
                    {
                        if (generated[i] == playerClicks[i])
                        {
                            continue;
                        }
                        else
                        {
                            string failMessage = "Simon says you Lost. Try Again.";
                            message.Display(failMessage);
                            message.MoveTo(75, 75);
                            scene.AddActor("labels", message);

                            break;
                        }
                    }
                    string successMessage = "Simon says you win! Play again :)";
                    message.Display(successMessage);
                    message.MoveTo(25, 25);
                    scene.AddActor("labels", message);
                }

                // draw the actors on the screen

            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't check score.", exception);
            }
        }
    }
}