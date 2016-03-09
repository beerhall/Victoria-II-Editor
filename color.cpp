//color.h
//颜色

#include"color.h"

color::color ( short R , short G , short B )
{
	this->red = R;	//红
	this->green = G;	//绿
	this->blue = B;	//蓝
}

void color::set ( short R , short G , short B )
{
	this->red = R;	//红
	this->green = G;	//绿
	this->blue = B;	//蓝
}

short color::get_red ()	//获得红色
{
	return red;
}
short color::get_green ()	//获得绿色
{
	return green;
}
short color::get_blue ()//获得蓝色
{
	return blue;
}