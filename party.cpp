//party.cpp
//政党

#include"party.h"
#include"ideologies_group.h"

extern vector<ideologies_gruop> ideologies_gruop_vector;	//储存意识形态组
extern vector<economic_policy> economic_policy_vector;	//储存经济政策
extern vector<citizenship_policy> citizenship_policy_vector;	//储存公民权政策
extern vector<religious_policy> religious_policy_vector;	//储存宗教政策
extern vector<trade_policy> trade_policy_vector;	//储存贸易政策
extern vector<war_policy> war_policy_vector;	//储存战争政策

party::party ( string name , date start_date , date end_date ,
			   string ideo , string economic , string trade , string religious ,
			   string citizenship , string war )
{
	this->name = name;
	this->start_date = start_date;
	this->end_date = end_date;


	int len = ideologies_gruop_vector.size ();
	int i = 0 , j = 0;
	for ( ideologies_gruop* p = &ideologies_gruop_vector [ 0 ]; i < len; p++ , i++ )
	{
		int len2 = p->get_ideology_list ().size ();
		for ( ideology* p2 = &( p->get_ideology_list () ) [ 0 ]; j < len2; p2++ , j++ )
		{
			if ( p2->get_name () == ideo )
			{
				this->ideo = p2;
				goto JUMP_OUT;
			}
		}
	}
	JUMP_OUT:

	i = 0;
	len = economic_policy_vector.size ();
	for ( economic_policy* p = &economic_policy_vector [ 0 ]; i < len; p++ , i++ )
	{
		if ( p->get_name () == economic )
		{
			this->economic = p;
			break;
		}
	}

	i = 0;
	len = citizenship_policy_vector.size ();
	for ( citizenship_policy* p = &citizenship_policy_vector [ 0 ]; i < len; p++ , i++ )
	{
		if ( p->get_name () == citizenship )
		{
			this->citizenship = p;
			break;
		}
	}

	i = 0;
	len = religious_policy_vector.size ();
	for ( religious_policy* p = &religious_policy_vector [ 0 ]; i < len; p++ , i++ )
	{
		if ( p->get_name () == religious )
		{
			this->religious = p;
			break;
		}
	}

	i = 0;
	len = trade_policy_vector.size ();
	for ( trade_policy* p = &trade_policy_vector [ 0 ]; i < len; p++ , i++ )
	{
		if ( p->get_name () == trade )
		{
			this->trade = p;
			break;
		}
	}

	i = 0;
	len = war_policy_vector.size ();
	for ( war_policy* p = &war_policy_vector [ 0 ]; i < len; p++ , i++ )
	{
		if ( p->get_name () == war )
		{
			this->war = p;
			break;
		}
	}
}

string party::get_name ()	//取得政党名
{
	return name;
}