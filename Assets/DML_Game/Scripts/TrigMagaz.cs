using UnityEngine;

public class TrigMagaz : MonoBehaviour {

	public GameObject panel;
	
	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			panel.SetActive (true);
			Time.timeScale = 0f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
	
	public void OnTriggerExit()
	{
		panel.SetActive (false);
		Time.timeScale = 1f;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}