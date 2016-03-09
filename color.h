//color.h
//颜色类

#ifndef COLOR_H
#define COLOR_H

class color	//颜色
{
public:
	color () = default;
	color ( short R , short G , short B );
	void set ( short R , short G , short B );	//设置颜色
	short get_red ();	//获得红色
	short get_green ();	//获得绿色
	short get_blue ();	//获得蓝色
private:
	short red;	//红
	short green;	//绿
	short blue;	//蓝
};

#endif