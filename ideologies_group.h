//ideologies_group.h
//意识形态组类

#ifndef IDEOLOGIES_GROUP_H
#define IDEOLOGIES_GROUP_H

#include<string>
#include<vector>
#include"ideology.h"

using namespace std;

class ideologies_gruop
{
public:
	ideologies_gruop ( const string name );
	void load ( const string text );	//加载意识形态

	string get_name ();	//取得名字
	vector<ideology>& get_ideology_list ();	//取得意识形态列表
private:
	string name;	//名字
	vector<ideology> ideology_list;	//意识形态列表
};

#endif