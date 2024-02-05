using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(EnemyStats))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();

    [SerializeField] float enemySpeed = 1;

    PlayerStats playerStats;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(PathFollow());
    }

    void FindPath()
    {

        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            WayPoint waypoint = child.GetComponent<WayPoint>();

            if(waypoint != null)
            {
                path.Add(child.GetComponent<WayPoint>());
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        playerStats.DamageBase(1);
        gameObject.SetActive(false);
    }
    IEnumerator PathFollow()
    {
        foreach(WayPoint wayPoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y + 2.5f, wayPoint.transform.position.z);
            float travelPercent = 0f;

            transform.position = new Vector3 (wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * enemySpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}
