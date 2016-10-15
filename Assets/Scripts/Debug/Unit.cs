using UnityEngine;
public class Unit {
	bool istest = true;

	public Unit(bool istest = true){
		this.istest = istest;
	}

	public void log(string value){
		Debug.Log (value);
	}

	public void stringCheck(string value,string resultstr,bool log = true){
		if (!log || !istest)
			return;
		bool result = (value == resultstr);
		Debug.Log (result + "結果:" + value + "想定:" + resultstr);
	}

	public void intCheck(int value , int resultint , bool log =true){
		if (!log || !istest)
			return;
		bool result = (value == resultint);
		Debug.Log (result + "結果:" + value + "想定:" + resultint);
	}

	public void floatCheck(float value , float resultfloat , bool log =true){
		if (!log || !istest)
			return;
		bool result = (value == resultfloat);
		Debug.Log (result + "結果:" + value + "想定:" + resultfloat);
	}
}
