using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour
{
    private ShieldManager shieldManagerHP;
    private ShieldManager shieldManagerTimer;
    private MeshRenderer meshStatus;
    private CircleCollider2D colliderStatus;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = GameObject.Find("Button Shield").GetComponent<Button>();
        shieldManagerHP = GameObject.Find("Text Shield").GetComponent<ShieldManager>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        shieldManagerHP.shieldHP = 30;
        meshStatus = GameObject.Find("First Person Shield").GetComponent<MeshRenderer>();
        colliderStatus = GameObject.Find("First Person Shield").GetComponent<CircleCollider2D>();
        meshStatus.enabled = true;
        colliderStatus.enabled = true;
        StartCoroutine(shieldDuration());
    }

    IEnumerator shieldDuration()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(10);
        meshStatus.enabled = false;
        colliderStatus.enabled = false;
        shieldManagerHP.shieldHP = 0;
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
