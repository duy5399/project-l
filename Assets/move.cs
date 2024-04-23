using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Vector3 vector3 = new Vector3(0, 0.25f, 5);
    public float time;
    public float speed;
    public float dictace = 0;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.transform.position);
        Debug.Log(vector3);
        speed = 25f;
        dictace = Vector3.Distance(this.transform.position, vector3);
        time = dictace / speed;
        Debug.Log(dictace);
        Debug.Log(time);
        StartCoroutine(_run());
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, vector3, time);
        }
    }

    IEnumerator _run()
    {
        yield return new WaitForSeconds(3);
        check = true;
    }
}
