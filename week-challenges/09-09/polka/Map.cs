namespace Polka;

public class PScene_Test : PScene
{
    public Player player;

    public PTilemap tilemapBG;
    public PTilemap tilemapDeco;
    public PTilemap tilemapSolid;

    public PScene_Test()
    {
        player = new Player();

        string tilemapSprPath = "Content/Sprites/tiles.png";
        tilemapBG = new PTilemap( "Content/Maps/map_01_bg.csv",  tilemapSprPath);
        tilemapSolid = new PTilemap( "Content/Maps/map_01_solid.csv",  tilemapSprPath);
        tilemapDeco = new PTilemap( "Content/Maps/map_01_deco.csv",  tilemapSprPath);
       
        // Ordem de desenho
        objectList.Add(tilemapBG);
        objectList.Add(tilemapSolid);
        objectList.Add(player);
        objectList.Add(tilemapDeco);
    }
}