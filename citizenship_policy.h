//citizenship_policy.h
//公民权政策类

#ifndef CITIZENSHIP_POLICY_H
#define CITIZENSHIP_POLICY_H

#include<string>

using namespace std;

enum citizenship_policy_rule	//公民权规则
{
	primary_culture_voting ,	//居留权
	culture_voting ,	//有限公民权
	all_voting	//完整公民权
};

class citizenship_policy	//公民权政策
{
public:
	citizenship_policy ( string name , double global_assimilation_rate , string citizenship_policy_rule );
	string get_name ();	//取得公民权政策名
private:
	string name;	//公民权政策名
	double global_assimilation_rate;	//同化率
	citizenship_policy_rule rules;
};

#endif