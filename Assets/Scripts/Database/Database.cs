using UnityEngine;

public class Land
{
    public string Name;
    public float TimeToHarvest;
    public bool IsPlanted;
    public Plant PlantedWith;
}

public class Plant
{
    public PlantType PlantType;
    public string Name;
    public float GrowthTime;
    public int NumbersInLifeCycle;
    public int SellPrice;
}

public class Seed
{
    public SeedType SeedType;
    public string Name;
    public int Amount;
    public int BuyPrice;
}

public class Fruit
{
    public FruitType FruitType;
    public string Name;
    public int Amount;
}

public class Employee 
{
    public string Name;
    public float TimeFinishWork;
    public int RentPrice;
    public bool IsWorking;
}


public class User
{
    public string Username;
    public int Coins;
    public int Level;
    public Employee[] Employees;
    public Seed[] SeedUnused;
    public Fruit[] FruitHarvest;
    public Land[] Lands;
}

public enum SeedType
{
    Tomato,
    Cow
}

public enum FruitType
{
    Tomato,
    Milk
}

public enum PlantType
{
    Tomato,
    Blueberry,
    Strawberry,
    Cow
}