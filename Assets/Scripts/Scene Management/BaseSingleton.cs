using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingleton : Singleton<BaseSingleton>
{
    // This nothing let object be moved from scene to scene
    // It's used in the scene in the Managers gameobject
}
