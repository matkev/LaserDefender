using UnityEngine;
using System.Collections;

public class AlienSpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float speed = 1f;
    public float spawnDelay = 0.5f;

    public float padding = 0;

    private float xmin = -7.5f;
    private float xmax = 7.5f;

    private bool movingRight = true;

    // Use this for initialization
    void Start () {


        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        print(leftMost.x);
        print(rightMost.x);

        xmin = leftEdge.x;
        xmax = rightEdge.x;

        SpawnUntilFull();
	}
	

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

	// Update is called once per frame
	void Update () {

        
        if(movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        
        


        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);



        
        if (rightEdgeOfFormation > xmax )
        {
            print(rightEdgeOfFormation);
            movingRight = false;
        }
            
        else if (leftEdgeOfFormation < xmin)
        {
            print(leftEdgeOfFormation);
            movingRight = true;
        }
        

        if (AllMembersDead())
        {
            print("Empty formation");
            SpawnUntilFull();
        }

       
    }

    bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }

    void SpawnFormation()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;

        }
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
            GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePosition;

        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);

        }


    }
}
