using UnityEngine;
using ArrayUtilities;
using System;
using System.Collections;

public class arrayTestsLite : MonoBehaviour {
	public int[] intArray;
	public int findIntIndex;
	public int intAverage;
	public int selectRandomInt;
	public int[] selectRandomStackInt;
	public int intMode;
	public int lowestInt;
	public int highestInt;
	public bool intArrayBool;
	public float[] floatArray;
	public float findFloatIndex;
	public float floatAverage;
	public float selectRandomFloat;
	public float[] selectRandomStackFloat;
	public float floatMode;
	public float lowestFloat;
	public float highestFloat;
	public bool floatArrayBool;
	public char[] charArray;
	public float findCharIndex;
	public char selectRandomChar;
	public char[] selectRandomStackChar;
	public char charMode;
	public char lowestChar;
	public char highestChar;
	public bool charArrayBool;
	public string[] charArrayReturn;
	public string[] stringArray;
	public float findStringIndex;
	public string stringMode;
	public string selectRandomString;
	public string[] selectRandomStackString;
	public string lowestString;
	public string highestString;
	public bool stringArrayBool;
	public bool[] boolArray;
	public float findBoolIndex;
	public float boolAverage;
	public bool selectRandomBool;
	public bool[] selectRandomStackBool;
	public int boolMode;
	public bool lowestBool;
	public bool highestBool;
	public bool boolArrayBool;
	public bool [][] boolArrayReturn;
	public string joinString;

