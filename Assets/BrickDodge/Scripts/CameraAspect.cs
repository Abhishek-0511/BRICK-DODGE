using UnityEngine;

public class CameraAspect : MonoBehaviour 
{
	void Start () 
	{
		Camera.main.aspect = 16/10f;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1;
	}
}