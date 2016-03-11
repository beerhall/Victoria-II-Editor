//date.h
//日期类

#ifndef DATE_H
#define DATE_H

class date	//日期类
{
public:
	date () = default;
	date ( unsigned year , unsigned month , unsigned day );
private:
	unsigned year;	//年
	unsigned month;	//月
	unsigned day;	//日
};

#endif