# Match One
This is a simple and interactive Unity example project to show how to use Entitas.
Entitas is a super fast Entity Component System (ECS) Framework specifically made for C# and Unity.

See https://github.com/sschmid/Entitas

---

Match One is a very simple CandyCrush-like Match 3 example, except it's Match One.

[Watch the talk from Unite Europe 2015](https://www.youtube.com/watch?v=Re5kGtxTW6E) to get an in-depth tutorial.

![Match One](readme/images/Match-One.png)

Match One shows
- systems list in `GameController`
- how you can use reactive systems to only process changed entities
- the usage of `EntityIndex` to conveniently access entities with a specific position
- how you can use multiple `contexts` to reduce the memory footprint of each entity (Game, Input, GameState, Config)
- how to decouple views from the game logic and use listeners to update themselves

---

Play around, add some features and ideas, and when you need to regenerate code, e.g. after adding new components, run

```
dotnet Jenny/Jenny.Generator.Cli.dll gen
```

Happy coding :)
