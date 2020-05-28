using System.Collections;
using UnityEngine;

public class ItemLaunch : MonoBehaviour
{
    GameObject gameMaster;

    float travelDuration = 1;


    private Transform player;

    /// The start position
    private Vector3 startPosition;

    /// The target position
    private Vector3 targetPosition;


    /// The coroutine
    private IEnumerator coroutine;


    void Start()
    {
        PlayerInventory.hasDispenserKit = true;
        gameMaster = GameObject.Find("Game Master");
        player = GameObject.FindWithTag("Player").transform;
        Launch(travelDuration, Vector3.Distance(player.position, transform.position) * .1f);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, 100 * Time.deltaTime);
    }


    public void Launch(float duration, float amplitude)
    {
        startPosition = transform.position;
        targetPosition = player.transform.position;

        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = Fly(duration, amplitude);
        StartCoroutine(coroutine);
    }

    
    private IEnumerator Fly(float duration, float amplitude)
    {
        if (duration > Mathf.Epsilon)
        {
            for (float progress = 0; progress < duration; progress += Time.deltaTime)
            {
                targetPosition = player.position;
                transform.position = Vector3.Lerp(startPosition, targetPosition, progress / duration) + Vector3.up * Mathf.Sin(progress / duration * Mathf.PI) * amplitude;
                yield return null;
            }
        }
        transform.position = targetPosition;
        Grabbed();
        coroutine = null;
    }

    void Grabbed()
    {
        PlayerInventory.Instance.AddToInventory("DispenserKit");
       
        Destroy(gameObject);
    }


    
}
