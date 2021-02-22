using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public static SaveData _current;
    public static SaveData current;

    public PlayerProfile profile;
    public int buy;
}
