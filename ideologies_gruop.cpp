//ideologies_group.cpp
//意识形态组

#include<sstream>
#include"ideologies_group.h"

ideologies_gruop::ideologies_gruop ( const string name )
{
	this->name = name;
}

void ideologies_gruop::load ( const string text )	//加载
{
	istringstream istr ( text );
	string str;
	unsigned brace = 0;
	while ( istr >> str )
	{
		if ( str [ 0 ] == '#' || str [ 0 ] == '=' )	//跳过注释和等号
		{
			continue;
		}
		else if ( str [ 0 ] == '{' )
		{
			brace++;
		}
		else if ( str [ 0 ] == '}' )
		{
			brace--;
		}
		else if ( brace == 0 )
		{
			this->ideology_list.push_back ( ideology ( str ) );
		}
	}
}

string ideologies_gruop::get_name ()	//获得名字
{
	return this->name;
}

vector<ideology>& ideologies_gruop::get_ideology_list ()	//取得意识形态列表
{
	return this->ideology_list;
}