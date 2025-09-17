using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Current { get; private set; }

    public GridLayout GridLayout;
    public Tilemap MainTilemap;
    public TileBase TakenTile;

    private void Awake()
    {
        Current = this;
    }

    #region Tilemap Managerment

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileBase tiles, Tilemap tilemap)
    {
        TileBase[] tileArray = new TileBase[area.size.x * area.size.y];
        FillTiles(tileArray, tiles);
        tilemap.SetTilesBlock(area, tileArray);
    }

    private static void FillTiles(TileBase[] arr, TileBase tileBase)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBase;
        }
    }

    private static void ClearArea(BoundsInt area, Tilemap tilemap)
    {
        SetTilesBlock(area, null, tilemap);
    }

    #endregion


    #region Building Placement

    public void InitializeWithObject(GameObject building, Vector3 pos)
    {
        pos.z = 0;
        pos.y -= building.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2f;
        Vector3Int cellPos = GridLayout.WorldToCell(pos);
        Vector3 position = GridLayout.CellToLocalInterpolated(cellPos);

        GameObject obj = Instantiate(building, position, Quaternion.identity);
        PlaceableObject temp = obj.GetComponent<PlaceableObject>();
        temp.gameObject.AddComponent<ObjectDrag>();
    }

    public void InitializeWithObjectFromData(GameObject building, Vector3 pos, Land land)
    {
        pos.z = 0;
        pos.y -= building.GetComponentInChildren<SpriteRenderer>().bounds.size.y / 2f;
        Vector3Int cellPos = GridLayout.WorldToCell(pos);
        Vector3 position = GridLayout.CellToLocalInterpolated(cellPos);

        GameObject obj = Instantiate(building, position, Quaternion.identity);
        obj.GetComponent<PlaceableObject>().Place();
        //obj.GetComponent<LandController>().LoadDataLand(land);
    }

    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] tileArray = GetTilesBlock(area, MainTilemap);

        foreach (var tile in tileArray)
        {
            if (tile != null)
            {
                return false;
            }
        }

        return true;
    }
    
    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, TakenTile, MainTilemap);
    }  

    #endregion
}
