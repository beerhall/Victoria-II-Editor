//ideology.cpp
//��ʶ��̬

#include"ideology.h"

ideology::ideology ( const string name )
{
	this->name = name;
}

string ideology::get_name ()	//�������
{
	return this->name;
}