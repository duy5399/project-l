using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MiniChatManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chatViewText;
    [SerializeField] private Queue<string> displayingMessages;

    private void Awake()
    {
        displayingMessages = new Queue<string>();
        chatViewText = transform.GetChild(0).GetComponent<ScrollRect>().content.GetComponent<TextMeshProUGUI>();
    }

    public void DisplayMessage(string msg)
    {
        if (displayingMessages.Count == 10)
        {
            string msgLine0 = displayingMessages.Dequeue();
            if (chatViewText.text.Contains(msgLine0))
            {
                chatViewText.text.Remove(0, msgLine0.Length-1);
            }
        }
        chatViewText.text += "\n" + msg;
    }
}