	// Use this for initialization
	void Start () {
		//Int .Add works
		intArray = new int[]{1,2,3,4,2,5,5,2,7,8,9,10,11,12};
//		intArray = ArrayManip.Add(intArray,intArray);  																			//Adds Array1[0] to Array2[0] and so on
		
		//Float .Add works
		floatArray = new float[]{1.1f,2.2f,2.2f,3.3f,4.4f,5.5f};
//		floatArray = ArrayManip.Add(floatArray,floatArray);																		//Adds Array1[0] to Array2[0] and so on
		
		//Char .Add Works
		charArray = new char[]{'a','b','c','d','e','b'};
//		charArrayReturn = ArrayManip.Add(charArray,charArray);																	//Adds Array1[0] to Array2[0] and so on
		
		//String .Add Works
		stringArray = new string[]{"a","b","c","d","e","a"};
//		stringArray = ArrayManip.Add(stringArray,stringArray);																	//Adds Array1[0] to Array2[0] and so on
		
		//Bool  .Add Works
		boolArray = new bool[]{true,false,true,true,false};
//		boolArrayReturn = ArrayManip.Add(boolArray,boolArray);																	//Creates a 2D array in which the two bools sit side by side
//		for (int i = 0;i < boolArray.Length; i ++)
//		{
//			Debug.Log(boolArrayReturn[i][0] +","+boolArrayReturn[i][1] ); 														//This shows the 2D array as you cannot see it in the Editor
//		}
		// .Clear Works
//		intArray = ArrayManip.Clear(intArray);  																				//Clears the array and returns empty array of size 0
//		floatArray = ArrayManip.Clear(floatArray);																				//Clears the array and returns empty array of size 0
//		charArray = ArrayManip.Clear(charArray);																				//Clears the array and returns empty array of size 0
//		stringArray = ArrayManip.Clear(stringArray);																			//Clears the array and returns empty array of size 0
//		boolArray = ArrayManip.Clear(boolArray);																				//Clears the array and returns empty array of size 0
		
//		//Int .Concat works
//		intArray = new int[]{1,2,3,4,5};
//		intArray = ArrayManip.Concat(intArray,intArray);  																		//Appends second array to the end of first
//		
//		//Float .Concat works
//		floatArray = new float[]{1.1f,2.2f,3.3f,4.4f,5.5f};
//		floatArray = ArrayManip.Concat(floatArray,floatArray);																	//Appends second array to the end of first
//		
//		//Char .Concat Works
//		charArray = new char[]{'a','b','c','d','e'};
//		charArray = ArrayManip.Concat(charArray,charArray);																		//Appends second array to the end of first
//		
//		//String .Concat Works
//		stringArray = new string[]{"a","b","c","d","e"};
//		stringArray = ArrayManip.Concat(stringArray,stringArray);																//Appends second array to the end of first
//		
//		//Bool  .Concat Works
//		boolArray = new bool[]{true,false,true,true};
//		boolArray = ArrayManip.Concat(boolArray,boolArray);																		//Appends second array to the end of first
		
		//.Join Works
//		joinString = ArrayManip.Join(intArray);  																				//Joins the contents of an array into one string
//		joinString = ArrayManip.Join(floatArray);																				//Joins the contents of an array into one string
//		joinString = ArrayManip.Join(charArray);																				//Joins the contents of an array into one string
//		joinString = ArrayManip.Join(stringArray);																				//Joins the contents of an array into one string
//		joinString = ArrayManip.Join(boolArray);																				//Joins the contents of an array into one string
		
		//Pop Works
//		intArray = ArrayManip.Pop(intArray);																					//Removes the last element of the array and returns new array
//		floatArray = ArrayManip.Pop(floatArray);																				//Removes the last element of the array and returns new array
//		charArray = ArrayManip.Pop(charArray);																					//Removes the last element of the array and returns new array
//		stringArray = ArrayManip.Pop(stringArray);																				//Removes the last element of the array and returns new array
//		boolArray = ArrayManip.Pop(boolArray);																					//Removes the last element of the array and returns new array
		
		//Push Works
//		intArray = ArrayManip.Push(intArray,1);  																				//Adds value to the end of the array
//		floatArray = ArrayManip.Push(floatArray,1.1f); 																			//Adds value to the end of the array
//		charArray = ArrayManip.Push(charArray,'f'); 																			//Adds value to the end of the array
//		stringArray = ArrayManip.Push(stringArray,"f"); 																		//Adds value to the end of the array
//		boolArray = ArrayManip.Push(boolArray,false); 																			//Adds value to the end of the array
		
		//RemoveAt Works
//		intArray = ArrayManip.RemoveAt(intArray, 1);  																			//Removes Value at given position and returns new array
//		floatArray = ArrayManip.RemoveAt(floatArray, 2);																		//Removes Value at given position and returns new array
//		charArray = ArrayManip.RemoveAt(charArray, 3);																			//Removes Value at given position and returns new array
//		stringArray = ArrayManip.RemoveAt(stringArray, 4);																		//Removes Value at given position and returns new array
//		boolArray = ArrayManip.RemoveAt(boolArray, 0);																			//Removes Value at given position and returns new array
		
		//Sort
//		intArray = new int[]{4,10,6,7,3};  
//		intArray = ArrayManip.Sort(intArray);  																					//Sorts the array from smallest to largest
//		floatArray = new float[]{4.4f,10.1f,6.2f,7.3f,3.4f};
//		floatArray = ArrayManip.Sort(floatArray);																				//Sorts the array from smallest to largest
//		charArray = new char[]{'d','e','a','w','q'};
//		charArray = ArrayManip.Sort(charArray);  																				//Sorts alphabetically
		//Based on length of the word
//		stringArray = new string[]{"one","five","seven","two","eight"};  
//		stringArray = ArrayManip.Sort(stringArray);  																			//Sorts based on Length of the string
//		stringArray = ArrayManip.Sort(stringArray,true);  																		//Sorts Alphabetically
//		boolArray = new bool[]{true,false,false,true,false};
//		boolArray = ArrayManip.Sort(boolArray);  																				//Sorts the array false first then true
		
		//Reverse Works
//		intArray = ArrayManip.Reverse(intArray);  																				//Reverses all positions in array
//		floatArray = ArrayManip.Reverse(floatArray);																			//Reverses all positions in array
//		charArray = ArrayManip.Reverse(charArray);																				//Reverses all positions in array
//		stringArray = ArrayManip.Reverse(stringArray);																			//Reverses all positions in array
//		boolArray = ArrayManip.Reverse(boolArray);																				//Reverses all positions in array
		
		//Shift Works
//		intArray = ArrayManip.Shift(intArray,0);  																				//Adds given value to beginning of array
//		floatArray = ArrayManip.Shift(floatArray,0.1f);																			//Adds given value to beginning of array
//		charArray = ArrayManip.Shift(charArray, 'z');																			//Adds given value to beginning of array
//		stringArray = ArrayManip.Shift(stringArray, "insert");																	//Adds given value to beginning of array
//		boolArray = ArrayManip.Shift(boolArray, true);																			//Adds given value to beginning of array
		
		//InsertAt Works
//		intArray = ArrayManip.InsertAt(intArray,3,3); 																			//Adds given value at given position in array
//		floatArray = ArrayManip.InsertAt(floatArray,0.1f,3);																	//Adds given value at given position in array
//		charArray = ArrayManip.InsertAt(charArray, 'z',3);																		//Adds given value at given position in array
//		stringArray = ArrayManip.InsertAt(stringArray, "insert",4);																//Adds given value at given position in array
//		boolArray = ArrayManip.InsertAt(boolArray, true,3);																		//Adds given value at given position in array
		
		//Lowest Works
//		lowestInt = ArrayManip.Lowest(intArray);  																				//Returns the lowest value of array
//		lowestFloat = ArrayManip.Lowest(floatArray);																			//Returns the lowest value of array
//		lowestChar = ArrayManip.Lowest(charArray);																				//Returns the lowest value of array
//		lowestString = ArrayManip.Lowest(stringArray);																			//Returns the lowest value of array
//		lowestBool = ArrayManip.Lowest(boolArray);																				//Returns the lowest value of array
		
		//Highest Works
//		highestInt = ArrayManip.Highest(intArray); 																				//Returns the highest value of array
//		highestFloat = ArrayManip.Highest(floatArray);																			//Returns the highest value of array
//		highestChar = ArrayManip.Highest(charArray);																			//Returns the highest value of array
//		highestString = ArrayManip.Highest(stringArray);																		//Returns the highest value of array
//		highestBool = ArrayManip.Highest(boolArray);																			//Returns the highest value of array
		
/****************************************Pro Version Only**********************************************/
//		Shuffle Works
//		intArray = ArrayManip.Shuffle(intArray);  																				//Randomly shuffles all elements in the array
//		floatArray = ArrayManip.Shuffle(floatArray); 																			//Randomly shuffles all elements in the array
//		charArray = ArrayManip.Shuffle(charArray); 																				//Randomly shuffles all elements in the array
//		stringArray = ArrayManip.Shuffle(stringArray); 																			//Randomly shuffles all elements in the array
//		boolArray = ArrayManip.Shuffle(boolArray); 																				//Randomly shuffles all elements in the array
		
		//AreEqual Works
//		int[] testInt = new int[]{1,2,3,4};
//		intArrayBool = ArrayManip.AreEqual(intArray,testInt);  																	//Compares two given arrays and returns a bool
//		float[] testFloat = new float[]{1.1f,2.2f,3.3f,4.4f};
//		floatArrayBool = ArrayManip.AreEqual(floatArray,testFloat); 															//Compares two given arrays and returns a bool
//		char[] testChar = new char[]{'a','b','c','d','e'};
//		charArrayBool = ArrayManip.AreEqual(charArray,testChar);  																//Compares two given arrays and returns a bool
//		string[] testString = new string[]{"one","two","three","four"};
//		stringArrayBool = ArrayManip.AreEqual(stringArray,testString); 															//Compares two given arrays and returns a bool
//		bool[] testBool = new bool[]{true,false,true,false};
//		boolArrayBool = ArrayManip.AreEqual(boolArray,testBool); 																//Compares two given arrays and returns a bool
		
		//ShiftStack Works
//		int[] testInt = new int[]{11,12,13,14};
//		intArray = ArrayManip.ShiftStack(intArray,testInt); 																	//Inserts an array at beginning of an array
//		float[] testFloat = new float[]{1.1f,2.2f,3.3f,4.4f};
//		floatArray = ArrayManip.ShiftStack(floatArray,testFloat);																//Inserts an array at beginning of an array
//		char[] testChar = new char[]{'a','b','c','d','e'};
//		charArray = ArrayManip.ShiftStack(charArray,testChar);																	//Inserts an array at beginning of an array
//		string[] testString = new string[]{"one","two","three","four"};
//		stringArray = ArrayManip.ShiftStack(stringArray,testString);															//Inserts an array at beginning of an array
//		bool[] testBool = new bool[]{true,false,true,false};
//		boolArray = ArrayManip.ShiftStack(boolArray,testBool);																	//Inserts an array at beginning of an array
		
		//InsertStackAt Works
//		intArray = ArrayManip.InsertStackAt(intArray,intArray,3);  																//Inserts an array at given position of an array
//		floatArray = ArrayManip.InsertStackAt(floatArray,floatArray,3); 														//Inserts an array at given position of an array
//		charArray = ArrayManip.InsertStackAt(charArray,charArray,3); 															//Inserts an array at given position of an array
//		stringArray = ArrayManip.InsertStackAt(stringArray,stringArray,3); 														//Inserts an array at given position of an array
//		boolArray = ArrayManip.InsertStackAt(boolArray,boolArray,3); 															//Inserts an array at given position of an array
		
		//Find Works  //Returns -1 if it does not find what you're looking for
//		findIntIndex = ArrayManip.Find(intArray,4);  																			//Finds a given value in an array
//		findFloatIndex = ArrayManip.Find(floatArray,4.4f); 																		//Finds a given value in an array
//		findCharIndex = ArrayManip.Find(charArray,'w'); 																		//Finds a given value in an array
//		findStringIndex = ArrayManip.Find(stringArray,"d"); 																	//Finds a given value in an array
//		findBoolIndex = ArrayManip.Find(boolArray,false); 																		//Finds a given value in an array
		
		//Average Works
//		intAverage = ArrayManip.Average(intArray);   																			//Finds the average value of all elements in an array
//		floatAverage = ArrayManip.Average(floatArray); 																			//Finds the average value of all elements in an array
//		boolAverage = ArrayManip.Average(boolArray); 																			//Finds the average value of all elements in an array (1 is considered true, 0 is false, returns a float)
		
		//Mode Works
//		intMode = ArrayManip.Mode(intArray);  																					//Returns the most common value in an array
//		floatMode = ArrayManip.Mode(floatArray); 																				//Returns the most common value in an array
//		charMode = ArrayManip.Mode(charArray); 																					//Returns the most common value in an array
//		stringMode = ArrayManip.Mode(stringArray); 																				//Returns the most common value in an array
//		boolMode = ArrayManip.Mode(boolArray); 																					//Returns the most common value in an array
		
		//PopStack Works
//		intArray = ArrayManip.PopStack(intArray,5); 																			//Removes a given amount off the end of an array
//		floatArray = ArrayManip.PopStack(floatArray,4); 																		//Removes a given amount off the end of an array
//		charArray = ArrayManip.PopStack(charArray,3); 																			//Removes a given amount off the end of an array
//		stringArray = ArrayManip.PopStack(stringArray, 5); 																		//Removes a given amount off the end of an array
//		boolArray = ArrayManip.PopStack(boolArray,3); 																			//Removes a given amount off the end of an array

		//PushStack Works
//		intArray = ArrayManip.PushStack(intArray, intArray);  																	//Add an array at end of an array
//		floatArray = ArrayManip.PushStack(floatArray,floatArray);  																//Add an array at end of an array
//		charArray = ArrayManip.PushStack(charArray,charArray);  																//Add an array at end of an array
//		stringArray = ArrayManip.PushStack(stringArray, stringArray); 															//Add an array at end of an array
//		boolArray = ArrayManip.PushStack(boolArray,boolArray);  																//Add an array at end of an array
		
		//Select Random Works
//		selectRandomInt = ArrayManip.SelectRandom(intArray);  																	//Randomly return a selected value from array
//		selectRandomFloat = ArrayManip.SelectRandom(floatArray); 																//Randomly return a selected value from array
//		selectRandomChar = ArrayManip.SelectRandom(charArray); 																	//Randomly return a selected value from array
//		selectRandomString = ArrayManip.SelectRandom(stringArray); 																//Randomly return a selected value from array
//		selectRandomBool = ArrayManip.SelectRandom(boolArray); 																	//Randomly return a selected value from array
		
		//Select Random Range Works
//		selectRandomInt = ArrayManip.SelectRandomRange(intArray, 1, 3); 														//Randomly return a selected value from selected range of an array
//		selectRandomFloat = ArrayManip.SelectRandomRange(floatArray, 2, 4);														//Randomly return a selected value from selected range of an array
//		selectRandomChar = ArrayManip.SelectRandomRange(charArray, 1,2);														//Randomly return a selected value from selected range of an array
//		selectRandomString = ArrayManip.SelectRandomRange(stringArray, 3, 5);													//Randomly return a selected value from selected range of an array
//		selectRandomBool = ArrayManip.SelectRandomRange(boolArray, 2,5);														//Randomly return a selected value from selected range of an array
		
//		//Select Random Stack Works
//		selectRandomStackInt = ArrayManip.SelectStackRandom(intArray);  														//Randomly return an array from selected array
//		selectRandomStackFloat = ArrayManip.SelectStackRandom(floatArray);														//Randomly return an array from selected array
//		selectRandomStackChar = ArrayManip.SelectStackRandom(charArray);														//Randomly return an array from selected array
//		selectRandomStackString = ArrayManip.SelectStackRandom(stringArray);													//Randomly return an array from selected array
//		selectRandomStackBool = ArrayManip.SelectStackRandom(boolArray);														//Randomly return an array from selected array
		
		//Select Random Stack Range Works
//		selectRandomStackInt = ArrayManip.SelectStackRandomRange(intArray, 1, 3);												//Randomly return an array from selected range of an array
//		selectRandomStackFloat = ArrayManip.SelectStackRandomRange(floatArray, 2, 4);											//Randomly return an array from selected range of an array
//		selectRandomStackChar = ArrayManip.SelectStackRandomRange(charArray, 1,2);												//Randomly return an array from selected range of an array
//		selectRandomStackString = ArrayManip.SelectStackRandomRange(stringArray, 3, 5);											//Randomly return an array from selected range of an array
//		selectRandomStackBool = ArrayManip.SelectStackRandomRange(boolArray, 2,5);												//Randomly return an array from selected range of an array
		
	}
}
