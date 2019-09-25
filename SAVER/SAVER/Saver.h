#pragma once
#include <fstream>
#include <vector>
#include <string>

#define SAVER_H _declspec(dllexport)

using namespace std;

class SAVER_H Saver {
private:
	static Saver *instanceVar;

	Saver() {
	
	};

	vector<string> tokenize(string text);

public:

	static Saver *instance() {
		if (!instanceVar) {
			instanceVar = new Saver();
		}
		return instanceVar;
	}

	void RequestPosition();
	void SavePosition(float x, float y, float z);

};


extern "C" {
	void (*recieveData)(float x, float y, float z);

	SAVER_H void SetupRecieve(void(*action)(float x, float y, float z));
	SAVER_H void RequestPosition();
	SAVER_H void SavePosition(float x, float y, float z);
}

