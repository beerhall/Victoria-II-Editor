//trade_policy.h
//ó��������

#ifndef TRADE_POLICY_H
#define TRADE_POLICY_H

#include<string>

using namespace std;

class trade_policy
{
public:
	trade_policy ( string name , double max_tariff , double min_tariff );
	string get_name ();	//ȡ��������
private:
	string name;	//������
	double max_tariff;	//��߹�˰
	double min_tariff;	//��͹�˰
};

#endif