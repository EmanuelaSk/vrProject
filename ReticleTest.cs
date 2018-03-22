using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleTest : MonoBehaviour {

    public int scoreIncrease = 10;

    public void Teleport()
    {
        gameObject.transform.position = new Vector3(GetRandomCoordinate(), Random.Range(0.5f, 2), GetRandomCoordinate());
    }

    private float GetRandomCoordinate()
    {
        var coordinate = Random.Range(-7, 7);
        while (coordinate > -1.5 && coordinate <1.5)
        {
            coordinate = Random.Range(-5, 5);
        }
        return coordinate;
    }

    public void Collect()
    {
        PlayerUIScript.Score += scoreIncrease;
        Destroy(gameObject, 0.1f);
    }
}
