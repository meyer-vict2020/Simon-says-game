using Byui.Games.Casting;
using Byui.Games.Directing;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scaling
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to scale an actor up and down on the screen.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            Label label = new Label();
            label.Display("Simon Says");
            label.MoveTo(25, 25);
            
            Actor square1 = new Actor();
            square1.SizeTo(100, 100);
            square1.MoveTo(200, 100);
            square1.Tint(Color.Blue());

            Actor square2 = new Actor();
            square2.SizeTo(100, 100);
            square2.MoveTo(340, 100);
            square2.Tint(Color.Red());

            Actor square3 = new Actor();
            square3.SizeTo(100, 100);
            square3.MoveTo(200, 250);
            square3.Tint(Color.Yellow());

            Actor square4 = new Actor();
            square4.SizeTo(100, 100);
            square4.MoveTo(340, 250);
            square4.Tint(Color.Green());

            // Instantiate the actions that use the actors.
            ScaleActorAction scaleActorAction = new ScaleActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);
            GamePattern gamePattern = new GamePattern(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actors", square1);
            scene.AddActor("actors", square2);
            scene.AddActor("actors", square3);
            scene.AddActor("actors", square4);

            scene.AddActor("labels", label);
            scene.AddAction(Phase.Input, scaleActorAction);
            scene.AddAction(Phase.Output, drawActorAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
