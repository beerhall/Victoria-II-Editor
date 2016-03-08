//government.cpp
//政体

#include<iostream>
#include<fstream>
#include"government.h"
#include"ideologies_group.h"
#include"ideology.h"

using namespace std;

extern vector<ideologies_gruop> ideologies_gruop_vector;	//储存政体
extern ofstream governments_output;

extern bool is_in_government ( const string gov_name );	//判断政体是否存在
extern string bool_to_ok ( const bool flag );	//将bool类型转换成bool"yes","no"
extern string ft_to_str ( flagType ft );	//将flagType类型转换成字符串类型

government::government ( const string name )
{
	this->name = name;
}

void government::set_property ( const string id_name , bool ok )	//设置意识形态	
{
	bool id_exists = false;
	ideology* id = nullptr;
	int len = ideologies_gruop_vector.size ();
	int i2 = 0;
	for ( ideologies_gruop* i = &ideologies_gruop_vector [ 0 ]; i2 < len; i++ , i2++ )
	{
		int len2 = i->get_ideology_list ().size ();
		int j2 = 0;
		for ( ideology* j = &( i->get_ideology_list () [ 0 ] ); j2 < len2; j2++ , j++ )
		{
			if ( id_name == j->get_name () )
			{
				id_exists = true;
				id = j;
			}
		}
	}

	if ( id_exists )
	{
		this->properties.push_back ( pair<ideology* , bool> ( id , ok ) );
	}
	else
	{
		cerr << "“" << id_name << "”不存在！" << endl;
		return;
	}
}

void government::set_election ( bool ok )	//设置是否可以选举
{
	this->election = ok;
}

void government::set_duration ( short dur )	//设置选举间隔
{
	this->duration = dur;
}

void government::set_appoint_ruling_party ( bool ok )	//设置是否允许指定执政党
{
	this->appoint_ruling_party = ok;
}

void government::set_flag_type ( flagType flag_type )	//设置旗帜风格
{
	this->flag_type = flag_type;
}

string government::get_name ()	//获得名字
{
	return this->name;
}

short government::get_duration ()	//获得选举间隔
{
	return this->duration;
}

bool government::get_election ()	//获得是否允许选举
{
	return this->election;
}

bool government::get_appoint_ruling_party ()	//获得是否允许指定执政党
{
	return this->appoint_ruling_party;
}

flagType government::get_flag_type ()	//获得旗帜风格
{
	return flag_type;
}

vector<pair<ideology* , bool>> government::get_properties ()	//获得意识形态是否允许
{
	return properties;
}

void government::save ()	//保存到文件
{
	if ( !is_in_government ( this->get_name () ) )
	{
		governments_output << endl << endl << endl;
		governments_output << this->name << "  =" << endl;
		governments_output << "{" << endl;
		for ( auto &i : this->properties )
		{
			governments_output << "\t" << i.first->get_name () << " = " << bool_to_ok ( i.second ) << endl;
		}
		governments_output << endl;
		governments_output << "\telection = " << bool_to_ok ( this->get_election () ) << endl;
		if ( this->get_election () )
		{
			governments_output << "\tduration = " << this->get_duration () << endl;
		}
		governments_output << "\tappoint_ruling_party = " << bool_to_ok ( this->get_appoint_ruling_party () ) << endl;
		governments_output << "\tflagType = " << ft_to_str ( this->get_flag_type () ) << endl;
		governments_output << "}" << endl;
	}
	else
	{
		cerr << "“" << this->name << "”已经存在！" << endl;
		return;
	}
}