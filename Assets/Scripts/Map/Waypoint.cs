using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Waypoint : MonoBehaviour
{
    public string map_id;
    public bool teleported;
    public float channelDuration;

    private void Awake()
    {
        teleported = false;
        channelDuration = 3f;
    }

    void OnTriggerEnter(Collider character)
    {
        if (character.CompareTag("Player"))
        {
            ChBase chBase = character.GetComponent<ChBase>();
            if (!chBase.isLocalPlayer)
            {
                Debug.Log("!chBase.isLocalPlayer");
                return;
            }
            ChCurState chCurState = character.GetComponent<ChCurState>();
            if (chCurState.inCombat)
            {
                Debug.Log("chCurState.inCombat");
                return;
            }
            if (!chCurState.isTeleporting)
            {
                chCurState.isTeleporting = true;
                StartCoroutine(Teleport(character.gameObject));
            }
        }
    }

    IEnumerator Teleport(GameObject go)
    {
        yield return new WaitForSeconds(channelDuration);
        ChCurState chCurState = go.GetComponent<ChCurState>();
        if (chCurState.isTeleporting)
        {
            SocketIO.instance.sceneSocketIO.Emit_GoToMap(map_id);
        }
    }


    void OnTriggerExit(Collider character)
    {
        if (character.CompareTag("Player"))
        {
            Debug.Log("OnTriggerExit" + character.name);
            ChCurState chCurState = character.GetComponent<ChCurState>();
            chCurState.isTeleporting = false;
        }
    }
}
