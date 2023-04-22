using System;
using Raylib_cs;

public class Store : Scene
{
    Rectangle sellButton = new Rectangle(580, 450, 200, 100); // in store button
    Rectangle leaveButton = new Rectangle(30, 40, 280, 75); // in store button 
    Texture2D insideStoreImg = Raylib.LoadTexture("insidestore.png"); // background image 


    //logic
    public void Update()
    {
        //selling wheat
        System.Numerics.Vector2 mousePos = Raylib.GetMousePosition();
        bool wannaSell = Raylib.CheckCollisionPointRec(mousePos, sellButton);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && playerWheat > 0 && wannaSell == true)
        {
            playerMoney += 10;
            playerWheat -= 1;
        }
    }

    //graphics for the store
    public void Draw()
    {
        //background picture
        Raylib.DrawTexture(insideStoreImg, 0, 0, Color.WHITE);
        //npc interaction
        Raylib.DrawText("Hi and welcome to the bakery!", 565, 20, 19, Color.BLACK);
        Raylib.DrawText("Do you wanna sell us", 610, 45, 19, Color.BLACK);
        Raylib.DrawText("wheat so we can bake", 610, 70, 19, Color.BLACK);
        Raylib.DrawText("our delicious goods?", 610, 95, 19, Color.BLACK);

        // in store buttons 
        Raylib.DrawText("1 wheat for 10 money", 550, 410, 25, Color.BLACK);
        Raylib.DrawRectangleRec(sellButton, Color.GRAY);
        Raylib.DrawText("SELL", 630, 480, 40, Color.BLACK);

        Raylib.DrawRectangleRec(leaveButton, Color.GRAY);
        Raylib.DrawText("LEAVE STORE", 60, 60, 30, Color.BLACK);
        //playerstats
        Raylib.DrawRectangle(990, 5, 200, 73, Color.BEIGE);
        Raylib.DrawText($"Money = {playerMoney}", 1000, 10, 20, Color.BLACK);
        Raylib.DrawText($"Wheat = {playerWheat}", 1000, 30, 20, Color.BLACK);
        Raylib.DrawText($"Seeds = {playerSeeds}", 1000, 50, 20, Color.BLACK);
    }
}
