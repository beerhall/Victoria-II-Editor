//country.cpp
//����

#include"country.h"

country::country ( const string name , const string full_name , bool dynamic )
{
	this->name = name;
	this->full_name = full_name;
	this->dynamic = dynamic;
}

string country::get_name ()	//��ù�����
{
	return name;
}

string country::get_full_name ()	//���·��
{
	return full_name;
}

bool country::is_dynamic ()	//����Ƿ��Ƕ�̬����
{
	return dynamic;
}

void country::set_color_coats ( int r , int g , int b )	//�����·���ɫ
{
	this->coats.set ( r , g , b );
	this->color_seted = true;
}

void country::set_color_trousers ( int r , int g , int b )	//���ÿ�����ɫ
{
	this->trousers.set ( r , g , b );
	this->color_seted = true;
}

void country::set_color_hats ( int r , int g , int b )	//����ñ����ɫ
{
	this->hats.set ( r , g , b );
	this->color_seted = true;
}

bool country::is_color_seted ()
{
	return this->color_seted;
}

color country::get_coats_color ()	//����·���ɫ
{
	return this->coats;
}
color country::get_trousers_color ()	//��ÿ�����ɫ
{
	return this->trousers;
}
color country::get_hats_color ()	//���ñ����ɫ
{
	return this->hats;
}