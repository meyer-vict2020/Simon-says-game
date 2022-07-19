using Byui.Games.Services;
using Byui.Games.Scripting;


namespace Byui.Games.Scenes
{
    public abstract class SceneLoader
    {
        private static IServiceFactory ServiceFactory;

        public SceneLoader(IServiceFactory serviceFactory)
        {
            ServiceFactory = serviceFactory;
        }

        public IServiceFactory GetServiceFactory()
        {
            return ServiceFactory;
        }

        public abstract void Load(Scene scene);

    }
}

