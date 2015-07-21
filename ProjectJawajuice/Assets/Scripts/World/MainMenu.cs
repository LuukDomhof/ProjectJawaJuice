using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour{

	public Transform optionPos;
	public Transform mainPos;
	public Slider volumeSlider;
	public Slider SFXSlider;
	public float transitionDuration = 2f;
	public string levelToLoad;

	IEnumerator Transition(Transform target)
	{
		Quaternion newRot = Quaternion.Euler (target.eulerAngles);
		float t = 0f;
		Vector3 startingPos = transform.position;
		while (t < 1.0f)
		{
			t += Time.deltaTime * (Time.timeScale/transitionDuration);
			transform.position = Vector3.Lerp(startingPos, target.position, t);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRot, t/10);
			yield return 0;
		}
	}

	void Start()
	{
		AudioListener.volume = PlayerPrefs.GetFloat ("Volume");
		volumeSlider.value = AudioListener.volume;
		SFXSlider.value = PlayerPrefs.GetFloat ("SFXVolume");

	}

	public void Play()
	{
		Application.LoadLevel(levelToLoad);
	}

	public void Options()
	{
		StartCoroutine (Transition(optionPos));
	}

	public void Exit()
	{
		Application.Quit ();
	}

	public void VolumeControl(float volume)
	{
		AudioListener.volume = volume;
		PlayerPrefs.SetFloat ("Volume", volume);
	}

	public void SFXControl(float volume)
	{
		PlayerPrefs.SetFloat ("SFXVolume", volume);
	}

	public void Save()
	{
		PlayerPrefs.Save ();
	}

	public void backToMainMenu()
	{
		StartCoroutine (Transition(mainPos));
	}
}