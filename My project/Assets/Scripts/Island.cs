using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public List<GameObject> teleportCamera = new List<GameObject>();
    public List<NextLevel> Exits = new List<NextLevel>();
}
