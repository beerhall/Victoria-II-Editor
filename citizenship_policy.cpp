//citizenship_policy.cpp
//公民权政策

#include<iostream>
#include"citizenship_policy.h"

citizenship_policy::citizenship_policy ( string name , double global_assimilation_rate , string citizenship_policy_rule )
{
	this->name = name;
	this->global_assimilation_rate = global_assimilation_rate;
	if ( citizenship_policy_rule == "primary_culture_voting" )
	{
		this->global_assimilation_rate = primary_culture_voting;
	}
	else if ( citizenship_policy_rule == "culture_voting" )
	{
		this->global_assimilation_rate = culture_voting;
	}
	else if ( citizenship_policy_rule == "all_voting" )
	{
		this->global_assimilation_rate = all_voting;
	}
	else
	{
		std::cerr << "公民权政策规则“" << global_assimilation_rate << "”不存在，请重新载入！" << endl;
	}
}

string citizenship_policy::get_name ()	//获得公民权政策名
{
	return name;
}