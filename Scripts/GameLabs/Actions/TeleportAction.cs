using UnityEngine;
using System.Collections;

public class TeleportAction : Action
{
    public Transform teleportTo;
    public Transform toTeleport;

    public override void Invoke()
    {
        toTeleport.position = teleportTo.position;
    }
}
