using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public FullsaveData fullSaveData = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        fullSaveData.scoreAmount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            saveGame();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            loadGame();
        }
    }

    public void DamageTemple(int amount)
    {
        fullSaveData.templeInfo.HP -= amount;
    }

    public void AddScore(int scoreAmnt)
    {
        fullSaveData.scoreAmount += scoreAmnt;
    }

    public void saveGame()
    {
        SaveSystemService.instance.SaveToJson(fullSaveData);
    }

    public void loadGame()
    {
        SaveSystemService.instance.LoadFromJson();
    }
}

[System.Serializable]
public class FullsaveData
{
    public int scoreAmount;
    public TempleData templeInfo;
}

[System.Serializable]
public class TempleData
{
    public int HP = 100;
}