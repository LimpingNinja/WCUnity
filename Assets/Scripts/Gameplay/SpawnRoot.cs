using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoot : MonoBehaviour
{
    public GameObject SpawnParent;
    public bool isPlayer;
    public AIPlayer.AILevel aiLevel;
    public MessageHandler messageOverride;



    public void Awake()
    {
        GameObject root = Instantiate(SpawnParent, transform.position, transform.rotation);
        transform.parent = root.transform;
        root.name = SpawnParent.name;
        root.GetComponent<AIPlayer>().AISkillLevel = aiLevel;
        root.GetComponent<ShipSettings>().isPlayer = true;
        root.GetComponent<ShipSettings>().playerUI = this.gameObject;
        if (isPlayer) SetPlayable();
    }
    public void SetPlayable()
    {
        if (!transform.parent) return;
       if (transform.parent.TryGetComponent(out AIPlayer ship))
        {
            ship.enabled = false;
            ship.gameObject.AddComponent<HumanPlayer>();
        }

    }
}
