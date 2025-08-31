using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private string fileUserPath;
    private string filePlantPath;

    void Awake()
    {
        fileUserPath = Path.Combine(Application.persistentDataPath, "userData.json");
        filePlantPath = Path.Combine(Application.persistentDataPath, "plantData.json");
    }

    // Lưu User ra JSON
    public void SaveUser(User user)
    {
        string json = JsonConvert.SerializeObject(user);
        File.WriteAllText(fileUserPath, json);
        Debug.Log("Saved user to " + fileUserPath);
    }

    // Load User từ JSON
    public User LoadUser(string json = null)
    {
        if (File.Exists(fileUserPath))
        {
            json = File.ReadAllText(fileUserPath);

            User user = JsonConvert.DeserializeObject<User>(json);
            Debug.Log("Loaded user " + user.Username);
            return user;
        }
        else
        {
            Debug.LogWarning("No user file found, creating default one...");
            return new User()
            {
                Username = "NewPlayer",
                Coins = 100,
                Level = 1,
                Employees = new Employee[0],
                SeedUnused = new Seed[0],
                FruitHarvest = new Fruit[0],
                Lands = new Land[0]
            };
        }
    }

    public Plant[] LoadPlants(string json = null)
    {
        if (File.Exists(filePlantPath))
        {
            json = File.ReadAllText(filePlantPath);
            Plant[] plants = JsonConvert.DeserializeObject<Plant[]>(json);
            Debug.Log("Loaded " + plants.Length + " plants from " + filePlantPath);
            return plants;
        }
        else
        {
            Debug.LogError("No plant file found at " + filePlantPath);
            return new Plant[0];
        }
    }
}
