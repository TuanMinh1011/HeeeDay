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
    public LandSpaceChangedGameEvent(int amount)
    {
        Amount = amount;
    }
}

public class LandPlatedChangedGameEvent : GameEvent
{
    public int Amount;
    public Plant PlantedWith;

    public LandPlatedChangedGameEvent(int amount, Plant plantedWith)
    {
        Amount = amount;
        PlantedWith = plantedWith;
    }
}

public class LandPlantedSuccessGameEvent : GameEvent
{
    public int Amount { get; set; }
    public LandPlantedSuccessGameEvent(int amount)
    {
        Amount = amount;
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


