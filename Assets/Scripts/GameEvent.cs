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

public class EmployeeChangedGameEvent : GameEvent
{
    public int idle;
    public int working;

    public EmployeeChangedGameEvent(int idleAmount, int workingAmount)
    {
        idle = idleAmount;
        working = workingAmount;
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


