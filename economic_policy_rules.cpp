//economic_policy_rules.cpp
//经济政策规则

#include"economic_policy_rules.h"
#include<iostream>

economic_policy_rules::economic_policy_rules ( vector<pair<string , bool>> args )
{
	for ( auto &i : args )
	{
		string name = i.first;
		bool value = i.second;
		if ( name == "build_factory" )
		{
			this->build_factory = value;
		}
		else if ( name == "expand_factory" )
		{
			this->expand_factory = value;
		}
		else if ( name == "open_factory" )
		{
			this->open_factory = value;
		}
		else if ( name == "destroy_factory" )
		{
			this->destroy_factory = value;
		}
		else if ( name == "build_railway" )
		{
			this->build_railway = value;
		}
		else if ( name == "factory_priority" )
		{
			this->factory_priority = value;
		}
		else if ( name == "can_subsidise" )
		{
			this->can_subsidise = value;
		}
		else if ( name == "pop_build_factory" )
		{
			this->pop_build_factory = value;
		}
		else if ( name == "pop_expand_factory" )
		{
			this->pop_expand_factory = value;
		}
		else if ( name == "pop_open_factory" )
		{
			this->pop_open_factory = value;
		}
		else if ( name == "delete_factory_if_no_input" )
		{
			this->delete_factory_if_no_input = value;
		}
		else if ( name == "pop_build_factory_invest" )
		{
			this->pop_build_factory_invest = value;
		}
		else if ( name == "pop_expand_factory_invest" )
		{
			this->pop_expand_factory_invest = value;
		}
		else if ( name == "open_factory_invest" )
		{
			this->open_factory_invest = value;
		}
		else if ( name == "allow_foreign_investment" )
		{
			this->allow_foreign_investment = value;
		}
		else if ( name == "build_railway_invest" )
		{
			this->build_railway_invest = value;
		}
		else if ( name == "build_factory_invest" )
		{
			this->build_factory_invest = value;
		}
		else if ( name == "expand_factory_invest" )
		{
			this->expand_factory_invest = value;
		}
		else if ( name == "can_invest_in_pop_projects" )
		{
			this->can_invest_in_pop_projects = value;
		}
		else
		{
			cerr << "不存在规则“" << name << "”，请重新载入！" << endl;
			return;
		}
	}
}