//economic_policy_rules.h
//经济政策规则类

#ifndef ECONOMIC_POLICY_RULES_H
#define ECONOMIC_POLICY_RULES_H

#include<vector>
#include<string>

using namespace std;

class economic_policy_rules
{
public:
	economic_policy_rules ( vector<pair<string , bool>> args );
	economic_policy_rules () = default;
private:
	bool build_factory;	//建造工厂
	bool	expand_factory;	//升级工厂
	bool open_factory;	//重开工厂
	bool destroy_factory;	//摧毁工厂
	bool	build_railway;	//建造铁路
	bool	factory_priority;	//工厂优先级
	bool	can_subsidise;	//可以补贴
	bool	pop_build_factory;	//资本家建造工厂
	bool	pop_expand_factory;	//资本家升级工厂
	bool	pop_open_factory;	//资本家重开工厂
	bool delete_factory_if_no_input;	//关闭工厂如果没有原料
	bool	pop_build_factory_invest;	//资本家投资建造工厂
	bool	pop_expand_factory_invest;	//资本家投资升级工厂
	bool	open_factory_invest;	//投资重开工厂
	bool	allow_foreign_investment;	//允许外国投资
	bool	build_railway_invest;	//投资建造铁路
	bool build_factory_invest;	//投资建造工厂
	bool expand_factory_invest;	//投资升级工厂
	bool	can_invest_in_pop_projects;	//允许投资民间建设
};

#endif