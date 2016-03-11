//religious_policy.cpp
//宗教政策

#include"religious_policy.h"

religious_policy::religious_policy ( string name )
{
	this->name = name;
}

string religious_policy::get_name ()	//获得宗教政策名
{
	return name;
}