//color.h
//��ɫ��

#ifndef COLOR_H
#define COLOR_H

class color	//��ɫ
{
public:
	color () = default;
	color ( short R , short G , short B );
	void set ( short R , short G , short B );	//������ɫ
	short get_red ();	//��ú�ɫ
	short get_green ();	//�����ɫ
	short get_blue ();	//�����ɫ
private:
	short red;	//��
	short green;	//��
	short blue;	//��
};

#endif