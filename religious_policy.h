//religious_policy.h
//宗教政策类

#include<string>

using namespace std;

#ifndef RELIGIOUS_POLICY_H
#define RELIGIOUS_POLICY_H

class religious_policy	//宗教政策
{
public:
	religious_policy ( string name );
	string get_name ();	//获得宗教政策名
private:
	string name;	//宗教政策名
};

#endif