using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Normal,
    Flyer,
    Summoner
};

public class EnemyDataList : ScriptableObject
{
    public List<EnemyData> enemyDataList = new List<EnemyData>();
}

[System.Serializable]
public class EnemyData
{
    public uint id;
    public uint progressId;
    public string enemyType;
    public float spawnTime;
    public int spawnPositionX;
    public int spawnPositionY;
}
