//color.h
//��ɫ

#include"color.h"

color::color ( short R , short G , short B )
{
	this->red = R;	//��
	this->green = G;	//��
	this->blue = B;	//��
}

void color::set ( short R , short G , short B )
{
	this->red = R;	//��
	this->green = G;	//��
	this->blue = B;	//��
}

short color::get_red ()	//��ú�ɫ
{
	return red;
}
short color::get_green ()	//�����ɫ
{
	return green;
}
short color::get_blue ()//�����ɫ
{
	return blue;
}