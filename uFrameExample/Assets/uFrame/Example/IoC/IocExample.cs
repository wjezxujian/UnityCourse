using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using uFrame.IOC;
using uFrame.Kernel;

public class IocExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var container = new UFrameContainer();

        container.RegisterInstance(container);

        container.Register<IPlayer, Player>();

        container.Resolve<IPlayer>().Run();

        var player1 = container.Resolve<IPlayer>();
        var player2 = container.Resolve<IPlayer>();

        Debug.Log(player1.GetHashCode());
        Debug.Log(player2.GetHashCode());

        container.RegisterInstance<IPlayer>(new Player());

        var player3 = container.Resolve<IPlayer>();
        var player4 = container.Resolve<IPlayer>();

        Debug.Log(player3.GetHashCode());
        Debug.Log(player4.GetHashCode());

        Debug.Log(container.Resolve<UFrameContainer>().GetHashCode());
        Debug.Log(container.GetHashCode());
    }

    public interface IPlayer
    {
        void Run();
    }

    public class Player: IPlayer
    {
        public void Run()
        {
            Debug.Log("Run");
        }
    }
}
