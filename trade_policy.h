//trade_policy.h
//贸易政策类

#ifndef TRADE_POLICY_H
#define TRADE_POLICY_H

#include<string>

using namespace std;

class trade_policy
{
public:
	trade_policy ( string name , double max_tariff , double min_tariff );
	string get_name ();	//取得政策名
private:
	string name;	//政策名
	double max_tariff;	//最高关税
	double min_tariff;	//最低关税
};

#endif