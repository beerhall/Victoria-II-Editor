//ideologies_group.h
//��ʶ��̬����

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
	void load ( const string text );	//������ʶ��̬

	string get_name ();	//ȡ������
	vector<ideology>& get_ideology_list ();	//ȡ����ʶ��̬�б�
private:
	string name;	//����
	vector<ideology> ideology_list;	//��ʶ��̬�б�
};

#endif