using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class CameraController : MonoBehaviour
{
    protected Transform Target;

    protected Transform tfContainer;

    public float T = 0f;

    private void Awake()
    {
        tfContainer = GetComponent<Transform>();

        var player = SceneManager.GetActiveScene().GetRootGameObjects()
            .Where(g => g.name.Contains("Player")).First();
        Target = player.GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        //tfContainer.position = Vector3.Lerp(tfContainer.position, Target.position, T * Time.deltaTime) ;
        tfContainer.position = Target.position;
    }
}
