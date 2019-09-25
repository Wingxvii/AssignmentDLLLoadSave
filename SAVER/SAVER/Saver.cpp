#include "Saver.h"

Saver* Saver::instanceVar = 0;

SAVER_H void SetupRecieve(void(*action)(float x, float y, float z)) {
	recieveData = action;
}

SAVER_H void RequestPosition() {
	Saver::instance()->RequestPosition();
}

SAVER_H void SavePosition(float x, float y, float z)
{
	Saver::instance()->SavePosition(x,y,z);
}


void Saver::RequestPosition()
{
	std::ifstream save;
	save.open("save.txt");
	string data;

	getline(save, data);

	vector<string> parsedData = tokenize(data);
	recieveData(std::stof(parsedData[0]), std::stof(parsedData[1]), std::stof(parsedData[2]));
	save.close();

}

void Saver::SavePosition(float x, float y, float z)
{
	std::ofstream save;
	save.open("save.txt");
	save.clear();
	save << to_string(x) << "," << to_string(y) << "," << to_string(z);
	save.close();

}

vector<string> Saver::tokenize(string text)
{
	char token = ',';
	std::vector<std::string> temp;
	int lastTokenLocation = 0;

	for (int i = 0; i < text.size(); i++) {
		if (text[i] == token) {
			temp.push_back(text.substr(lastTokenLocation, i - lastTokenLocation));
			lastTokenLocation = i + 1;

		}
	}
	return temp;
}
