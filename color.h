//color.h
//��ɫ��

#ifndef COLOR_H
#define COLOR_H

class color	//��ɫ
{
public:
	color ( short R , short G , short B );
	void set ( short R , short G , short B );	//������ɫ
private:
	short red;	//��
	short green;	//��
	short blue;	//��
};

#endif