//ideology.h
//意识形态类

#ifndef IDEOLOGY_H
#define IDEOLOGY_H

#include<string>

using namespace std;

class ideology
{
public:
	ideology ( const string name );

	string get_name ();
private:
	string name;	//名字
};

#endif