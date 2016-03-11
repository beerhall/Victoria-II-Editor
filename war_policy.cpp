//war_policy.cpp
//战争政策

#include"war_policy.h"

war_policy::war_policy ( string name , double max_military_spending ,
						 double supply_consumption , double war_exhaustion_effect ,
						 bool is_jingoism , double cb_generation_speed_modifier ,
						 int mobilization_impact , double org_regain , double reinforce_speed )
{
	this->name = name;
	this->max_military_spending = max_military_spending;
	this->supply_consumption = supply_consumption;
	this->war_exhaustion_effect = war_exhaustion_effect;
	this->is_jingoism = is_jingoism;
	this->cb_generation_speed_modifier = cb_generation_speed_modifier;
	this->mobilization_impact = mobilization_impact;
	this->org_regain = org_regain;
	this->reinforce_speed = reinforce_speed;
}

string  war_policy::get_name ()	//获取战争政策名
{
	return name;
}