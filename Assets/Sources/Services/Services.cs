using System;

public class Services {

    public static Services singleton = new Services();

    public void Initialize(GameController gameController) {
        var random = new Random(DateTime.UtcNow.Millisecond);
        UnityEngine.Random.InitState(random.Next());
        RandomService.game.Initialize(random.Next());
        RandomService.view.Initialize(random.Next());

        ViewService.singleton.Initialize(gameController.transform);
    }
}
