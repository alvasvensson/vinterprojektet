using Raylib_cs;
public class soil
{

    public Rectangle rect;
    public Texture2D image;
    public soil()
    {
        image = Raylib.LoadTexture("farm.png");
        rect = new Rectangle(820, 200, 100, 100);
    }

    public void Draw()
    {
        Raylib.DrawTexture(image,
          (int)rect.x,
          (int)rect.y,
          Color.WHITE);
    }
}