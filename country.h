//country.h
//国家类

#ifndef COUNTRY_H
#define COUNTRY_H

#include<string>
#include"color.h"

using namespace std;

class country
{
public:
	country ( const string name , const string full_name , bool dynamic );
	string get_name ();	//获得国家名
	string get_full_name ();	//获得路径
	bool is_dynamic ();	//获得是否是动态国家
	void set_color_coats ( int r , int g , int b );	//设置衣服颜色
	void set_color_trousers ( int r , int g , int b );	//设置裤子颜色
	void set_color_hats ( int r , int g , int b );	//设置帽子颜色
	bool is_color_seted ();	//获得是否设置了颜色
	color get_coats_color ();	//获得衣服颜色
	color get_trousers_color ();	//获得裤子颜色
	color get_hats_color ();	//获得帽子颜色
private:
	string name;	//国家名
	string full_name;	//路径
	bool dynamic;	//是否是动态国家
	color coats;	//衣服颜色
	color trousers;	//裤子颜色
	color hats;	//帽子颜色
	bool color_seted = false;
};

#endif