using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RescueData
{
    public bool savedRyan;
    public bool returnedEarly;
    public List<string> rescues;

    public RescueData(bool savedRyan, bool returnedEarly, List<string> rescues)
    {
        this.savedRyan = savedRyan;
        this.returnedEarly = returnedEarly;
        this.rescues = rescues;
    }
}
