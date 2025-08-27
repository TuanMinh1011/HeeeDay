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
    public string Name;
    public float GrowthTime;
    public int NumbersInLifeCycle;
    public int SellPrice;
}

public class Seed
{
    public string Name;
    public int Amount;
    public int BuyPrice;
}

public class Fruit
{
    public string Name;
    public int Amount;
}

public class User
{
    public string Username;
    public int Coins;
    public int Level;
    public int EmployeesWorking;
    public int EmployeesIdle;
    public Seed[] SeedUnused;
    public Fruit[] FruitHarvest;
    public Land[] Lands;
}