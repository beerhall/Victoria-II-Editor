//date.h
//������

#ifndef DATE_H
#define DATE_H

class date	//������
{
public:
	date () = default;
	date ( unsigned year , unsigned month , unsigned day );
private:
	unsigned year;	//��
	unsigned month;	//��
	unsigned day;	//��
};

#endif