//ideologies_group.cpp
//��ʶ��̬��

#include<sstream>
#include"ideologies_group.h"

ideologies_gruop::ideologies_gruop ( const string name )
{
	this->name = name;
}

void ideologies_gruop::load ( const string text )	//����
{
	istringstream istr ( text );
	string str;
	unsigned brace = 0;
	while ( istr >> str )
	{
		if ( str [ 0 ] == '#' || str [ 0 ] == '=' )	//����ע�ͺ͵Ⱥ�
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

string ideologies_gruop::get_name ()	//�������
{
	return this->name;
}

vector<ideology>& ideologies_gruop::get_ideology_list ()	//ȡ����ʶ��̬�б�
{
	return this->ideology_list;
}