//economic_policy
//经济政策类

#ifndef ECONOMIC_POLICY_H
#define ECONOMIC_POLICY_H

#include<string>
#include<vector>
#include"economic_policy_rules.h"

using namespace std;

class economic_policy
{
public:
	economic_policy ( string name , double max_tax , double min_tax ,
					  double factory_throughput , double factory_owner_cost ,
					  double factory_output , economic_policy_rules rules );
	string get_name ();	//获得政策名
private:
	string name;	//政策名
	double max_tax;	//最高税率
	double min_tax;	//最低税率
	double factory_throughput;	//工厂吞吐
	double factory_owner_cost;	//建造工厂花费
	double factory_output;	//工厂产出
	economic_policy_rules rules;	//规则
};

#endif