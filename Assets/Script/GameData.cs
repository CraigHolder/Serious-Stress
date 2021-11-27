using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 1)]
public class GameData : ScriptableObject
{
    public float stressLevel;
    public int workTasks;
    public int morningTasks;
    public int hour;
    public int min;
    public int day;
    public bool isMorning;


    public void AddStress(float s)
    {
        stressLevel += s;
    }
    public void AddMin(int s)
    {
        min += s;
    }
    public void AddHour(int s)
    {
        hour += s;
    }
}
