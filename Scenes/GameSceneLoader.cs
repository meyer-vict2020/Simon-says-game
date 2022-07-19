using System;
using System.Collections.Generic;
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;
using Byui.Games.Scenes;


namespace Byui.Games.Scenes
{
    public class GameSceneLoader : SceneLoader
    {

        private ActorFactory _actorFactory;

        public GameSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) 
        {
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            _actorFactory = new ActorFactory(settingsService);
        }

        public override void Load(Scene scene)
        {
            scene.Clear();
            LoadBackground(scene);
            LoadActors(scene);
            LoadActions(scene);
        }

        private void LoadActions(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            
            LoadSceneAction loadSceneAction = new LoadSceneAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            scene.AddAction(Phase.Update, loadSceneAction);
            scene.AddAction(Phase.Output, drawActorsAction);
            scene.AddAction(Phase.Input, gamePattern);
        }

        private void LoadActors(Scene scene)
        {
                        // Instantiate the actors that are used in this example.
            Label label = new Label();
            label.Display("Simon Says");
            label.MoveTo(25, 25);
            
            Actor square0 = new Actor();
            square0.SizeTo(100, 100);
            square0.MoveTo(200, 100);
            square0.Tint(Color.Blue());

            Actor square1 = new Actor();
            square1.SizeTo(100, 100);
            square1.MoveTo(340, 100);
            square1.Tint(Color.Red());

            Actor square2 = new Actor();
            square2.SizeTo(100, 100);
            square2.MoveTo(200, 250);
            square2.Tint(Color.Yellow());

            Actor square3 = new Actor();
            square3.SizeTo(100, 100);
            square3.MoveTo(340, 250);
            square3.Tint(Color.Green());

            // Instantiate the actions that use the actors.
            ScaleActorAction scaleActorAction = new ScaleActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);
            GamePattern gamePattern = new GamePattern(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actors", square0);
            scene.AddActor("actors", square1);
            scene.AddActor("actors", square2);
            scene.AddActor("actors", square3);

            scene.AddActor("labels", label);
            scene.AddAction(Phase.Input, scaleActorAction);
            scene.AddAction(Phase.Output, drawActorAction);
        }

        private void LoadBackground(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            IVideoService videoService = serviceFactory.GetVideoService();
            videoService.SetBackground(Color.White());
        }

    }
}

