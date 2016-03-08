//ideology.cpp
//意识形态

#include"ideology.h"

ideology::ideology ( const string name )
{
	this->name = name;
}

string ideology::get_name ()	//获得名字
{
	return this->name;
}