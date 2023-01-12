using System;
using Raylib_cs;

public class Instructions
{

    Rectangle playButton = new Rectangle(525, 450, 150, 100); // button to start the game 

    public void Draw()
    {

        Raylib.ClearBackground(Color.PURPLE); // background
        Raylib.DrawText("Farming Sim", 500, 40, 40, Color.BLACK); //title 
        Raylib.DrawText("School Project by Alva Svensson", 440, 85, 20, Color.BLACK); //title 

        //draws out the play button 
        Raylib.DrawRectangleRec(playButton, Color.BROWN);
        Raylib.DrawText("PLAY!", 555, 480, 30, Color.BLACK);

        // draws out the instructions
        Raylib.DrawText("Grow wheat in you farming area by clicking the soil you want to plant.", 160, 150, 25, Color.BLACK);
        Raylib.DrawText("When the wheat is ready to be picked up, pick it up by clicking it. ", 180, 200, 25, Color.BLACK);
        Raylib.DrawText("To get money, go to the bakery and sell your wheat.", 250, 250, 25, Color.BLACK);
        Raylib.DrawText("To get more seeds, go to the store and buy seads.", 255, 300, 25, Color.BLACK);

    }
}
