using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class JsonManager : MonoBehaviour
{
    private string filePath;

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "userData.json");
    }

    // Lưu User ra JSON
    public void SaveUser(User user)
    {
        string json = JsonConvert.SerializeObject(user);
        File.WriteAllText(filePath, json);
        Debug.Log("Saved user to " + filePath);
    }

    // Load User từ JSON
    public User LoadUser(string json = null)
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);

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
                EmployeesIdle = 1,
                EmployeesWorking = 0,
                SeedUnused = new Seed[0],
                FruitHarvest = new Fruit[0],
                Lands = new Land[0]
            };
        }
    }
}
