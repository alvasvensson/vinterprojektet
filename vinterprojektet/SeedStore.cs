using System;
using Raylib_cs;


public class SeedStore : Scene
{
    Texture2D insideSeedStoreImg = Raylib.LoadTexture("insideSeedStore.png"); //background picture
    Rectangle buyButton = new Rectangle(800, 450, 200, 50); // in store button
    Rectangle leaveButton = new Rectangle(30, 40, 280, 75); // in store button 

    //logic
    public void Update()
    {
        // buying seeds
        System.Numerics.Vector2 mousePos = Raylib.GetMousePosition();
        bool wannaBuy = Raylib.CheckCollisionPointRec(mousePos, buyButton);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && playerMoney >= 10 && wannaBuy == true)
        {
            playerMoney -= 8;
            playerSeeds += 1;
        }
    }

    //graphics for the seedstore
    public void Draw()
    {
        //background picture
        Raylib.DrawTexture(insideSeedStoreImg, 0, 0, Color.WHITE);

        //player stats
        Raylib.DrawRectangle(990, 5, 200, 73, Color.BEIGE);
        Raylib.DrawText($"Money = {playerMoney}", 1000, 10, 20, Color.BLACK);
        Raylib.DrawText($"Wheat = {playerWheat}", 1000, 30, 20, Color.BLACK);
        Raylib.DrawText($"Seeds = {playerSeeds}", 1000, 50, 20, Color.BLACK);


        // in store buttons
        Raylib.DrawRectangleRec(leaveButton, Color.GRAY);
        Raylib.DrawText("LEAVE STORE", 60, 60, 30, Color.BLACK);

        Raylib.DrawRectangleRec(buyButton, Color.GRAY);
        Raylib.DrawText("BUY SEEDS", 830, 465, 25, Color.BLACK);
    }


}
