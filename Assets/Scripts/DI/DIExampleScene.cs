using UnityEngine;

namespace DI
{
    public class DIExampleScene : MonoBehaviour
    {
        public void Init(DIContainer projectContainer)
        {
            //var serviceWithoutTag = projectContainer.Resolve<MyAwesomeProjectService>();
            //var service1 = projectContainer.Resolve<MyAwesomeProjectService>("option 1");
            //var service2 = projectContainer.Resolve<MyAwesomeProjectService>("option 2");

            var sceneContainer = new DIContainer(projectContainer);
            //sceneContainer.Resolve<MyAwesomeProjectService>();
            sceneContainer.RegisterSingleton(c => new MySceneService(c.Resolve<MyAwesomeProjectService>()));
            sceneContainer.RegisterSingleton(_ => new MyAwesomeFactory());
            sceneContainer.RegisterInstance(new MyAwesomeObject("instance", 10));

            var objectFactory = sceneContainer.Resolve<MyAwesomeFactory>();
            objectFactory.CreateInstance("id", 0);

            var instance = sceneContainer.Resolve<MyAwesomeObject>();
        }
    }
}