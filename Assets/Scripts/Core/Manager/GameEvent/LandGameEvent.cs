using System;
using UnityEngine;

public class LandGameEvent : GameEvent {}

public class LandSpaceChangedGameEvent : LandGameEvent
{
    public int Amount;
    public Vector3 Position;
    public LandSpaceChangedGameEvent(int amount, Vector3 position)
    {
        Amount = amount;
        Position = position;
    }
}

//public class LandSpaceSuccessGameEvent : GameEvent
//{
//    public Land Land { get; set; }
//    public LandSpaceSuccessGameEvent(Land land)
//    {
//        Land = land;
//    }
//}

//public class LandPlatedChangedGameEvent : LandGameEvent
//{
//    public int Amount;
//    public Land Land;
//    public Plant PlantedWith;
//    public Action<Land> OnLandSelected;

//    public LandPlatedChangedGameEvent(int amount, Land land, Plant plantedWith, Action<Land> onLandSelected)
//    {
//        Amount = amount;
//        Land = land;
//        PlantedWith = plantedWith;
//        OnLandSelected = onLandSelected;
//    }
//}

//public class LandPlantedSuccessGameEvent : LandGameEvent
//{
//    public int Amount { get; set; }
//    public Land Land { get; set; }

//    public LandPlantedSuccessGameEvent(int amount, Land land)
//    {
//        Amount = amount;
//        Land = land;
//    }
//}

//public class LandPlantedFailedGameEvent : LandGameEvent
//{
//    public string Reason { get; set; }
//    public LandPlantedFailedGameEvent(string reason)
//    {
//        Reason = reason;
//    }
//}

//public class LandSwitchToLandSpaceGameEvent : LandGameEvent
//{
//    public Land Land { get; set; }
//    public Action<Land> OnLandSwitchSelected;
//    public LandSwitchToLandSpaceGameEvent(Land land, Action<Land> onLandSwitchSelected)
//    {
//        Land = land;
//        OnLandSwitchSelected = onLandSwitchSelected;
//    }
//}

//public class LandUpdateLifeCircleGameEvent : LandGameEvent
//{
//    public Land Land { get; set; }
//    public int LifeCircle { get; set; }

//    public LandUpdateLifeCircleGameEvent(Land land, int lifeCircle)
//    {
//        Land = land;
//        LifeCircle = lifeCircle;
//    }
//}

//public class LandSwitchToLandSpaceSuccessGameEvent : GameEvent
//{
//    public Land Land { get; set; }
//    public LandSwitchToLandSpaceSuccessGameEvent(Land land)
//    {
//        Land = land;
//    }
//}
