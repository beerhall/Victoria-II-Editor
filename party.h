//party.h
//政党类

#ifndef PARTY_H
#define PARTY_H

#include<string>
#include"date.h"
#include"ideology.h"
#include"economic_policy.h"
#include"trade_policy.h"
#include"religious_policy.h"
#include"citizenship_policy.h"
#include"war_policy.h"

using namespace std;

class party	//政党类
{
public:
	party ( string name , date start_date , date end_date ,
			string ideo , string economic , string trade , string religious ,
			string citizenship , string war_policy );
	string get_name ();	//取得政党名
private:
	string name;	//政党名
	date start_date;	//建立时间
	date end_date;	//解散时间
	ideology* ideo;	//意识形态
	economic_policy* economic;	//经济政策
	trade_policy* trade;	//贸易政策
	religious_policy* religious;	//宗教政策
	citizenship_policy* citizenship;	//公民权政策
	war_policy* war;	//战争政策
};

#endif