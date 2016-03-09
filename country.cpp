//country.cpp
//国家

#include"country.h"

country::country ( const string name , const string full_name , bool dynamic )
{
	this->name = name;
	this->full_name = full_name;
	this->dynamic = dynamic;
}

string country::get_name ()	//获得国家名
{
	return name;
}

string country::get_full_name ()	//获得路径
{
	return full_name;
}

bool country::is_dynamic ()	//获得是否是动态国家
{
	return dynamic;
}

void country::set_color_coats ( int r , int g , int b )	//设置衣服颜色
{
	this->coats.set ( r , g , b );
	this->color_seted = true;
}

void country::set_color_trousers ( int r , int g , int b )	//设置裤子颜色
{
	this->trousers.set ( r , g , b );
	this->color_seted = true;
}

void country::set_color_hats ( int r , int g , int b )	//设置帽子颜色
{
	this->hats.set ( r , g , b );
	this->color_seted = true;
}

bool country::is_color_seted ()
{
	return this->color_seted;
}

color country::get_coats_color ()	//获得衣服颜色
{
	return this->coats;
}
color country::get_trousers_color ()	//获得裤子颜色
{
	return this->trousers;
}
color country::get_hats_color ()	//获得帽子颜色
{
	return this->hats;
}