using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    #region making singleton
    public static PointsManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public Text awardedPoints;
    public GameObject gun;

    public Canvas canvas;
    private Animator awardedPointsAnim;


    int player1PastPoints = 0;
    int player1FuturePoints;
    public static int player1CurrentPoints;


    // 10 points on hit is in the "gun" script


    public Text player1Points;


    #region AwardPoints

    private IEnumerator currentProcess;
    private WaitForSeconds cachedDelay;


    public void StartCoroutine()
    {
        if (currentProcess != null)
        {
            StopCoroutine(currentProcess);
        }
        currentProcess = Process();
        StartCoroutine(currentProcess);
    }

    private void StopCoroutine()
    {
        if (currentProcess != null)
        {
            StopCoroutine(currentProcess);
            currentProcess = null;
        }
    }

    private IEnumerator Process()
    {

        if (true)
        {

            if (gun.GetComponent<gun>().hit.collider.transform.root.tag.Contains("Enemy"))
            {
                yield return cachedDelay;
                if (gun.GetComponent<gun>().hit.collider.transform.root.tag == ("Untagged"))
                {
                    StartCoroutine(AddPoints(60));
                }
                else
                {
                    StartCoroutine(AddPoints(10));
                }
            }
            yield return null;
        }
    }

    #endregion








    void Start()
    {
        player1Points.text = player1CurrentPoints.ToString();
        player1CurrentPoints = 0;
        cachedDelay = new WaitForSeconds(0.1f);

    }

    
    
    public IEnumerator AddPoints(int pointsToAdd)
    {

        player1PastPoints = player1FuturePoints;
        player1FuturePoints = player1FuturePoints + pointsToAdd;


        Text newAwardedPoints = Instantiate(awardedPoints) as Text;
        newAwardedPoints.text = PointDifferencePastAndFuture().ToString();
        newAwardedPoints.transform.SetParent(canvas.transform, false);

        yield return new WaitForSeconds(1.7f);
        player1CurrentPoints = player1CurrentPoints + pointsToAdd;
        UpdatePointsNow();




    }

   public void UpdatePointsNow()
    {
        player1Points.text = player1CurrentPoints.ToString();
    }


    int PointDifferencePastAndFuture()
    {
        return player1FuturePoints - player1PastPoints;
    }



}
