using System;
using System.Diagnostics;
using Zenject;

public class GameSceneInstaller : MonoInstaller<GameSceneInstaller>
{
   public override void InstallBindings()
   {
        Container.Bind<ApplicationContainer>().AsSingle();
    }
}
