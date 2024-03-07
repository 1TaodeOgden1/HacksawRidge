using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueTracker : MonoBehaviour
{
    List<RescueData> rescues = new List<RescueData>();

    public void AddRescueData(RescueData rescueData)
    {
        UpdateRescueData();
        rescues.Add(rescueData);
        SaveData.SaveToJSON<RescueData>(rescues, "RescueData.json");
    }

    public void UpdateRescueData()
    {
        rescues = SaveData.ReadFromJSON<RescueData>("RescueData.json");
    }
}
