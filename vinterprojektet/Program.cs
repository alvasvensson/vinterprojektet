using Raylib_cs;

Raylib.InitWindow(1200, 600, "Farming Sim");
Raylib.SetTargetFPS(60);

Texture2D backgroundImg = Raylib.LoadTexture("background.png");
Texture2D avatarImg = Raylib.LoadTexture("avatar.png");
Texture2D storeImg = Raylib.LoadTexture("store.png");
Texture2D insideStoreImg = Raylib.LoadTexture("insidestore.png");
Texture2D farmWithSeeds = Raylib.LoadTexture("farmWithSeeds.png");
Texture2D farmWithWheat = Raylib.LoadTexture("farmWithWheat.png");

Rectangle soilBackground = new Rectangle(800, 180, 360, 340); //fields
Rectangle storeDoor = new Rectangle(210, 175, 70, 20); //door hitbox
Rectangle playerRect = new Rectangle(600, 260, avatarImg.width, avatarImg.height); //player hitbox

Rectangle sellButton = new Rectangle(580, 450, 200, 100); // in store button
Rectangle leaveButton = new Rectangle(30, 40, 280, 75); // in store button (in progress)


int playerMoney = 100;
int playerWheat = 5;

float speed = 3;


string currentScene = "farm"; //start, instructions, farm, store

List<soil> soils = new List<soil>();
soils.Add(new soil());
soils.Add(new soil());
soils.Add(new soil());
soils.Add(new soil());
soils.Add(new soil());
soils.Add(new soil());

soils[1].rect.x = 930;
soils[1].rect.y = 200;

soils[2].rect.x = 1040;
soils[2].rect.y = 200;

soils[3].rect.x = 820;
soils[3].rect.y = 400;

soils[4].rect.x = 930;
soils[4].rect.y = 400;

soils[5].rect.x = 1040;
soils[5].rect.y = 400;




while (!Raylib.WindowShouldClose())
{
    System.Numerics.Vector2 mousePos = Raylib.GetMousePosition();
    // logic
    if (currentScene == "farm")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && playerRect.x < 1166)
        {
            playerRect.x += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && playerRect.x > 2)
        {
            playerRect.x -= speed;
        }

        if (Raylib.IsKeyDown(KeyboardKey.KEY_S) && playerRect.y < 534)
        {
            playerRect.y += speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && playerRect.y > 2)
        {
            playerRect.y -= speed;
        }

        if (Raylib.CheckCollisionRecs(storeDoor, playerRect))
        {
            currentScene = "store";
        }

        for (int s = 0; s < soils.Count; s++)
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && Raylib.CheckCollisionPointRec(mousePos, soils[s].rect)
            && soils[s].state == 0)
            {
                soils[s].image = farmWithSeeds;
                soils[s].state++;
            }

            soils[s].timer += Raylib.GetFrameTime();
            if (soils[s].timer > 5 && soils[s].state != 0)
            {
                soils[s].image = farmWithWheat;
            }
        }
    }

    else if (currentScene == "store")
    {
        bool wannaSell = Raylib.CheckCollisionPointRec(mousePos, sellButton);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && playerWheat > 0 && wannaSell == true)
        {
            playerMoney += 10;
            playerWheat -= 1;
        }


        bool wannaLeave = Raylib.CheckCollisionPointRec(mousePos, leaveButton);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && wannaLeave == true)
        {
            currentScene = "farm";
            playerRect.y = 200;
        }

    }


    //graphics
    Raylib.BeginDrawing();

    if (currentScene == "farm")
    {

        Raylib.DrawTexture(backgroundImg, 0, 0, Color.WHITE);
        Raylib.DrawRectangleRec(storeDoor, Color.BROWN); // door hitbox, hid behind the pictrure of the door
        Raylib.DrawTexture(storeImg, 30, 0, Color.WHITE);

        Raylib.DrawRectangleRec(soilBackground, Color.BROWN);

        Raylib.DrawText($"Wheat = {playerWheat}", 1000, 30, 20, Color.BLACK);
        Raylib.DrawText($"Money = {playerMoney}", 1000, 10, 20, Color.BLACK);

        foreach (soil e in soils)
        {
            e.Draw();
        }

        Raylib.DrawTexture(avatarImg,
           (int)playerRect.x,
           (int)playerRect.y,
           Color.WHITE);
    }

    if (currentScene == "store")
    {
        Raylib.DrawTexture(insideStoreImg, 0, 0, Color.WHITE);
        Raylib.DrawText("Hi and welcome to the bakery!", 565, 20, 19, Color.BLACK);
        Raylib.DrawText("Do you wanna sell us", 610, 45, 19, Color.BLACK);
        Raylib.DrawText("wheat so we can bake", 610, 70, 19, Color.BLACK);
        Raylib.DrawText("our delicious goods?", 610, 95, 19, Color.BLACK);

        Raylib.DrawText("1 wheat for 10 money", 550, 410, 25, Color.BLACK);
        Raylib.DrawRectangleRec(sellButton, Color.GRAY);
        Raylib.DrawText("SELL", 630, 480, 40, Color.BLACK);

        Raylib.DrawRectangleRec(leaveButton, Color.GRAY);
        Raylib.DrawText("LEAVE STORE", 60, 60, 30, Color.BLACK);

        Raylib.DrawRectangle(990, 5, 200, 55, Color.BEIGE);
        Raylib.DrawText($"Money = {playerMoney}", 1000, 10, 20, Color.BLACK);
        Raylib.DrawText($"Wheat = {playerWheat}", 1000, 30, 20, Color.BLACK);
    }

    if (currentScene == "start")
    {

    }

    Raylib.EndDrawing();
}