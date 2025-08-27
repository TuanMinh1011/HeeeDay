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

public class CurrencyChangeGameEvent : GameEvent {
    public int Amount { get; set; }
    public CurrencyType CurrencyType { get; set; }

    public CurrencyChangeGameEvent(int amount, CurrencyType currencyType)
    {
        Amount = amount;
        CurrencyType = currencyType;
    }
}

public class NotEnoughCurrencyGameEvent : GameEvent
{
    public int Amount { get; set; }
    public CurrencyType CurrencyType { get; set; }

    public NotEnoughCurrencyGameEvent(int amount, CurrencyType currencyType)
    {
        Amount = amount;
        CurrencyType = currencyType;
    }
}

public class EnoughCurrencyGameEvent : GameEvent
{

}

public class LevelChangedGameEvent : GameEvent
{
    public int newLvl;

    public LevelChangedGameEvent(int currLvl)
    {
        newLvl = currLvl;
    }
}
