using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "CTRPG/Command", order = 0)]
public class Command : ScriptableObject {
    public int SpCost;
    public string CommandName;
}