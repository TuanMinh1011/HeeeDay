using UnityEngine;

public class Land
{
    public string Name;
    public bool IsPlanted;
    public Plant PlantedWith;
    public double StartTime;
    public SerializableVector3 LandPos;
}

public class Plant
{
    public PlantType PlantType;
    public string Name;
    public float GrowthTime;
    public int NumbersInLifeCycle;
    public int CurrentCycle;
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
    public int SellPrice;
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
    public double LastLoginTime;
}

public enum SeedType
{
    Tomato,
    Blueberry,
    Strawberry,
    Cow
}

public enum FruitType
{
    Tomato,
    Blueberry,
    Strawberry,
    Milk
}

public enum PlantType
{
    Tomato,
    Blueberry,
    Strawberry,
    Cow
}

public struct SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}