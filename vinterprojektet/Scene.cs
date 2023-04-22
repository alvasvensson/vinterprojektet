using System;

public class Scene
{
    //player stats, used in all scenes
    public static int playerMoney = 0;
    public static int playerWheat = 0;
    public static int playerSeeds = 6;
    public static string farmName = "";

    public static string InstructionsScene(Vector2 mousePos, Rectangle playButton, string currentScene,
    Farm theFarm, Instructions theInstructions)
    {
        bool wannaPlay = Raylib.CheckCollisionPointRec(mousePos, playButton);
        bool haveName = Scene.farmName.Length > 0 && Scene.farmName.Length < 11;

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) && wannaPlay == true
        && haveName == true)
        {
            theFarm.playerRect.y = 200;
            currentScene = "farm";
        }

        else if (wannaPlay == true
        && haveName == false)
        {
            theInstructions.noName();
        }

        // kör funktionen för att kunna välja namn på sin gård
        theInstructions.writeName();

        return currentScene;
    }
}
