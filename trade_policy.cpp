//trade_policy.h
//贸易政策

#include"trade_policy.h"

trade_policy::trade_policy ( string name , double max_tariff , double min_tariff )
{
	this->name = name;
	this->max_tariff = max_tariff;
	this->min_tariff = min_tariff;
}

string trade_policy::get_name ()
{
	return this->name;
}