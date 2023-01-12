using Raylib_cs;

Raylib.InitWindow(1200, 600, "Farming Sim");
Raylib.SetTargetFPS(60);

Rectangle leaveButton = new Rectangle(30, 40, 280, 75); // in store button 
Rectangle storeDoor = new Rectangle(210, 175, 70, 20); //door hitbox
Rectangle seedStoreDoor = new Rectangle(530, 175, 70, 20); //seedstore door hitbox
Rectangle playButton = new Rectangle(525, 450, 150, 100);
Rectangle infoButton = new Rectangle(50, 450, 100, 100);

string currentScene = "instructions"; //start, instructions, farm, store, seedStore

//classes 
Farm theFarm = new Farm();
Store theStore = new Store();
SeedStore theSeedStore = new SeedStore();
Instructions theInstructions = new Instructions();


while (!Raylib.WindowShouldClose())
{
    // logic
    // lets the player change the scene and runs the update methods for each scene
    System.Numerics.Vector2 mousePos = Raylib.GetMousePosition();
    if (currentScene == "farm")
    {
        theFarm.Update();

        if (Raylib.CheckCollisionRecs(storeDoor, theFarm.playerRect))
        {
            currentScene = "store";
        }
        if (Raylib.CheckCollisionRecs(seedStoreDoor, theFarm.playerRect))
        {
            currentScene = "seedStore";
        }

        bool wantInfo = Raylib.CheckCollisionPointRec(mousePos, infoButton);
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && wantInfo == true)
        {
            currentScene = "instructions";
        }
    }

    else if (currentScene == "store")
    {
        theStore.Update();

        bool wannaLeave = Raylib.CheckCollisionPointRec(mousePos, leaveButton);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && wannaLeave == true)
        {
            currentScene = "farm";
            theFarm.playerRect.y = 200;
        }
    }

    else if (currentScene == "seedStore")
    {
        theSeedStore.Update();

        bool wannaLeave = Raylib.CheckCollisionPointRec(mousePos, leaveButton);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && wannaLeave == true)
        {
            currentScene = "farm";
            theFarm.playerRect.y = 200;
        }
    }

    else if (currentScene == "instructions")
    {
        bool wannaPlay = Raylib.CheckCollisionPointRec(mousePos, playButton);
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && wannaPlay == true)
        {
            currentScene = "farm";
            theFarm.playerRect.y = 200;
        }
    }

    //graphics
    Raylib.BeginDrawing();

    //runs the draw methods for each scene

    if (currentScene == "farm")
    {
        theFarm.Draw();
    }

    if (currentScene == "store")
    {
        theStore.Draw();
    }

    if (currentScene == "start")
    {

    }
    if (currentScene == "seedStore")
    {
        theSeedStore.Draw();
    }

    if (currentScene == "instructions")
    {
        theInstructions.Draw();
    }

    Raylib.EndDrawing();
}

