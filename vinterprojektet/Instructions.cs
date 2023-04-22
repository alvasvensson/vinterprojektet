using System;
using Raylib_cs;

public class Instructions
{

    Rectangle playButton = new Rectangle(525, 450, 150, 100); // button to start the game 
    Rectangle textBox = new Rectangle(475, 370, 250, 50); // button to start the game 

// funktion för att kunna välja namn på sin gård, 
// läser in knapparna på tangentbordet och adderar de på en string
    public void writeName()
    {
        int key = Raylib.GetKeyPressed();
        if (key != 0)
        {

            if (key == 259)
            {
                try
                {
                    Scene.farmName = Scene.farmName.Substring(0, Scene.farmName.Length - 1);
                }
                catch
                {
                    Scene.farmName = Scene.farmName.Substring(0, Scene.farmName.Length);
                }
            }
            else if (Scene.farmName.Length < 10)
            {
                Scene.farmName += (char)key;
            }
        }
    }

//ritar allting som ska synas i instructions-scenen
    public void Draw()
    {

        Raylib.ClearBackground(Color.PURPLE); // background
        Raylib.DrawText("Farming Sim", 500, 40, 40, Color.BLACK); //title 
        Raylib.DrawText("School Project by Alva Svensson", 440, 85, 20, Color.BLACK); //title 

        //draws out the play button 
        Raylib.DrawRectangleRec(playButton, Color.BROWN);
        Raylib.DrawText("PLAY!", 555, 480, 30, Color.BLACK);

        // draws out the instructions
        Raylib.DrawText("Grow wheat in you farming area by clicking the soil you want to plant.", 160, 120, 25, Color.BLACK);
        Raylib.DrawText("When the wheat is ready to be picked up, pick it up by clicking it. ", 180, 170, 25, Color.BLACK);
        Raylib.DrawText("To get money, go to the bakery and sell your wheat.", 250, 220, 25, Color.BLACK);
        Raylib.DrawText("To get more seeds, go to the store and buy seads.", 255, 270, 25, Color.BLACK);


        Raylib.DrawText("But first, what's the name of your farm? (MAX 10 characters)", 220, 320, 25, Color.BLACK);
        Raylib.DrawRectangleRec(textBox, Color.BEIGE);
        Raylib.DrawText($"{Scene.farmName}", 485, 375, 30, Color.BLACK);

        if (Scene.farmName.Length < 10 && Scene.farmName.Length > 0)
        {
            Raylib.DrawText($"{Scene.farmName.Length}/10", 735, 375, 30, Color.BLACK);
        }
        else
        {
            Raylib.DrawText($"{Scene.farmName.Length}/10", 735, 375, 30, Color.RED);
        }

    }

//ritar ut en text som bara syns om man skriver namnet på fel sätt
    public void noName()
    {
        Raylib.DrawText("Your Farm needs a name that has at least 1 and at most 10 characters", 170, 420, 25, Color.RED);
    }
}
