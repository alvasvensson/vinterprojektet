
using System.Numerics;
using Raylib_cs;
public class soil
{
    // variables used for this scene
    public Rectangle rect;
    public Texture2D image;
    public float timer = 0;
    public int state = 0;

    //images for this scene
    static Texture2D farmWithSeeds = Raylib.LoadTexture("farmWithSeeds.png");
    static Texture2D farmWithWheat = Raylib.LoadTexture("farmWithWheat.png");
    static Texture2D farmWithReadyWheat = Raylib.LoadTexture("farmWithReadyWheat.png");

    //when a soil is created this method is run 
    public soil(int x, int y)
    {
        image = Raylib.LoadTexture("farm.png");
        rect = new Rectangle(x, y, 100, 100);
    }

    //all logik för soils
    public void Update(Rectangle playerRect, Rectangle soilBackground)
    {
        Vector2 mousePos = Raylib.GetMousePosition();
        //places wheat and grows it with help from a timer
        if (Raylib.CheckCollisionRecs(playerRect, soilBackground) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) &&
            Raylib.CheckCollisionPointRec(mousePos, rect) && state == 0 && Scene.playerSeeds > 0)
        {
            image = farmWithSeeds;
            Scene.playerSeeds -= 1;
            state++;
        }

        if (state > 0)
        {
            timer += Raylib.GetFrameTime();
        }

        if (timer > 5 && state == 1)
        {
            image = farmWithWheat;
            state++;
        }
        if (timer > 10 && state == 2)
        {
            image = farmWithReadyWheat;
            state++;
        }
        // checks if the wheat is ready and if it is, you can pick it up
        if (Raylib.CheckCollisionRecs(playerRect, soilBackground) && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT) &&
            Raylib.CheckCollisionPointRec(mousePos, rect) && state == 3)
        {
            image = Raylib.LoadTexture("farm.png");
            state = 0;
            timer = 0;
            Scene.playerWheat += 1;
        }


    }

    //method for drawing each soil
    public void Draw()
    {
        Raylib.DrawTexture(image,
          (int)rect.x,
          (int)rect.y,
          Color.WHITE);
    }
}