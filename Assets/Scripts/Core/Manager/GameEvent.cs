using System;
using UnityEngine;

public abstract class GameEvent {}

public class LoadDataGameEvent : GameEvent
{
    public User User { get; set; }

    public LoadDataGameEvent(User user)
    {
        User = user;
    }
}
#region Currency
public class CurrencyChangeGameEvent : GameEvent {
    public int Amount { get; set; }

    public CurrencyChangeGameEvent(int amount)
    {
        Amount = amount;
    }
}

public class NotEnoughCurrencyGameEvent : GameEvent
{
    public int Amount { get; set; }

    public NotEnoughCurrencyGameEvent(int amount)
    {
        Amount = amount;
    }
}

public class EnoughCurrencyGameEvent : GameEvent
{

}
#endregion

public class LevelChangedGameEvent : GameEvent
{
    public int newLvl;

    public LevelChangedGameEvent(int currLvl)
    {
        newLvl = currLvl;
    }
}

public class EmployeeIdleChangedGameEvent : GameEvent
{
    public int IdleAmount;

    public EmployeeIdleChangedGameEvent(int amount)
    {
        IdleAmount = amount;
    }
}

public class EmployeeWorkingChangedGameEvent : GameEvent
{
    public EmployeeWorkingChangedGameEvent()
    { 
    }
}

public class EmployeeWorkingSuccessGameEvent : GameEvent
{
    public int WorkingAmount;
    public EmployeeWorkingSuccessGameEvent(int amount)
    {
        WorkingAmount = amount;
    }
}

public class EmployeeWorkingFailedGameEvent : GameEvent
{
    public string Reason;
    public EmployeeWorkingFailedGameEvent(string reason)
    {
        Reason = reason;
    }
}

public class SeedChangedGameEvent : GameEvent
{
    public int Amount;
    public SeedType SeedType;

    public SeedChangedGameEvent(int amount, SeedType seedType)
    {
        Amount = amount;
        SeedType = seedType;
    }
}

public class FruitChangedGameEvent : GameEvent
{
    public int Amount;
    public FruitType FruitType;
    public FruitChangedGameEvent(int amount, FruitType fruitType)
    {
        Amount = amount;
        FruitType = fruitType;
    }
}

public class LandSpaceChangedGameEvent : GameEvent
{
    public int Amount;
    public Action<Land> OnLandSpaceSelected;
    public Vector3 Position;
    public LandSpaceChangedGameEvent(int amount, Action<Land> onLandSpaceSelected, Vector3 position)
    {
        Amount = amount;
        OnLandSpaceSelected = onLandSpaceSelected;
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

public class LandPlatedChangedGameEvent : GameEvent
{
    public int Amount;
    public Land Land;
    public Plant PlantedWith;
    public Action<Land> OnLandSelected;

    public LandPlatedChangedGameEvent(int amount, Land land, Plant plantedWith, Action<Land> onLandSelected)
    {
        Amount = amount;
        Land = land;
        PlantedWith = plantedWith;
        OnLandSelected = onLandSelected;
    }
}

public class LandPlantedSuccessGameEvent : GameEvent
{
    public int Amount { get; set; }
    public Land Land { get; set; }

    public LandPlantedSuccessGameEvent(int amount, Land land)
    {
        Amount = amount;
        Land = land;
    }
}

public class LandPlantedFailedGameEvent : GameEvent
{
    public string Reason { get; set; }
    public LandPlantedFailedGameEvent(string reason)
    {
        Reason = reason;
    }
}

public class LandSwitchToLandSpaceGameEvent : GameEvent
{
    public Land Land { get; set; }
    public Action<Land> OnLandSwitchSelected;
    public LandSwitchToLandSpaceGameEvent(Land land, Action<Land> onLandSwitchSelected)
    {
        Land = land;
        OnLandSwitchSelected = onLandSwitchSelected;
    }
}

public class LandUpdateLifeCircleGameEvent : GameEvent
{
    public Land Land { get; set; }
    public int LifeCircle { get; set; }

    public LandUpdateLifeCircleGameEvent(Land land, int lifeCircle)
    {
        Land = land;
        LifeCircle = lifeCircle;
    }
}

//public class LandSwitchToLandSpaceSuccessGameEvent : GameEvent
//{
//    public Land Land { get; set; }
//    public LandSwitchToLandSpaceSuccessGameEvent(Land land)
//    {
//        Land = land;
//    }
//}


