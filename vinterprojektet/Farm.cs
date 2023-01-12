using Raylib_cs;
public class Farm : Scene
{

    //instans variables 


    Texture2D avatarImg = Raylib.LoadTexture("avatar.png"); //player image 
    Texture2D backgroundImg = Raylib.LoadTexture("background.png"); //farm background image
    Texture2D storeImg = Raylib.LoadTexture("store.png"); // bakery(store) image
    Texture2D seedStoreImg = Raylib.LoadTexture("seedStore.png"); //seedstore image 
    Rectangle soilBackground = new Rectangle(800, 180, 360, 340); //fields
    Rectangle storeDoor = new Rectangle(210, 175, 70, 20); //bakery (store) door hitbox
    Rectangle seedStoreDoor = new Rectangle(530, 175, 70, 20); //seedstore door hitbox
    Rectangle infoButton = new Rectangle(50, 450, 100, 100); //information button
    public Rectangle playerRect; //player hitbox

    // list for soils where wheat can be planted
    List<soil> soils = new List<soil>();
    //variable for player speed
    float speed = 3;

    //adds soils to the list
    public Farm() //constructor
    {
        playerRect = new Rectangle(600, 260, avatarImg.width, avatarImg.height); //player hitbox

        for (int i = 0; i < 3; i++)
        {
            soils.Add(new soil(820 + (i * 110), 200));
            soils.Add(new soil(820 + (i * 110), 400));
        }
    }

    //logic method
    public void Update()
    {
        // player movement 
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

        // runs every soils update method
        for (int s = 0; s < soils.Count; s++)
        {
            soils[s].Update(playerRect, soilBackground);
        }
    }


    //graphics
    public void Draw()
    {
        Raylib.DrawTexture(backgroundImg, 0, 0, Color.WHITE);
        Raylib.DrawRectangleRec(storeDoor, Color.BROWN); // bakery (store) door hitbox, hid behind the picture of the door
        Raylib.DrawRectangleRec(seedStoreDoor, Color.BROWN); // seed store door hitbox, hid behind the picture of the door
        Raylib.DrawTexture(storeImg, 30, 0, Color.WHITE); // bakery(store) image
        Raylib.DrawTexture(seedStoreImg, 350, 0, Color.WHITE);

        Raylib.DrawRectangleRec(soilBackground, Color.BROWN);

        // player stats 
        Raylib.DrawText($"Wheat = {playerWheat}", 1000, 30, 20, Color.BLACK);
        Raylib.DrawText($"Money = {playerMoney}", 1000, 10, 20, Color.BLACK);
        Raylib.DrawText($"Seeds = {playerSeeds}", 1000, 50, 20, Color.BLACK);

        //draws each soil in the list of soil
        foreach (soil e in soils)
        {
            e.Draw();
        }

        // draws the player avatar
        Raylib.DrawTexture(avatarImg,
           (int)playerRect.x,
           (int)playerRect.y,
           Color.WHITE);

        // draws the information button
        Raylib.DrawRectangleRec(infoButton, Color.BROWN);
        Raylib.DrawText("?", 85, 475, 50, Color.BLACK);
    }
}