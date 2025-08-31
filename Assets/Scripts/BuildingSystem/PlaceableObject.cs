using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool Placed { get; private set; }

    public BoundsInt Area;

    public bool CanBePlaced()
    {
        Vector3Int positionInt = BuildingSystem.Current.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = Area;
        areaTemp.position = positionInt;

        if (BuildingSystem.Current.CanTakeArea(areaTemp))
        {
            return true;
        }

        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = BuildingSystem.Current.GridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = Area;
        areaTemp.position = positionInt;

        Placed = true;

        BuildingSystem.Current.TakeArea(areaTemp);
    }

    public void CheckPlacement()
    {
        if (CanBePlaced())
        {
            Place();

            GameManager.Instance.SetLandSpace(1);
        }
        else
        {
            Destroy(transform.gameObject);
        }

        //ShopManagement.Current.ShopButton_Click();
    }
}
