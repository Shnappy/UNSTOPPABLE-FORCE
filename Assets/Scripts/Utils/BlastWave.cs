using System.Collections;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    //TODO figure out why the this script has to be attached as a component
    private static BlastWave _blastWave;
    void Awake()
    {
        _blastWave = this;
    }
    public static void handleBlastwave(GameObject blastwave, int blastwaveSize)
    {
        _blastWave.StartCoroutine(handleBlastwaveCaroutine(blastwave, blastwaveSize));
    }
    static IEnumerator handleBlastwaveCaroutine(GameObject blastwave, int blastwaveSize)
    {
        int counter = 0;
        while (counter < blastwaveSize)
        {
            blastwave.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);;
            yield return new WaitForSeconds(.01f);
            counter++;
        }
        Destroy(blastwave);
    }
}
