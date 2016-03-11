//war_policy.h
//战争政策类

#ifndef WAR_POLICY_H
#define WAR_POLICY_H

#include<string>

using namespace std;

class war_policy	//战争政策类
{
public:
	war_policy ( string name , double max_military_spending ,
				 double supply_consumption , double war_exhaustion_effect ,
				 bool is_jingoism , double cb_generation_speed_modifier ,
				 int mobilization_impact , double org_regain , double reinforce_speed );
	string get_name ();	//获取战争政策名
private:
	string name;	//战争政策类名
	double max_military_spending;	//最大国防预算
	double	supply_consumption;	//补给消耗
	double	war_exhaustion_effect;	//厌战影响
	bool	is_jingoism;	//是否为沙文主义
	double	cb_generation_speed_modifier;	//造战争借口的速度修正
	int mobilization_impact;	//动员影响
	double	org_regain;	//组织度恢复
	double	reinforce_speed;	//增援速度
};

#endif