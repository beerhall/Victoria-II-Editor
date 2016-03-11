//economic_policy.cpp
//经济政策

#include"economic_policy.h"

economic_policy::economic_policy ( string name , double max_tax , double min_tax ,
								   double factory_throughput , double factory_owner_cost ,
								   double factory_output , economic_policy_rules rules )
{
	this->name = name;
	this->max_tax = max_tax;
	this->min_tax = min_tax;
	this->factory_throughput = factory_throughput;
	this->factory_owner_cost = factory_owner_cost;
	this->factory_output = factory_output;
	this->rules = rules;
}

string economic_policy::get_name ()	//获得政策名
{
	return name;
}