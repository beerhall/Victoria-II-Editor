//country.h
//������

#ifndef COUNTRY_H
#define COUNTRY_H

#include<string>
#include"color.h"

using namespace std;

class country
{
public:
	country ( const string name , const string full_name , bool dynamic );
	string get_name ();	//��ù�����
	string get_full_name ();	//���·��
	bool is_dynamic ();	//����Ƿ��Ƕ�̬����
	void set_color_coats ( int r , int g , int b );	//�����·���ɫ
	void set_color_trousers ( int r , int g , int b );	//���ÿ�����ɫ
	void set_color_hats ( int r , int g , int b );	//����ñ����ɫ
	bool is_color_seted ();	//����Ƿ���������ɫ
	color get_coats_color ();	//����·���ɫ
	color get_trousers_color ();	//��ÿ�����ɫ
	color get_hats_color ();	//���ñ����ɫ
private:
	string name;	//������
	string full_name;	//·��
	bool dynamic;	//�Ƿ��Ƕ�̬����
	color coats;	//�·���ɫ
	color trousers;	//������ɫ
	color hats;	//ñ����ɫ
	bool color_seted = false;
};

#endif