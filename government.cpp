//government.cpp
//����

#include<iostream>
#include<fstream>
#include"government.h"
#include"ideologies_group.h"
#include"ideology.h"

using namespace std;

extern vector<ideologies_gruop> ideologies_gruop_vector;	//��������
extern ofstream governments_output;

extern bool is_in_government ( const string gov_name );	//�ж������Ƿ����
extern string bool_to_ok ( const bool flag );	//��bool����ת����bool"yes","no"
extern string ft_to_str ( flagType ft );	//��flagType����ת�����ַ�������

government::government ( const string name )
{
	this->name = name;
}

void government::set_property ( const string id_name , bool ok )	//������ʶ��̬	
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
		cerr << "��" << id_name << "�������ڣ�" << endl;
		return;
	}
}

void government::set_election ( bool ok )	//�����Ƿ����ѡ��
{
	this->election = ok;
}

void government::set_duration ( short dur )	//����ѡ�ټ��
{
	this->duration = dur;
}

void government::set_appoint_ruling_party ( bool ok )	//�����Ƿ�����ָ��ִ����
{
	this->appoint_ruling_party = ok;
}

void government::set_flag_type ( flagType flag_type )	//�������ķ��
{
	this->flag_type = flag_type;
}

string government::get_name ()	//�������
{
	return this->name;
}

short government::get_duration ()	//���ѡ�ټ��
{
	return this->duration;
}

bool government::get_election ()	//����Ƿ�����ѡ��
{
	return this->election;
}

bool government::get_appoint_ruling_party ()	//����Ƿ�����ָ��ִ����
{
	return this->appoint_ruling_party;
}

flagType government::get_flag_type ()	//������ķ��
{
	return flag_type;
}

vector<pair<ideology* , bool>> government::get_properties ()	//�����ʶ��̬�Ƿ�����
{
	return properties;
}

void government::save ()	//���浽�ļ�
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
		cerr << "��" << this->name << "���Ѿ����ڣ�" << endl;
		return;
	}
}