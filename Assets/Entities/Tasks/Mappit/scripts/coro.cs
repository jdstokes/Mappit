using UnityEngine;
using System.Collections;

public class coro : MonoBehaviour {
	
		private bool _keyPressed = false;
		// Use this for initialization
		void Awake ()
		{
			//This is where it all begins.
			print("waking up...");
		}
		void Start ()
		{
			print("starting...");
			FirstFunction();
		}
		void FirstFunction()
		{
			//by default in our settings this is the space bar, so we will use this just to make it simple.
			StartCoroutine(WaitForKeyPress("Jump"));
			//to demonstrate that coroutines can work in parallel, we will make it do something right after the coroutine is told to begin.
			print("Coroutine did begin.");
		}
		/*
A little knowledge here for people who are saying "wtf is an IEnumerator?"
If you check this msdn docs on this interface you will see in this case it is used to read through enumeration data. This line is in the ref docs: "Enumerators can be used to read the data in the collection, but they cannot be used to modify the underlying collection." So basically every frame we're stepping through another index of an enumeration. We don't really need to know more, how or why in this case because Unity is going to handle all of this for us. All we need to know is how to set it up...
*/
		
		public IEnumerator WaitForKeyPress(string _button)
		{
			while(!_keyPressed)
			{
				if(Input.GetButtonDown (_button))
				{
					StartGame();
					break;
				}
				print("Awaiting key input.");
				yield return 0;
			}
		}
		private void StartGame()
		{
			_keyPressed = true;
			print("Starting the game officially!");
		}
	}
